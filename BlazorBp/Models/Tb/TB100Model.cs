// <copyright file="TB100Model.cs" company="cwkuehl.de">
// Copyright (c) cwkuehl.de. All rights reserved.
// </copyright>

namespace BlazorBp.Models.Tb;

using System.ComponentModel.DataAnnotations;
using BlazorBp.Base;
using CSBP.Services.Apis.Models;
using CSBP.Services.Base;

/// <summary>
/// Model-Klasse für das Formular TB100 Tagebuch.
/// </summary>
[Serializable]
public class TB100Model : PageModelBase
{
  /// <summary>Holt oder setzt die Kopie.</summary>
  public string? Kopie { get; set; }

  /// <summary>Holt oder setzt einen Wert, der angibt, ob der Suchbereich sichtbar ist.</summary>
  public bool Weathervisible { get; set; } = false;

  /// <summary>Holt oder setzt einen Wert, der angibt, ob der Suchbereich sichtbar ist.</summary>
  public bool Searchvisible { get; set; } = false;

  /// <summary>Holt oder setzt einen Wert, der angibt, ob ein vorheriger Eintrag geladen wurde.</summary>
  public bool OldLoaded { get; set; } = false;

  /// <summary>Holt oder setzt den alten Eintrag.</summary>
  public TbEintrag? OldEntry { get; set; } = null;

  /// <summary>Holt oder setzt die aktuelle Positionsliste.</summary>
  public List<TbEintragOrt>? PositionList { get; set; } = null;

  /// <summary>Holt oder setzt Kopieren.</summary>
  [Display(Name = "Kopieren", Description = "Kopieren des aktuellen Eintrags.")]
  public string? Copy { get; set; }

  /// <summary>Holt oder setzt Einfügen.</summary>
  [Display(Name = "Einfügen", Description = "Einfügen des kopierten Eintrags.")]
  public string? Paste { get; set; }

  /// <summary>Holt oder setzt Wetter.</summary>
  [Display(Name = "Wetter", Description = "Wetter")]
  public string? Weather { get; set; }

  /// <summary>Holt oder setzt Download.</summary>
  [Display(Name = "Download", Description = "Importieren der Rabp-Daten ins Tagebuch")]
  public string? Download { get; set; }

  /// <summary>Holt oder setzt 1 Tag vorher.</summary>
  [Display(Name = "1 Tag vorher", Description = "Eintrag vom Vortag")]
  //// [Required(ErrorMessage = "1 Tag vorher muss angegeben werden.")]
  public string? Before1 { get; set; }

  /// <summary>Holt oder setzt die Temperatur.</summary>
  [Display(Name = "Temperatur °C", Description = "Temperatur-Kurve zum ausgewählten Datum")]
  public string? Diagramb1 { get; set; }

  /// <summary>Holt oder setzt 1 Monat vorher.</summary>
  [Display(Name = "1 Monat vorher", Description = "Eintrag vor einem Monat")]
  //// [Required(ErrorMessage = "1 Monat vorher muss angegeben werden.")]
  public string? Before2 { get; set; }

  /// <summary>Holt oder setzt den Luftdruck.</summary>
  [Display(Name = "Luftdruck hPa", Description = "Luftdruck-Kurve zum ausgewählten Datum")]
  public string? Diagramb2 { get; set; }
  
  /// <summary>Holt oder setzt 1 Jahr vorher.</summary>
  [Display(Name = "1 Jahr vorher", Description = "Eintrag vor einem Jahr")]
  //// [Required(ErrorMessage = "1 Jahr vorher muss angegeben werden.")]
  public string? Before3 { get; set; }

  /// <summary>Holt oder setzt die relative Luftfeuchtigkeit.</summary>
  [Display(Name = "Rel. Luftfeucht. %", Description = "Relative Luftfeuchtigkeit-Kurve zum ausgewählten Datum")]
  public string? Diagramb3 { get; set; }

  /// <summary>Holt oder setzt Datum.</summary>
  [Display(Name = "_Datum", Description = "Datum zum Tagebuch-Eintrag")]
  //// [Required(ErrorMessage = "Datum muss angegeben werden.")]
  public DateTime? Date { get; set; }

  /// <summary>Holt oder setzt Eintrag.</summary>
  [Display(Name = "Ein_trag", Description = "Tagebuch-Eintrag")]
  //// [Required(ErrorMessage = "Eintrag muss angegeben werden.")]
  public string? Entry { get; set; }

  /// <summary>Holt oder setzt Positionen.</summary>
  [Display(Name = "Positionen", Description = "Positionen zum Tagebuch-Eintrag")]
  //// [Required(ErrorMessage = "Positionen muss angegeben werden.")]
  public string? Positions { get; set; }

