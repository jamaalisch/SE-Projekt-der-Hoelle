using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SE_Projekt.Modelle;
using System;
using System.IO;

namespace SE_Projekt.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Mitarbeiter> Mitarbeiter { get; set; }
        public DbSet<Schichtplan> Schichtplan { get; set; }
        public DbSet<Unternehmensdaten> Stammdaten { get; set; }
        public DbSet<Urlaubsantrag> Urlaubsantrag { get; set; }

        public ApplicationDbContext() { }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                try
                {
                    var configPath = Path.Combine(AppContext.BaseDirectory, "appsettings.json");

                    if (File.Exists(configPath))
                    {
                        var configuration = new ConfigurationBuilder()
                            .SetBasePath(AppContext.BaseDirectory)
                            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                            .Build();

                        string connectionString = configuration.GetConnectionString("DefaultConnection");

                        if (!string.IsNullOrEmpty(connectionString))
                        {
                            optionsBuilder.UseSqlServer(connectionString);
                            return;
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Warnung: Konnte appsettings.json nicht laden. Nutze statische Verbindung. Fehler: {ex.Message}");
                }

                // Falls appsettings.json nicht funktioniert, nutze die harte Verbindung
                optionsBuilder.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\cedri_i0o8qgp\\OneDrive\\Dokumente\\Schule\\Q4\\Informatik\\SE-Projekt\\Program\\SE-Projekt\\Database1.mdf;Integrated Security=True");
            }
        }
    }
}
