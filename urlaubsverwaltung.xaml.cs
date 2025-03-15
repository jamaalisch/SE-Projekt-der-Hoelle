using System;
using System.Linq;
using System.Windows;
using SE_Projekt.Data;
using SE_Projekt.Modelle;
using Microsoft.EntityFrameworkCore; // Vergessen Sie nicht, diese Namensraum hinzuzufügen.

namespace SE_Projekt
{
    public partial class Urlaubsverwaltung : Window
    {
        public Urlaubsverwaltung()
        {
            InitializeComponent();
            LadeUrlaubsanträge();
        }

        // Event-Handler für den "Dashboard"-Button
        private void DashboardButton_Click(object sender, RoutedEventArgs e)
        {
            Managerseite dashboardPage = new Managerseite();
            dashboardPage.Show();
            this.Close();  // Schließt das aktuelle Fenster
        }

        // Event-Handler für den "Stammdaten"-Button
        private void StammdatenButton_Click(object sender, RoutedEventArgs e)
        {
            Stammdaten stammdatenPage = new Stammdaten();
            stammdatenPage.Show();
            this.Close();  // Schließt das aktuelle Fenster
        }

        // Event-Handler für den "Mitarbeiterübersicht"-Button
        private void MitarbeiterübersichtButton_Click(object sender, RoutedEventArgs e)
        {
            MitarbeiterUebersicht mitarbeiterübersichtPage = new MitarbeiterUebersicht();
            mitarbeiterübersichtPage.Show();
            this.Close();  // Schließt das aktuelle Fenster
        }

        // Event-Handler für den "Schichtplanung"-Button
        private void SchichtplanungButton_Click(object sender, RoutedEventArgs e)
        {
            Schichtplanung schichtplanungPage = new Schichtplanung();
            schichtplanungPage.Show();
            this.Close();  // Schließt das aktuelle Fenster
        }

        // Event-Handler für den "Arbeitszeiten"-Button
        private void ArbeitszeitenButton_Click(object sender, RoutedEventArgs e)
        {
            Arbeitszeiten arbeitszeitenPage = new Arbeitszeiten();
            arbeitszeitenPage.Show();
            this.Close();  // Schließt das aktuelle Fenster
        }

        // Event-Handler für den "Urlaub"-Button
        private void UrlaubButton_Click(object sender, RoutedEventArgs e)
        {
            Urlaubsverwaltung urlaubPage = new Urlaubsverwaltung();
            urlaubPage.Show();
            this.Close();  // Schließt das aktuelle Fenster
        }

        // Event-Handler für den "PDF"-Button
        private void PdfButton_Click(object sender, RoutedEventArgs e)
        {
            LohnabrechnungExport pdfPage = new LohnabrechnungExport();
            pdfPage.Show();
            this.Close();  // Schließt das aktuelle Fenster
        }

        // Event-Handler für den "Zurück zur Login-Seite"-Button
        private void ZurückZurLoginButton_Click(object sender, RoutedEventArgs e)
        {
            Loginseite loginPage = new Loginseite();
            loginPage.Show();
            this.Close();  // Schließt das aktuelle Fenster
        }

        // Event-Handler für den "Annehmen"-Button
        private void AnnehmenButton_Click(object sender, RoutedEventArgs e)
        {
            var urlaubsantrag = UrlaubsantragsTabelle.SelectedItem as Urlaubsantrag;
            if (urlaubsantrag != null)
            {
                urlaubsantrag.Status = "genehmigt";
                AktualisiereUrlaubsantrag(urlaubsantrag);
                MessageBox.Show("Urlaubsantrag wurde angenommen.");
            }
            else
            {
                MessageBox.Show("Bitte wählen Sie einen Urlaubsantrag aus.");
            }
        }

        // Event-Handler für den "Ablehnen"-Button
        private void AblehnenButton_Click(object sender, RoutedEventArgs e)
        {
            var urlaubsantrag = UrlaubsantragsTabelle.SelectedItem as Urlaubsantrag;
            if (urlaubsantrag != null)
            {
                urlaubsantrag.Status = "abgelehnt";
                AktualisiereUrlaubsantrag(urlaubsantrag);
                MessageBox.Show("Urlaubsantrag wurde abgelehnt.");
            }
            else
            {
                MessageBox.Show("Bitte wählen Sie einen Urlaubsantrag aus.");
            }
        }

        // Methode zum Aktualisieren des Urlaubsantrags in der Datenbank
        private void AktualisiereUrlaubsantrag(Urlaubsantrag urlaubsantrag)
        {
            using (var dbContext = new ApplicationDbContext())
            {
                dbContext.Urlaubsantrag.Update(urlaubsantrag);
                dbContext.SaveChanges();
            }

            LadeUrlaubsanträge();  // Tabelle nach der Aktualisierung neu laden
        }

        // Methode zum Laden der Urlaubsanträge
        private void LadeUrlaubsanträge()
        {
            using (var dbContext = new ApplicationDbContext())
            {
                var urlaubsanträge = dbContext.Urlaubsantrag
                    .Where(u => u.Status == "beantragt")
                    .Include(u => u.Mitarbeiter)  // Ensure the Mitarbeiter data is loaded
                    .ToList();

                UrlaubsantragsTabelle.ItemsSource = urlaubsanträge;
            }
        }

        // Event-Handler für die Auswahl einer Zeile im DataGrid
        private void UrlaubsantragsTabelle_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            var urlaubsantrag = UrlaubsantragsTabelle.SelectedItem as Urlaubsantrag;
            if (urlaubsantrag != null)
            {
                MessageBox.Show($"Ausgewählter Antrag: {urlaubsantrag.Mitarbeiter.Nachname}");
            }
        }
    }
}
