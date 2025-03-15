using System;
using System.ComponentModel.DataAnnotations;

namespace SE_Projekt.Modelle
{
    public class Mitarbeiter
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public string Anrede { get; set; } // Dropdown

        [Required]
        public string Vorname { get; set; }

        [Required]
        public string Nachname { get; set; }

        [Required]
        public DateTime Geburtsdatum { get; set; }

        public string Geburtsort { get; set; } // Dropdown
        public string Nationalität { get; set; }
        public string Position { get; set; }

        [Required]
        public DateTime Einstellungsdatum { get; set; }

        public string Familienstand { get; set; } // Dropdown
        public decimal Stundenlohn { get; set; }

        // Adresse
        public string Straße { get; set; }
        public int PLZ { get; set; }
        public string Ort { get; set; }
        public string Land { get; set; }

        // Kontakt
        public string Email { get; set; }
        public int Mobil { get; set; } // Jetzt als string für führende Null

        // Bankverbindung
        public string IBAN { get; set; } // Jetzt als string
        public int BIC { get; set; } // Jetzt als string

        // Steuerliche Angaben
        public string Steuerklasse { get; set; } // Dropdown
        public int SteuerID { get; set; }

        // Konfession
        public string Konfession { get; set; } // Dropdown
    }
}