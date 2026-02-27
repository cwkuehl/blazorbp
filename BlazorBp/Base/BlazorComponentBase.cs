// <copyright file="BlazorComponentBase.cs" company="cwkuehl.de">
// Copyright (c) cwkuehl.de. All rights reserved.
// </copyright>

namespace BlazorBp.Base;

using BlazorBp.Models;
using CSBP.Services.Base;
using CSBP.Services.Base.Csv;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

/// <summary>
/// Basis-Klasse für alle Blazor-Formulare.
/// </summary>
public class BlazorComponentBase<T, V> : LayoutComponentBase
  where T : PageModelBase where V : TableRowModelBase
{
  /// <summary>
  /// Alle möglichen Formulare als Kopiervorlage für Use cases.
  /// </summary>
  private static readonly Dictionary<string, Formular> Formulare = new Dictionary<string, Formular>
  {
      { "Index", new Formular { Action = "index", Area = "", Name = "Startseite" } },
      { "AG100", new Formular { Action = "ag100", Area = "ag", Name = "Mandanten" } },
      // { "AG110", new Formular { Action = "ag110", Area = "ag", Name = "Mandant" } },
      { "AG200", new Formular { Action = "ag200", Area = "ag", Name = "Benutzer" } },
      { "AM100", new Formular { Action = "am100", Area = "am", Name = "Kennwort ändern" } },
      { "AM500", new Formular { Action = "am500", Area = "am", Name = "Einstellungen" } },
      { "DM100", new Formular { Action = "dm100", Area = "demo", Name = "Steuerelemente" } },
      { "DM200", new Formular { Action = "dm200", Area = "demo", Name = "Tabelle" } },
      { "FZ200", new Formular { Action = "fz200", Area = "fz", Name = "Fahrräder" } },
      { "FZ250", new Formular { Action = "fz250", Area = "fz", Name = "Fahrradstände" } },
      { "FZ700", new Formular { Action = "fz700", Area = "fz", Name = "Notizen" } },
      { "TB100", new Formular { Action = "tb100", Area = "tb", Name = "Tagebuch" } },
      { "TB200", new Formular { Action = "tb200", Area = "tb", Name = "Positionen" } },
};

  /// <summary>
  /// Standard-Model für Steuerelemente.
  /// </summary>
  [SupplyParameterFromForm]
  protected T Model { get; set; } = default!;

  /// <summary>Standard-Model für Tabellen.</summary>
  [SupplyParameterFromForm]
  public TableModelBase<V>? Table { get; set; } = default!;

  /// <summary>Betroffener Formular-Titel.</summary>
  protected string Title = "";

  /// <summary>Betroffener EditContext.</summary>
  protected EditContext? EditContext;

  /// <summary>Betroffener ValidationMessageStore.</summary>
  protected ValidationMessageStore? Messages;

  /// <summary>Navigation-Manager zum Navigieren.</summary>
  [Inject]
  protected NavigationManager Navigation { get; set; } = default!;

  /// <summary>Zugriff auf den HttpContext.</summary>
  [CascadingParameter]
  protected HttpContext HttpContext { get; set; } = default!;

  /// <summary>Id des Formulars muss immer im @page Attribut vorhanden sein, z.B. @page("demo/dm100/{Id?}").</summary>
  [Parameter]
  public string? Id { get; set; }

  /// <summary>Postback-Zustand: 0=kein Postback, 1=Postback vom Model, 2=Postback vom Table.</summary>
  protected int Postback = 0;

  /// <summary>Holt eine neue Instanz der ServiceDaten.</summary>
  protected ServiceDaten ServiceDaten
  {
    get
    {
      var ud = HttpContext?.Session.GetUserDaten();
      if (ud == null)
        OpenEmptyPage();
      return new ServiceDaten(ud);
    }
  }

  /// <summary>
  /// Redirect zur EmptyPage, z.B. nach Berechtigungsfehler oder zum Schließen eines Formulars.
  /// </summary>
  /// <returns>Immer null.</returns>
  ////[Authorize]
  ////[AcceptVerbs(HttpVerbs.Get)]
  protected object? OpenEmptyPage()
  {
    // Navigation.NavigateTo("/", new NavigationOptions { HistoryEntryState = "Navigation state" });
    Navigation.NavigateTo("/index");
    return null;
  }

  /// <summary>
  /// Öffnen eines Formulars mit Legen auf den Formular-Stapel.
  /// </summary>
  /// <param name="action">Name der Action, Formularname oder "" für aktuelles Formular.</param>
  /// <param name="id">ID bzw. Parameter des Formulars.</param>
  /// <param name="usecase">Soll ein neuer Use case erstellt werden, falls noch nicht offen?</param>
  /// <returns>ActionResult für Redirect.</returns>
  protected Formular OpenFormular(string action, string? id = null, bool usecase = false)
  {
    // Jede Formular-Instanz bekommt nach dem Aufruf eine ID (Guid) und ist somit eindeutig.
    var fz = HttpContext.Session?.GetFormState() ?? new FormularZustand();
    try
    {
      UseCase? uc = null;
      Formular? f = null;
      if (string.IsNullOrEmpty(action))
      {
        var uc0 = fz.UseCases.FirstOrDefault(a => a.Id == fz.AktuellId);
        if (uc0 != null)
          f = uc0.Formulare.LastOrDefault();
        if (f != null)
          return f;
      }
      if (!string.IsNullOrEmpty(id))
      {
        uc = fz.GetUseCaseAktion(action, id);
        if (uc != null)
        {
          f = uc.GetFormular(action, id);
          usecase = false;
        }
      }
      if (f == null)
      {
        if (!Formulare.TryGetValue(action, out f))
          Formulare.TryGetValue("Index", out f);
        if (string.IsNullOrEmpty(id))
          id = Guid.NewGuid().ToString(); // neue ID vergeben
        f = new Formular { Action = f?.Action, Area = f?.Area, Name = f?.Name, Id = id };
        if (string.IsNullOrEmpty(fz.AktuellId))
          usecase = true;
        else
          uc = fz.UseCases.FirstOrDefault(a => a.Id == fz.AktuellId);
        if (uc == null || usecase)
        {
          // Neuen Use case mit Formular erzeugen.
          uc = new UseCase { Id = action, Name = f.Name };
          var uc0 = fz.UseCases.FirstOrDefault(a => (a.Id ?? "").StartsWith(action));
          if (uc0 != null)
          {
            var i = 1;
            string? actionid = null;
            string? name = null;
            do
            {
              i++;
              actionid = $"{action} {i}";
              name = $"{f.Name} {i}";
              if (fz.UseCases.FirstOrDefault(a => a.Id == actionid) == null)
                break;
            }
            while (true);
            uc.Id = actionid;
            uc.Name = name;
          }
          fz.UseCases.Add(uc);
        }
        uc.Formulare.Add(f);
      }
      fz.AktuellId = uc?.Id;
      return f;
    }
    finally
    {
      HttpContext.Session?.SetFormState(fz);
    }
  }

  /// <summary>
  /// Öffnen eines Formulars.
  /// </summary>
  /// <param name="f">Betroffenes Formular oder aktuelles Formular, falls null.</param>
  /// <returns>Immer null.</returns>
  protected object? OpenFormular(Formular? f = null)
  {
    if (f == null)
    {
      var fz = HttpContext.Session?.GetFormState() ?? new FormularZustand();
      try
      {
        var uc = fz.UseCases.FirstOrDefault(a => a.Id == fz.AktuellId);
        if (uc != null)
          f = uc.Formulare.LastOrDefault();
      }
      finally
      {
        HttpContext.Session?.SetFormState(fz);
      }
    }
    if (f == null)
      return OpenEmptyPage();
    var parm = f.Init ? "?init=1" : $"";
    if (string.IsNullOrEmpty(f.Area))
      Navigation.NavigateTo($"/{f.Action}/{f.Id ?? ""}{parm}", true, true);
    else
    {
      // Redirect mit Id gibt immer Exception.
      Navigation.NavigateTo($"/{f.Area}/{f.Action}/{f.Id ?? ""}{parm}", true, true);
    }
    return null;
  }

  /// <summary>
  /// Schließen eines Formular mit Entfernen aus dem Formular-Stapel.
  /// </summary>
  /// <returns>Immer null.</returns>
  protected object? CloseFormular()
  {
    var fz = HttpContext.Session?.GetFormState() ?? new FormularZustand();
    try
    {
      var uc = string.IsNullOrEmpty(fz.AktuellId) ? null : fz.UseCases.FirstOrDefault(a => a.Id == fz.AktuellId);
      if (uc != null)
      {
        var f = uc.Formulare.LastOrDefault();
        if (f != null)
          uc.Formulare.Remove(f);
        if (uc.Formulare.Count <= 0)
        {
          fz.UseCases.Remove(uc);
          uc = fz.UseCases.LastOrDefault();
          fz.AktuellId = uc?.Id;
        }
        if (uc != null)
        {
          f = uc.Formulare.LastOrDefault();
          if (f != null)
          {
            f.Init = true; // Damit wird in OnInitializedFormular erkannt, dass das Formular schon existiert.
            return OpenFormular(f);
          }
        }
      }
      return OpenEmptyPage();
    }
    finally
    {
      HttpContext.Session?.SetFormState(fz);
    }
  }

  /// <summary>
  /// Lesen des Models eine Formular-Instanz.
  /// </summary>
  /// <param name="id">Betroffene ID.</param>
  protected T? ReadFormularModel(string id)
  {
    var form = GetType().Name;
    var model = HttpContext.Session?.GetObjectFromJson<T>($"{form}.Form.{id}");
    return model;
  }

  /// <summary>
  /// Lesen des Table-Models eine Formular-Instanz.
  /// </summary>
  /// <param name="id">Betroffene ID.</param>
  protected TableModelBase<V>? ReadFormularTableModel(string id)
  {
    var form = GetType().Name;
    var model = HttpContext.Session?.GetObjectFromJson<TableModelBase<V>>($"{form}.Table.{id}");
    return model;
  }

  /// <summary>
  /// Schreiben der Modelle eine Formular-Instanz.
  /// </summary>
  /// <param name="id">Betroffene ID.</param>
  /// <param name="model">Betroffenes Model.</param>
  /// <param name="tmodel">Betroffenes Table-Model.</param>
  protected void WriteFormularModel(string id, T? model, TableModelBase<V>? tmodel = null)
  {
    var form = GetType().Name;
    if (model != null)
      HttpContext.Session?.SetObjectAsJson($"{form}.Form.{id}", model);
    if (tmodel != null)
      HttpContext.Session?.SetObjectAsJson($"{form}.Table.{id}", tmodel);
  }

  /// <summary>
  /// Initialisierung des Formulars kann wegen EditContext nicht asynchron sein:
  /// -Formular-Manager braucht eine Id, ansonsten Redirect mit neuer Guid.
  /// -Lesen des Models aus der Session, ansonsten Initialisierung des Models.
  /// -Verarbeitung des Postbacks, weil danach gerendert wird.
  /// </summary>
  /// <param name="action">Name der Action, Formularname oder "" für aktuelles Formular.</param>
  /// <param name="id">Betroffene ID.</param>
  /// <param name="title">Betroffene Formular-Titel.</param>
  /// <param name="usecase">Soll ein neuer Use case erstellt werden, falls noch nicht offen?</param>
  /// <returns>Muss die Funktion OnInitialized wegen Redirect verlassen werden.</returns>
  protected bool OnInitializedFormular(string action, string title, string? id, bool usecase = false)
  {
    var f = OpenFormular(action, id, usecase);
    if (string.IsNullOrEmpty(id))
    {
      OpenFormular(f);
      return true;
    }
    Title = title;
    Postback = Model != null ? 1 : Table != null ? 2 : 0;
    T? model = null;
    TableModelBase<V>? table = null;
    if (Postback == 0 || Postback == 2)
    {
      model = ReadFormularModel(id); // Bei Model-Postback ist kein Read notwendig.
      if (!string.IsNullOrEmpty(model?.ModalId) && (HttpContext?.Request?.QueryString.HasValue ?? false)
        && HttpContext.Request.QueryString.Value?.Contains("init=1") == true) 
      {
        model.ModalId = null; // Unterformular nicht anzeigen.
      }
    }
    if (Postback == 0 || Postback == 1)
      table = ReadFormularTableModel(id); // Der Table-Postback wird im SortableTable verarbeitet.
    if (Postback == 1 && Model != null)
    {
      // Model-Postback.
      var fz = HttpContext.Session?.GetFormState() ?? new FormularZustand();
      try
      {
        var uc = fz.UseCases.FirstOrDefault(a => a.Id == fz.AktuellId);
        if (uc != null)
        {
          var f0 = uc.Formulare.LastOrDefault();
          if (f0 != null)
          {
            if (id != f0.Id)
              throw new Exception($"Falsche Formular-ID {f0.Id}: Erwartet {id}.");
            var model0 = ReadFormularModel(f0.Id ?? "");
            if (model0 != null)
              CopyNotPostbackData(Model, model0);
            WriteFormularModel(id, Model);
          }
        }
      }
      finally
      {
        HttpContext.Session?.SetFormState(fz);
        Model.GetSubmit(HttpContext.Request);
      }
    }
    Init(id, model, table);
    if (HttpContext.Session?.GetBoolean("Refresh") ?? false)
    {
      HttpContext.Session?.SetBoolean("Refresh", false);
      Refresh();
    }

#pragma warning disable CS8604
    EditContext = new(Model);
#pragma warning restore CS8604
    // #pragma warning disable CS0618
    // EditContext.EnableDataAnnotationsValidation();
    // #pragma warning disable CS0618
    Messages = new(EditContext);

    if (Model != null && Table != null)
    {
      // Öffnen und schließen eines modalen Dialogs.
      if (HttpContext.Request.Method == "POST")
      {
        var handler = HttpContext.Request.Query["handler"];
        var form = HttpContext.Request.Form["_handler"];
        var modalid = HttpContext.Request.Form["Table.ModalId"];
        InitModal(form, handler, modalid);
      }
    }
    if (Postback == 0)
    {
      if (Table != null) // && !(Table.Liste?.Any() ?? false))
      {
        if (Table.Liste == null)
        {
          TableData(Table, Messages);
          var sr = Table.SelectedRow ?? 0;
          var row = sr > 0 && Table.Liste != null && Table.Liste.Count >= sr ? Table.Liste[sr - 1] : null;
          OnRowChanged(row, sr, Messages);
        }
      }
      WriteFormularModel(Model?.Nr ?? "0", Model, Table); // Nach Init beides schreiben.
    }
    return false;
  }

  /// <summary>
  /// Kopieren von Daten im Model, die nicht über Postback gesendet werden.
  /// Diese Funktion sollte überschrieben werden, wenn es solche Daten gibt.
  /// </summary>
  /// <param name="model">Betroffenes Model, das geändert werden soll.</param>
  /// <param name="model0">Model, aus dem kopiert werden soll.</param>
  protected virtual void CopyNotPostbackData(T model, T model0)
  {
  }

  /// <summary>
  /// Setzen von readonly, hidden, error.
  /// Diese Funktion sollte überschrieben werden.
  /// </summary>
  protected virtual void SetRhe()
  {
  }

  /// <summary>
  /// Initialisierung des Models.
  /// </summary>
  /// <param name="id">Betroffene Id.</param>
  /// <param name="model">Evtl. gelesenes Model.</param>
  /// <param name="table">Evtl. gelesenes Table-Model.</param>
  protected virtual void Init(string? id, T? model = null, TableModelBase<V>? table = null)
  {
  }

  /// <summary>
  /// Aktualisierung nach Undo/Redo.
  /// </summary>
  protected virtual void Refresh()
  {
  }

  /// <summary>
  /// Bereitstellen der Tabellen-Daten mit Berücksichtigung der Filterung, Sortierung und Paginierung.
  /// Diese Funktion sollte in Formularen mit Tabellen überschrieben werden.
  /// </summary>
  /// <param name="m"></param>
  /// <returns>Tabellen-Daten als Liste.</returns>
  /// <param name="Messages">Betroffene Fehlermeldungen.</param>
  protected virtual List<V> TableData(TableModelBase<V>? m, ValidationMessageStore? Messages)
  {
    return new List<V>();
  }

  /// <summary>
  /// Verarbeitung bei geänderter Zeile.
  /// </summary>
  /// <param name="row">Betroffene Tabellen-Zeile-Daten.</param>
  /// <param name="selrow">Betroffene Tabellen-Zeile-Nummer.</param>
  /// <param name="messages">Betroffene Fehlermeldungen.</param>
  /// <returns>True, wenn am Model etwas geändert wurde, sonst false.</returns>
  protected virtual bool OnRowChanged(V? row, int selrow, ValidationMessageStore? messages)
  {
    return false;
  }

  /// <summary>
  /// Dialog wird über Tabellen-Aktion informiert und kann für den Aufruf eines modalen Dialogs benutzt werden.
  /// </summary>
  /// <param name="form">Betroffenes Postback-Formular.</param>
  /// <param name="handler">Handler aus Tabellen-Aktion.</param>
  /// <param name="id">Id aus Tabellen-Aktion.</param>
  public virtual void InitModal(string? form, string? handler, string? id)
  {
  }

  /// <summary>
  /// Verarbeitung der Tabellen-Aktionen.
  /// </summary>
  /// <param name="table">Betroffene Tabellen-Daten.</param>
  /// <param name="messages">Betroffene Fehlermeldungen.</param>
  /// <param name="rowchange">True, wenn die Zeile geändert wurde, sonst false.</param>
  public void OnTable(TableModelBase<V> table, ValidationMessageStore? messages, bool rowchange = true)
  {
    // if (table == null)
    // {
    //   SetRhe();
    //   return;
    // }
    var handler = table.Handler;
    var selpage = table.SelectedPage;
    var selrow = table.SelectedRow;
    if (handler == "Table_First")
    {
      table.SelectedPage = 1;
      table.SelectedRow = 1;
    }
    if (handler == "Table_Prev" && table.SelectedPage > 1)
    {
      table.SelectedPage--;
    }
    if (handler == "Table_Next")
    {
      table.SelectedPage++;
    }
    var last = handler == "Table_Last";
    if (last)
    {
      last = true;
      table.SelectedPage = table.PageCount;
    }
    if (handler == "Table_All")
      table.Search = "%%";
    // if (!string.IsNullOrEmpty(handler))
    // {
    //   WriteFormularModel(table.Nr ?? "", null, table);
    //   Navigation.NavigateTo(HttpContext.Request.Path, true, true); // Query-Parameter handler entfernen.
    // }
    table.Liste = TableData(table, messages);
    if (table.SelectedPage > table.PageCount)
    {
      table.SelectedPage = table.PageCount;
      if (string.IsNullOrEmpty(handler))
        table.Liste = TableData(table, messages);
    }
    if (last || table.SelectedRow > (table.Liste?.Count ?? 0))
      table.SelectedRow = table.Liste?.Count ?? 0;
    if (table.SelectedRow < 1 && (table.Liste?.Count ?? 0) > 0)
      table.SelectedRow = 1;
    if (rowchange || selpage != table.SelectedPage || selrow != table.SelectedRow)
    {
      var sr = table.SelectedRow ?? 0;
      var row = sr > 0 && table.Liste != null && table.Liste.Count >= sr ? table.Liste[sr - 1] : null;
      if (OnRowChanged(row, sr, messages))
        WriteFormularModel(Model?.Nr ?? "0", Model, null);
    }
    if (handler == "Table_Export")
    {
      var csv = new CsvWriter();
      csv.AddCsvLine(["1", "2", "3"]);
      csv.AddCsvLine(["4", "5", "6"]);
      //csv.WriteFile();
    }
    WriteFormularModel(table.Nr ?? "", null, table);
    SetRhe();
    if (!string.IsNullOrEmpty(handler) && handler != "Table_New" && handler != "Table_Edit" && handler != "Table_Delete" && handler != "Table_Copy")
      Navigation.NavigateTo(HttpContext.Request.Path, true, true); // Query-Parameter handler entfernen.
  }

  /// <summary>
  /// Speichern aller Upload-Dateien eines input-Elements.
  /// </summary>
  /// <param name="fileprefix">Erster Teil des Dateinamens.</param>
  /// <param name="fileid">Betroffene ID des input-Elements kann null sein.</param>
  /// <returns>Liste der gespeicherten Dateinamen.</returns>
  protected List<string> SaveUploadFiles(string fileprefix, string? fileid = null)
  {
    var fliste = new List<string>();
    var folderPath = System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), "wwwroot", "uploads");
    Directory.CreateDirectory(folderPath);
    var files = HttpContext.Request?.Form?.Files;
    if (files != null && files.Count > 0)
    {
      foreach (var f in files)
      {
        if (fileid != null && f.Name != fileid)
          continue; // Andere Dateien ignorieren.
        var extension = Path.GetExtension(f.FileName);
        var fn = Functions.GetDateiname(fileprefix, true, true, extension);
        var filePath = Path.Combine(folderPath, fn);
        try
        {
          using (var fileStream = new FileStream(filePath, FileMode.Create))
          {
            using var uploadedFileStream = f.OpenReadStream();
            uploadedFileStream.CopyTo(fileStream);
            fliste.Add(filePath);
          }
        }
        catch (Exception ex)
        {
          // Console.WriteLine(ex.Message);
          Messages?.Add(() => Model, ex.Message);
        }
      }
    }
    return fliste;
  }

  /// <summary>
  /// Extracts possible errors from service result.
  /// </summary>
  /// <param name="r">Affected service result.</param>
  /// <param name="messages">Affected messages store.</param>
  /// <typeparam name="T1">Affected result type.</typeparam>
  /// <returns>Result of service result.</returns>
  protected T1? Get<T1>(ServiceErgebnis<T1> r, ValidationMessageStore? messages = null)
  {
    if (r == null)
      return default;
    if (!r.Ok)
    {
      if (messages == null)
        messages = Messages;
      if (messages != null)
        foreach (var e in r.Errors)
          messages.Add(() => Model, e.MessageText);
    }
    return r.Ergebnis;
  }

  /// <summary>
  /// Extracts possible errors from service result.
  /// </summary>
  /// <param name="r">Affected service result.</param>
  /// <param name="messages">Affected messages store.</param>
  /// <returns>Is it OK or not.</returns>
  protected bool Get(ServiceErgebnis r, ValidationMessageStore? messages = null)
  {
    if (r == null)
      return false;
    if (r.Ok)
      return true;
    if (messages == null)
      messages = Messages;
    if (messages != null)
      foreach (var e in r.Errors)
        messages.Add(() => Model, e.MessageText);
    return false;
  }

  /// <summary>
  /// Inserts empty entry at the beginning of the list.
  /// </summary>
  /// <param name="l">Affected list.</param>
  /// <returns>List with empty entry.</returns>
  protected List<ListItem>? InsertEmpty(List<ListItem>? l)
  {
    if (l != null)
      l.Insert(0, new ListItem("", ""));
    return l;
   }

  /// <summary>
  /// Gehört der Submit zu einem Datum oder m, h, p?
  /// </summary>
  /// <param name="submit">Betroffener Submit.</param>
  /// <param name="valueSubmit">Submit-Value für Datum.</param>
  /// <param name="date">Betroffenes Datum.</param>
  /// <param name="result">Betroffenes Datum oder geändert mit m, h ,p.</param>
  /// <returns>True, wenn Submit zu Datum oder m, h, p gehört.</returns>
  protected bool IsDateMhp(string? submit, string? valueSubmit, DateTime? date, out DateTime? result)
  {
    result = date;
    if (string.IsNullOrEmpty(submit) || string.IsNullOrEmpty(valueSubmit))
      return false;
    if (submit == valueSubmit)
      return true;
    if (submit == $"{valueSubmit}m")
    {
      result = date?.AddDays(-1);
      return true;
    }
    if (submit == $"{valueSubmit}h")    {
      result = DateTime.Today;
      return true;
    }
    if (submit == $"{valueSubmit}p")
    {
      result = date?.AddDays(1);
      return true;
    }
    return false;
  }
}

/// <summary>
/// Statische Hilfsfunktionen.
/// </summary>
public static class BlazorComponentBaseStatic
{
  /// <summary>
  /// Lesen des Table-Models einer Formular-Instanz.
  /// </summary>
  /// <param name="session">Betroffene Session.</param>
  /// <param name="form">Betroffener Formularname.</param>
  /// <param name="id">Betroffene ID.</param>
  public static U? ReadFormularTableModel<U>(ISession session, string form, string id)
  {
    var model = session.GetObjectFromJson<U>($"{form}.Table.{id}");
    return model;
  }

  /// <summary>
  /// Lesen des Form-Models einer Formular-Instanz.
  /// </summary>
  /// <param name="session">Betroffene Session.</param>
  /// <param name="form">Betroffener Formularname.</param>
  /// <param name="id">Betroffene ID.</param>
  public static U? ReadFormularFormModel<U>(ISession session, string form, string id)
  {
    var model = session.GetObjectFromJson<U>($"{form}.Form.{id}");
    return model;
  }
}
