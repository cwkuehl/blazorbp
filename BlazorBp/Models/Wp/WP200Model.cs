// <copyright file="WP200Model.cs" company="cwkuehl.de">
// Copyright (c) cwkuehl.de. All rights reserved.
// </copyright>

namespace BlazorBp.Models.Wp;

using System.ComponentModel.DataAnnotations;
using BlazorBp.Base;
using CSBP.Services.Base;
using static BlazorBp.Base.DialogTypeEnum;

/// <summary>
/// Model-Klasse für das Formular WP200 Wertpapiere.
/// </summary>
[Serializable]
public class WP200Model : PageModelBase
{
  /// <summary>Holt oder setzt Aktualisieren.</summary>
  [Display(Name = "Aktualisieren", Description = "Aktualisieren")]
  //// [Required(ErrorMessage = "Aktualisieren muss angegeben werden.")]
  public string? Refresh { get; set; }

  /// <summary>Holt oder setzt Importieren und Exportieren.</summary>
  [Display(Name = "Importieren und Exportieren", Description = "Importieren und Exportieren")]
  //// [Required(ErrorMessage = "Importieren und Exportieren muss angegeben werden.")]
  public string? Floppy { get; set; }

  /// <summary>Holt oder setzt Chart oder Karte.</summary>
  [Display(Name = "Chart oder Karte", Description = "Chart oder Karte")]
  //// [Required(ErrorMessage = "Chart oder Karte muss angegeben werden.")]
  public string? Chart { get; set; }

  /// <summary>Holt oder setzt Status.</summary>
  [Display(Name = "Status", Description = "")]
  //// [Required(ErrorMessage = "Status muss angegeben werden.")]
  public string? Status { get; set; }

  /// <summary>Holt oder setzt Muster.</summary>
  [Display(Name = "_Muster", Description = "Zu suchendes Muster")]
  //// [Required(ErrorMessage = "Muster muss angegeben werden.")]
  public string? Muster { get; set; }

  /// <summary>Holt oder setzt auch inaktive.</summary>
  [Display(Name = "auch inaktive", Description = "Sollen auch inaktive Wertpapiere angezeigt werden?")]
  //// [Required(ErrorMessage = "auch inaktive muss angegeben werden.")]
  public bool Auchinaktiv { get; set; }

  /// <summary>Holt oder setzt Bewertungen berechnen.</summary>
  [Display(Name = "Bewertungen berechnen", Description = "Soll die Bewertung für jedes aktive Wertpapier berechnet werden?")]
  //// [Required(ErrorMessage = "Bewertungen berechnen muss angegeben werden.")]
  public string? Berechnen { get; set; }

  /// <summary>Holt oder setzt Bis.</summary>
  [Display(Name = "B_is", Description = "")]
  //// [Required(ErrorMessage = "Bis muss angegeben werden.")]
  public DateTime? Bis { get; set; }

  /// <summary>Holt oder setzt die Auswahlliste von Konfiguration.</summary>
  public List<ListItem>? AuswahlKonfiguration { get; set; } = default!;

  /// <summary>Holt oder setzt Konfiguration.</summary>
  [Display(Name = "_Konfiguration", Description = "Konfiguration für Bewertung festlegen")]
  //// [Required(ErrorMessage = "Konfiguration muss angegeben werden.")]
  public string? Konfiguration { get; set; }

  /// <summary>Holt oder setzt Schließen.</summary>
  [Display(Name = "Schließen", Description = "Schließen")]
  public string? Schliessen { get; set; }

  /// <summary>Setzt die Werte und Modi für das Model.</summary>
  /// <param name="mode">Betroffener Modus.</param>
  /// <param name="daten">Service-Daten für den Datenbankzugriff.</param>
  public void SetMhrf(DialogTypeEnum mode, ServiceDaten daten)
  {
    if (mode == New || mode == Copy)
    {
      Muster = "%%";
      Bis = daten.Heute;
    }
    if (mode == New)
    {
      Auchinaktiv = false;
    }
    SetMandatoryHiddenReadonly(nameof(Status), false, false, true, false);
  }
}
