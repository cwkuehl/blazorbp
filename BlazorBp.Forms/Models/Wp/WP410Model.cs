// <copyright file="WP410Model.cs" company="cwkuehl.de">
// Copyright (c) cwkuehl.de. All rights reserved.
// </copyright>

namespace BlazorBp.Forms.Models.Wp;

using System.ComponentModel.DataAnnotations;
using BlazorSpa.Base;
using BlazorSpa.Core.Base;
using BlazorSpa.Core.Models;
using CSBP.Services.Apis.Models;
using CSBP.Services.Base;
using static BlazorSpa.Core.Base.DialogTypeEnum;

/// <summary>
/// Model-Klasse für das nicht modale Formular WP410 WP-Buchungen.
/// </summary>
[Serializable]
public class WP410Model : PageModelBase
{
  /// <summary>Holt oder setzt Nr..</summary>
  [Display(Name = "Nr.", Description = "")]
  public string? Nummer { get; set; }

  /// <summary>Holt oder setzt die Auswahlliste von Anlagen.</summary>
  public List<ListItem>? AuswahlAnlage { get; set; } = default!;

  /// <summary>Holt oder setzt Anlage.</summary>
  [Display(Name = "_Anlage", Description = "Betroffene Anlage.")]
  [Required(ErrorMessage = "Anlage muss angegeben werden.")]
  public string? Anlage { get; set; }

  /// <summary>Holt oder setzt Datum.</summary>
  [Display(Name = "_Datum", Description = "Buchungsdatum.")]
  [Required(ErrorMessage = "Datum muss angegeben werden.")]
  public DateTime? Valuta { get; set; }

  /// <summary>Holt oder setzt Preis.</summary>
  [Display(Name = "Preis", Description = "Kurs des Wertpapiers am Datum.")]
  public string? Preis { get; set; }

  /// <summary>Holt oder setzt Betrag.</summary>
  [Display(Name = "_Betrag", Description = "Zahlungsbetrag der Buchung.")]
  //// [Required(ErrorMessage = "Betrag muss angegeben werden.")]
  public string? Betrag { get; set; }

  /// <summary>Holt oder setzt Rabatt.</summary>
  [Display(Name = "_Rabatt", Description = "Rabatt auf die Buchung. Positiv für Rabatt, negativ für Gebühren.")]
  //// [Required(ErrorMessage = "Rabatt muss angegeben werden.")]
  //// [MaxLength(255, ErrorMessage = "Rabatt darf maximal {1} Zeichen lang sein.")]
  public string? Rabatt { get; set; }

  /// <summary>Holt oder setzt Anteile.</summary>
  [Display(Name = "_Anteile", Description = "Anzahl der Anteile.")]
  //// [Required(ErrorMessage = "Anteile muss angegeben werden.")]
  //// [MaxLength(255, ErrorMessage = "Anteile darf maximal {1} Zeichen lang sein.")]
  public string? Anteile { get; set; }

  /// <summary>Holt oder setzt Preis.</summary>
  [Display(Name = "Preis", Description = "Berechneter Kurs des Wertpapiers am Datum.")]
  //// [Required(ErrorMessage = "Preis muss angegeben werden.")]
  //// [MaxLength(255, ErrorMessage = "Preis darf maximal {1} Zeichen lang sein.")]
  public string? Preis2 { get; set; }

  /// <summary>Holt oder setzt Zinsen.</summary>
  [Display(Name = "_Zinsen", Description = "Zinsen für die Buchung.")]
  //// [Required(ErrorMessage = "Zinsen muss angegeben werden.")]
  //// [MaxLength(255, ErrorMessage = "Zinsen darf maximal {1} Zeichen lang sein.")]
  public string? Zinsen { get; set; }

  /// <summary>Holt oder setzt Buchungstext.</summary>
  [Display(Name = "Buchungste_xt", Description = "Beschreibung der Buchung.")]
  [Required(ErrorMessage = "Buchungstext muss angegeben werden.")]
  [MaxLength(255, ErrorMessage = "Buchungstext darf maximal {1} Zeichen lang sein.")]
  public string? BText { get; set; }

