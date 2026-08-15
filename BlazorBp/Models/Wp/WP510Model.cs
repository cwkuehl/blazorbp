// <copyright file="WP510Model.cs" company="cwkuehl.de">
// Copyright (c) cwkuehl.de. All rights reserved.
// </copyright>

namespace BlazorBp.Models.Wp;

using System.ComponentModel.DataAnnotations;
using BlazorBp.Base;
using CSBP.Services.Apis.Models;
using CSBP.Services.Base;
using static BlazorBp.Base.DialogTypeEnum;

/// <summary>
/// Model-Klasse für das nicht modale Formular WP510 Stände.
/// </summary>
[Serializable]
public class WP510Model : PageModelBase
{
  /// <summary>Holt oder setzt die Auswahlliste von Wertpapieren.</summary>
  public List<ListItem>? AuswahlWertpapier { get; set; } = default!;

  /// <summary>Holt oder setzt Wertpapier.</summary>
  [Display(Name = "_Wertpapier", Description = "Bezug zum Wertpapier")]
  [Required(ErrorMessage = "Wertpapier muss angegeben werden.")]
  //// [MaxLength(255, ErrorMessage = "Wertpapier darf maximal {1} Zeichen lang sein.")]
  public string? Wertpapier { get; set; }

  /// <summary>Holt oder setzt Datum.</summary>
  [Display(Name = "_Datum", Description = "")]
  [Required(ErrorMessage = "Datum muss angegeben werden.")]
  public DateTime? Valuta { get; set; }

  /// <summary>Holt oder setzt Betrag.</summary>
  [Display(Name = "_Betrag", Description = "Kurs am Datum")]
  [Required(ErrorMessage = "Betrag muss angegeben werden.")]
  //// [MaxLength(255, ErrorMessage = "Betrag darf maximal {1} Zeichen lang sein.")]
  public decimal? Betrag { get; set; }

  /// <summary>Holt oder setzt Angelegt.</summary>
  [Display(Name = "Angelegt", Description = "Datum, Uhrzeit und Benutzer, der die Daten angelegt hat")]
  public string? Angelegt { get; set; }

  /// <summary>Holt oder setzt Geändert.</summary>
  [Display(Name = "Geändert", Description = "Datum, Uhrzeit und Benutzer, der die Daten geändert hat")]
  public string? Geaendert { get; set; }

  /// <summary>Holt oder setzt OK.</summary>
  [Display(Name = "_OK", Description = "Dialog mit Speichern schließen")]
  //// [Required(ErrorMessage = "OK muss angegeben werden.")]
  //// [MaxLength(255, ErrorMessage = "OK darf maximal {1} Zeichen lang sein.")]
  public string? Ok { get; set; }

  /// <summary>Holt oder setzt Abbrechen.</summary>
  [Display(Name = "Abbre_chen", Description = "Dialog ohne Speichern schließen")]
  //// [Required(ErrorMessage = "Abbrechen muss angegeben werden.")]
  //// [MaxLength(255, ErrorMessage = "Abbrechen darf maximal {1} Zeichen lang sein.")]
  public string? Abbrechen { get; set; }

  /// <summary>Kopiert die Werte aus einem Model.</summary>
  /// <param name="m">Zu kopierendes Model.</param>
  public void From(WpStand m) =>
  (
    Wertpapier,
    Valuta,
    Betrag,
    Angelegt,
    Geaendert
  ) = (
    m.Wertpapier_Uid,
    m.Datum,
    m.Stueckpreis,
    ModelBase.FormatDateOf(m.Angelegt_Am, m.Angelegt_Von),
    ModelBase.FormatDateOf(m.Geaendert_Am, m.Geaendert_Von)
  );

  /// <summary>Kopiert die Werte in ein Model.</summary>
  /// <param name="daten">Service-Daten für den Datenbankzugriff.</param>
  /// <returns>Das kopierte Model.</returns>
  public WpStand To(ServiceDaten daten) => new()
  {
    Mandant_Nr = daten.MandantNr,
    Wertpapier_Uid = Wertpapier,
    Datum = Valuta ?? daten.Heute,
    Stueckpreis = Betrag ?? 0,
  };

  /// <summary>Setzt die Werte und Modi für das Model.</summary>
  /// <param name="mode">Betroffener Modus.</param>
  /// <param name="daten">Service-Daten für den Datenbankzugriff.</param>
  public void SetMhrf(DialogTypeEnum mode, ServiceDaten daten)
  {
    if (mode == New || mode == Copy)
    {
      // TODO Nummer = "";
    }
    if (mode == New)
    {
      Valuta = daten.Heute;
    }
    SetMandatoryHiddenReadonly(nameof(Wertpapier), true, false, mode == Edit || mode == Delete, mode == New);
    SetMandatoryHiddenReadonly(nameof(Valuta), true, false, mode == Edit || mode == Delete, false);
    SetMandatoryHiddenReadonly(nameof(Betrag), true, false, mode == Delete, mode == Edit);
    SetMandatoryHiddenReadonly(nameof(Angelegt), false, mode == New, true);
    SetMandatoryHiddenReadonly(nameof(Geaendert), false, mode == New, true);
    SetMandatoryHiddenReadonly(nameof(Ok), false, false, false, mode == Delete);
  }
}
