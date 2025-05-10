// <copyright file="DemoService.cs" company="cwkuehl.de">
// Copyright (c) cwkuehl.de. All rights reserved.
// </copyright>

namespace BlazorBp.Services.Impl;

using BlazorBp.Services.Apis;
using BlazorBp.Services.Models;
using CSBP.Services.Base;
using CSBP.Services.Base.Csv;

public class DemoService : IDemoService
{
  private readonly List<Book> booklist = new();

  public Book? GetBook(int id)
  {
    return booklist.FirstOrDefault(a => a.Id == id);
  }

  public List<Book> GetBookList(string? filter = null)
  {
    if (string.IsNullOrEmpty(filter))
      return booklist;
    return booklist.Where(a => (a.Title ?? "").Contains(filter) || (a.Author ?? "").Contains(filter)).ToList();
  }

  public void SaveBook(Book book)
  {
    var b = booklist.FirstOrDefault(a => a.Id == book.Id);
    if (b != null)
      booklist.Remove(b);
    if (book.Id == 0)
      book.Id = booklist.Count <= 0 ? 1 : booklist.Max(a => a.Id) + 1;
    booklist.Add(book);
  }

  private readonly List<Objekt> objlist = new();

  public List<Objekt> GetObjektList(TableReadModel? rm = null)
  {
    if (rm == null)
      return new List<Objekt>();
    if (objlist.Count <= 0)
    {
      for (var i = 1; i <= 34; i++)
      {
        objlist.Add(new() { Id = i, Name = $"Objekt {i}", Description = $"Beschreibung {i}" });
      }
    }
    var l = objlist.ToList();
    if (CsbpBase.IsLike(rm.Search))
    {
      l = l.Where(a => Like(a.Name, rm.Search) || Like(a.Description, rm.Search)).ToList();
    }
    rm.PageCount = rm.RowsPerPage == 0 ? 1 : (int)Math.Ceiling(l.Count / (decimal)(rm.RowsPerPage ?? 0));
    SortList(l, rm.SortColumn);
    if (rm.NoPaging)
      return l;
    var page = Math.Max(1, rm.SelectedPage ?? 1) - 1;
    var rowsPerPage = Math.Max(1, rm.RowsPerPage ?? 1);
    var l2 = l.Skip(page * rowsPerPage).Take(rowsPerPage).ToList();
    return l2;
  }

  /// <summary>
  /// Speichern eines Objekts.
  /// </summary>
  /// <param name="o">Betroffenes Objekt.</param>
  /// <returns>Evtl. Fehlermeldungen.</returns>
  public ServiceErgebnis SaveObjekt(Objekt o)
  {
    var r = new ServiceErgebnis();
    if (o != null)
    {
      if (string.IsNullOrEmpty(o.Name))
      {
        r.Errors.Add(Message.New("M0000Die Bezeichnung des Objekts ist erforderlich."));
      }
      if (!r.Ok)
        return r;
      if (o.Id <= 0)
      {
        o.Id = objlist.Count <= 0 ? 1 : objlist.Max(a => a.Id) + 1;
      }
      else
      {
        var o2 = objlist.FirstOrDefault(a => a.Id == o.Id);
        if (o2 != null)
        {
          objlist.Remove(o2);
        }
      }
      objlist.Add(o);
    }
    return r;
  }

  /// <summary>
  /// Löschen eines Objekts.
  /// </summary>
  /// <param name="o">Betroffenes Objekt.</param>
  /// <returns>Evtl. Fehlermeldungen.</returns>
  public ServiceErgebnis DeleteObjekt(Objekt o)
  {
    var r = new ServiceErgebnis();
    if (o != null)
    {
      var o2 = objlist.FirstOrDefault(a => a.Id == o.Id);
      if (o2 != null)
      {
        objlist.Remove(o2);
      }
    }
    return r;
  }

