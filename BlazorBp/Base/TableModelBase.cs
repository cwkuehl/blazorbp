// <copyright file="TableModelBase.cs" company="cwkuehl.de">
// Copyright (c) cwkuehl.de. All rights reserved.
// </copyright>

namespace BlazorBp.Base;

using System.ComponentModel.DataAnnotations;
using System.Reflection;
using BlazorBp.Models;
using CSBP.Services.Base;

/// <summary>
/// Basis-Klasse für alle Table-Models zur Behandlung von Postbacks in Tabellen.
/// </summary>
[Serializable]
public class TableModelBase<T>
{
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
    get { return StandardAuswahlRowsPerPage; }
  }

  /// <summary>Holt oder setzt die Liste für die Anzahl der Zeilen pro Seite.</summary>
  private static List<ListItem>? StandardAuswahlRowsPerPage = new List<ListItem>
  {
    new("5","5"),
    new("10","10"),
    new("15","15"),
    new("20","20"),
  };

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

  /// <summary>Holt oder setzt die aktuelle Liste.</summary>
  public List<T>? Liste { get; set; } = default!;

  /// <summary>Holt oder setzt das ReadModel.</summary>
  public TableReadModel ReadModel
  {
    get => new TableReadModel
    {
      SelectedPage = SelectedPage,
      PageCount = PageCount,
      RowsPerPage = RowsPerPage,
      SortColumn = SortColumn,
      Search = CsbpBase.GetSuche(Search),
    };
  }

  /// <summary>Lesen der Submit-auslösenden Schaltfläche und des Submit-Controls aus dem Request.</summary>
  /// <param name="Request">Betroffener Request.</param>
  /// <param name="handler">Betroffener Handler bzw. Formname.</param>
  /// <param name="columns">Liste der Spalten.</param>///
  public void GetSubmit(HttpRequest? Request, string? handler = null, List<Column>? columns = null)
  {
    if (Request == null)
      return;
    Handler = Request.Query["handler"];
    if (Request.Method == "POST")
    {
      if (handler != null && handler != Request.Form["_handler"])
        return;
      if (Request.Form["SubmitControl"] == nameof(Search))
        Handler = null;
      if (columns != null)
      {
        VisibleColumns = "";
        for (int i = 0; i < columns.Count; i++)
        {
          columns[i].Visible = Functions.ToBool(Request.Form[$"Table.Column{i}"]) ?? false;
          VisibleColumns += Functions.Iif(columns[i].Visible, "1", "0");
        }
      }
      SortColumn = GetLastValue(Request.Form["Table.SortColumn"]);
      SelectedRow = Functions.ToNullableInt32(GetLastValue(Request.Form["Table.SelectedRow"])) ?? -1;
      ModalId = GetLastValue(Request.Form["Table.ModalId"]);
    }
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

  /// <summary>
  /// Record für Spalten-Eigenschaften.
  /// </summary>
  //// public record Column(string Name, string SortName, string Label, string Title, string SortTitle, PropertyInfo Pi, bool Visible);
  public record Column
  {
    /// <summary>
    /// Record für Spalten-Eigenschaften.
    /// </summary>
    /// <param name="name">Name der Model-Spalte.</param>
    /// <param name="sortName">Name der Datenbank-Spalte zur Sortierung.</param>
    /// <param name="label">Angezeigte Bezeichnung der Spalte.</param>
    /// <param name="title">Tooltip des Wertes wird nicht verwendet.</param>
    /// <param name="sortTitle">Tooltip auf Sortier-Schaltfläche.</param>
    /// <param name="pi">Betroffene PropertyInfo im Model.</param>
    /// <param name="visible">Sichbarkeit der Spalte.</param>
    /// <returns></returns>
    public Column(string name, string sortName, string label, string title, string sortTitle, PropertyInfo pi, bool visible)
    {
      Name = name;
      SortName = sortName;
      Label = label;
      Title = title;
      SortTitle = sortTitle;
      Pi = pi;
      Visible = visible;
    }

    /// <summary>Holt oder setzt den Namen der Model-Spalte.</summary>
    public string Name { get; init; }

    /// <summary>Holt oder setzt den Namen der Datenbank-Spalte zur Sortierung.</summary>
    public string SortName { get; init; }

    /// <summary>Holt oder setzt die angezeigte Bezeichnung der Spalte.</summary>
    public string Label { get; init; }

    /// <summary>Holt oder setzt den Tooltip des Wertes (wird nicht verwendet).</summary>
    public string Title { get; init; }

    /// <summary>Holt oder setzt den Namen der Model-Spalte.</summary>
    public string SortTitle { get; init; }

    /// <summary>Holt oder setzt die PropertyInfo im Model.</summary>
    public PropertyInfo Pi { get; init; }

    /// <summary>Holt oder setzt die Sichtbarkeit der Spalte.</summary>
    public bool Visible { get; set; }
  };
