using System;
using System.ComponentModel.DataAnnotations;

namespace SE_Projekt.Modelle
{
    public class Unternehmensdaten
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public string Unternehmensname { get; set; }

        [Required]
        public string Rechtsform { get; set; }

        [Required]
        public string Hauptsitz { get; set; }

        [Required]
        public string Inhaber { get; set; }

        [Required]
        public int Gruendungsjahr { get; set; }

        [Required]
        public int AnzahlMitarbeiter { get; set; }

        public decimal Umsatz { get; set; }
    }
}