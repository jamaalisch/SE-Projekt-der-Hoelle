using System;
using System.Linq;
using System.Windows;
using Microsoft.EntityFrameworkCore;
using SE_Projekt.Data;

namespace SE_Projekt
{
    public partial class Loginseite : Window
    {
        public Loginseite()
        {
            InitializeComponent();
        }

        private void ManagerLoginButton_Click(object sender, RoutedEventArgs e)
        {
            string managerName = ManagerNameTextBox.Text;
            string password = ManagerPasswordBox.Password;

            // Überprüfen, ob der Benutzername und das Passwort korrekt sind
            if (managerName == "admin" && password == "passwort")
            {
                Managerseite managerDashboard = new Managerseite();
                managerDashboard.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Manageranmeldung fehlgeschlagen. Bitte überprüfen Sie Ihre Anmeldedaten.");
            }
        }

        private void EmployeeLoginButton_Click(object sender, RoutedEventArgs e)
        {
            string employeeName = EmployeeNameTextBox.Text;
            DateTime? employeeBirthday = EmployeeBirthdayDatePicker.SelectedDate; // Das Geburtsdatum von einem DatePicker

            if (!employeeBirthday.HasValue)
            {
                MessageBox.Show("Bitte Geburtsdatum angeben.");
                return;
            }

            // Verwende AppDbContext, um den Mitarbeiter zu finden
            using (var context = new ApplicationDbContext())
            {
                var employee = context.Mitarbeiter
                    .FirstOrDefault(m => m.Nachname == employeeName && m.Geburtsdatum.Date == employeeBirthday.Value.Date);

                if (employee != null)
                {
                    // MitarbeiterId in globaler Variable speichern
                    GlobalData.MitarbeiterId = employee.ID;

                    // Weiter zur MitarbeiterDaten-Seite
                    MitarbeiterDaten mitarbeiterDatenPage = new MitarbeiterDaten();
                    mitarbeiterDatenPage.Show();
                    this.Close(); // Schließt das Login-Fenster
                }
                else
                {
                    MessageBox.Show("Mitarbeiteranmeldung fehlgeschlagen. Bitte überprüfen Sie Ihre Anmeldedaten.");
                }
            }
        }
    }
}
