// <copyright file="FZ700ModalModel.cs" company="cwkuehl.de">
// Copyright (c) cwkuehl.de. All rights reserved.
// </copyright>

namespace BlazorBp.Models.Fz;

using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using BlazorBp.Base;
using CSBP.Services.Apis.Models;
using CSBP.Services.Base;
using static BlazorBp.Base.DialogTypeEnum;

/// <summary>
/// Model-Klasse für das modale Formular FZ700 Notizen.
/// </summary>
[Serializable]
public class FZ700ModalModel : PageModelBase
{
  /// <summary>Holt oder setzt Nr..</summary>
  [Display(Name = "Nr.", Description = "Notiz-Nr.")]
  //// [Required(ErrorMessage = "Nr. muss angegeben werden.")]
  public string? Nummer { get; set; }

  /// <summary>Holt oder setzt Thema.</summary>
  [Display(Name = "_Thema", Description = "Thema")]
  [Required(ErrorMessage = "Thema muss angegeben werden.")]
  public string? Thema { get; set; }

  /// <summary>Holt oder setzt Notiz.</summary>
  [Display(Name = "_Notiz", Description = "Unstrukturierte Notizen.")]
  public string? Notiz { get; set; }

  /// <summary>Holt oder setzt Tabelle.</summary>
  [Display(Name = "T_abelle", Description = "Notizen in Tabellen-Form (momentan nur lesen).")]
  public string? Tabelle { get; set; }

  /// <summary>Holt oder setzt Angelegt.</summary>
  [Display(Name = "Angelegt", Description = "Datum, Uhrzeit und Benutzer, der die Daten angelegt hat")]
  public string? Angelegt { get; set; }

  /// <summary>Holt oder setzt Geändert.</summary>
  [Display(Name = "Geändert", Description = "Datum, Uhrzeit und Benutzer, der die Daten geändert hat")]
  public string? Geaendert { get; set; }

  /// <summary>Holt oder setzt OK.</summary>
  [Display(Name = "_OK", Description = "Dialog mit Speichern schließen")]
  public string? Ok { get; set; }

  /// <summary>Holt oder setzt Abbrechen.</summary>
  [Display(Name = "Abbre_chen", Description = "Dialog ohne Speichern schließen")]
  public string? Abbrechen { get; set; }

  /// <summary>Kopiert die Werte in ein Model.</summary>
  /// <returns>Das kopierte Model.</returns>
  public FzNotiz To() => new()
  {
    Uid = Nummer,
    Thema = Thema,
    Notiz = Notiz,
  };

  /// <summary>Kopiert die Werte aus einem Model.</summary>
  /// <param name="m">Zu kopierendes Model.</param>
  public void From(FZ700TableRowModel m) =>
  (
    Nummer,
    Thema,
    Notiz,
    Tabelle,
    Angelegt,
    Geaendert
  ) = (
    m.Nummer,
    m.Thema,
    GetMemo(m.Notiz),
    GetTable(m.Notiz),
    ModelBase.FormatDateOf(m.AngelegtAm, m.AngelegtVon),
    ModelBase.FormatDateOf(m.GeaendertAm, m.GeaendertVon)
  );

  /// <summary>Setzt die Werte und Modi für das Model.</summary>
  /// <param name="mode">Betroffener Modus.</param>
  public void SetMhrf(DialogTypeEnum mode)
  {
    if (mode == New)
    {
      Nummer = "";
      Thema = null;
      Notiz = null;
      Tabelle = null;
    }
    SetMandatoryHiddenReadonly(nameof(Nummer), true, false, true, false);
    SetMandatoryHiddenReadonly(nameof(Thema), true, false, mode == Delete, mode == New);
    SetMandatoryHiddenReadonly(nameof(Notiz), false, false, mode == Delete, mode == Edit);
    SetMandatoryHiddenReadonly(nameof(Tabelle), false, false, true, false);
    SetMandatoryHiddenReadonly(nameof(Angelegt), false, mode == New, true);
    SetMandatoryHiddenReadonly(nameof(Geaendert), false, mode == New, true);
    SetMandatoryHiddenReadonly(nameof(Ok), false, false, false, mode == Delete);
  }

