using System;
using System.Linq;
using System.Windows;
using SE_Projekt.Data;
using SE_Projekt.Modelle;

namespace SE_Projekt
{
    public partial class UrlaubsantragMitarbeiter : Window
    {
        public UrlaubsantragMitarbeiter()
        {
            InitializeComponent();
            LadeLetztenUrlaubsantrag();
        }

        // Event-Handler für den "Antrag stellen"-Button
        private void AntragStellenButton_Click(object sender, RoutedEventArgs e)
        {
            if (StartdatumPicker.SelectedDate == null || EnddatumPicker.SelectedDate == null)
            {
                MessageBox.Show("Bitte wählen Sie ein Start- und Enddatum aus.", "Fehlende Eingabe", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            DateTime startDatum = StartdatumPicker.SelectedDate.Value;
            DateTime endDatum = EnddatumPicker.SelectedDate.Value;

            if (startDatum > endDatum)
            {
                MessageBox.Show("Das Startdatum darf nicht nach dem Enddatum liegen.", "Fehlerhafte Eingabe", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Erstelle einen neuen Urlaubsantrag
            using (var dbContext = new ApplicationDbContext())
            {
                var urlaubsantrag = new Urlaubsantrag
                {
                    MitarbeiterID = GlobalData.MitarbeiterId,  // Verwende die aktuelle Mitarbeiter-ID aus GlobalData
                    Startdatum = startDatum,
                    Enddatum = endDatum,
                    Status = "beantragt"  // Standardmäßig auf "beantragt" setzen
                };

                // Speichere den Urlaubsantrag in der Datenbank
                dbContext.Urlaubsantrag.Add(urlaubsantrag);
                dbContext.SaveChanges();
            }

            MessageBox.Show($"Urlaubsantrag gestellt:\nVon: {startDatum:dd.MM.yyyy} bis {endDatum:dd.MM.yyyy}", "Erfolgreich", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        // Methode zum Laden des letzten Urlaubsantrags
        private void LadeLetztenUrlaubsantrag()
        {
            using (var dbContext = new ApplicationDbContext())
            {
                var letzterAntrag = dbContext.Urlaubsantrag
                    .Where(u => u.MitarbeiterID == GlobalData.MitarbeiterId)
                    .OrderByDescending(u => u.Startdatum)
                    .FirstOrDefault();  // Den letzten Urlaubsantrag abrufen

                if (letzterAntrag != null)
                {
                    // Das DataGrid mit dem letzten Urlaubsantrag befüllen
                    LastUrlaubsantragDataGrid.ItemsSource = new[]
                    {
                            new
                            {
                                letzterAntrag.Startdatum,
                                letzterAntrag.Enddatum,
                                Status = letzterAntrag.Status == "beantragt" ? "Warten auf Entscheidung" : letzterAntrag.Status
                            }
                        };
                }
                else
                {
                    // Wenn kein Antrag vorhanden ist
                    LastUrlaubsantragDataGrid.ItemsSource = null;
                }
            }
        }

        // Event-Handler für den "Dashboard"-Button
        private void DashboardButton_Click(object sender, RoutedEventArgs e)
        {
            MitarbeiterDashboard dashboard = new MitarbeiterDashboard();
            dashboard.Show();
            this.Close();
        }

        // Event-Handler für den "Mitarbeiterdaten"-Button
        private void MitarbeiterdatenButton_Click(object sender, RoutedEventArgs e)
        {
            MitarbeiterDaten mitarbeiterdaten = new MitarbeiterDaten();
            mitarbeiterdaten.Show();
            this.Close();
        }

        // Event-Handler für den "Schichtplan"-Button
        private void SchichtplanButton_Click(object sender, RoutedEventArgs e)
        {
            MitarbeiterArbeitszeiten schichtplan = new MitarbeiterArbeitszeiten();
            schichtplan.Show();
            this.Close();
        }

        // Event-Handler für den "Urlaub"-Button
        private void UrlaubButton_Click(object sender, RoutedEventArgs e)
        {
            UrlaubsantragMitarbeiter urlaub = new UrlaubsantragMitarbeiter();
            urlaub.Show();
            this.Close();
        }

        // Event-Handler für den "Zurück zur Login-Seite"-Button
        private void ZurückZurLoginButton_Click(object sender, RoutedEventArgs e)
        {
            Loginseite login = new Loginseite();
            login.Show();
            this.Close();
        }
    }
}
