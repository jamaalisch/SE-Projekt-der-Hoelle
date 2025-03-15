using System;

namespace SE_Projekt.Modelle
{
    public class Urlaubsantrag
    {
        public int ID { get; set; }  // ID des Urlaubsantrags
        public int MitarbeiterID { get; set; }  // Verweis auf den Mitarbeiter
        public DateTime Startdatum { get; set; }  // Startdatum des Urlaubs
        public DateTime Enddatum { get; set; }  // Enddatum des Urlaubs
        public string Status { get; set; }  // Status des Antrags (z.B. "beantragt", "genehmigt", "abgelehnt")

        // Navigation Property für den Mitarbeiter (optional, falls benötigt)
        public virtual Mitarbeiter Mitarbeiter { get; set; }
    }
}