  /// <summary>Holt oder setzt fixieren.</summary>
  [Display(Name = "fixieren", Description = "Soll der Buchungstext fixiert und nicht durch das Ereignis überschrieben werden?")]
  public bool Fixtext { get; set; }

  /// <summary>Holt oder setzt Angelegt.</summary>
  [Display(Name = "Angelegt", Description = "Datum der Erstellung.")]
  public string? Angelegt { get; set; }

  /// <summary>Holt oder setzt Geändert.</summary>
  [Display(Name = "Geändert", Description = "Datum der letzten Änderung.")]
  public string? Geaendert { get; set; }

  /// <summary>Holt oder setzt Letzte Buchung.</summary>
  [Display(Name = "Letzte Buchung", Description = "Letzte Buchung")]
  public string? Buchung { get; set; }

  /// <summary>Holt oder setzt HH-Buchung.</summary>
  [Display(Name = "HH-Buchung", Description = "ID der zugeordneten Haushaltsbuchung")]
  public string? Hhbuchung { get; set; }

  /// <summary>Holt oder setzt Ändern.</summary>
  [Display(Name = "Ändern", Description = "Zugeordnete Buchung ändern")]
  public string? HhAendern { get; set; }

  /// <summary>Holt oder setzt Storno.</summary>
  [Display(Name = "Storno", Description = "Zugeordnete Buchung stornieren")]
  public string? HhStorno { get; set; }

  /// <summary>Holt oder setzt Valuta.</summary>
  [Display(Name = "_Valuta", Description = "Valuta der zugeordneten Haushaltsbuchung")]
  //// [Required(ErrorMessage = "Valuta muss angegeben werden.")]
  public DateTime? Hhvaluta { get; set; }

  /// <summary>Holt oder setzt Betrag.</summary>
  [Display(Name = "Betrag", Description = "Betrag der zugeordneten Haushaltsbuchung")]
  public string? Hhbetrag { get; set; }

  /// <summary>Holt oder setzt die Auswahlliste von Ereignis.</summary>
  public List<HhEreignis>? AuswahlHhEreignis0 { get; set; } = default!;

  /// <summary>Holt oder setzt die Auswahlliste von Ereignis.</summary>
  public List<ListItem>? AuswahlHhEreignis { get; set; } = default!;

  /// <summary>Holt oder setzt Ereignis.</summary>
  [Display(Name = "Ereignis", Description = "Ereignis der zugeordneten Haushaltsbuchung")]
  public string? HhEreignis { get; set; }

  /// <summary>Holt oder setzt die Anlage zur Ereignisliste.</summary>
  public string? AnlageEreignis { get; set; }

  /// <summary>Holt oder setzt OK.</summary>
  [Display(Name = "_OK", Description = "Dialog speichern und schließen")]
  public string? Ok { get; set; }

  /// <summary>Holt oder setzt Abbrechen.</summary>
  [Display(Name = "Abbre_chen", Description = "Dialog abbrechen und schließen")]
  public string? Abbrechen { get; set; }

  /// <summary>Kopiert die Werte aus einem Model.</summary>
  /// <param name="m">Zu kopierendes Model.</param>
  /// <param name="b">Zugehörige Haushaltsbuchung.</param>
  public void From(WpBuchung m, HhBuchung? b = null)
  {
    (
      Nummer,
      Anlage,
      Valuta,
      Preis,
      Betrag,
      Rabatt,
      Anteile,
      Preis2,
      Zinsen,
      BText,
      Angelegt,
      Geaendert
    ) = (
      m.Uid,
      m.Anlage_Uid,
      m.Datum,
      Funktionen.ToString(0),
      Funktionen.ToString(m.Zahlungsbetrag),
      Funktionen.ToString(m.Rabattbetrag),
      Funktionen.ToString(m.Anteile, 5),
      Funktionen.ToString(0),
      Funktionen.ToString(m.Zinsen),
      m.BText,
      ModelBase.FormatDateOf(m.Angelegt_Am, m.Angelegt_Von),
      ModelBase.FormatDateOf(m.Geaendert_Am, m.Geaendert_Von)
    );
    if (m.BookingUid != null && b != null)
    {
      (
        Hhbuchung,
        Hhvaluta,
        Hhbetrag
      ) = (
        b.Uid,
        b.Soll_Valuta,
        Funktionen.ToString(b.EBetrag, 2)
      );
      var events = AuswahlHhEreignis0;
      if (events != null)
      {
        var ev = events.FirstOrDefault(a => a.Soll_Konto_Uid == b.Soll_Konto_Uid && a.Haben_Konto_Uid == b.Haben_Konto_Uid);
        if (ev != null)
          HhEreignis = ev.Uid;
      }
    }
  }

