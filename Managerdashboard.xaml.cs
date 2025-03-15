using Microsoft.Extensions.DependencyInjection;
using SE_Projekt.Data;
using System;
using System.Windows;

namespace SE_Projekt
{
    public partial class Managerseite : Window
    {
        public Managerseite()
        {
            InitializeComponent();
        }

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

        // Provisorische Mitteilung für "Start" Button in Stammdaten
        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            Stammdaten stammdatenPage = new Stammdaten();
            stammdatenPage.Show();
            this.Close();
        }

        // Provisorische Mitteilung für "Mitarbeiter anlegen" Button
        private void MitarbeiterAnlegenButton_Click(object sender, RoutedEventArgs e)
        {
            // Hole den ApplicationDbContext aus dem DI-Container, qualifiziert über den Klassennamen
            var context = App.ServiceProvider.GetService<ApplicationDbContext>();

            if (context != null)
            {
                // Übergib den ApplicationDbContext an den Konstruktor von MitarbeiterAnlegen
                MitarbeiterAnlegen mitarbeiterAnlegenPage = new MitarbeiterAnlegen(context);
                mitarbeiterAnlegenPage.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Datenbankkontext konnte nicht gefunden werden.", "Fehler", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }



        // Provisorische Mitteilung für "Arbeitszeitbetrug" Button
        private void ArbeitszeitbetrugButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Diese Funktion ist derzeit noch nicht verfügbar.");
        }
    }
}
