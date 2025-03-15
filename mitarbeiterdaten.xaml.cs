using System;
using System.Linq;
using System.Windows;
using SE_Projekt.Data;

namespace SE_Projekt
{
    public partial class MitarbeiterDaten : Window
    {
        public MitarbeiterDaten()
        {
            InitializeComponent();
            LoadMitarbeiterData(); // Wir rufen die Methode auf, um die Mitarbeiterdaten zu laden
        }

        private void LoadMitarbeiterData()
        {
            using (var context = new ApplicationDbContext())
            {
                // Hole den aktuellen angemeldeten Mitarbeiter aus der globalen Variable
                var mitarbeiter = context.Mitarbeiter.FirstOrDefault(m => m.ID == GlobalData.MitarbeiterId);

                if (mitarbeiter != null)
                {
                    // Mitarbeiterdaten in die UI eintragen
                    AnredeText.Text = mitarbeiter.Anrede;
                    GeburtsdatumText.Text = mitarbeiter.Geburtsdatum.ToString("dd.MM.yyyy");
                    VornameText.Text = mitarbeiter.Vorname;
                    NachnameText.Text = mitarbeiter.Nachname;
                    GeburtsortText.Text = mitarbeiter.Geburtsort;
                    NationalitätText.Text = mitarbeiter.Nationalität;
                    PositionText.Text = mitarbeiter.Position;
                    EinstellungsdatumText.Text = mitarbeiter.Einstellungsdatum.ToString("dd.MM.yyyy");
                    FamilienstandText.Text = mitarbeiter.Familienstand;
                    StundenlohnText.Text = mitarbeiter.Stundenlohn.ToString("F2");
                    EmailText.Text = mitarbeiter.Email;
                    MobilText.Text = mitarbeiter.Mobil.ToString();
                    StraßeText.Text = mitarbeiter.Straße;
                    PLZText.Text = mitarbeiter.PLZ.ToString();
                    OrtText.Text = mitarbeiter.Ort;
                    LandText.Text = mitarbeiter.Land;
                    IBANText.Text = mitarbeiter.IBAN;
                    BICText.Text = mitarbeiter.BIC.ToString();
                    SteuerklasseText.Text = mitarbeiter.Steuerklasse;
                    KonfessionText.Text = mitarbeiter.Konfession;
                    SteuerIDText.Text = mitarbeiter.SteuerID.ToString();
                }
                else
                {
                    MessageBox.Show("Mitarbeiter nicht gefunden.");
                }
            }
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