  /// <summary>Kopiert die Werte in ein Model.</summary>
  /// <param name="daten">Service-Daten für den Datenbankzugriff.</param>
  /// <returns>Das kopierte Model.</returns>
  public WpBuchung To(ServiceDaten daten) => new()
  {
    Mandant_Nr = daten.MandantNr,
    Uid = DialogType == Edit || DialogType == Delete ? Nummer : null,
    //// Wertpapier_Uid = Wertpapier,
    Anlage_Uid = Anlage,
    Datum = Valuta ?? daten.Heute,
    Zahlungsbetrag = Functions.ToDecimal(Betrag, 2) ?? 0,
    Rabattbetrag = Functions.ToDecimal(Rabatt, 2) ?? 0,
    Anteile = Functions.ToDecimal(Anteile, 5) ?? 0,
    Zinsen = Functions.ToDecimal(Zinsen, 2) ?? 0,
    BText = BText,
    //// Notiz = null,
  };

  /// <summary>Setzt die Werte und Modi für das Model.</summary>
  /// <param name="mode">Betroffener Modus.</param>
  public void SetMhrf(DialogTypeEnum mode)
  {
    if (mode == Copy)
    {
      Fixtext = true;
    }
    var b = string.IsNullOrEmpty(Hhbuchung);
    SetMandatoryHiddenReadonly(nameof(Nummer), true, false, true, false);
    SetMandatoryHiddenReadonly(nameof(Anlage), true, false, mode == Delete, false);
    SetMandatoryHiddenReadonly(nameof(Valuta), true, false, mode == Delete, false);
    SetMandatoryHiddenReadonly(nameof(Preis), false, false, true, false);
    SetMandatoryHiddenReadonly(nameof(Betrag), false, false, mode == Delete, mode == New || mode == Copy);
    SetMandatoryHiddenReadonly(nameof(Rabatt), false, false, mode == Delete, false);
    SetMandatoryHiddenReadonly(nameof(Anteile), false, false, mode == Delete, false);
    SetMandatoryHiddenReadonly(nameof(Preis2), false, false, true, false);
    SetMandatoryHiddenReadonly(nameof(Zinsen), false, false, mode == Delete, false);
    SetMandatoryHiddenReadonly(nameof(BText), true, false, mode == Delete, false);
    SetMandatoryHiddenReadonly(nameof(Buchung), false, false, true, false);
    SetMandatoryHiddenReadonly(nameof(Fixtext), false, false, mode == Delete, false);
    SetMandatoryHiddenReadonly(nameof(Angelegt), false, mode == New, true, false);
    SetMandatoryHiddenReadonly(nameof(Geaendert), false, mode == New, true, false);
    SetMandatoryHiddenReadonly(nameof(Hhbuchung), false, false, true, false);
    SetMandatoryHiddenReadonly(nameof(HhAendern), false, false, b || mode == Delete, false);
    SetMandatoryHiddenReadonly(nameof(HhStorno), false, false, b || mode == Delete, false);
    SetMandatoryHiddenReadonly(nameof(Hhvaluta), false, false, !b || mode == Delete, false);
    SetMandatoryHiddenReadonly(nameof(Hhbetrag), false, false, !b || mode == Delete, false);
    SetMandatoryHiddenReadonly(nameof(HhEreignis), false, false, !b || mode == Delete, false);
    SetMandatoryHiddenReadonly(nameof(Ok), false, false, false, false);
    SetMandatoryHiddenReadonly(nameof(Abbrechen), false, false, false, false);
  }
}
