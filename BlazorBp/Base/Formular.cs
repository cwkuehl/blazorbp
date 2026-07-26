// <copyright file="Formular.cs" company="cwkuehl.de">
// Copyright (c) cwkuehl.de. All rights reserved.
// </copyright>

namespace BlazorBp.Base;

using CSBP.Services.Base;

/// <summary>
/// Die Klasse speichert ein Formular mit Controller und Action.
/// </summary>
[Serializable]
public class Formular
{
  /// <summary>Holt oder setzt den Namen des Formulars.</summary>
  public string? Name { get; set; }

  /// <summary>Holt oder setzt die betroffene Action.</summary>
  public string? Action { get; set; }

  /// <summary>Holt oder setzt die betroffene Area.</summary>
  public string? Area { get; set; }

  /// <summary>Holt oder setzt die betroffene ID.</summary>
  public string? Id { get; set; }

  /// <summary>Holt oder setzt einen Wert, ob das Formular initialisiert werden sollen.</summary>
  public bool Init { get; set; }

  /// <summary>
  /// Liefert die URL für das Formular.
  /// </summary>
  /// <param name="id">Gibt an, ob die ID mit übergeben werden soll.</param>
  /// <param name="close">Gibt an, ob die Action mit ID geschlossen werden soll.</param>
  /// <returns>URL für das Formular.</returns>
  internal string GetHref(bool id = false, bool close = false)
  {
    if (close)
      return $"/close/{Action}/{Id}";
    return $"{Functions.Iif(string.IsNullOrEmpty(Area), "", $"/{Area}")}/{Action}{Functions.Iif(string.IsNullOrEmpty(Id) || !id, "", $"/{Id}")}";
  }

  /// <summary>
  /// Liefert zum Table-Handler passenden DialogType.
  /// </summary>
  /// <param name="handler">Betroffener Table-Handler.</param>
  /// <returns>Passender DialogType.</returns>
  public static DialogTypeEnum GetTableDialogType(string? handler)
  {
    switch (handler)
    {
      case "Table_New":
      case "N":
        return DialogTypeEnum.New;
      case "Table_Edit":
      case "Form_Edit":
      case "E":
        return DialogTypeEnum.Edit;
      case "Table_Copy":
      case "C":
        return DialogTypeEnum.Copy;
      case "Table_Delete":
      case "D":
        return DialogTypeEnum.Delete;
      default:
        return DialogTypeEnum.Without;
    }
  }

  /// <summary>
  /// Liefert den Kurznamen für den DialogType.
  /// </summary>
  /// <param name="dt">Betroffener DialogType.</param>
  /// <returns>Passender Kurzname.</returns>
  public static string ToShortString(DialogTypeEnum dt)
  {
    switch (dt)
    {
      case DialogTypeEnum.New:
        return "N";
      case DialogTypeEnum.Edit:
        return "E";
      case DialogTypeEnum.Copy:
        return "C";
      case DialogTypeEnum.Delete:
        return "D";
      default:
        return "W";
    }
  }

  /// <summary>
  /// Liefert DialogType und Id.
  /// </summary>
  /// <param name="id0">Betroffene Id mit vorangestelltem Dialogtyp.</param>
  /// <returns>Passender DialogType und Id.</returns>
  public static (DialogTypeEnum dt, string id) GetDtId(string? id0)
  {
    var parts = (id0 ?? "").Split('_');
    var dt = GetTableDialogType(parts.Length > 0 ? parts[0] : null);
    var id = parts.Length > 1 ? parts[1] : "";
    return (dt, id);
  }

  /// <summary>
  /// Liefert Formulartitel für den DialogType.
  /// </summary>
  /// <param name="title">Betroffener Titel.</param>
  /// <param name="dt">Betroffener DialogType.</param>
  /// <returns>Passender Kurzname.</returns>
  public static string ToTitle(string title, DialogTypeEnum dt)
  {
    switch (dt)
    {
      case DialogTypeEnum.Edit:
        return $"{title} bearbeiten";
      case DialogTypeEnum.Copy:
        return $"{title} kopieren";
      case DialogTypeEnum.Delete:
        return $"{title} löschen";
      case DialogTypeEnum.Without:
        return title;
      default:
        return $"{title} erfassen";
    }
  }
}
