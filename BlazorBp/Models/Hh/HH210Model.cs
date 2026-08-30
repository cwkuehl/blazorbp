// <copyright file="HH210Model.cs" company="cwkuehl.de">
// Copyright (c) cwkuehl.de. All rights reserved.
// </copyright>

namespace BlazorBp.Models.Hh;

using System.ComponentModel.DataAnnotations;
using BlazorBp.Base;
using CSBP.Services.Apis.Models;
using CSBP.Services.Base;
using static BlazorBp.Base.DialogTypeEnum;

/// <summary>
/// Model-Klasse für das nicht modale Formular HH210 Konten.
/// </summary>
[Serializable]
public class HH210Model : PageModelBase
{
  /// <summary>Holt oder setzt Nr..</summary>
  [Display(Name = "Nr.", Description = "Konto-Nr.")]
  public string? Nummer { get; set; }

  /// <summary>Holt oder setzt Bezeichnung.</summary>
  [Display(Name = "_Bezeichnung", Description = "Bezeichnung")]
  [Required(ErrorMessage = "Bezeichnung muss angegeben werden.")]
  [MaxLength(50, ErrorMessage = "Bezeichnung darf maximal {1} Zeichen lang sein.")]
  public string? Bezeichnung { get; set; }

  /// <summary>Holt oder setzt die Auswahlliste von Kennzeichen.</summary>
  public List<ListItem>? AuswahlKennzeichen { get; set; } = default!;

  /// <summary>Holt oder setzt Kennzeichen.</summary>
  [Display(Name = "_Kennzeichen", Description = "Kennzeichen des Kontos, z.B. Eigenkapitel-Konto, Gewinn+Verlust-Konto, Depot-Konto")]
  public string? Kennzeichen { get; set; }

  /// <summary>Holt oder setzt die Auswahlliste von Kontoart.</summary>
  public List<ListItem>? AuswahlKontoart { get; set; } = default!;

  /// <summary>Holt oder setzt Kontoart.</summary>
  [Display(Name = "Kontoa_rt", Description = "")]
  [Required(ErrorMessage = "Kontoart muss angegeben werden.")]
  public string? Kontoart { get; set; }

  /// <summary>Holt oder setzt Gültigkeit von.</summary>
  [Display(Name = "Gültigkeit _von", Description = "Buchungen ab diesem Datum zugelassen")]
  public DateTime? Von { get; set; }

  /// <summary>Holt oder setzt Bis.</summary>
  [Display(Name = "B_is", Description = "Buchungen bis zu diesem Datum zugelassen")]
  public DateTime? Bis { get; set; }

  /// <summary>Holt oder setzt Betrag.</summary>
  [Display(Name = "B_etrag", Description = "Betrag am 1. Gültigkeitstag für Aktiv- und Passivkonten, negativ für Aktivkonten.")]
  public decimal? Betrag { get; set; }

  /// <summary>Holt oder setzt Angelegt.</summary>
  [Display(Name = "Angelegt", Description = "Datum, Uhrzeit und Benutzer, der die Daten angelegt hat")]
  public string? Angelegt { get; set; }

  /// <summary>Holt oder setzt Geändert.</summary>
  [Display(Name = "Geändert", Description = "Datum, Uhrzeit und Benutzer, der die Daten geändert hat")]
  public string? Geaendert { get; set; }

  /// <summary>Holt oder setzt die Buchung.</summary>
  [Display(Name = "Buchungen", Description = "Zeitraum der Buchungen")]
  public string? Buchung { get; set; }

  /// <summary>Holt oder setzt OK.</summary>
  [Display(Name = "_OK", Description = "Dialog mit Speichern schließen")]
  public string? Ok { get; set; }

  /// <summary>Holt oder setzt Abbrechen.</summary>
  [Display(Name = "Abbre_chen", Description = "Dialog ohne Speichern schließen")]
  public string? Abbrechen { get; set; }

  /// <summary>Kopiert die Werte aus einem Model.</summary>
  /// <param name="m">Zu kopierendes Model.</param>
  public void From(HhKonto m) =>
  (
    Nummer,
    Kontoart,
    Kennzeichen,
    Bezeichnung,
    Von,
    Bis,
    Betrag,
    Angelegt,
    Geaendert
  ) = (
    m.Uid,
    m.Art,
    m.Kz,
    m.Name,
    m.Gueltig_Von,
    m.Gueltig_Bis,
    m.EBetrag,
    ModelBase.FormatDateOf(m.Angelegt_Am, m.Angelegt_Von),
    ModelBase.FormatDateOf(m.Geaendert_Am, m.Geaendert_Von)
  );

  /// <summary>Kopiert die Werte in ein Model.</summary>
  /// <param name="daten">Service-Daten für den Datenbankzugriff.</param>
  /// <returns>Das kopierte Model.</returns>
  public HhKonto To(ServiceDaten daten) => new()
  {
    Mandant_Nr = daten.MandantNr,
    Uid = Nummer,
    Art = Kontoart,
    Kz = Kennzeichen,
    Name = Bezeichnung,
    Gueltig_Von = Von,
    Gueltig_Bis = Bis,
    EBetrag = Betrag ?? 0,
  };

  /// <summary>Setzt die Werte und Modi für das Model.</summary>
  /// <param name="mode">Betroffener Modus.</param>
  public void SetMhrf(DialogTypeEnum mode)
  {
    if (mode == New || mode == Copy)
    {
      Nummer = "";
    }
    if (mode == New)
    {
      Kennzeichen = "";
      Kontoart = "";
      Betrag = 0;
    }
    SetMandatoryHiddenReadonly(nameof(Nummer), false, false, true, false);
    SetMandatoryHiddenReadonly(nameof(Bezeichnung), true, false, mode == Delete, mode != Delete);
    SetMandatoryHiddenReadonly(nameof(Kennzeichen), true, false, (mode == Edit && (Kennzeichen == Constants.KZK_EK || Kennzeichen == Constants.KZK_GV)) || mode == Delete, false);
    SetMandatoryHiddenReadonly(nameof(Kontoart), true, false, mode == Edit || mode == Delete, false);
    SetMandatoryHiddenReadonly(nameof(Von), false, false, mode == Delete, false);
    SetMandatoryHiddenReadonly(nameof(Bis), false, false, mode == Delete, false);
    SetMandatoryHiddenReadonly(nameof(Betrag), false, false, mode == Delete, false);
    SetMandatoryHiddenReadonly(nameof(Angelegt), false, mode == New, true);
    SetMandatoryHiddenReadonly(nameof(Geaendert), false, mode == New, true);
    SetMandatoryHiddenReadonly(nameof(Buchung), false, mode == New || mode == Copy, true);
    SetMandatoryHiddenReadonly(nameof(Ok), false, false, false, mode == Delete);
    SetMandatoryHiddenReadonly(nameof(Abbrechen), false, false, false, false);
  }
}
