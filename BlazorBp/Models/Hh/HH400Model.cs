// <copyright file="HH400Model.cs" company="cwkuehl.de">
// Copyright (c) cwkuehl.de. All rights reserved.
// </copyright>

namespace BlazorBp.Models.Hh;

using System.ComponentModel.DataAnnotations;
using BlazorBp.Base;
using CSBP.Services.Apis.Models;
using CSBP.Services.Base;
using static BlazorBp.Base.DialogTypeEnum;

/// <summary>
/// Model-Klasse für das Formular HH400 Buchungen.
/// </summary>
[Serializable]
public class HH400Model : PageModelBase
{
  /// <summary>Holt oder setzt Betrag.</summary>
  [Display(Name = "B_etrag", Description = "Betrag")]
  public string? Betrag { get; set; }

  /// <summary>Holt oder setzt die Auswahlliste von Konto.</summary>
  public List<ListItem>? AuswahlKonto { get; set; } = default!;

  /// <summary>Holt oder setzt Konto.</summary>
  [Display(Name = "_Konto", Description = "Soll- oder Habenkonto")]
  public string? Konto { get; set; }

  /// <summary>Holt oder setzt die Liste von Kennzeichen.</summary>
  public List<ListItem>? AuswahlKennzeichen { get; set; }

  /// <summary>Holt oder setzt Suche nach.</summary>
  [Display(Name = "_Suche nach", Description = "Valuta oder Revision (Angelegt/Geändert)")]
  [Required(ErrorMessage = "Suche nach muss angegeben werden.")]
  public string? Kennzeichen { get; set; }

  /// <summary>Holt oder setzt Von.</summary>
  [Display(Name = "_Von", Description = "Ab-Datum für Soll-Valuta")]
  public DateTime? Von { get; set; }

  /// <summary>Holt oder setzt Bis.</summary>
  [Display(Name = "B_is", Description = "Bis-Datum für Soll-Valuta")]
  public DateTime? Bis { get; set; }

  /// <summary>Holt oder setzt Aktualisieren.</summary>
  [Display(Name = "Aktualisieren", Description = "Aktualisieren")]
  public string? Refresh { get; set; }

  /// <summary>Holt oder setzt Schließen.</summary>
  [Display(Name = "Schließen", Description = "Schließen")]
  public string? Schliessen { get; set; }

  /// <summary>Setzt die Werte und Modi für das Model.</summary>
  /// <param name="daten">Service-Daten für den Datenbankzugriff.</param>
  /// <param name="mode">Betroffener Modus.</param>
  public void SetMhrf(DialogTypeEnum mode, ServiceDaten daten)
  {
    if (mode == New || mode == Copy)
    {
      Betrag = null;
      Konto = null;
      Kennzeichen = "1";
      var d = daten.Heute;
      Von = d.AddDays(1 - d.Day).AddMonths(-14);
      Bis = d.AddDays(1 - d.Day).AddMonths(1);
    }
    SetMandatoryHiddenReadonly(nameof(Betrag), false, false, false, false);
    SetMandatoryHiddenReadonly(nameof(Konto), false, false, false, false);
    SetMandatoryHiddenReadonly(nameof(Kennzeichen), true, false, false, false);
    SetMandatoryHiddenReadonly(nameof(Von), false, false, false, false);
    SetMandatoryHiddenReadonly(nameof(Bis), false, false, false, false);
    SetMandatoryHiddenReadonly(nameof(Refresh), false, false, false, false);
    SetMandatoryHiddenReadonly(nameof(Schliessen), false, false, false, false);
  }
}
