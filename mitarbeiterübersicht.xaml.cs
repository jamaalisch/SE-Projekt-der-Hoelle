using Microsoft.EntityFrameworkCore;
using SE_Projekt.Data;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace SE_Projekt
{
    public partial class MitarbeiterUebersicht : Window
    {
        private ApplicationDbContext _context;

        public MitarbeiterUebersicht()
        {
            InitializeComponent();
            _context = new ApplicationDbContext();
            LoadMitarbeiterData();
        }

        private async void LoadMitarbeiterData()
        {
            try
            {
                var mitarbeiterList = await _context.Mitarbeiter.ToListAsync();
                MitarbeiterDataGrid.ItemsSource = mitarbeiterList;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Fehler beim Laden der Mitarbeiter: " + ex.Message);
            }
        }

        private void DashboardButton_Click(object sender, RoutedEventArgs e)
        {
            Managerseite dashboardPage = new Managerseite();
            dashboardPage.Show();
            this.Close();
        }

        private void StammdatenButton_Click(object sender, RoutedEventArgs e)
        {
            Managerseite stammdatenPage = new Managerseite();
            stammdatenPage.Show();
            this.Close();
        }

        private void MitarbeiterübersichtButton_Click(object sender, RoutedEventArgs e)
        {
            if (!(Application.Current.Windows.OfType<MitarbeiterUebersicht>().Any()))
            {
                MitarbeiterUebersicht mitarbeiterübersichtPage = new MitarbeiterUebersicht();
                mitarbeiterübersichtPage.Show();
                this.Close();
            }
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
