using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace SE_Projekt
{
    public partial class Arbeitszeiten : Window
    {
        public Arbeitszeiten()
        {
            InitializeComponent();
            LadeArbeitszeiten();
        }

        // Leere Liste für Arbeitszeiten vorbereiten
        private void LadeArbeitszeiten()
        {
            ArbeitszeitenTabelle.ItemsSource = new List<MitarbeiterArbeitszeiten>();
        }

        // Navigation Buttons
        private void DashboardButton_Click(object sender, RoutedEventArgs e)
        {
            Managerseite dashboard = new Managerseite();
            dashboard.Show();
            this.Close();
        }

        private void StammdatenButton_Click(object sender, RoutedEventArgs e)
        {
            Stammdaten stammdaten = new Stammdaten();
            stammdaten.Show();
            this.Close();
        }

        private void MitarbeiterübersichtButton_Click(object sender, RoutedEventArgs e)
        {
            MitarbeiterUebersicht mitarbeiterUebersicht = new MitarbeiterUebersicht();
            mitarbeiterUebersicht.Show();
            this.Close();
        }

        private void SchichtplanungButton_Click(object sender, RoutedEventArgs e)
        {
            Schichtplanung schichtplanung = new Schichtplanung();
            schichtplanung.Show();
            this.Close();
        }

        private void ArbeitszeitenButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Sie befinden sich bereits in der Arbeitszeiten-Ansicht.");
        }

        private void UrlaubButton_Click(object sender, RoutedEventArgs e)
        {
            Urlaubsverwaltung urlaub = new Urlaubsverwaltung();
            urlaub.Show();
            this.Close();
        }

        private void PdfButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("PDF-Export-Funktion noch in Arbeit.");
        }

        private void ZurückZurLoginButton_Click(object sender, RoutedEventArgs e)
        {
            Loginseite login = new Loginseite();
            login.Show();
            this.Close();
        }
    }

    // Modellklasse für die Arbeitszeiten (optional, falls benötigt)
    public partial class MitarbeiterArbeitszeiten
    {
        public new string Name { get; set; }
        public string Montag { get; set; }
        public string Dienstag { get; set; }
        public string Mittwoch { get; set; }
        public string Donnerstag { get; set; }
        public string Freitag { get; set; }
        public string Samstag { get; set; }
        public string Sonntag { get; set; }
    }
}