  /// <summary>
  /// Sortieren einer Liste.
  /// </summary>
  /// <param name="l">Betroffene Liste.</param>
  /// <param name="sortColumn">Spalte zur Sortierung.</param>
  public static void SortList<T>(List<T> l, string? sortColumn) where T : new()
  {
    if (!string.IsNullOrEmpty(sortColumn))
    {
      var desc = sortColumn.EndsWith("-");
      var sort = sortColumn.TrimEnd(['-', '+']).TrimEnd('#');
      var l1 = l.AsQueryable().OrderBy(sort ?? "", desc).ToList();
      l.Clear();
      l.AddRange(l1);
    }
  }

  /// <summary>
  /// Liefert eine CSV-Datei mit allen Datensätze des betroffenen Formulars.
  /// </summary>
  /// <param name="page">Betroffenes Formular.</param>
  /// <param name="rm">Betroffene Filterung und Sortierung.</param>
  /// <returns>CSV-Datei als String.</returns>
  public string GetCsvString(string page, TableReadModel? rm = null)
  {
    if (string.IsNullOrEmpty(page) || rm == null)
      return "";
    rm.NoPaging = true;
    var cs = new CsvWriter();
    var l = GetObjektList(rm);
    cs.AddCsvLine(["Id", "Name", "Description"]);
    foreach (var o in l)
    {
      cs.AddCsvLine([Functions.ToString(o.Id), o.Name, o.Description]);
    }
    return cs.GetContent();
  }

  /// <summary>
  /// Speichern aller Objekte aus einer CSV-Datei.
  /// </summary>
  /// <param name="fn">Betroffener Dateiname der CSV-Datei.</param>
  /// <returns>Evtl. Fehlermeldungen.</returns>
  public ServiceErgebnis SaveObjektList(string fn)
  {
    var r = new ServiceErgebnis();
    try
    {
      if (!string.IsNullOrEmpty(fn))
      {
        // var cs = new CsvColumnReader(fn, ["Id", "Name", "Description"]);
        var cs = new CsvColumnReader(fn, ["Name", "Description", "Id"]);
        var l = new List<Objekt>();
        string[]? sp = null;
        while ((sp = cs.GetLineInColums()) != null)
        {
          var o = new Objekt
          {
            Id = Functions.ToInt32(sp[2]),
            Name = sp[0],
            Description = sp[1]
          };
          l.Add(o);
        }
        objlist.Clear();
        objlist.AddRange(l);
      }
    }
    catch (Exception ex)
    {
      r.Errors.Add(Message.Exception(ex));
    }
    return r;
  }

  /// <summary>
  /// Simulation of function like with StartsWith, Contains and EndsWith.
  /// </summary>
  /// <param name="s">Affected string.</param>
  /// <param name="exp">Affected like expression.</param>
  /// <returns>The string fulfills the like expression.</returns>
  protected static bool Like(string? s, string exp)
  {
    // The 'Like' method is not supported because the query has switched to client-evaluation.
    // This usually happens when the arguments to the method cannot be translated to server.
    // Rewrite the query to avoid client evaluation of arguments so that method can be translated to server.
    if (!CsbpBase.IsLike(exp))
      return true;
    if (string.IsNullOrEmpty(s))
      return false;
    var arr = exp.Split('%', StringSplitOptions.None);
    if (!string.IsNullOrEmpty(arr[0]))
      if (!s.StartsWith(arr[0], StringComparison.CurrentCultureIgnoreCase))
        return false;
    if (arr.Length > 1 && !string.IsNullOrEmpty(arr[^1]))
      if (!s.EndsWith(arr[^1], StringComparison.CurrentCultureIgnoreCase))
        return false;
    for (var i = 1; i < arr.Length - 1; i++)
    {
      if (!string.IsNullOrEmpty(arr[i]) && !s.Contains(arr[i], StringComparison.CurrentCultureIgnoreCase))
        return false;
    }
    return true;
  }
}
