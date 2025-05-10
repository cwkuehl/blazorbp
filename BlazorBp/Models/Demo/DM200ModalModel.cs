// <copyright file="DM200ModalModel.cs" company="cwkuehl.de">
// Copyright (c) cwkuehl.de. All rights reserved.
// </copyright>

namespace BlazorBp.Models.Demo;

using System.ComponentModel.DataAnnotations;
using BlazorBp.Base;
using BlazorBp.Services.Models;

/// <summary>
/// Model-Klasse für das modale Formular DM200 Tabelle.
/// </summary>
[Serializable]
public class DM200ModalModel : PageModelBase
{
  /// <summary>Holt oder setzt die Nummer.</summary>
  [Display(Name = "_Nr.", Description = "Die Nummer des Objekts kann nicht geändert werden.")]
  public int? Nummer { get; set; } = default!;

  /// <summary>Holt oder setzt die Bezeichnung.</summary>
  [Display(Name = "_Bezeichnung", Description = "Die Bezeichnung des Objekts ist Pflichtfeld.")]
  [Required(ErrorMessage = "Die Bezeichnung muss angegeben werden.")]
  public string? Bezeichnung { get; set; } = default!;

  /// <summary>Holt oder setzt die Beschreibung.</summary>
  [Display(Name = "Be_schreibung", Description = "Die Beschreibung des Objekts kann angegeben werden.")]
  // [Required(ErrorMessage = "Die Beschreibung muss angegeben werden.")]
  public string? Beschreibung { get; set; } = default!;

  /// <summary>Holt oder setzt den OK-Button.</summary>
  [Display(Name = "_OK", Description = "Formular schließen mit Speichern.")]
  public string? Ok { get; set; } = default!;

  /// <summary>Holt oder setzt den Schließen-Button.</summary>
  [Display(Name = "S_chließen", Description = "Formular schließen ohne Speichern.")]
  public string? Schliessen { get; set; } = default!;

  /// <summary>Kopiert die Werte aus einem Model.</summary>
  /// <param name="m">Zu kopierendes Model.</param>
  public void From(DM200TableRowModel m) => (Nummer, Bezeichnung, Beschreibung) = (m.Nummer, m.Bezeichnung, m.Beschreibung);

  /// <summary>Kopiert die Werte in ein Model.</summary>
  public Objekt ToObjekt() => new() { Id = Nummer ?? 0, Name = Bezeichnung ?? "", Description = Beschreibung ?? "" };
}
