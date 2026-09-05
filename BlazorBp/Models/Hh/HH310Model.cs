// <copyright file="HH310Model.cs" company="cwkuehl.de">
// Copyright (c) cwkuehl.de. All rights reserved.
// </copyright>

namespace BlazorBp.Models.Hh;

using System.ComponentModel.DataAnnotations;
using BlazorBp.Base;
using CSBP.Services.Apis.Models;
using CSBP.Services.Base;
using static BlazorBp.Base.DialogTypeEnum;

/// <summary>
/// Model-Klasse für das nicht modale Formular HH310 Ereignisse.
/// </summary>
[Serializable]
public class HH310Model : PageModelBase
{
  /// <summary>Holt oder setzt Nr..</summary>
  [Display(Name = "Nr.", Description = "Ereignis-Nr.")]
  public string? Nummer { get; set; }

  /// <summary>Holt oder setzt Bezeichnung.</summary>
  [Display(Name = "_Bezeichnung", Description = "Bezeichnung")]
  [Required(ErrorMessage = "Bezeichnung muss angegeben werden.")]
  [MaxLength(50, ErrorMessage = "Bezeichnung darf maximal {1} Zeichen lang sein.")]
  public string? Bezeichnung { get; set; }

  /// <summary>Holt oder setzt Kennzeichen.</summary>
  [Display(Name = "_Kennzeichen", Description = "Kennzeichen")]
  [MaxLength(1, ErrorMessage = "Kennzeichen darf maximal {1} Zeichen lang sein.")]
  public string? Kennzeichen { get; set; }

  /// <summary>Holt oder setzt Buchungstext.</summary>
  [Display(Name = "Buchungste_xt", Description = "Buchungstext")]
  [Required(ErrorMessage = "Buchungstext muss angegeben werden.")]
  [MaxLength(100, ErrorMessage = "Buchungstext darf maximal {1} Zeichen lang sein.")]
  public string? EText { get; set; }

  /// <summary>Holt oder setzt die Auswahlliste von Sollkonto.</summary>
  public List<ListItem>? AuswahlSollkonto { get; set; } = default!;

  /// <summary>Holt oder setzt Sollkonto.</summary>
  [Display(Name = "_Sollkonto", Description = "Sollkonto")]
  [Required(ErrorMessage = "Sollkonto muss angegeben werden.")]
  public string? Sollkonto { get; set; }

  /// <summary>Holt oder setzt die Auswahlliste von Habenkonto.</summary>
  public List<ListItem>? AuswahlHabenkonto { get; set; } = default!;

  /// <summary>Holt oder setzt Habenkonto.</summary>
  [Display(Name = "_Habenkonto", Description = "Habenkonto")]
  [Required(ErrorMessage = "Habenkonto muss angegeben werden.")]
  public string? Habenkonto { get; set; }

  /// <summary>Holt oder setzt Angelegt.</summary>
  [Display(Name = "Angelegt", Description = "Datum, Uhrzeit und Benutzer, der die Daten angelegt hat")]
  public string? Angelegt { get; set; }

  /// <summary>Holt oder setzt Geändert.</summary>
  [Display(Name = "Geändert", Description = "Datum, Uhrzeit und Benutzer, der die Daten geändert hat")]
  public string? Geaendert { get; set; }

  /// <summary>Holt oder setzt OK.</summary>
  [Display(Name = "_OK", Description = "Dialog mit Speichern schließen")]
  public string? Ok { get; set; }

  /// <summary>Holt oder setzt Kontentausch.</summary>
  [Display(Name = "Kon_tentausch", Description = "Kontentausch")]
  public string? Kontentausch { get; set; }

  /// <summary>Holt oder setzt Abbrechen.</summary>
  [Display(Name = "Abbre_chen", Description = "Dialog ohne Speichern schließen")]
  public string? Abbrechen { get; set; }

  /// <summary>Kopiert die Werte aus einem Model.</summary>
  /// <param name="m">Zu kopierendes Model.</param>
  public void From(HhEreignis m) =>
  (
    Nummer,
    Bezeichnung,
    Kennzeichen,
    EText,
    Sollkonto,
    Habenkonto,
    Angelegt,
    Geaendert
  ) = (
    m.Uid,
    m.Bezeichnung,
    m.Kz,
    m.EText,
    m.Soll_Konto_Uid,
    m.Haben_Konto_Uid,
    ModelBase.FormatDateOf(m.Angelegt_Am, m.Angelegt_Von),
    ModelBase.FormatDateOf(m.Geaendert_Am, m.Geaendert_Von)
  );

  /// <summary>Kopiert die Werte in ein Model.</summary>
  /// <param name="daten">Service-Daten für den Datenbankzugriff.</param>
  /// <returns>Das kopierte Model.</returns>
  public HhEreignis To(ServiceDaten daten) => new()
  {
    Mandant_Nr = daten.MandantNr,
    Uid = Nummer,
    Kz = Kennzeichen,
    Bezeichnung = Bezeichnung,
    EText = EText,
    Soll_Konto_Uid = Sollkonto,
    Haben_Konto_Uid = Habenkonto,
  };

  /// <summary>Setzt die Werte und Modi für das Model.</summary>
  /// <param name="mode">Betroffener Modus.</param>
  public void SetMhrf(DialogTypeEnum mode)
  {
    if (mode == New || mode == Copy)
    {
      Nummer = "";
    }
    SetMandatoryHiddenReadonly(nameof(Nummer), true, false, true, false);
    SetMandatoryHiddenReadonly(nameof(Bezeichnung), true, false, mode == Delete, mode != Delete);
    SetMandatoryHiddenReadonly(nameof(Kennzeichen), false, false, mode == Delete, false);
    SetMandatoryHiddenReadonly(nameof(EText), true, false, mode == Delete, false);
    SetMandatoryHiddenReadonly(nameof(Sollkonto), true, false, mode == Delete, false);
    SetMandatoryHiddenReadonly(nameof(Habenkonto), true, false, mode == Delete, false);
    SetMandatoryHiddenReadonly(nameof(Angelegt), false, mode == New, true);
    SetMandatoryHiddenReadonly(nameof(Geaendert), false, mode == New, true);
    SetMandatoryHiddenReadonly(nameof(Ok), false, false, false, mode == Delete);
    SetMandatoryHiddenReadonly(nameof(Kontentausch), false, mode == Delete, false, false);
    SetMandatoryHiddenReadonly(nameof(Abbrechen), false, false, false, false);
  }
}