  /// <summary>
  /// Initialize Memo.
  /// </summary>
  /// <returns>Memo as XML string.</returns>
  private static string InitMemo()
  {
    var zeilen = 1;
    var spalten = 2;
    var teiler = 0;
    var doc = new XDocument(new XDeclaration("1.0", "UTF-8", null));
    var table = new XElement("tabelle", new XAttribute("spalten", $"{spalten - 2}"),
      new XAttribute("zeilen", $"{zeilen}"), new XAttribute("teiler", $"{teiler}"),
      new XAttribute("breite0", "50"), new XAttribute("hoehe0", "30")
    );
    doc.Add(table);
    using var sw = new StringWriter();
    using var tw = XmlWriter.Create(sw);
    doc.WriteTo(tw);
    tw.Flush();
    return sw.GetStringBuilder().ToString();
  }

  /// <summary>
  /// Gets memo from xml.
  /// </summary>
  /// <param name="xml">Affected xml.</param>
  /// <returns>Memo from xml.</returns>
  public static string? GetMemo(string? xml)
  {
    if (string.IsNullOrWhiteSpace(xml))
      xml = InitMemo();
    var doc = new XmlDocument();
    doc.Load(new StringReader(xml));
    var root = doc.DocumentElement;
    // var table = root.SelectSingleNode("/tabelle");
    // if (table != null)
    // {
    //   var teiler = Functions.ToInt32(table.Attributes["teiler"]?.Value);
    //   if (teiler > 0)
    //     splitpane.Position = teiler;
    //   var spalten = Math.Max(Functions.ToInt32(table.Attributes["spalten"]?.Value), 1);
    //   var zeilen = Math.Max(Functions.ToInt32(table.Attributes["zeilen"]?.Value), 1);
    //   var list = new List<string[]>();
    //   var flist = new Formulas();
    //   for (var i = 0; i < zeilen; i++)
    //   {
    //     var arr = new string[spalten + 2];
    //     arr[0] = Functions.ToString(i + 1);
    //     arr[1] = $"{i + 1:000}";
    //     var zellen = table.SelectNodes($"zelle[@y='{i}']");
    //     foreach (XmlElement z in zellen)
    //     {
    //       var x = Functions.ToInt32(z.Attributes["x"]?.Value);
    //       var formel = z.FirstChild?.InnerText;
    //       arr[x + 2] = formel;
    //       var f = Formula.Instance(formel, x, i); // Read formula.
    //       if (f != null)
    //         flist.List.Add(f);
    //     }
    //     list.Add(arr);
    //   }
    //   AddStringColumns(tabelle, spalten, DialogType != DialogTypeEnum.Delete, list, flist);
    // }
    var node = root?.SelectSingleNode("//tabelle//notiz");
    if (node != null)
      return node.InnerText;
    return null;
  }

