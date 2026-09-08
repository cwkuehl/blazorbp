// <copyright file="HH410Model.cs" company="cwkuehl.de">
// Copyright (c) cwkuehl.de. All rights reserved.
// </copyright>

namespace BlazorBp.Models.Hh;

using System.ComponentModel.DataAnnotations;
using BlazorBp.Base;
using CSBP.Services.Apis.Models;
using CSBP.Services.Base;
using static BlazorBp.Base.DialogTypeEnum;

/// <summary>
/// Model-Klasse für das nicht modale Formular HH410 Buchungen.
/// </summary>
[Serializable]
public class HH410Model : PageModelBase
{
  /// <summary>Holt oder setzt Nr..</summary>
  [Display(Name = "Nr.", Description = "Buchung-Nr.")]
  public string? Nummer { get; set; }

  /// <summary>Holt oder setzt Valuta.</summary>
  [Display(Name = "_Valuta", Description = "")]
  [Required(ErrorMessage = "Valuta muss angegeben werden.")]
  public DateTime? Valuta { get; set; }

  /// <summary>Holt oder setzt Betrag.</summary>
  [Display(Name = "_Betrag", Description = "Betrag, evtl. mit vorangestelltem Operator +, -, * oder /.")]
  //// [Required(ErrorMessage = "Betrag muss angegeben werden.")]
  [MaxLength(20, ErrorMessage = "Betrag darf maximal {1} Zeichen lang sein.")]
  public string? Betrag { get; set; }

  /// <summary>Holt oder setzt Summe.</summary>
  [Display(Name = "Summe", Description = "Summe")]
  public decimal? Summe { get; set; }

  /// <summary>Holt oder setzt die Auswahlliste von Ereignis.</summary>
  public List<ListItem>? AuswahlEreignis { get; set; } = default!;

  /// <summary>Holt oder setzt Ereignis.</summary>
  [Display(Name = "_Ereignis", Description = "Ereignis")]
  public string? Ereignis { get; set; }

  /// <summary>Holt oder setzt die Auswahlliste von Sollkonto.</summary>
  public List<ListItem>? AuswahlSollkonto { get; set; } = default!;

  /// <summary>Holt oder setzt Sollkonto.</summary>
  //// [Display(Name = "_Sollkonto", Description = "Sollkonto")]
  //// [Required(ErrorMessage = "Sollkonto muss angegeben werden.")]
  public string? Sollkonto { get; set; }

  /// <summary>Holt oder setzt die Auswahlliste von Habenkonto.</summary>
  public List<ListItem>? AuswahlHabenkonto { get; set; } = default!;

  /// <summary>Holt oder setzt Habenkonto.</summary>
  //// [Display(Name = "Habe_nkonto", Description = "Habenkonto")]
  //// [Required(ErrorMessage = "Habenkonto muss angegeben werden.")]
  public string? Habenkonto { get; set; }

  /// <summary>Holt oder setzt Buchungstext.</summary>
  [Display(Name = "Buchungste_xt", Description = "Buchungstext")]
  //// [Required(ErrorMessage = "Buchungstext muss angegeben werden.")]
  [MaxLength(100, ErrorMessage = "Buchungstext darf maximal {1} Zeichen lang sein.")]
  public string? BText { get; set; }

  /// <summary>Holt oder setzt Beleg.</summary>
  [Display(Name = "Bele_g", Description = "Belegnummer")]
  [MaxLength(50, ErrorMessage = "Beleg darf maximal {1} Zeichen lang sein.")]
  public string? BelegNr { get; set; }

  /// <summary>Holt oder setzt Neue Nr..</summary>
  [Display(Name = "Neue N_r.", Description = "Neue Belegnummer berechnen")]
  public string? NeueNr { get; set; }

  /// <summary>Holt oder setzt Vom.</summary>
  [Display(Name = "Vom", Description = "Belegdatum")]
  public DateTime? BelegDatum { get; set; }

  /// <summary>Holt oder setzt Angelegt.</summary>
  [Display(Name = "Angelegt", Description = "Datum, Uhrzeit und Benutzer, der die Daten angelegt hat")]
  public string? Angelegt { get; set; }

  /// <summary>Holt oder setzt Geändert.</summary>
  [Display(Name = "Geändert", Description = "Datum, Uhrzeit und Benutzer, der die Daten geändert hat")]
  public string? Geaendert { get; set; }

  /// <summary>Holt oder setzt Letzte Buchung.</summary>
  [Display(Name = "Letzte Buchung", Description = "Letzte Buchung")]
  public string? Buchung { get; set; }

  /// <summary>Holt oder setzt OK.</summary>
  [Display(Name = "_OK", Description = "Dialog mit Speichern schließen")]
  public string? Ok { get; set; }

  /// <summary>Holt oder setzt Kontentausch.</summary>
  [Display(Name = "Kon_tentausch", Description = "Kontentausch")]
  public string? Kontentausch { get; set; }

  /// <summary>Holt oder setzt Addition.</summary>
  [Display(Name = "_Addition", Description = "Addtion, Multiplikation, Division zur Summe")]
  public string? Addition { get; set; }

  /// <summary>Holt oder setzt Abbrechen.</summary>
  [Display(Name = "Abbre_chen", Description = "Dialog ohne Speichern schließen")]
  public string? Abbrechen { get; set; }

