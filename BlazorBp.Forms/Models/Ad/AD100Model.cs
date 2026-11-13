// <copyright file="AD100Model.cs" company="cwkuehl.de">
// Copyright (c) cwkuehl.de. All rights reserved.
// </copyright>

namespace BlazorBp.Forms.Models.Ad;

using System.ComponentModel.DataAnnotations;
using BlazorSpa.Core.Base;
using static BlazorSpa.Core.Base.DialogTypeEnum;

/// <summary>
/// Model-Klasse für das Formular AD100 Personen.
/// </summary>
[Serializable]
public class AD100Model : PageModelBase
{
  /// <summary>Holt oder setzt Name.</summary>
  [Display(Name = "_Name", Description = "Suche für Name")]
  //// [Required(ErrorMessage = "Name muss angegeben werden.")]
  //// [MaxLength(255, ErrorMessage = "Name darf maximal {1} Zeichen lang sein.")]
  public string? Name { get; set; }

  /// <summary>Holt oder setzt Vorname.</summary>
  [Display(Name = "_Vorname", Description = "Suche für Vorname")]
  //// [Required(ErrorMessage = "Vorname muss angegeben werden.")]
  //// [MaxLength(255, ErrorMessage = "Vorname darf maximal {1} Zeichen lang sein.")]
  public string? Vorname { get; set; }

  /// <summary>Holt oder setzt Neuer Sitz.</summary>
  [Display(Name = "N_euer Sitz", Description = "Neuen Sitz erstellen")]
  //// [Required(ErrorMessage = "Neuer Sitz muss angegeben werden.")]
  //// [MaxLength(255, ErrorMessage = "Neuer Sitz darf maximal {1} Zeichen lang sein.")]
  public string? SitzNeu { get; set; }

  /// <summary>Holt oder setzt 1. Sitz.</summary>
  [Display(Name = "1. _Sitz", Description = "Ausgewählten Sitz zum 1. Sitz machen")]
  //// [Required(ErrorMessage = "1. Sitz muss angegeben werden.")]
  //// [MaxLength(255, ErrorMessage = "1. Sitz darf maximal {1} Zeichen lang sein.")]
  public string? SitzEins { get; set; }

  /// <summary>Holt oder setzt Geburtstagsliste.</summary>
  [Display(Name = "_Geburtstagsliste", Description = "Liste von aktuellen Geburtstagen anzeigen")]
  //// [Required(ErrorMessage = "Geburtstagsliste muss angegeben werden.")]
  //// [MaxLength(255, ErrorMessage = "Geburtstagsliste darf maximal {1} Zeichen lang sein.")]
  public string? GebListe { get; set; }

  /// <summary>Holt oder setzt Action.print.</summary>
  [Display(Name = "Action.print", Description = "Action.print")]
  //// [Required(ErrorMessage = "Action.print muss angegeben werden.")]
  //// [MaxLength(255, ErrorMessage = "Action.print darf maximal {1} Zeichen lang sein.")]
  public string? Print { get; set; }

  /// <summary>Holt oder setzt Importieren und Exportieren.</summary>
  [Display(Name = "Importieren und Exportieren", Description = "Importieren und Exportieren")]
  //// [Required(ErrorMessage = "Importieren und Exportieren muss angegeben werden.")]
  //// [MaxLength(255, ErrorMessage = "Importieren und Exportieren darf maximal {1} Zeichen lang sein.")]
  public string? Floppy { get; set; }

  /// <summary>Holt oder setzt Aktualisieren.</summary>
  [Display(Name = "Aktualisieren", Description = "Aktualisieren")]
  //// [Required(ErrorMessage = "Aktualisieren muss angegeben werden.")]
  //// [MaxLength(255, ErrorMessage = "Aktualisieren darf maximal {1} Zeichen lang sein.")]
  public string? Refresh { get; set; }

  /// <summary>Holt oder setzt Schließen.</summary>
  [Display(Name = "Schließen", Description = "Schließen")]
  //// [Required(ErrorMessage = "Schließen muss angegeben werden.")]
  //// [MaxLength(255, ErrorMessage = "Schließen darf maximal {1} Zeichen lang sein.")]
  public string? Schliessen { get; set; }

  /// <summary>Setzt die Werte und Modi für das Model.</summary>
  /// <param name="mode">Betroffener Modus.</param>
  public void SetMhrf(DialogTypeEnum mode)
  {
    if (mode == New || mode == Copy)
    {
      Name = "%%";
      Vorname = "%%";
    }
    SetMandatoryHiddenReadonly(nameof(Name), false, false, false, false);
    SetMandatoryHiddenReadonly(nameof(Vorname), false, false, false, false);
    SetMandatoryHiddenReadonly(nameof(SitzNeu), false, false, false, false);
    SetMandatoryHiddenReadonly(nameof(SitzEins), false, false, false, false);
    SetMandatoryHiddenReadonly(nameof(GebListe), false, false, false, false);
    SetMandatoryHiddenReadonly(nameof(Print), false, false, false, false);
    SetMandatoryHiddenReadonly(nameof(Floppy), false, false, false, false);
    SetMandatoryHiddenReadonly(nameof(Refresh), false, false, false, false);
    SetMandatoryHiddenReadonly(nameof(Schliessen), false, false, false, false);
  }
}