  /// <summary>
  /// Gets table from xml.
  /// </summary>
  /// <param name="xml">Affected xml.</param>
  /// <returns>Table from xml.</returns>
  public static string? GetTable(string? xml)
  {
    if (string.IsNullOrWhiteSpace(xml))
      xml = InitMemo();
    var doc = new XmlDocument();
    doc.Load(new StringReader(xml));
    var root = doc.DocumentElement;
    var table = root?.SelectSingleNode("/tabelle");
    if (table != null)
    {
      // return table.InnerText;
      var spalten = Math.Max(Functions.ToInt32(table.Attributes?["spalten"]?.Value), 1);
      var zeilen = Math.Max(Functions.ToInt32(table.Attributes?["zeilen"]?.Value), 1);
      var list = new List<string?[]>();
      var flist = new Formulas();
      for (var i = 0; i < zeilen; i++)
      {
        var arr = new string?[spalten + 1];
        arr[0] = $"{i + 1:000}";
        var zellen = table.SelectNodes($"zelle[@y='{i}']");
        if (zellen != null)
          foreach (XmlElement z in zellen)
          {
            var x = Functions.ToInt32(z.Attributes["x"]?.Value);
            var formel = Functions.MakeBold(z.FirstChild?.InnerText, true);
            arr[x + Formula.Offset] = formel;
            var f = Formula.Instance(formel, x, i); // Read formula.
            if (f != null)
              flist.List.Add(f);
          }
        list.Add(arr);
      }
      flist.CalculateFormulas(list);
      var sb = new StringBuilder();
      foreach (var z in list)
      {
        sb.AppendLine(string.Join('|', z));
      }
      return sb.ToString();
    }
    return null;
  }

  // / <summary>
  // / Gets xml string from memo and TreeView model.
  // / </summary>
  // / <param name="model">Affected TreeView model.</param>
  // / <param name="flist">Affected list of formulas.</param>
  // / <param name="memo">Affected memo as string.</param>
  // / <param name="teiler">Affected divider value.</param>
  // / <returns>Xml string from memo and TreeView model.</returns>
  // private static string SetMemo(ITreeModel model, Formulas flist, string memo, int teiler)
  // {
  //   memo = memo.TrimNull();
  //   var spalten = model.NColumns;
  //   var zeilen = 1;
  //   if (model.GetIterFirst(out var it))
  //   {
  //     while (model.IterNext(ref it))
  //       zeilen++;
  //   }
  //   var doc = new XDocument(new XDeclaration("1.0", "UTF-8", null));
  //   var table = new XElement("tabelle", new XAttribute("spalten", $"{spalten - 2}"),
  //     new XAttribute("zeilen", $"{zeilen}"), new XAttribute("teiler", $"{teiler}"),
  //     new XAttribute("breite0", "50"), new XAttribute("hoehe0", "30")
  //   );
  //   doc.Add(table);
  //   if (model.GetIterFirst(out it))
  //   {
  //     var y = 0;
  //     do
  //     {
  //       for (var x = 0; x < spalten - 2; x++)
  //       {
  //         var f = flist?.Get(x + 2, y); // Save formula instead of value.
  //         var value = f?.Formula1;
  //         if (string.IsNullOrEmpty(value))
  //         {
  //           var v = default(GLib.Value);
  //           model.GetValue(it, x + 2, ref v);
  //           value = v.Val as string;
  //         }
  //         else if (f.Bold)
  //           value = Functions.MakeBold(value);
  //         if (!string.IsNullOrEmpty(value))
  //         {
  //           var e = new XElement("zelle", new XAttribute("x", $"{x}"), new XAttribute("y", $"{y}"), new XElement("formel", value));
  //           if (y == 0)
  //             e.Add(new XElement("format", new XAttribute("fett", "true")));
  //           table.Add(e);
  //         }
  //       }
  //       y++;
  //     }
  //     while (model.IterNext(ref it));
  //   }
  //   for (var y = 0; y < zeilen; y++)
  //   {
  //     table.Add(new XElement("zeile", new XAttribute("nr", $"{y}"), new XAttribute("hoehe", "30")));
  //   }
  //   for (var x = 0; x < spalten - 2; x++)
  //   {
  //     table.Add(new XElement("spalte", new XAttribute("nr", $"{x}"), new XAttribute("breite", "50")));
  //   }
  //   table.Add(new XElement("notiz", Functions.ToString(memo)));
  //   using var stringWriter = new StringWriter();
  //   using var xmlTextWriter = XmlWriter.Create(stringWriter);
  //   doc.WriteTo(xmlTextWriter);
  //   xmlTextWriter.Flush();
  //   return stringWriter.GetStringBuilder().ToString();
  // }
}
