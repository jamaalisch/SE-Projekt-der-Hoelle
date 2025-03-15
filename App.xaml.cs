using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SE_Projekt.Data;
using SE_Projekt.Modelle;
using System;
using System.Windows;

namespace SE_Projekt
{
    public partial class App : Application
    {
        public static IServiceProvider ServiceProvider { get; private set; }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            // Erstelle den ServiceCollection-Container für Dependency Injection
            var serviceCollection = new ServiceCollection();

            // Füge DbContext für die Datenbank hinzu
            serviceCollection.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\cedri_i0o8qgp\\OneDrive\\Dokumente\\Schule\\Q4\\Informatik\\SE-Projekt\\Program\\SE-Projekt\\Database1.mdf;Integrated Security=True"));

            // Registriere alle benötigten Services und Fenster
            serviceCollection.AddSingleton<Loginseite>();  // Login-Seite
            serviceCollection.AddSingleton<MitarbeiterUebersicht>();  // Mitarbeiterübersicht
            serviceCollection.AddSingleton<Schichtplanung>();  // Schichtplanung
            serviceCollection.AddSingleton<Managerseite>();  // Managerseite
            serviceCollection.AddSingleton<Arbeitszeiten>();  // Arbeitszeiten
            serviceCollection.AddSingleton<Urlaubsverwaltung>();  // Urlaubsverwaltung
            serviceCollection.AddSingleton<LohnabrechnungExport>();  // Lohnabrechnung PDF

            // Baue den ServiceProvider
            ServiceProvider = serviceCollection.BuildServiceProvider();

            // Hole und zeige das Loginfenster (erste Ansicht)
            var loginWindow = ServiceProvider.GetRequiredService<Loginseite>();
        }
    }
}