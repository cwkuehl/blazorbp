// <copyright file="AD120Model.cs" company="cwkuehl.de">
// Copyright (c) cwkuehl.de. All rights reserved.
// </copyright>

namespace BlazorBp.Forms.Models.Ad;

using System.ComponentModel.DataAnnotations;
using BlazorSpa.Core.Base;
using BlazorSpa.Core.Models;
using CSBP.Services.Base;
using static BlazorSpa.Core.Base.DialogTypeEnum;

/// <summary>
/// Model-Klasse für das Formular AD120 Geburtstagsliste.
/// </summary>
[Serializable]
public class AD120Model : PageModelBase
{
  /// <summary>Holt oder setzt Datum.</summary>
  [Display(Name = "_Datum", Description = "")]
  [Required(ErrorMessage = "Datum muss angegeben werden.")]
  public DateTime? Datum { get; set; }

  /// <summary>Holt oder setzt Anzahl Tage.</summary>
  [Display(Name = "_Anzahl Tage", Description = "Tage, die vor und nach dem Datum berücksichtigt werden")]
  [Required(ErrorMessage = "Anzahl Tage muss angegeben werden.")]
  public int Tage { get; set; }

  /// <summary>Holt oder setzt die Auswahlliste von Geburtstage.</summary>
  public List<ListItem>? AuswahlGeburtstage { get; set; } = default!;

  /// <summary>Holt oder setzt Geburtstage.</summary>
  [Display(Name = "_Geburtstage", Description = "Liste der Personen, die im angegebenen Zeitraum Geburtstag haben")]
  public string? Geburtstage { get; set; }

  /// <summary>Holt oder setzt Nach dem Anmelden anzeigen.</summary>
  [Display(Name = "Nach dem Anmelden _anzeigen", Description = "Nach dem Anmelden anzeigen")]
  public bool Starten { get; set; }

  /// <summary>Holt oder setzt OK.</summary>
  [Display(Name = "_OK", Description = "Dialog mit Speichern schließen")]
  public string? Ok { get; set; }

  /// <summary>Setzt die Werte und Modi für das Model.</summary>
  /// <param name="mode">Betroffener Modus.</param>
  /// <param name="daten">Service-Daten für den Datenbankzugriff.</param>
  public void SetMhrf(DialogTypeEnum mode, ServiceDaten daten)
  {
    if (mode == New)
    {
      Datum = daten.Heute;
    }
    SetMandatoryHiddenReadonly(nameof(Datum), true, false, false, false);
    SetMandatoryHiddenReadonly(nameof(Tage), true, false, false, mode == New);
    SetMandatoryHiddenReadonly(nameof(Geburtstage), false, false, false, false);
    SetMandatoryHiddenReadonly(nameof(Starten), false, false, false, false);
    SetMandatoryHiddenReadonly(nameof(Ok), false, false, false, false);
  }
}
