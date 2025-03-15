using System.Windows;

namespace SE_Projekt
{
    public partial class MitarbeiterDashboard : Window
    {
        public MitarbeiterDashboard()
        {
            InitializeComponent();
        }

        // Event-Handler für den "Dashboard"-Button
        private void DashboardButton_Click(object sender, RoutedEventArgs e)
        {
            // Da wir uns bereits im Dashboard befinden, muss nichts passieren
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
    }
}