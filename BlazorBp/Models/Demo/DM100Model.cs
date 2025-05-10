// <copyright file="DM100Model.cs" company="cwkuehl.de">
// Copyright (c) cwkuehl.de. All rights reserved.
// </copyright>

namespace BlazorBp.Models.Demo;

using System.ComponentModel.DataAnnotations;
using BlazorBp.Base;

/// <summary>
/// Model-Klasse für das Formular DM100 Steuerelemente.
/// </summary>
[Serializable]
public class DM100Model : PageModelBase
{
  /// <summary>Holt oder setzt die CSS-Klasse des Formulars.</summary>
  public string VerticalColClass { get; set; } = "";

  /// <summary>Holt oder setzt den Test-Button.</summary>
  [Display(Name = "_Button", Description = "Test-Button")]
  public string? Button { get; set; } = default!;

  /// <summary>Holt oder setzt die Test-TextBox.</summary>
  [Display(Name = "_TextBox", Description = "Test-TextBox")]
  [Required]
  public string? TextBox { get; set; } = default!;

  /// <summary>Holt oder setzt die Test-TextArea.</summary>
  [Display(Name = "Text_Area", Description = "Test-TextArea")]
  public string? TextArea { get; set; } = default!;

  /// <summary>Holt oder setzt die Test-NumberBox.</summary>
  [Display(Name = "_NumberBox", Description = "Test-NumberBox")]
  [Range(0, 124)]
  public int? NumberBox { get; set; } = default!;

  /// <summary>Holt oder setzt die Test-CurrencyBox.</summary>
  [Display(Name = "Currenc_yBox", Description = "Test-CurrencyBox")]
  public decimal? CurrencyBox { get; set; } = default!;

  /// <summary>Holt oder setzt die Test-DateBox.</summary>
  [Display(Name = "_DateBox", Description = "Test-DateBox")]
  public DateTime? DateBox { get; set; } = default!;

  /// <summary>Holt oder setzt die Test-CheckBox.</summary>
  [Display(Name = "_CheckBox", Description = "Test-CheckBox")]
  public bool CheckBox { get; set; } = default!;

  /// <summary>Holt oder setzt den Test-RadioButton.</summary>
  [Display(Name = "_RadioButton", Description = "Test-RadioButton")]
  public string? RadioButton { get; set; } = default!;

  /// <summary>Holt oder setzt die Liste von RadioButton.</summary>
  public List<ListItem>? AuswahlRadioButton { get; set; }

  /// <summary>Holt oder setzt die ComboBox.</summary>
  [Display(Name = "C_omboBox", Description = "Test-ComboBox")]
  [Required]
  public string? ComboBox { get; set; } = default!;

  /// <summary>Holt oder setzt die Auswahlliste von ComboBox.</summary>
  public List<ListItem>? AuswahlComboBox { get; set; } = default!;

  /// <summary>Holt oder setzt die ListBox.</summary>
  [Display(Name = "_ListBox", Description = "Test-ListBox")]
  public string? ListBox { get; set; } = default!;

  /// <summary>Holt oder setzt die Auswahlliste von ListBox.</summary>
  public List<ListItem>? AuswahlListBox { get; set; } = default!;

  /// <summary>Holt oder setzt den ReadWrite-Button.</summary>
  [Display(Name = "ReadWrite", Description = "Alle Steuerelemente sind sichtbar und bedienbar.")]
  public string? ReadWrite { get; set; } = default!;

  /// <summary>Holt oder setzt den ReadOnly-Button.</summary>
  [Display(Name = "ReadOnly", Description = "Alle Steuerelemente sind sichtbar aber nicht bedienbar.")]
  public string? ReadOnly { get; set; } = default!;

  /// <summary>Holt oder setzt den Hidden-Button.</summary>
  [Display(Name = "Hidden", Description = "Alle Steuerelemente sind unsichtbar.")]
  public string? Hidden { get; set; } = default!;

  /// <summary>Holt oder setzt den Color0-Button.</summary>
  [Display(Name = "No Color", Description = "Alle Steuerelemente ohne Farbe versehen.")]
  public string? Color0 { get; set; } = default!;

  /// <summary>Holt oder setzt den Color1-Button.</summary>
  [Display(Name = "Color 1", Description = "Alle Steuerelemente mit Farbe 1 versehen.")]
  public string? Color1 { get; set; } = default!;

  /// <summary>Holt oder setzt den Color1-Button.</summary>
  [Display(Name = "Color 2", Description = "Alle Steuerelemente mit Farbe 2 versehen.")]
  public string? Color2 { get; set; } = default!;

  /// <summary>Holt oder setzt den Color1-Button.</summary>
  [Display(Name = "Color 3", Description = "Alle Steuerelemente mit Farbe 3 versehen.")]
  public string? Color3 { get; set; } = default!;

  /// <summary>Holt oder setzt den Mandatory-Button.</summary>
  [Display(Name = "Mandatory", Description = "Alle Steuerelemente sind verpflichtend.")]
  public string? Mandatory { get; set; } = default!;

  /// <summary>Holt oder setzt den Not Mandatory-Button.</summary>
  [Display(Name = "Not Mandatory", Description = "Kein Steuerelement ist verpflichtend.")]
  public string? MandatoryNot { get; set; } = default!;

  /// <summary>Holt oder setzt den Error-Button.</summary>
  [Display(Name = "Error", Description = "Alle Steuerelemente sind fehlerhaft.")]
  public string? Error { get; set; } = default!;

  /// <summary>Holt oder setzt den No Error-Button.</summary>
  [Display(Name = "No Error", Description = "Kein Steuerelement ist fehlerhaft.")]
  public string? ErrorNot { get; set; } = default!;

  /// <summary>Holt oder setzt den No Error-Button.</summary>
  [Display(Name = "Error Message", Description = "Alle Steuerelemente haben eine Fehlermeldung.")]
  public string? ErrorMessage { get; set; } = default!;

  /// <summary>Holt oder setzt den Horizontal-Button.</summary>
  [Display(Name = "Horizontal", Description = "Alle Steuerelemente werden im horizontalen Layout angezeigt.")]
  public string? Horizontal { get; set; } = default!;

  /// <summary>Holt oder setzt den Vertikal-Button.</summary>
  [Display(Name = "Vertikal", Description = "Alle Steuerelemente werden im vertikalen Layout angezeigt.")]
  public string? Vertikal { get; set; } = default!;

  /// <summary>Holt oder setzt den Schließen-Button.</summary>
  [Display(Name = "S_chließen", Description = "Formular schließen ohne Speichern.")]
  public string? Schliessen { get; set; } = default!;
}