  /// <summary>Holt oder setzt die Auswahlliste von Positionen.</summary>
  public List<ListItem>? AuswahlPositions { get; set; } = default!;

  /// <summary>Holt oder setzt Neu.</summary>
  [Display(Name = "Neu", Description = "Neuen Ort oder Position erfassen.")]
  //// [Required(ErrorMessage = "TB100.new muss angegeben werden.")]
  public string? New { get; set; }

  /// <summary>Holt oder setzt Entfernen.</summary>
  [Display(Name = "Entfernen", Description = "Ort oder Position entfernen.")]
  //// [Required(ErrorMessage = "TB100.remove muss angegeben werden.")]
  public string? Remove { get; set; }

  /// <summary>Holt oder setzt Position.</summary>
  [Display(Name = "Position", Description = "Ort oder Position zum Hinzufügen.")]
  //// [Required(ErrorMessage = "Position muss angegeben werden.")]
  public string? Position { get; set; }

  /// <summary>Holt oder setzt die Auswahlliste von Positionen.</summary>
  public List<ListItem>? AuswahlPosition { get; set; } = default!;

  /// <summary>Holt oder setzt TB100.add.</summary>
  [Display(Name = "Hinzufügen", Description = "Ausgewählten Ort oder Position hinzufügen.")]
  //// [Required(ErrorMessage = "TB100.add muss angegeben werden.")]
  public string? Add { get; set; }

  /// <summary>Holt oder setzt Angelegt.</summary>
  [Display(Name = "Angelegt", Description = "Datum, Uhrzeit und Benutzer, der die Daten angelegt hat")]
  //// [Required(ErrorMessage = "Angelegt muss angegeben werden.")]
  public string? Angelegt { get; set; }

  /// <summary>Holt oder setzt Geändert.</summary>
  [Display(Name = "Geändert", Description = "Datum, Uhrzeit und Benutzer, der die Daten geändert hat")]
  //// [Required(ErrorMessage = "Geändert muss angegeben werden.")]
  public string? Geaendert { get; set; }

  /// <summary>Holt oder setzt P. Vortag.</summary>
  [Display(Name = "P. Vortag", Description = "Positionen vom Vortag hinzufügen.")]
  //// [Required(ErrorMessage = "P. Vortag muss angegeben werden.")]
  public string? Posbefore { get; set; }

  /// <summary>Holt oder setzt 1 Tag danach.</summary>
  [Display(Name = "1 Tag danach", Description = "Eintrag vom Folgetag")]
  //// [Required(ErrorMessage = "1 Tag danach muss angegeben werden.")]
  public string? After1 { get; set; }

  /// <summary>Holt oder setzt den Niederschlag.</summary>
  [Display(Name = "Niederschlag mm", Description = "Niederschlags-Kurve zum ausgewählten Datum")]
  public string? Diagrama1 { get; set; }

  /// <summary>Holt oder setzt 1 Monat danach.</summary>
  [Display(Name = "1 Monat danach", Description = "1 Monat danach")]
  //// [Required(ErrorMessage = "1 Monat danach muss angegeben werden.")]
  public string? After2 { get; set; }

  /// <summary>Holt oder setzt die Windgeschwindigkeit.</summary>
  [Display(Name = "Windgeschwindigkeit km/h", Description = "Windgeschwindigkeit-Kurve zum ausgewählten Datum")]
  public string? Diagrama2 { get; set; }

  /// <summary>Holt oder setzt 1 Jahr danach.</summary>
  [Display(Name = "1 Jahr danach", Description = "Eintrag nach einem Jahr")]
  //// [Required(ErrorMessage = "1 Jahr danach muss angegeben werden.")]
  public string? After3 { get; set; }

  /// <summary>Holt oder setzt die Windrichtung.</summary>
  [Display(Name = "Windrichtung °", Description = "Windrichtungs-Kurve zum ausgewählten Datum")]
  public string? Diagrama3 { get; set; }

  /// <summary>Holt oder setzt TB100.search.</summary>
  [Display(Name = "Suche", Description = "Such-Bereich ein- bzw. ausblenden.")]
  //// [Required(ErrorMessage = "TB100.search muss angegeben werden.")]
  public string? Search { get; set; }

  /// <summary>Holt oder setzt Suche (Platzhalter % und ; Reihenfolge-Prüfung ####).</summary>
  [Display(Name = "_Suche (Platzhalter % und __; Reihenfolge-Prüfung ####)", Description = "Suchhilfe")]
  //// [Required(ErrorMessage = "Suche (Platzhalter % und ; Reihenfolge-Prüfung ####) muss angegeben werden.")]
  public string? Search00 { get; set; }

  /// <summary>Holt oder setzt (.</summary>
  [Display(Name = "(", Description = "1. Suchbegriff")]
  //// [Required(ErrorMessage = "( muss angegeben werden.")]
  public string? Search1 { get; set; }

