// <copyright file="WP250Model.cs" company="cwkuehl.de">
// Copyright (c) cwkuehl.de. All rights reserved.
// </copyright>

namespace BlazorBp.Models.Wp;

using System.ComponentModel.DataAnnotations;
using BlazorBp.Base;
using CSBP.Services.Base;
using static BlazorBp.Base.DialogTypeEnum;

/// <summary>
/// Model-Klasse für das Formular WP250 Anlagen.
/// </summary>
[Serializable]
public class WP250Model : PageModelBase
{
  /// <summary>Holt oder setzt Status.</summary>
  [Display(Name = "Status", Description = "")]
  //// [Required(ErrorMessage = "Status muss angegeben werden.")]
  //// [MaxLength(255, ErrorMessage = "Status darf maximal {1} Zeichen lang sein.")]
  public string? Status { get; set; }

  /// <summary>Holt oder setzt die Auswahlliste von Wertpapieren.</summary>
  public List<ListItem>? AuswahlWertpapier { get; set; } = default!;

  /// <summary>Holt oder setzt Wertpapier.</summary>
  [Display(Name = "_Wertpapier", Description = "Zu suchendes Wertpapier")]
  public string? Wertpapier { get; set; }

  /// <summary>Holt oder setzt auch inaktive.</summary>
  [Display(Name = "auch inaktive", Description = "Sollen auch inaktive Anlagen angezeigt werden?")]
  //// [Required(ErrorMessage = "auch inaktive muss angegeben werden.")]
  //// [MaxLength(255, ErrorMessage = "auch inaktive darf maximal {1} Zeichen lang sein.")]
  public bool Auchinaktiv { get; set; }

  /// <summary>Holt oder setzt Bewertungen berechnen.</summary>
  [Display(Name = "Bewertungen berechnen", Description = "Soll die Bewertung für jedes aktive Wertpapier berechnet werden?")]
  public string? Berechnen { get; set; }

  /// <summary>Holt oder setzt Bis.</summary>
  [Display(Name = "B_is", Description = "")]
  [Required(ErrorMessage = "Bis muss angegeben werden.")]
  public DateTime? Bis { get; set; }

  /// <summary>Holt oder setzt Details.</summary>
  [Display(Name = "Details", Description = "Details")]
  public string? Details { get; set; }

  /// <summary>Holt oder setzt Abbrechen.</summary>
  [Display(Name = "Abbre_chen", Description = "Berechnung der Bewertungen abbrechen")]
  public string? Abbrechen { get; set; }

  /// <summary>Holt oder setzt Chart oder Karte.</summary>
  [Display(Name = "Chart oder Karte", Description = "Chart oder Karte")]
  public string? Chart { get; set; }

  /// <summary>Holt oder setzt Aktualisieren.</summary>
  [Display(Name = "Aktualisieren", Description = "Aktualisieren")]
  public string? Refresh { get; set; }

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
      Wertpapier = null;
      Bis = daten.Heute;
    }
    if (mode == New)
    {
      Auchinaktiv = false;
    }
    SetMandatoryHiddenReadonly(nameof(Status), false, false, true, false);
  }
}
