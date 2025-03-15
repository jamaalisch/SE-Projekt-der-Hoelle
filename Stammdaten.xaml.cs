using SE_Projekt.Data;
using SE_Projekt.Modelle;
using System.Windows;
using System.Windows.Controls;

namespace SE_Projekt
{
    public partial class Stammdaten : Window
    {
        public Stammdaten()
        {
            InitializeComponent();
        }

        // Event-Handler für den "Speichern"-Button  
        private void SpeichernButton_Click(object sender, RoutedEventArgs e)
        {
            // Die Eingabewerte aus den Textboxen und Comboboxen holen  
            string unternehmensname = ((TextBox)this.FindName("UnternehmensnameTextBox")).Text;
            string rechtsform = ((ComboBox)this.FindName("RechtsformComboBox")).SelectedItem.ToString();
            string hauptsitz = ((TextBox)this.FindName("HauptsitzTextBox")).Text;
            string inhaber = ((TextBox)this.FindName("InhaberTextBox")).Text;
            int gruendungsjahr = int.Parse(((TextBox)this.FindName("GruendungsjahrTextBox")).Text);
            int mitarbeiterAnzahl = int.Parse(((TextBox)this.FindName("MitarbeiterAnzahlTextBox")).Text);
            decimal umsatz = decimal.Parse(((TextBox)this.FindName("UmsatzTextBox")).Text);

            // Stammdatenobjekt erstellen  
            var stammdaten = new SE_Projekt.Modelle.Unternehmensdaten()
            {
                Unternehmensname = unternehmensname,
                Rechtsform = rechtsform,
                Hauptsitz = hauptsitz,
                Inhaber = inhaber,
                Gruendungsjahr = gruendungsjahr,
                AnzahlMitarbeiter = mitarbeiterAnzahl,
                Umsatz = umsatz
            };

            // Stammdaten in der Datenbank speichern  
            using (var context = new ApplicationDbContext())
            {
                context.Set<SE_Projekt.Modelle.Unternehmensdaten>().Add(stammdaten);
                context.SaveChanges();
            }

            MessageBox.Show(
                $"Die Stammdaten wurden gespeichert:\nUnternehmensname: {unternehmensname}\nRechtsform: {rechtsform}\nHauptsitz: {hauptsitz}\nInhaber: {inhaber}\nGründungsjahr: {gruendungsjahr}\nAnzahl Mitarbeiter: {mitarbeiterAnzahl}\nUmsatz: {umsatz}");
        }

        // Event-Handler für die Navigation zu anderen Seiten
        private void DashboardButton_Click(object sender, RoutedEventArgs e)
        {
            Managerseite dashboardPage = new Managerseite();
            dashboardPage.Show();
            this.Close();
        }

        private void StammdatenButton_Click(object sender, RoutedEventArgs e)
        {
            Stammdaten stammdatenPage = new Stammdaten();
            stammdatenPage.Show();
            this.Close();
        }

        private void MitarbeiterübersichtButton_Click(object sender, RoutedEventArgs e)
        {
            MitarbeiterUebersicht mitarbeiterübersichtPage = new MitarbeiterUebersicht();
            mitarbeiterübersichtPage.Show();
            this.Close();
        }

        private void SchichtplanungButton_Click(object sender, RoutedEventArgs e)
        {
            Schichtplanung schichtplanungPage = new Schichtplanung();
            schichtplanungPage.Show();
            this.Close();
        }

        private void ArbeitszeitenButton_Click(object sender, RoutedEventArgs e)
        {
            Arbeitszeiten arbeitszeitenPage = new Arbeitszeiten();
            arbeitszeitenPage.Show();
            this.Close();
        }

        private void UrlaubButton_Click(object sender, RoutedEventArgs e)
        {
            Urlaubsverwaltung urlaubPage = new Urlaubsverwaltung();
            urlaubPage.Show();
            this.Close();
        }

        private void PdfButton_Click(object sender, RoutedEventArgs e)
        {
            LohnabrechnungExport pdfPage = new LohnabrechnungExport();
            pdfPage.Show();
            this.Close();
        }

        private void ZurückZurLoginButton_Click(object sender, RoutedEventArgs e)
        {
            Loginseite loginPage = new Loginseite();
            loginPage.Show();
            this.Close();
        }
    }
}
