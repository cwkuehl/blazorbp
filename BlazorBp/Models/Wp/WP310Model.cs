// <copyright file="WP310Model.cs" company="cwkuehl.de">
// Copyright (c) cwkuehl.de. All rights reserved.
// </copyright>

namespace BlazorBp.Models.Wp;

using System.ComponentModel.DataAnnotations;
using BlazorBp.Base;
using CSBP.Services.Apis.Models;
using CSBP.Services.Base;
using static BlazorBp.Base.DialogTypeEnum;

/// <summary>
/// Model-Klasse für das modale Formular WP310 Konfigurationen.
/// </summary>
[Serializable]
public class WP310Model : PageModelBase
{
  /// <summary>Holt oder setzt Nr..</summary>
  [Display(Name = "Nr.", Description = "Konfiguration-Nr.")]
  //// [Required(ErrorMessage = "Nr. muss angegeben werden.")]
  public string? Nummer { get; set; }

  /// <summary>Holt oder setzt Bezeichnung.</summary>
  [Display(Name = "_Bezeichnung", Description = "Bezeichnung")]
  //// [Required(ErrorMessage = "Bezeichnung muss angegeben werden.")]
  public string? Bezeichnung { get; set; }

  /// <summary>Holt oder setzt Boxgröße.</summary>
  [Display(Name = "Bo_xgröße", Description = "Boxgröße absolut oder prozentual")]
  //// [Required(ErrorMessage = "Boxgröße muss angegeben werden.")]
  public decimal Box { get; set; }
  
  /// <summary>Holt oder setzt die Auswahlliste von Skala.</summary>
  public List<ListItem>? AuswahlSkala { get; set; } = default!;

  /// <summary>Holt oder setzt Skala.</summary>
  [Display(Name = "_Skala", Description = "Skala für Kursberechnung")]
  //// [Required(ErrorMessage = "Skala muss angegeben werden.")]
  public string? Skala { get; set; }

  /// <summary>Holt oder setzt Umkehr.</summary>
  [Display(Name = "_Umkehr", Description = "Anzahl der Boxen für Umkehr")]
  //// [Required(ErrorMessage = "Umkehr muss angegeben werden.")]
  public int Umkehr { get; set; }

  /// <summary>Holt oder setzt die Auswahlliste von Methode.</summary>
  public List<ListItem>? AuswahlMethode { get; set; } = default!;

  /// <summary>Holt oder setzt Methode.</summary>
  [Display(Name = "_Methode", Description = "Methode für Kursberechnung")]
  //// [Required(ErrorMessage = "Methode muss angegeben werden.")]
  public string? Methode { get; set; }

  /// <summary>Holt oder setzt Dauer.</summary>
  [Display(Name = "_Dauer", Description = "Anzahl der Tage, die ausgewertet werden sollen.")]
  //// [Required(ErrorMessage = "Dauer muss angegeben werden.")]
  public int Dauer { get; set; }

  /// <summary>Holt oder setzt Relativ.</summary>
  [Display(Name = "_Relativ", Description = "Soll die Auswertung relativ zu anderem Wertpapier oder Index erfolgen?")]
  //// [Required(ErrorMessage = "Relativ muss angegeben werden.")]
  public bool Relativ { get; set; }

  /// <summary>Holt oder setzt die Auswahlliste von Status.</summary>
  public List<ListItem>? AuswahlStatus { get; set; } = default!;

  /// <summary>Holt oder setzt Status.</summary>
  [Display(Name = "_Status", Description = "Status")]
  //// [Required(ErrorMessage = "Status muss angegeben werden.")]
  public string? Status { get; set; }

  /// <summary>Holt oder setzt Notiz.</summary>
  [Display(Name = "Notiz", Description = "")]
  //// [Required(ErrorMessage = "Notiz muss angegeben werden.")]
  public string? Notiz { get; set; }

