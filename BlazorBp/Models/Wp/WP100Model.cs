// <copyright file="WP100Model.cs" company="cwkuehl.de">
// Copyright (c) cwkuehl.de. All rights reserved.
// </copyright>

namespace BlazorBp.Models.Wp;

using System.ComponentModel.DataAnnotations;
using BlazorBp.Base;
using CSBP.Services.Base;
using static BlazorBp.Base.DialogTypeEnum;

/// <summary>
/// Model-Klasse für das Formular WP100 Point and Figure.
/// </summary>
[Serializable]
public class WP100Model : PageModelBase
{
  /// <summary>Holt oder setzt die Auswahlliste von Daten.</summary>
  public List<ListItem>? AuswahlData { get; set; } = default!;

  /// <summary>Holt oder setzt Daten.</summary>
  [Display(Name = "_Daten", Description = "")]
  public string? Data { get; set; }

  /// <summary>Holt oder setzt Von.</summary>
  [Display(Name = "_Von", Description = "")]
  [Required(ErrorMessage = "Von muss angegeben werden.")]
  public DateTime? Von { get; set; }

  /// <summary>Holt oder setzt Bis.</summary>
  [Display(Name = "B_is", Description = "")]
  [Required(ErrorMessage = "Bis muss angegeben werden.")]
  public DateTime? Bis { get; set; }

  /// <summary>Holt oder setzt die Auswahlliste von Wertpapieren.</summary>
  public List<ListItem>? AuswahlWertpapier { get; set; } = default!;

  /// <summary>Holt oder setzt Wertpapier.</summary>
  [Display(Name = "_Wertpapier", Description = "Wertpapier")]
  [Required(ErrorMessage = "Wertpapier muss angegeben werden.")]
  public string? Wertpapier { get; set; }

  /// <summary>Holt oder setzt Boxgröße.</summary>
  [Display(Name = "Bo_xgröße", Description = "Boxgröße absolut oder prozentual")]
  [Required(ErrorMessage = "Boxgröße muss angegeben werden.")]
  public decimal? Box { get; set; }

  /// <summary>Holt oder setzt die Auswahlliste von Skala.</summary>
  public List<ListItem>? AuswahlSkala { get; set; } = default!;

  /// <summary>Holt oder setzt Skala.</summary>
  [Display(Name = "Skala", Description = "Zugrundeliegende Skala für die Boxgröße")]
  [Required(ErrorMessage = "Skala muss angegeben werden.")]
  public string? Skala { get; set; }

  /// <summary>Holt oder setzt Umkehr.</summary>
  [Display(Name = "_Umkehr", Description = "Anzahl der Boxen für Umkehr")]
  [Required(ErrorMessage = "Umkehr muss angegeben werden.")]
  public int? Umkehr { get; set; }

  /// <summary>Holt oder setzt die Auswahlliste von Methode.</summary>
  public List<ListItem>? AuswahlMethode { get; set; } = default!;

  /// <summary>Holt oder setzt Methode.</summary>
  [Display(Name = "_Methode", Description = "Methode für Kursberechnung")]
  [Required(ErrorMessage = "Methode muss angegeben werden.")]
  public string? Methode { get; set; }

  /// <summary>Holt oder setzt Relativ.</summary>
  [Display(Name = "_Relativ", Description = "Soll die Auswertung relativ zur Relation erfolgen?")]
  public bool Relativ { get; set; }

  /// <summary>Holt oder setzt Chart.</summary>
  [Display(Name = "Chart", Description = "")]
  public string? Chart { get; set; }

  /// <summary>Holt oder setzt Aktualisieren.</summary>
  [Display(Name = "Aktualisieren", Description = "Aktualisieren")]
  public string? Refresh { get; set; }

  /// <summary>Holt oder setzt Schließen.</summary>
  [Display(Name = "Schließen", Description = "Schließen")]
  public string? Schliessen { get; set; }

  /// <summary>Setzt die Werte und Modi für das Model.</summary>
  /// <param name="mode">Betroffener Modus.</param>
  /// <param name="daten">Die Service-Daten.</param>
  public void SetMhrf(DialogTypeEnum mode, ServiceDaten daten)
  {
    if (mode == New)
    {
      Von = daten.Heute.AddDays(-180);
      Bis = daten.Heute;
      Box = 1;
      Umkehr = 3;
    }
    SetMandatoryHiddenReadonly(nameof(Data), false, false, true, false);
    SetMandatoryHiddenReadonly(nameof(Von), true, false, false, false);
    SetMandatoryHiddenReadonly(nameof(Bis), true, false, false, false);
    SetMandatoryHiddenReadonly(nameof(Wertpapier), true, false, true, mode == New);
    SetMandatoryHiddenReadonly(nameof(Box), true, false, false, false);
    SetMandatoryHiddenReadonly(nameof(Skala), true, false, false, false);
    SetMandatoryHiddenReadonly(nameof(Umkehr), true, false, false, false);
    SetMandatoryHiddenReadonly(nameof(Methode), true, false, false, false);
    SetMandatoryHiddenReadonly(nameof(Relativ), false, true, true);
    SetMandatoryHiddenReadonly(nameof(Chart), false, false, false, false);
    SetMandatoryHiddenReadonly(nameof(Refresh), false, false, false, false);
    SetMandatoryHiddenReadonly(nameof(Schliessen), false, false, false, false);
  }
}
