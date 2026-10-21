// <copyright file="TableModelBase.cs" company="cwkuehl.de">
// Copyright (c) cwkuehl.de. All rights reserved.
// </copyright>

namespace BlazorSpa.Core.Base;

using System.ComponentModel.DataAnnotations;
using System.Reflection;
using BlazorSpa.Base;
using BlazorSpa.Base.Models;
using BlazorSpa.Core.Models;
using Microsoft.AspNetCore.Http;

/// <summary>
/// Basis-Klasse für alle Table-Models zur Behandlung von Postbacks in Tabellen.
/// </summary>
/// <typeparam name="T">Typ der Zeilen-Models.</typeparam>
[Serializable]
public class TableModelBase<T>
{
  /// <summary>Holt oder setzt die Liste für die Anzahl der Zeilen pro Seite.</summary>
  private static List<ListItem>? standardAuswahlRowsPerPage = new List<ListItem>
  {
    new("5", "5"),
    new("10", "10"),
    new("15", "15"),
    new("20", "20"),
  };

  /// <summary>Holt oder setzt die eindeutige Nummer des Models.</summary>
  public string? Nr { get; set; } = default;

  /// <summary>Holt oder setzt die Nummer der aktuell angezeigten Seite.</summary>
  [Display(Name = "Seite", Description = "Nr. der aktuellen Seite")]
  public int? SelectedPage { get; set; } = default;

  /// <summary>Holt oder setzt die Anzahl der Seiten.</summary>
  [Display(Name = "Seitenanzahl", Description = "Anzahl der Seiten")]
  public int? PageCount { get; set; } = default;

  /// <summary>Holt oder setzt die Anzahl der Zeilen pro Seite.</summary>
  [Display(Name = "Datensätze pro Seite", Description = "Anzahl der Datensätze pro Seite")]
  public int? RowsPerPage { get; set; } = default;

  /// <summary>Holt oder setzt die Liste für die Anzahl der Zeilen pro Seite.</summary>
  public List<ListItem>? AuswahlRowsPerPage
  {
    get { return standardAuswahlRowsPerPage; }
  }

  /// <summary>Holt oder setzt die Spalte, die zum Sortieren der Daten verwendet wird.</summary>
  [Display(Name = "Sortierung", Description = "Spalte zum Sortieren")]
  public string? SortColumn { get; set; } = default;

  /// <summary>Holt oder setzt die Spalte, die zum Sortieren der Daten verwendet wird.</summary>
  [Display(Name = "Aktuelle Zeile", Description = "Ausgewählte Zeile")]
  public int? SelectedRow { get; set; } = default;

  /// <summary>Holt oder setzt die Spalte, die zum Sortieren der Daten verwendet wird.</summary>
  [Display(Name = "Ausgewählte Zeilen", Description = "Ausgewählte Zeilen")]
  public List<int>? SelectedRows { get; set; } = default!;

  /// <summary>Holt oder setzt die anzuzeigenden Spalten.</summary>
  [Display(Name = "Spalten", Description = "Anzuzeigende Spalten")]
  public string VisibleColumns { get; set; } = "1";

  /// <summary>Holt oder setzt die Sucheingabe.</summary>
  [Display(Name = "_Suche", Description = "Suchen nach Text in Tabelle, Platzhalter % und _")]
  public string? Search { get; set; } = "%%";

  /// <summary>Holt oder setzt die letzte Benutzer-Aktion.</summary>
  public string? Handler { get; set; } = default;

  /// <summary>Holt oder setzt die Id für modalen Dialogs.</summary>
  public string? ModalId { get; set; }

  /// <summary>Holt oder setzt die Id für nicht modalen Dialogs.</summary>
  public string? NoModalId { get; set; }

  /// <summary>Holt oder setzt die aktuelle Liste.</summary>
  public List<T>? Liste { get; set; } = default!;

  /// <summary>Holt oder setzt die Summenzeile unter der Liste.</summary>
  public string? Essence { get; set; } = default;

  /// <summary>Holt oder setzt das ReadModel.</summary>
  public TableReadModel ReadModel
  {
    get => new TableReadModel
    {
      SelectedPage = SelectedPage,
      PageCount = PageCount,
      RowsPerPage = RowsPerPage,
      SortColumn = SortColumn,
      Search = Funktionen.GetSuche(Search),
    };
  }

  /// <summary>Lesen der Submit-auslösenden Schaltfläche und des Submit-Controls aus dem Request.</summary>
  /// <param name="request">Betroffener Request.</param>
  /// <param name="handler">Betroffener Handler bzw. Formname.</param>
  /// <param name="columns">Liste der Spalten.</param>///
  /// <returns>True, wenn ein Zeilenwechsel erkannt wurde, sonst false.</returns>
  public bool GetSubmit(HttpRequest? request, string? handler = null, List<Column>? columns = null)
  {
    if (request == null)
      return false;
    Handler = request.Query["handler"];
    if (request.Method == "POST")
    {
      if (handler != null && handler != request.Form["_handler"])
        return false;
      if (request.Form["SubmitControl"] == nameof(Search))
        Handler = null;
      if (columns != null)
      {
        VisibleColumns = "";
        for (int i = 0; i < columns.Count; i++)
        {
          columns[i].Visible = Funktionen.ToBool(request.Form[$"Table.Column{i}"]) ?? false;
          VisibleColumns += Funktionen.Iif(columns[i].Visible, "1", "0");
        }
      }
      SortColumn = GetLastValue(request.Form["Table.SortColumn"]);
      var sr0 = SelectedRow;
      SelectedRow = Funktionen.ToNullableInt32(GetLastValue(request.Form["Table.SelectedRow"])) ?? -1;
      ModalId = GetLastValue(request.Form["Table.ModalId"]);
      if (SelectedRow != sr0)
        return true;
    }
    return false;
  }

  /// <summary>
  /// Liefert den letzten Wert eines komma-getrennten Strings.
  /// </summary>
  /// <param name="s">Betroffener String.</param>
  /// <returns>Letzter Wert.</returns>
  private static string? GetLastValue(string? s)
  {
    if (s == null)
      return null;
    string[] values = s.Split(',');
    if (values.Length > 0)
      return values[values.Length - 1];
    return null;
  }
}
