using System;
using System.Linq;
using System.Windows;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using SE_Projekt.Data;
using SE_Projekt.Modelle;

namespace SE_Projekt
{
    public partial class LohnabrechnungExport : Window
    {
        public LohnabrechnungExport()
        {
            InitializeComponent();
            // Die ComboBox für die Mitarbeiter füllen
            using (var dbContext = new ApplicationDbContext())
            {
                var mitarbeiterListe = dbContext.Mitarbeiter.ToList();
                MitarbeiterComboBox.ItemsSource = mitarbeiterListe.Select(m => m.Nachname).ToList();
            }
        }

        private void PdfButton_Click(object sender, RoutedEventArgs e)
        {
            var mitarbeiterName = MitarbeiterComboBox.SelectedItem.ToString();  // Der Name des Mitarbeiters, dessen Lohnabrechnung erstellt werden soll

            // Hole die Mitarbeiterdaten aus der Datenbank
            using (var dbContext = new ApplicationDbContext())
            {
                var mitarbeiter = dbContext.Mitarbeiter
                    .FirstOrDefault(m => m.Nachname == mitarbeiterName); // Sucht den Mitarbeiter in der Datenbank

                if (mitarbeiter != null)
                {
                    // Erstelle eine neue PDF-Datei mit dem Nachnamen des Mitarbeiters
                    string dateiName = $"{mitarbeiter.Nachname}_Lohnabrechnung.pdf";
                    var writer = new PdfWriter(dateiName);
                    var pdf = new PdfDocument(writer);
                    var document = new Document(pdf);

                    // Füge die Mitarbeiterinformationen zur PDF hinzu
                    document.Add(new Paragraph($"Mitarbeiter: {mitarbeiter.Vorname} {mitarbeiter.Nachname}"));
                    document.Add(new Paragraph($"Anrede: {mitarbeiter.Anrede}"));
                    document.Add(new Paragraph($"Position: {mitarbeiter.Position}"));
                    document.Add(new Paragraph($"Geburtsdatum: {mitarbeiter.Geburtsdatum.ToShortDateString()}"));
                    document.Add(new Paragraph($"Geburtsort: {mitarbeiter.Geburtsort}"));
                    document.Add(new Paragraph($"Nationalität: {mitarbeiter.Nationalität}"));
                    document.Add(new Paragraph($"Einstellungsdatum: {mitarbeiter.Einstellungsdatum.ToShortDateString()}"));
                    document.Add(new Paragraph($"Familienstand: {mitarbeiter.Familienstand}"));
                    document.Add(new Paragraph($"Stundenlohn: {mitarbeiter.Stundenlohn:C}"));
                    document.Add(new Paragraph("Adresse:"));
                    document.Add(new Paragraph($"Straße: {mitarbeiter.Straße}"));
                    document.Add(new Paragraph($"PLZ: {mitarbeiter.PLZ}"));
                    document.Add(new Paragraph($"Ort: {mitarbeiter.Ort}"));
                    document.Add(new Paragraph($"Land: {mitarbeiter.Land}"));
                    document.Add(new Paragraph("Kontakt:"));
                    document.Add(new Paragraph($"E-Mail: {mitarbeiter.Email}"));
                    document.Add(new Paragraph($"Mobil: {mitarbeiter.Mobil}"));
                    document.Add(new Paragraph("Bankverbindung:"));
                    document.Add(new Paragraph($"IBAN: {mitarbeiter.IBAN}"));
                    document.Add(new Paragraph($"BIC: {mitarbeiter.BIC}"));
                    document.Add(new Paragraph("Steuerliche Angaben:"));
                    document.Add(new Paragraph($"Steuerklasse: {mitarbeiter.Steuerklasse}"));
                    document.Add(new Paragraph($"Steuer-ID: {mitarbeiter.SteuerID}"));
                    document.Add(new Paragraph($"Konfession: {mitarbeiter.Konfession}"));

                    // Hole die Schichtdaten des Mitarbeiters für den aktuellen Monat
                    var schichtdaten = dbContext.Schichtplan
                        .Where(a => a.MitarbeiterID == mitarbeiter.ID)
                        .ToList();

                    if (schichtdaten.Any())
                    {
                        // Bestimme den Monat anhand des ersten Schichtdatums
                        var ersterSchicht = schichtdaten.First().Datum;
                        var monat = ersterSchicht.ToString("MMMM yyyy"); // Format: "Januar 2025"

                        // Berechne die geleisteten Arbeitsstunden im aktuellen Monat
                        var arbeitsstunden = schichtdaten
                            .Where(a => a.Datum.Month == ersterSchicht.Month) // Filter nach Monat
                            .Sum(a => Convert.ToDecimal((a.Schichtende - a.Schichtbeginn).TotalHours)); // Konvertiere TotalHours zu decimal


                        document.Add(new Paragraph($"Geleistete Arbeitsstunden im Monat {monat}: {arbeitsstunden} Stunden"));

                        // Berechne das Gehalt basierend auf den Arbeitsstunden
                        decimal gehalt = arbeitsstunden * mitarbeiter.Stundenlohn;
                        document.Add(new Paragraph($"Gehalt: {gehalt:C}"));
                    }



                    // Schließe das Dokument und speichere die PDF
                    document.Close();

                    // Bestätigungsnachricht
                    MessageBox.Show($"Lohnabrechnung für {mitarbeiter.Vorname} {mitarbeiter.Nachname} wurde als PDF exportiert.", "Erfolgreich", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    // Fehlermeldung, falls der Mitarbeiter nicht gefunden wird
                    MessageBox.Show("Mitarbeiter nicht gefunden.", "Fehler", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void ZurückZurLoginButton_Click(object sender, RoutedEventArgs e)
        {
            // Hier kannst du die Navigation zur Login-Seite oder Hauptmenü hinzufügen
            MessageBox.Show("Zurück zur Login-Seite klicken.");
        }

        // Weitere Button-Click-Events für Navigation und andere Aktionen
        private void DashboardButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Navigiere zum Dashboard.");
        }

        private void StammdatenButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Navigiere zu den Stammdaten.");
        }

        private void MitarbeiterübersichtButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Navigiere zur Mitarbeiterübersicht.");
        }

        private void SchichtplanungButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Navigiere zur Schichtplanung.");
        }

        private void ArbeitszeitenButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Navigiere zu den Arbeitszeiten.");
        }

        private void UrlaubButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Navigiere zum Urlaub.");
        }
    }
}
