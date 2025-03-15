using SE_Projekt.Data;
using SE_Projekt.Modelle;
using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace SE_Projekt
{
    public partial class MitarbeiterAnlegen : Window
    {
        private readonly ApplicationDbContext _context;

        public MitarbeiterAnlegen(ApplicationDbContext context)
        {
            InitializeComponent();
            _context = context;
        }

        // Event-Handler für den "Dashboard"-Button
        private void DashboardButton_Click(object sender, RoutedEventArgs e)
        {
            // Navigiere zur Dashboard-Seite
            Managerseite dashboardPage = new Managerseite();
            dashboardPage.Show();
            this.Close();  // Schließt das aktuelle Fenster
        }

        // Event-Handler für den "Stammdaten"-Button
        private void StammdatenButton_Click(object sender, RoutedEventArgs e)
        {
            // Navigiere zur Stammdaten-Seite
            Managerseite stammdatenPage = new Managerseite();
            stammdatenPage.Show();
            this.Close();  // Schließt das aktuelle Fenster
        }

        // Event-Handler für den "Mitarbeiterübersicht"-Button
        private void MitarbeiterübersichtButton_Click(object sender, RoutedEventArgs e)
        {
            // Navigiere zur Mitarbeiterübersicht-Seite
            MitarbeiterUebersicht mitarbeiterübersichtPage = new MitarbeiterUebersicht();
            mitarbeiterübersichtPage.Show();
            this.Close();  // Schließt das aktuelle Fenster
        }

        // Event-Handler für den "Schichtplanung"-Button
        private void SchichtplanungButton_Click(object sender, RoutedEventArgs e)
        {
            // Navigiere zur Schichtplanung-Seite
            Schichtplanung schichtplanungPage = new Schichtplanung();
            schichtplanungPage.Show();
            this.Close();  // Schließt das aktuelle Fenster
        }

        // Event-Handler für den "Arbeitszeiten"-Button
        private void ArbeitszeitenButton_Click(object sender, RoutedEventArgs e)
        {
            // Navigiere zur Arbeitszeiten-Seite
            Arbeitszeiten arbeitszeitenPage = new Arbeitszeiten();
            arbeitszeitenPage.Show();
            this.Close();  // Schließt das aktuelle Fenster
        }

        // Event-Handler für den "Urlaub"-Button
        private void UrlaubButton_Click(object sender, RoutedEventArgs e)
        {
            // Navigiere zur Urlaub-Seite
            Urlaubsverwaltung urlaubPage = new Urlaubsverwaltung();
            urlaubPage.Show();
            this.Close();  // Schließt das aktuelle Fenster
        }

        // Event-Handler für den "PDF"-Button
        private void PdfButton_Click(object sender, RoutedEventArgs e)
        {
            // Navigiere zur PDF-Seite
            LohnabrechnungExport pdfPage = new LohnabrechnungExport();
            pdfPage.Show();
            this.Close();  // Schließt das aktuelle Fenster
        }

        // Event-Handler für den "Zurück zur Login-Seite"-Button
        private void ZurückZurLoginButton_Click(object sender, RoutedEventArgs e)
        {
            // Navigiere zurück zur Login-Seite
            Loginseite loginPage = new Loginseite();
            loginPage.Show();
            this.Close(); // Schließt das aktuelle Fenster
        }

        // Event-Handler für den "Hinzufügen"-Button
        private void HinzufügenButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Die Benutzereingaben werden aus den Feldern gelesen
                var neuerMitarbeiter = new Mitarbeiter
                {
                    Anrede = AnredeComboBox.Text,
                    Geburtsdatum = GeburtsdatumPicker.SelectedDate ?? default(DateTime),
                    Vorname = VornameTextBox.Text,
                    Nachname = NachnameTextBox.Text,
                    Geburtsort = GeburtsortTextBox.Text,
                    Nationalität = NationalitätTextBox.Text,
                    Position = PositionTextBox.Text,
                    Einstellungsdatum = EinstellungsdatumPicker.SelectedDate ?? default(DateTime),
                    Familienstand = FamilienstandTextBox.Text,
                    Stundenlohn = decimal.TryParse(StundenlohnTextBox.Text, out var lohn) ? (decimal)lohn : 0m,  // Verwende explizite Umwandlung in decimal
                    Straße = StraßeTextBox.Text,
                    PLZ = int.TryParse(PLZTextBox.Text, out var plz) ? plz : 0,
                    Ort = OrtTextBox.Text,
                    Land = LandTextBox.Text,
                    Email = EmailTextBox.Text,
                    Mobil = int.TryParse(MobilTextBox.Text, out var mobil) ? 0 : mobil,
                    IBAN = IBANTextBox.Text,
                    BIC = int.TryParse(BICTextBox.Text, out var bic) ? 0 : bic,
                    Steuerklasse = SteuerklasseTextBox.Text,
                    Konfession = KonfessionTextBox.Text,
                    SteuerID = int.TryParse(SteuerIDTextBox.Text, out var sid) ? sid : 0 // Korrektur der Umwandlung für SteuerID

                };


                    _context.Mitarbeiter.Add(neuerMitarbeiter);
                _context.SaveChanges();
                MessageBox.Show("Mitarbeiter erfolgreich hinzugefügt!", "Erfolg", MessageBoxButton.OK, MessageBoxImage.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Fehler: {ex.Message}", "Fehler", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        public async Task AddMitarbeiterAndLogAsync(Mitarbeiter mitarbeiter)
        {
            // Mitarbeiter hinzufügen
            _context.Mitarbeiter.Add(mitarbeiter);
            await _context.SaveChangesAsync();

            // Bestätigung über Konsolenausgabe
            Console.WriteLine($"Mitarbeiter {mitarbeiter.Vorname} wurde erfolgreich hinzugefügt.");
        }

    }
}
