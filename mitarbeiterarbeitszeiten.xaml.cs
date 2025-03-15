using System;
using System.Linq;
using System.Windows;
using SE_Projekt.Data;
using SE_Projekt.Modelle;

namespace SE_Projekt
{
    public partial class MitarbeiterArbeitszeiten : Window
    {
        public MitarbeiterArbeitszeiten()
        {
            InitializeComponent();
            LoadSchichtplanData();  // Daten laden, wenn das Fenster geladen wird
        }

        private void LoadSchichtplanData()
        {
            using (var dbContext = new ApplicationDbContext())
            {
                // Hole den Stundenlohn des aktuellen Mitarbeiters (als decimal)
                var stundenlohn = dbContext.Mitarbeiter
                    .Where(m => m.ID == GlobalData.MitarbeiterId)
                    .Select(m => m.Stundenlohn)
                    .FirstOrDefault();

                // Hole die Schichten des aktuellen Mitarbeiters aus der Schichtplan-Datenbank
                var schichten = dbContext.Schichtplan
                    .Where(s => s.MitarbeiterID == GlobalData.MitarbeiterId)
                    .Select(s => new
                    {
                        Tag = s.Datum.ToString("dd.MM.yyyy") + " (" + s.Datum.ToString("dddd") + ")", // Datum und Wochentag
                        Arbeitsbeginn = s.Schichtbeginn.ToString(@"hh\:mm"),
                        Arbeitsende = s.Schichtende.ToString(@"hh\:mm"),
                        Stunden = (decimal)(s.Schichtende - s.Schichtbeginn).TotalHours,  // Stelle sicher, dass es als decimal behandelt wird
                        Gehalt = stundenlohn * (decimal)(s.Schichtende - s.Schichtbeginn).TotalHours // Berechnung des Gehalts
                    }).ToList();

                // Setze die Datenquelle für das DataGrid
                MonatlicheArbeitszeitenDataGrid.ItemsSource = schichten;
            }
        }

        // Event-Handler für den "Dashboard"-Button
        private void DashboardButton_Click(object sender, RoutedEventArgs e)
        {
            MitarbeiterDashboard dashboardPage = new MitarbeiterDashboard();
            dashboardPage.Show();
            this.Close();  // Schließt das aktuelle Fenster
        }

        // Event-Handler für den "Mitarbeiterdaten"-Button
        private void MitarbeiterdatenButton_Click(object sender, RoutedEventArgs e)
        {
            MitarbeiterDaten mitarbeiterdatenPage = new MitarbeiterDaten();
            mitarbeiterdatenPage.Show();
            this.Close();  // Schließt das aktuelle Fenster
        }

        // Event-Handler für den "Schichtplan"-Button
        private void SchichtplanButton_Click(object sender, RoutedEventArgs e)
        {
            MitarbeiterArbeitszeiten schichtplanPage = new MitarbeiterArbeitszeiten();
            schichtplanPage.Show();
            this.Close();  // Schließt das aktuelle Fenster
        }

        // Event-Handler für den "Urlaub"-Button
        private void UrlaubButton_Click(object sender, RoutedEventArgs e)
        {
            UrlaubsantragMitarbeiter urlaubPage = new UrlaubsantragMitarbeiter();
            urlaubPage.Show();
            this.Close();  // Schließt das aktuelle Fenster
        }

        // Event-Handler für den "Zurück zur Login-Seite"-Button
        private void ZurückZurLoginButton_Click(object sender, RoutedEventArgs e)
        {
            Loginseite loginPage = new Loginseite();
            loginPage.Show();
            this.Close();  // Schließt das aktuelle Fenster
        }

        // Event-Handler für den "Daten aktualisieren"-Button
        private void DatenAktualisierenButton_Click(object sender, RoutedEventArgs e)
        {
            LoadSchichtplanData(); // Die Schichtdaten erneut laden
            MessageBox.Show("Daten wurden aktualisiert.");
        }
    }
}