  /// <summary>Holt oder setzt  oder .</summary>
  [Display(Name = " oder ", Description = "2. Suchbegriff")]
  //// [Required(ErrorMessage = " oder  muss angegeben werden.")]
  public string? Search2 { get; set; }

  /// <summary>Holt oder setzt  oder .</summary>
  [Display(Name = " oder ", Description = "3. Suchbegriff")]
  //// [Required(ErrorMessage = " oder  muss angegeben werden.")]
  public string? Search3 { get; set; }

  /// <summary>Holt oder setzt ).</summary>
  [Display(Name = ")", Description = "ohne")]
  //// [Required(ErrorMessage = ") muss angegeben werden.")]
  public string? Search4 { get; set; }

  /// <summary>Holt oder setzt  und (.</summary>
  [Display(Name = " und (", Description = "4. Suchbegriff")]
  //// [Required(ErrorMessage = " und ( muss angegeben werden.")]
  public string? Search5 { get; set; }

  /// <summary>Holt oder setzt  oder .</summary>
  [Display(Name = " oder ", Description = "5. Suchbegriff")]
  //// [Required(ErrorMessage = " oder  muss angegeben werden.")]
  public string? Search6 { get; set; }

  /// <summary>Holt oder setzt  oder .</summary>
  [Display(Name = " oder ", Description = "6. Suchbegriff")]
  //// [Required(ErrorMessage = " oder  muss angegeben werden.")]
  public string? Search7 { get; set; }

  /// <summary>Holt oder setzt ).</summary>
  [Display(Name = ")", Description = "ohne")]
  //// [Required(ErrorMessage = ") muss angegeben werden.")]
  public string? Search8 { get; set; }

  /// <summary>Holt oder setzt  und nicht (.</summary>
  [Display(Name = " und nicht (", Description = "7. Suchbegriff")]
  //// [Required(ErrorMessage = " und nicht ( muss angegeben werden.")]
  public string? Search9 { get; set; }

  /// <summary>Holt oder setzt  oder .</summary>
  [Display(Name = " oder ", Description = "8. Suchbegriff")]
  //// [Required(ErrorMessage = " oder  muss angegeben werden.")]
  public string? Search100 { get; set; }

  /// <summary>Holt oder setzt  oder .</summary>
  [Display(Name = " oder ", Description = "9. Suchbegriff")]
  //// [Required(ErrorMessage = " oder  muss angegeben werden.")]
  public string? Search110 { get; set; }

  /// <summary>Holt oder setzt ).</summary>
  [Display(Name = ")", Description = "ohne")]
  //// [Required(ErrorMessage = ") muss angegeben werden.")]
  public string? Search120 { get; set; }

  /// <summary>Holt oder setzt TB100.clear.</summary>
  [Display(Name = "Leeren", Description = "Leeren der Such-Kriterien.")]
  //// [Required(ErrorMessage = "TB100.clear muss angegeben werden.")]
  public string? Clear { get; set; }

  /// <summary>Holt oder setzt Position.</summary>
  [Display(Name = "Position", Description = "Ort oder Position zum Suchen.")]
  //// [Required(ErrorMessage = "Position muss angegeben werden.")]
  public string? Position2 { get; set; }

  /// <summary>Holt oder setzt die Auswahlliste von Positionen.</summary>
  public List<ListItem>? AuswahlPosition2 { get; set; } = default!;

  /// <summary>Holt oder setzt Von.</summary>
  [Display(Name = "Von", Description = "Von-Datum für Suche")]
  //// [Required(ErrorMessage = "Von muss angegeben werden.")]
  public DateTime? From { get; set; }

  /// <summary>Holt oder setzt Bis.</summary>
  [Display(Name = "Bis", Description = "Bis-Datum für Suche")]
  //// [Required(ErrorMessage = "Bis muss angegeben werden.")]
  public DateTime? To { get; set; }

  /// <summary>Holt oder setzt TB100.first.</summary>
  [Display(Name = "|<", Description = "Sprung zum ersten Eintrag.")]
  //// [Required(ErrorMessage = "TB100.first muss angegeben werden.")]
  public string? First { get; set; }

  /// <summary>Holt oder setzt TB100.back.</summary>
  [Display(Name = "<", Description = "Sprung zum vorhergehenden Eintrag.")]
  //// [Required(ErrorMessage = "TB100.back muss angegeben werden.")]
  public string? Back { get; set; }

  /// <summary>Holt oder setzt TB100.forward.</summary>
  [Display(Name = ">", Description = "Sprung zum nächsten Eintrag.")]
  //// [Required(ErrorMessage = "TB100.forward muss angegeben werden.")]
  public string? Forward { get; set; }

