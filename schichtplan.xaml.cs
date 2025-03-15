using SE_Projekt.Data;
using SE_Projekt.Modelle;
using System.Windows;
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace SE_Projekt
{
    public partial class Schichtplanung : Window
    {
        private readonly ApplicationDbContext _context;

        public Schichtplanung()
        {
            InitializeComponent();
            _context = new ApplicationDbContext();
            LadeMitarbeiter();
        }

        private void LadeMitarbeiter()
        {
            MitarbeiterComboBox.ItemsSource = _context.Mitarbeiter.ToList();
        }

        private void SpeichernButton_Click(object sender, RoutedEventArgs e)
        {
            // Sicherstellen, dass ein Mitarbeiter ausgewählt ist und Uhrzeiten gültig sind
            if (MitarbeiterComboBox.SelectedItem is not Mitarbeiter ausgewaehlterMitarbeiter ||
                !TryParseTime(SchichtbeginnTextBox.Text, out TimeSpan schichtbeginn) ||
                !TryParseTime(SchichtendeTextBox.Text, out TimeSpan schichtende))
            {
                MessageBox.Show("Bitte alle Felder korrekt ausfüllen. Achten Sie auf das HHMM-Format.");
                return;
            }

            // Beispiel für die Umwandlung von TimeSpan in Stunden und Minuten
            int schichtbeginnStunden = schichtbeginn.Hours;
            int schichtbeginnMinuten = schichtbeginn.Minutes;
            int schichtendeStunden = schichtende.Hours;
            int schichtendeMinuten = schichtende.Minutes;

            // Erstelle und speichere eine neue Schicht
            var neueSchicht = new Schichtplan
            {
                Datum = CalendarControl.SelectedDate ?? DateTime.Now,
                Schichtbeginn = schichtbeginn,
                Schichtende = schichtende,
                MitarbeiterID = ausgewaehlterMitarbeiter.ID
            };

            _context.Schichtplan.Add(neueSchicht);
            _context.SaveChanges();

            MessageBox.Show("Schicht erfolgreich gespeichert!");
            LadeSchichtdaten(); // Tabelle aktualisieren
        }


        private void LadeSchichtdaten()
        {
            SchichtplanTabelle.ItemsSource = _context.Schichtplan.Include(s => s.Mitarbeiter).ToList();
        }

        private bool TryParseTime(string input, out TimeSpan timeSpan)
        {
            timeSpan = TimeSpan.Zero;
            if (input.Length == 4 && int.TryParse(input, out int result) && result >= 0 && result <= 2359)
            {
                int hours = result / 100;
                int minutes = result % 100;
                if (minutes < 60)
                {
                    timeSpan = new TimeSpan(hours, minutes, 0);
                    return true;
                }
            }
            return false;
        }

        // Leere Event-Handler für die Buttons
        private void DashboardButton_Click(object sender, RoutedEventArgs e) { }
        private void StammdatenButton_Click(object sender, RoutedEventArgs e) { }
        private void MitarbeiterübersichtButton_Click(object sender, RoutedEventArgs e) { }
        private void SchichtplanungButton_Click(object sender, RoutedEventArgs e) { }
        private void ArbeitszeitenButton_Click(object sender, RoutedEventArgs e) { }
        private void UrlaubButton_Click(object sender, RoutedEventArgs e) { }
        private void PdfButton_Click(object sender, RoutedEventArgs e) { }
        private void ZurückZurLoginButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
