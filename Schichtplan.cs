using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SE_Projekt.Modelle;

public class Schichtplan
{
    [Key]
    public int ID { get; set; }

    [Required]
    [ForeignKey("Mitarbeiter")]
    public int MitarbeiterID { get; set; }

    [Required]
    public DateTime Datum { get; set; }

    [Required]
    public TimeSpan Schichtbeginn { get; set; }  // Uhrzeit als TimeSpan

    [Required]
    public TimeSpan Schichtende { get; set; }  // Uhrzeit als TimeSpan

    public Mitarbeiter Mitarbeiter { get; set; }
}