  /// <summary>Kopiert die Werte aus einem Model.</summary>
  /// <param name="m">Zu kopierendes Model.</param>
  public void From(HhBuchung m) =>
  (
    Nummer,
    Valuta,
    Betrag,
    Summe,
    Sollkonto,
    Habenkonto,
    BText,
    BelegNr,
    BelegDatum,
    Angelegt,
    Geaendert
  ) = (
    m.Uid,
    m.Soll_Valuta,
    Functions.ToString(m.EBetrag, 2),
    0,
    m.Soll_Konto_Uid,
    m.Haben_Konto_Uid,
    m.BText,
    m.Beleg_Nr,
    m.Beleg_Datum,
    ModelBase.FormatDateOf(m.Angelegt_Am, m.Angelegt_Von),
    ModelBase.FormatDateOf(m.Geaendert_Am, m.Geaendert_Von)
  );

  /// <summary>Kopiert die Werte in ein Model.</summary>
  /// <param name="daten">Service-Daten für den Datenbankzugriff.</param>
  /// <returns>Das kopierte Model.</returns>
  public HhBuchung To(ServiceDaten daten)
  {
    var v = new HhBuchung
    {
      Mandant_Nr = daten.MandantNr,
      Uid = Nummer,
      Soll_Valuta = Valuta ?? daten.Heute,
      EBetrag = CalculateValue(),
      Soll_Konto_Uid = Sollkonto,
      Haben_Konto_Uid = Habenkonto,
      BText = BText,
      Beleg_Nr = BelegNr,
      Beleg_Datum = BelegDatum ?? daten.Heute,
    };
    v.Betrag = Functions.KonvDM(v.EBetrag);
    return v;
  }

  /// <summary>Berechnet den Betrag aus Einzelbetrag, Summe und Operator.</summary>
  /// <returns>Berechneter Betrag.</returns>
  public decimal CalculateValue()
  {
    var op = GetOperator();
    var b = Functions.ToDecimal(Betrag) ?? 0;
    var d = Summe ?? 0;
    if (string.IsNullOrEmpty(op))
      d += b;
    else if (op == "*")
      d *= b;
    else if (b != 0)
      d /= b; // operator.equals("/")
    d = Functions.Round(d) ?? 0;
    return d;
  }

  /// <summary>Setzt die Werte und Modi für das Model.</summary>
  /// <param name="mode">Betroffener Modus.</param>
  public void SetMhrf(DialogTypeEnum mode)
  {
    if (mode == New || mode == Copy)
    {
      Nummer = "";
    }
    SetMandatoryHiddenReadonly(nameof(Nummer), true, false, true, false);
    SetMandatoryHiddenReadonly(nameof(Valuta), true, false, mode == Delete, mode == New);
    SetMandatoryHiddenReadonly(nameof(Betrag), true, false, mode == Delete, mode == Edit);
    SetMandatoryHiddenReadonly(nameof(Summe), false, mode == Delete, true, false);
    SetMandatoryHiddenReadonly(nameof(Ereignis), false, mode == Delete, false, false);
    SetMandatoryHiddenReadonly(nameof(Sollkonto), true, false, mode == Delete, false);
    SetMandatoryHiddenReadonly(nameof(Habenkonto), true, false, mode == Delete, false);
    SetMandatoryHiddenReadonly(nameof(BText), true, false, mode == Delete, false);
    SetMandatoryHiddenReadonly(nameof(BelegNr), false, false, mode == Delete, false);
    SetMandatoryHiddenReadonly(nameof(NeueNr), false, mode == Delete, false, false);
    SetMandatoryHiddenReadonly(nameof(BelegDatum), true, false, mode == Delete, false);
    SetMandatoryHiddenReadonly(nameof(Angelegt), false, mode == New, true, false);
    SetMandatoryHiddenReadonly(nameof(Geaendert), false, mode == New, true, false);
    SetMandatoryHiddenReadonly(nameof(Buchung), false, mode == Delete || string.IsNullOrEmpty(Buchung), false, false);
    SetMandatoryHiddenReadonly(nameof(Ok), false, false, false, mode == Delete);
    SetMandatoryHiddenReadonly(nameof(Kontentausch), false, mode == Delete, false, false);
    SetMandatoryHiddenReadonly(nameof(Addition), false, mode == Delete, false, false);
    SetMandatoryHiddenReadonly(nameof(Abbrechen), false, false, false, false);
  }

  /// <summary>Liefert den Rechen-Operator und entfernt ihn aus dem Betrag.</summary>
  /// <returns>Bestimmter Rechen-Operator.</returns>
  private string GetOperator()
  {
    var op = "";
    var strBetrag = Functions.ToString(Betrag).Trim();
    if (strBetrag.StartsWith("+", StringComparison.InvariantCulture))
    {
      strBetrag = strBetrag[1..];
    }
    else if (strBetrag.StartsWith("*", StringComparison.InvariantCulture))
    {
      op = "*";
      strBetrag = strBetrag[1..];
    }
    else if (strBetrag.StartsWith("/", StringComparison.InvariantCulture))
    {
      op = "/";
      strBetrag = strBetrag[1..];
    }
    Betrag = strBetrag;
    return op;
  }
}