  /// <summary>Holt oder setzt TB100.last.</summary>
  [Display(Name = ">|", Description = "Sprung zum letzten Eintrag.")]
  //// [Required(ErrorMessage = "TB100.last muss angegeben werden.")]
  public string? Last { get; set; }

  /// <summary>Holt oder setzt TB100.save.</summary>
  [Display(Name = "Speichern", Description = "Speichern aller passenden Einträge in einer Datei.")]
  //// [Required(ErrorMessage = "TB100.save muss angegeben werden.")]
  public string? Save { get; set; }

  /// <summary>Holt oder setzt Schließen.</summary>
  [Display(Name = "Schließen", Description = "Schließen")]
  //// [Required(ErrorMessage = "Schließen muss angegeben werden.")]
  public string? Schliessen { get; set; }

  /// <summary>
  /// Clears the search data.
  /// </summary>
  public void ClearSearch()
  {
    Search1 = "%%";
    Search2 = "%%";
    Search3 = "%%";
    Search4 = null;
    Search5 = "%%";
    Search6 = "%%";
    Search7 = "%%";
    Search8 = null;
    Search9 = "%%";
    Search100 = "%%";
    Search110  = "%%";
    Search120 = null;
    Position2 = null;
    From = Functions.IsLinux() ? DateTime.Today.AddYears(-1) : null;
    To = DateTime.Today;
  }

  /// <summary>
  /// Gets the search array.
  /// </summary>
  /// <returns>Search array.</returns>
  public string?[] GetSearchArray()
  {
    var search = new string?[] { Search1, Search2, Search3, Search5, Search6, Search7, Search9, Search100, Search110 };
    return search;
  }

  /// <summary>Setzt die Werte und Modi für das Model.</summary>
  /// <param name="mode">Betroffener Modus.</param>
  public void SetMhrf(DialogTypeEnum mode)
  {
    if (mode == DialogTypeEnum.New || mode == DialogTypeEnum.Copy)
    {
      // TODO Nummer = "";
    }
    if (mode == DialogTypeEnum.New)
    {
      // TODO Thema = null;
    }
    var h = !Searchvisible;
    SetMandatoryHiddenReadonly(nameof(Download), false, true, false, false);
    SetMandatoryHiddenReadonly(nameof(Before1), false, false, true, false);
    SetMandatoryHiddenReadonly(nameof(Before2), false, false, true, false);
    SetMandatoryHiddenReadonly(nameof(Before3), false, false, true, false);
    SetMandatoryHiddenReadonly(nameof(Date), true, false, false, false);
    SetMandatoryHiddenReadonly(nameof(Entry), true, false, false, mode == DialogTypeEnum.New);
    SetMandatoryHiddenReadonly(nameof(After1), false, false, true, false);
    SetMandatoryHiddenReadonly(nameof(After2), false, false, true, false);
    SetMandatoryHiddenReadonly(nameof(After3), false, false, true, false);
    SetMandatoryHiddenReadonly(nameof(Angelegt), false, false, true);
    SetMandatoryHiddenReadonly(nameof(Geaendert), false, false, true);

    SetMandatoryHiddenReadonly(nameof(Clear), false, h, false);
    SetMandatoryHiddenReadonly(nameof(Search00), false, h, false);
    SetMandatoryHiddenReadonly(nameof(Search1), false, h, false);
    SetMandatoryHiddenReadonly(nameof(Search2), false, h, false);
    SetMandatoryHiddenReadonly(nameof(Search3), false, h, false);
    SetMandatoryHiddenReadonly(nameof(Search4), false, h, false);
    SetMandatoryHiddenReadonly(nameof(Search5), false, h, false);
    SetMandatoryHiddenReadonly(nameof(Search6), false, h, false);
    SetMandatoryHiddenReadonly(nameof(Search7), false, h, false);
    SetMandatoryHiddenReadonly(nameof(Search8), false, h, false);
    SetMandatoryHiddenReadonly(nameof(Search9), false, h, false);
    SetMandatoryHiddenReadonly(nameof(Search100), false, h, false);
    SetMandatoryHiddenReadonly(nameof(Search110), false, h, false);
    SetMandatoryHiddenReadonly(nameof(Search120), false, h, false);
    SetMandatoryHiddenReadonly(nameof(Position2), false, h, false);
    SetMandatoryHiddenReadonly(nameof(From), false, h, false);
    SetMandatoryHiddenReadonly(nameof(To), false, h, false);
    SetMandatoryHiddenReadonly(nameof(First), false, h, false);
    SetMandatoryHiddenReadonly(nameof(Back), false, h, false);
    SetMandatoryHiddenReadonly(nameof(Forward), false, h, false);
    SetMandatoryHiddenReadonly(nameof(Last), false, h, false);
    SetMandatoryHiddenReadonly(nameof(Save), false, h, false);
  }
}
