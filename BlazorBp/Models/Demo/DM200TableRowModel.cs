// <copyright file="DM200TableRowModel.cs" company="cwkuehl.de">
// Copyright (c) cwkuehl.de. All rights reserved.
// </copyright>

namespace BlazorBp.Models.Demo;

using System.ComponentModel.DataAnnotations;
using BlazorBp.Base;
using BlazorBp.Services.Models;

/// <summary>
/// Model-Klasse für eine Zeile in der Tabelle.
/// </summary>
[Serializable]
public class DM200TableRowModel : TableRowModelBase
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

  /// <summary>Kopiert die Werte in ein Model.</summary>
  public Objekt ToObjekt()
  {
    return new Objekt
    {
      Id = Nummer ?? 0,
      Name = Bezeichnung ?? "",
      Description = Beschreibung ?? "",
    };
  }

  /// <summary>Kopiert die Werte aus einem Model.</summary>
  /// <param name="b">Zu kopierendes Model.</param>
  public static DM200TableRowModel FromObjekt(Objekt b)
  {
    return new DM200TableRowModel
    {
      Nummer = b.Id,
      Bezeichnung = b.Name,
      Beschreibung = b.Description,
    };
  }
}