  /// <summary>Holt oder setzt Angelegt.</summary>
  [Display(Name = "Angelegt", Description = "Datum, Uhrzeit und Benutzer, der die Daten angelegt hat")]
  //// [Required(ErrorMessage = "Angelegt muss angegeben werden.")]
  public string? Angelegt { get; set; }

  /// <summary>Holt oder setzt Geändert.</summary>
  [Display(Name = "Geändert", Description = "Datum, Uhrzeit und Benutzer, der die Daten geändert hat")]
  //// [Required(ErrorMessage = "Geändert muss angegeben werden.")]
  public string? Geaendert { get; set; }

  /// <summary>Holt oder setzt OK.</summary>
  [Display(Name = "_OK", Description = "Dialog mit Speichern schließen")]
  //// [Required(ErrorMessage = "OK muss angegeben werden.")]
  public string? Ok { get; set; }

  /// <summary>Holt oder setzt Abbrechen.</summary>
  [Display(Name = "Abbre_chen", Description = "Dialog ohne Speichern schließen")]
  //// [Required(ErrorMessage = "Abbrechen muss angegeben werden.")]
  public string? Abbrechen { get; set; }

  /// <summary>Kopiert die Werte in ein Model.</summary>
  /// <param name="daten">Service-Daten für den Datenbankzugriff.</param>
  /// <returns>Das kopierte Model.</returns>
  public WpKonfiguration To(ServiceDaten daten) => new()
  {
    Mandant_Nr = daten.MandantNr,
    Uid = Nummer,
    Bezeichnung = Bezeichnung,
    Box = Box,
    Scale = Functions.ToInt32(Skala),
    Reversal = Umkehr,
    Method = Functions.ToInt32(Methode),
    Duration = Dauer,
    Relative = Relativ,
    Status = Status,
    Notiz = Notiz,
  };

  /// <summary>Kopiert die Werte aus einem Model.</summary>
  /// <param name="m">Zu kopierendes Model.</param>
  public void From(WP300TableRowModel m) =>
  (
    Nummer,
    Bezeichnung,
    Box,
    Skala,
    Umkehr,
    Methode,
    Dauer,
    Relativ,
    Status,
    Notiz,
    Angelegt,
    Geaendert
  ) = (
    m.Nummer,
    m.Bezeichnung,
    m.Box,
    Functions.ToString(m.Skala),
    m.Umkehr,
    Functions.ToString(m.Methode),
    m.Dauer,
    m.Relativ,
    m.Status,
    m.Notiz,
    ModelBase.FormatDateOf(m.AngelegtAm, m.AngelegtVon),
    ModelBase.FormatDateOf(m.GeaendertAm, m.GeaendertVon)
  );

  /// <summary>Setzt die Werte und Modi für das Model.</summary>
  /// <param name="mode">Betroffener Modus.</param>
  public void SetMhrf(DialogTypeEnum mode)
  {
    if (mode == New || mode == Copy)
    {
      Nummer = "";
      Skala = "1";
      Methode = "1";
      Status = "1";
    }
    SetMandatoryHiddenReadonly(nameof(Nummer), false, false, true, false);
    SetMandatoryHiddenReadonly(nameof(Bezeichnung), true, false, mode == Delete, mode != New);
    SetMandatoryHiddenReadonly(nameof(Box), true, false, mode == Delete, false);
    SetMandatoryHiddenReadonly(nameof(Skala), true, false, mode == Delete, false);
    SetMandatoryHiddenReadonly(nameof(Umkehr), true, false, mode == Delete, false);
    SetMandatoryHiddenReadonly(nameof(Methode), true, false, mode == Delete, false);
    SetMandatoryHiddenReadonly(nameof(Dauer), true, false, mode == Delete, false);
    SetMandatoryHiddenReadonly(nameof(Status), true, false, mode == Delete, false);
    SetMandatoryHiddenReadonly(nameof(Angelegt), false, mode == New, true);
    SetMandatoryHiddenReadonly(nameof(Geaendert), false, mode == New, true);
    SetMandatoryHiddenReadonly(nameof(Ok), false, false, false, mode == Delete);
  }
}
