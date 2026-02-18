// <copyright file="Generator.cs" company="cwkuehl.de">
// Copyright (c) cwkuehl.de. All rights reserved.
// </copyright>

using System.Diagnostics;
using System.Linq.Expressions;
using System.Text;
using System.Xml;
using CSBP.Services.Base;

namespace GladeBlazor;

[DebuggerDisplay("Name = {Name}, Type = {Type}, Text = {Text}, Tooltip = {Tooltip}, Left = {Left}, Top = {Top}")]
class Control
{
  public string Name { get; set; }
  public string Type { get; set; }
  public string Text { get; set; }
  public string Tooltip { get; set; }
  public int Left { get; set; } = -1;
  public int Top { get; set; } = -1;
  public int Width { get; set; } = -1;
  public int Height { get; set; } = -1;
  public int Sort { get; set; } = -1;
  public List<Control> Children { get; set; } = new();
  public Control? Parent { get; set; }

  public Control(string name, string type, string text, string tooltip, Control? parent)
  {
    Name = name;
    Type = type;
    Text = text;
    Tooltip = tooltip;
    Parent = parent;
  }
}

public class Generator
{
  /// <summary>
  /// Formulare in einem Blazor-Projekt erzeugen aus Glade-Dateien.
  /// </summary>
  /// <param name="file">Betroffene Glade-Datei.</param>
  /// <param name="modalfile">Betroffene Glade-Datei als modaler Dialog.</param>
  /// <param name="resfile">Betroffene Resource-Datei.</param>
  /// <param name="genpath">Betroffener Basis-Pfad zum Generieren.</param>
  public static void Generate(string file, string? modalfile, string resfile, string genpath)
  {
    var resxml = new XmlDocument();
    resxml.Load(resfile);
    var root = new Control("Root", "Form", "", "", null);
    Control? modalroot = null;
    ParseGlade(root, file, resxml);
    if (!string.IsNullOrEmpty(modalfile))
    {
      modalroot = new Control("ModalRoot", "Form", "", "", null);
      ParseGlade(modalroot, modalfile, resxml);
    }
    var area = Functions.ToFirstUpper(Directory.GetParent(file)?.Name, true);
    var form = Path.GetFileName(file).Left(5).ToUpper();
    var title = ReadResource(resxml, $"{form}.title") ?? form;
    var table = GetControls(root.Children, a => a.Type == "GtkTreeView").FirstOrDefault();
    var sorttable = "";
    List<Control>? rowcontrols = null;
    GenerateModel(genpath, root, area, form, title, "");
    GenerateModel(genpath, modalroot, area, form, title, "Modal");
    if (modalroot != null)
    {
      if (table == null)
        throw new Exception("Table fehlt.");
      rowcontrols = GenerateModel(genpath, modalroot, area, form, title, "TableRow");
      sorttable = GenerateTableModels(genpath, rowcontrols, area, form, title, table.Text);
    }
    GenerateRazor(genpath, root, modalroot, rowcontrols, area, form, title, sorttable);
  }

  /// <summary>
  /// Model erzeugen.
  /// </summary>
  /// <param name="genpath">Betroffener Basis-Pfad zum Generieren.</param>
  private static List<Control> GenerateModel(string genpath, Control? root, string area, string form, string title, string prefix)
  {
    if (root == null)
      return new();
    var table = false;
    var modal = false;
    var baseclass = "PageModelBase";
    var besch = "das ";
    if (prefix == "Modal")
    {
      modal = true;
      besch = "das modale ";
    }
    if (prefix == "TableRow")
    {
      table = true;
      baseclass = "TableRowModelBase";
      besch = "eine Zeile in der Tabelle von ";
    }
    var sb = new StringBuilder();
    var sbt = new StringBuilder();
    var sbt2 = new StringBuilder();
    var sbt3 = new StringBuilder();
    var sbt4 = new StringBuilder();
    var sbt5 = new StringBuilder();
    var sbt6 = new StringBuilder();
    var controls = GetControls(root.Children, a => !string.IsNullOrEmpty(a.Text) && a.Children.Count <= 0);
    if (table) // || modal)
    {
      controls = GetControls(controls, a => a.Name != "ok" && a.Name != "abbrechen" && a.Name != "angelegt" && a.Name != "geaendert");
      controls.Add(new Control("AngelegtAm", "GtkEntry", "Angelegt am", "Der Zeitpunkt der Anlage", root) { Sort = 1000 });
      controls.Add(new Control("AngelegtVon", "GtkEntry", "Angelegt von", "Die Benutzer-ID der Anlage", root) { Sort = 1001 });
      controls.Add(new Control("GeaendertAm", "GtkEntry", "Geändert am", "Der Zeitpunkt der letzten Änderung", root) { Sort = 1002 });
      controls.Add(new Control("GeaendertVon", "GtkEntry", "Geändert von", "Die Benutzer-ID der letzten Änderung", root) { Sort = 1003 });
    }
    controls = controls.OrderBy(a => a.Sort).ToList();
    var lastc = controls.Last();
    foreach (var c in controls)
    {
      if (IgnoreControl(c))
        continue;
      var n = c.Text.Replace("_", "");
      var typ = "string";
      if (c.Name == "AngelegtAm" || c.Name == "GeaendertAm")
        typ = "DateTime";
      sb.AppendLine($$"""
  /// <summary>Holt oder setzt {{n}}.</summary>
  [Display(Name = "{{c.Text}}", Description = "{{c.Tooltip}}")]
  //// [Required(ErrorMessage = "{{n}} muss angegeben werden.")]
  public {{typ}}? {{Functions.ToFirstUpper(c.Name)}} { get; set; }
""");
      if (c != lastc)
        sb.AppendLine();
      var na = c.Name.ToFirstUpper();
      if ((table || modal) && !IgnoreControl(c) && na != "Ok" && na != "Abbrechen" && !na.StartsWith("Angelegt") && !na.StartsWith("Geaendert"))
      {
        sbt.AppendLine($$"""
  /// <summary>Holt oder setzt die Spalte {{n}}.</summary>
  public string? {{Functions.ToFirstUpper(c.Name)}} { get; set; }

""");
        sbt2.AppendLine($$"""      {{Functions.ToFirstUpper(c.Name)}} = {{Functions.ToFirstUpper(c.Name)}},""");
        sbt3.AppendLine($$"""      {{Functions.ToFirstUpper(c.Name)}} = m.{{Functions.ToFirstUpper(c.Name)}},""");
        sbt4.AppendLine($$"""    {{Functions.ToFirstUpper(c.Name)}} = {{Functions.ToFirstUpper(c.Name)}},""");
        sbt5.AppendLine($$"""    {{Functions.ToFirstUpper(c.Name)}},""");
        sbt6.AppendLine($$"""    m.{{Functions.ToFirstUpper(c.Name)}},""");
      }
    }
    var model = $$"""
// <copyright file="{{form}}{{prefix}}Model.cs" company="cwkuehl.de">
// Copyright (c) cwkuehl.de. All rights reserved.
// </copyright>

namespace BlazorBp.Models.{{area}};

using System.ComponentModel.DataAnnotations;
using BlazorBp.Base;
using CSBP.Services.Base;
using static BlazorBp.Base.DialogTypeEnum;

""";
    if (table)
    {
      model += $$"""

/// <summary>
/// TodoModel-Klasse für Formular {{form}} {{title}}.
/// TODO Durch passendes Model ersetzen und löschen.
/// </summary>
[Serializable]
public class {{form}}TodoModel
{
{{sbt}}  /// <summary>Holt oder setzt die Spalte Angelegt_Am.</summary>
  public DateTime? Angelegt_Am { get; set; }

  /// <summary>Holt oder setzt die Spalte Angelegt_Von.</summary>
  public string? Angelegt_Von { get; set; }

  /// <summary>Holt oder setzt die Spalte Geaendert_Am.</summary>
  public DateTime? Geaendert_Am { get; set; }

  /// <summary>Holt oder setzt die Spalte Geaendert_Von.</summary>
  public string? Geaendert_Von { get; set; }
}

""";
    }
      model += $$"""

/// <summary>
/// Model-Klasse für {{besch}}Formular {{form}} {{title}}.
/// </summary>
[Serializable]
public class {{form}}{{prefix}}Model : {{baseclass}}
{
{{sb}}
""";
    if (table)
    {
      model += $$"""

  /// <summary>Kopiert die Werte in ein Model.</summary>
  /// <param name="daten">Service-Daten für den Datenbankzugriff.</param>
  public {{form}}TodoModel To(ServiceDaten daten)
  {
    return new {{form}}TodoModel
    {
      // TODO Mandant_Nr = daten.MandantNr,
{{sbt2}}      Angelegt_Am = AngelegtAm,
      Angelegt_Von = AngelegtVon,
      Geaendert_Am = GeaendertAm,
      Geaendert_Von = GeaendertVon,
    };
  }

  /// <summary>Kopiert die Werte aus einem Model.</summary>
  /// <param name="m">Zu kopierendes Model.</param>
  public static {{form}}TableRowModel From({{form}}TodoModel m)
  {
    return new {{form}}TableRowModel
    {
{{sbt3}}      AngelegtAm = m.Angelegt_Am,
      AngelegtVon = m.Angelegt_Von,
      GeaendertAm = m.Geaendert_Am,
      GeaendertVon = m.Geaendert_Von,
    };
  }
""";
    }
    else if (modal)
    {
      model += $$"""

  /// <summary>Kopiert die Werte in ein Model.</summary>
  /// <param name="daten">Service-Daten für den Datenbankzugriff.</param>
  /// <returns>Das kopierte Model.</returns>
  public {{form}}TodoModel To(ServiceDaten daten) => new()
  {
    // TODO Mandant_Nr = daten.MandantNr,
{{sbt4}}  };

  /// <summary>Kopiert die Werte aus einem Model.</summary>
  /// <param name="m">Zu kopierendes Model.</param>
  public void From({{form}}TableRowModel m) =>
  (
{{sbt5.ToString()[..^2]}}
    // TODO , Angelegt, Geaendert
  ) = (
{{sbt6.ToString()[..^2]}}
    // TODO , ModelBase.FormatDateOf(m.AngelegtAm, m.AngelegtVon), ModelBase.FormatDateOf(m.GeaendertAm, m.GeaendertVon)
  );

""";
    }
    if (!table)
    {
      model += $$"""

  /// <summary>Setzt die Werte und Modi für das Model.</summary>
  /// <param name="mode">Betroffener Modus.</param>
  public void SetMhrf(DialogTypeEnum mode)
  {
    if (mode == New || mode == Copy)
    {
      // TODO Nummer = "";
    }
    if (mode == New)
    {
      // TODO Thema = null;
    }
    // TODO SetMandatoryHiddenReadonly(nameof(Nummer), true, false, true, false);
    // SetMandatoryHiddenReadonly(nameof(Thema), true, false, mode == Delete, mode == New);
    // SetMandatoryHiddenReadonly(nameof(Angelegt), false, mode == New, true);
    // SetMandatoryHiddenReadonly(nameof(Geaendert), false, mode == New, true);
    // SetMandatoryHiddenReadonly(nameof(Ok), false, false, false, mode == Delete);
  }
""";
    }
    model += $$"""

}

""";
    var path = Path.Combine(genpath, "Models", area);
    Directory.CreateDirectory(path);
    File.WriteAllText(Path.Combine(path, $"{form}{prefix}Model.cs"), model);
    return controls;
  }

  /// <summary>
  /// TableModel erzeugen.
  /// </summary>
  /// <param name="genpath">Betroffener Basis-Pfad zum Generieren.</param>
  private static string GenerateTableModels(string genpath, List<Control> controls, string area, string form, string title, string table)
  {
    if (controls == null)
      return "";
    var sb = new StringBuilder();
    foreach (var c in controls)
    {
      var n = c.Text.Replace("_", "");
      if (!c.Name.StartsWith("Angelegt") && !c.Name.StartsWith("Geaendert"))
      {
        sb.AppendLine($$"""
    <TableColumn Field="@nameof({{form}}TableRowModel.{{Functions.ToFirstUpper(c.Name)}})" SortField="@nameof({{form}}TodoModel.{{Functions.ToFirstUpper(c.Name)}})" TModel="{{form}}Model" TRTable="{{form}}TableRowModel"/>
""");
      }
    }
    var sorttable = $$"""
<CascadingValue Value="this">
<SortableTable Table="Table" NoData="" FormName="{{form.ToLower()}}" EditAktion="true" DeleteAktion="true" CopyAktion="true" NewAktion="true" TModel="{{form}}Model" TRTable="{{form}}TableRowModel">
  <ChildContent>
{{sb}}    <TableColumn Field="@nameof({{form}}TableRowModel.AngelegtAm)" SortField="@nameof({{form}}TodoModel.Angelegt_Am)" TModel="{{form}}Model" TRTable="{{form}}TableRowModel"/>
    <TableColumn Field="@nameof({{form}}TableRowModel.AngelegtVon)" SortField="@nameof({{form}}TodoModel.Angelegt_Von)" TModel="{{form}}Model" TRTable="{{form}}TableRowModel"/>
    <TableColumn Field="@nameof({{form}}TableRowModel.GeaendertAm)" SortField="@nameof({{form}}TodoModel.Geaendert_Am)" TModel="{{form}}Model" TRTable="{{form}}TableRowModel"/>
    <TableColumn Field="@nameof({{form}}TableRowModel.GeaendertVon)" SortField="@nameof({{form}}TodoModel.Geaendert_Von)" TModel="{{form}}Model" TRTable="{{form}}TableRowModel"/>
  </ChildContent>
</SortableTable>
</CascadingValue>


""";
    return sorttable;
  }

  /// <summary>
  /// Soll Control bei Generierung ignoriert werden?
  /// </summary>
  /// <param name="c">Betroffenes Control.</param>
  /// <returns>True, wenn das Control nicht generiert werden soll.</returns>
  private static bool IgnoreControl(Control? c)
  {
    if (c == null || c.Type != "GtkButton")
      return false;
    var n = c.Name.ToLower();
    return n == "undo" || n == "redo" || n == "newaction" || n == "edit" || n == "delete" || n == "copy";
  }

  /// <summary>
  /// Razor-Datei erzeugen.
  /// </summary>
  /// <param name="genpath">Betroffener Basis-Pfad zum Generieren.</param>
  private static void GenerateRazor(string genpath, Control root, Control? modalroot, List<Control>? rowcontrols, string area, string form, string title, string sorttable)
  {
    var sbr = new StringBuilder();
    var sb = new StringBuilder();
    var sbm = new StringBuilder();
    var rowmodel = modalroot == null ? "TableRowModelBase" : $"{form}TableRowModel";
    var first = rowcontrols == null ? null : rowcontrols.First().Name.ToFirstUpper();

    sbr.Append($$"""
@page "/{{area.ToLower()}}/{{form.ToLower()}}/{id?}"
@inherits BlazorComponentBase<{{form}}Model, {{rowmodel}}>
@attribute [Authorize(Roles = "User, Admin, Superadmin")]

<SectionContent SectionName="title">@Title</SectionContent>
<PageTitle>@Title</PageTitle>

{{sorttable}}<EditForm Enhance method="post" EditContext="EditContext" OnValidSubmit="Submit" FormName="{{form.ToLower()}}">
  <DataAnnotationsValidator/>
  <ValidationSummary class="text-danger"/>
  <InputText type="hidden" @bind-Value="Model!.Nr"/>
  <input type="hidden" name="SubmitControl"/>
""");
    var controls = GetControls(root.Children, a => a.Children.Count <= 0);
    Control? parent = null;
    sb.AppendLine($"""    <div class="row ms-0 mt-1">""");
    foreach (var c in controls)
    {
      var n = c.Text.Replace("_", "");
      if (parent != c.Parent)
      {
        parent = c.Parent;
        sb.AppendLine($"  </div>");
        sb.AppendLine($"""  <div class="row ms-0 mt-1">""");
      }
      if (c.Type == "GtkButton")
      {
        if (!IgnoreControl(c))
          sb.AppendLine($$"""    <SubmitButton class="btn btn-secondary col-md-2 me-1" For="@(() => Model!.{{Functions.ToFirstUpper(c.Name)}})"/>""");
      }
      else
        sb.AppendLine($$"""    <LabelInputValid AutoPostback="" For="@(() => Model!.{{Functions.ToFirstUpper(c.Name)}})" VerticalColClass="form-group col-md-2"/>""");
    }
    sb.AppendLine($"  </div>");
    sbr.Append(sb);
    sbr.Append($$"""
  <!-- TODO btn-primary festlegen -->
</EditForm>


""");
    if (modalroot != null)
    {
      sbr.Append($$"""
@if (!string.IsNullOrEmpty(Model!.ModalId))
{
<div class="modal xxxfade" id="idmodal" tabindex="-1" role="dialog" aria-labelledby="lbldetails" aria-hidden="true">
  <div class="modal-dialog modal-lg" role="document">
    <div class="modal-content">
      <div class="modal-header">
        <h5 class="modal-title" id="lbldetails">TODO @Functions.Iif(Model?.ModalArt == "Table_Edit", "ändern", Functions.Iif(Model?.ModalArt == "Table_Delete", "löschen", Functions.Iif(Model?.ModalArt == "Table_Copy", "kopieren", "erfassen")))</h5>
        <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Schließen"></button>
      </div>
      <div class="modal-body">
        <EditForm Enhance method="post" EditContext="ModalEditContext" OnValidSubmit="Submit" FormName="{{form.ToLower()}}modal">
          <DataAnnotationsValidator/>
          <ValidationSummary class="text-danger"/>
          <InputText type="hidden" @bind-Value="ModalModel!.Nr"/>
          <InputText type="hidden" @bind-Value="ModalModel!.ReadonlyHiddenError"/>
          <input type="hidden" name="SubmitControl"/>

""");
      controls = GetControls(modalroot.Children, a => a.Children.Count <= 0 && a.Type != "GtkTreeView");
      parent = null;
      sb.Length = 0;
      sb.AppendLine($"""
        <div class="row ms-0 mt-1">
""");
      foreach (var c in controls)
      {
        var n = c.Text.Replace("_", "");
        if (parent != c.Parent)
        {
          parent = c.Parent;
          sb.AppendLine($"          </div>");
          sb.AppendLine($"""          <div class="row ms-0 mt-1">""");
        }
        if (c.Type == "GtkButton")
        {
          if (c.Name == "abbrechen")
            sb.AppendLine($$"""            <button type="button" class="btn btn-secondary col-md-2 me-1" data-bs-dismiss="modal">Abbrechen</button>""");
          else
            sb.AppendLine($$"""            <SubmitButton class="btn btn-{{Functions.Iif(c.Name == "ok", "primary", "secondary")}} col-md-2 me-1" For="@(() => ModalModel!.{{Functions.ToFirstUpper(c.Name)}})"/>""");
        }
        else
        {
          sb.AppendLine($$"""            <LabelInputValid AutoPostback="" For="@(() => ModalModel!.{{Functions.ToFirstUpper(c.Name)}})" VerticalColClass="form-group col-md-2"/>""");
          if (c.Name != "angelegt" && c.Name != "geaendert")
            sbm.AppendLine($$"""       {{Functions.ToFirstUpper(c.Name)}} = "{{Functions.ToFirstUpper(c.Name)}}1",""");
        }
      }
      sb.AppendLine($"          </div>");
      sbr.Append(sb);
      sbr.Append($$"""
        </EditForm>
      </div>
    </div>
  </div>
</div>
}
else
{
  <EditForm Enhance method="post" EditContext="ModalEditContext" FormName="{{form.ToLower()}}modal">
  </EditForm>
}


""");
    }
    sbr.Append($$"""
@code {

""");
    if (modalroot != null)
    {
      sbr.Append($$"""
  [SupplyParameterFromForm]
  protected {{form}}ModalModel ModalModel { get; set; } = default!;

  /// <summary>Betroffener EditContext.</summary>
  protected EditContext? ModalEditContext;

  /// <summary>Betroffener ValidationMessageStore.</summary>
  protected ValidationMessageStore? ModalMessages;

""");
    }
    sbr.Append($$"""
  /// <summary>True, wenn EditContext ohne Fehler.</summary>
  private bool valid;

  /// <summary>
  /// Initialisierung des Models.
  /// </summary>
  /// <param name="id">Betroffene Id.</param>
  /// <param name="model">Evtl. gelesenes Model.</param>
  /// <param name="table">Evtl. gelesenes Table-Model.</param>
  protected override void Init(string? id, {{form}}Model? model = null, TableModelBase<{{rowmodel}}>? table = null)
  {
    if (model != null)
      Model = model;
    if (Model == null)
    {
      var daten = ServiceDaten;
      Model = new {{form}}Model
      {
        Nr = id,
        // TODO Mandant = daten.MandantNr,
      };
      Model.SetMhrf(DialogTypeEnum.New);
    }
    Model.Nr = id;

""");
    if (modalroot != null)
    {
      sbr.Append($$"""
    if (table != null)
      Table = table;
    if (Table == null)
      Table = new TableModelBase<{{rowmodel}}>
      {
        SelectedPage = 1,
        RowsPerPage = 10,
        SelectedRow = 1,
        SortColumn = $"{nameof({{form}}TodoModel.{{first}})}#+",
      };
    Table.Nr = id;

""");
    }
    if (modalroot != null)
    {
      sbr.Append($$"""

    if (ModalModel == null)
      ModalModel = new {{form}}ModalModel
      {
        // TODO Nummer = "1",
        // Beschreibung = null,
      };
    ModalModel.Nr = id;
      #pragma warning disable CS8604
    ModalEditContext = new(ModalModel);
    #pragma warning restore CS8604
    // #pragma warning disable CS0618
    // ModalEditContext.EnableDataAnnotationsValidation();
    // #pragma warning disable CS0618
    ModalMessages = new(ModalEditContext);

""");
    }
    sbr.Append($$"""
  }

  /// <summary>
  /// Initialisierung des Formulars kann wegen EditContext nicht asynchron sein:
  /// -Formular-Manager braucht eine Id, ansonsten Redirect mit neuer Guid.
  /// -Lesen des Models aus der Session, ansonsten Initialisierung des Models.
  /// </summary>
  protected override void OnInitialized()
  {
    if (OnInitializedFormular("{{form}}", "{{title}} - {{form}}", Id, true))
      return;

    // Alle Submit-Aktionen, die vor dem Rendern der Komponenten ausgeführt werden müssen.
    // var submit = Model.Submit ?? "";
    // if (submit == nameof(Model.Import))
    // {
    //   var l = SaveUploadFiles("{{form}}", "filehochladen");
    // }
  }

""");
    if (modalroot != null)
    {
      sbr.Append($$"""

  /// <summary>
  /// Dialog wird über Tabellen-Aktion informiert und kann für den Aufruf eines modalen Dialogs benutzt werden.
  /// </summary>
  /// <param name="form">Betroffenes Postback-Formular.</param>
  /// <param name="handler">Handler aus Tabellen-Aktion.</param>
  /// <param name="id">Id aus Tabellen-Aktion.</param>
  public override void InitModal(string? form, string? handler, string? id)
  {
    if (!string.IsNullOrEmpty(handler) && !string.IsNullOrEmpty(id))
    {
      var dt = Formular.GetTableDialogType(handler);
      if (dt == DialogTypeEnum.New)
      {
        ModalModel.SetMhrf(DialogTypeEnum.New);
        Model.ModalArt = handler;
        Model.ModalId = id;
      }
      else
      {
        var i = Functions.ToInt32(id);
        if (i >= 1 && (Table?.Liste?.Count() ?? -1) < i)
        {
          var l = TableData(Table, ModalMessages);
          var ds = l.Skip(i - 1).FirstOrDefault();
          if (ds != null)
          {
            ModalModel.From(ds);
            ModalModel.SetMhrf(dt);
            Model.ModalArt = handler;
            Model.ModalId = id;
          }
        }
      }
    }
    else
    {
      var msubmit = ModalModel.Submit ?? "";
      if (msubmit == nameof(ModalModel.Ok))
      {
        var dt = Formular.GetTableDialogType(Model.ModalArt);
        var daten = ServiceDaten;
        var o = ModalModel.To(daten);
        var r = new ServiceErgebnis();
        // TODO var r = dt == DialogTypeEnum.Delete
        //   ? FactoryService.PrivateService.DeleteMemo(daten, o)
        //   : FactoryService.PrivateService.SaveMemo(daten, o.Uid, o.Thema, xml);
        if (r.Ok)
        {
          Model.ModalArt = null;
          Model.ModalId = null;
          TableData(Table, ModalMessages);
        }
        else
          ModalMessages?.Add(() => ModalModel, r.GetErrors());
      }
      else if (form != "{{form.ToLower()}}modal")
      {
        Model.ModalArt = null;
        Model.ModalId = null;
      }
    }
    WriteFormularModel(Model.Nr ?? "0", Model);
  }

""");
    }
    sbr.Append($$"""

  /// <summary>
  /// Verarbeitung des Postbacks.
  /// -Wegen Anzeige von Fehlermeldungen darf die Funktion nicht async sein (private async Task Submit()).
  /// -Speichern des geänderten Models.
  /// </summary>
  private void Submit()
  {
    if (Model == null || Messages == null)
      return;
    var submit = Model.Submit ?? "";
    if (!string.IsNullOrEmpty(submit))
    {
      valid = EditContext?.Validate() ?? false;
    }
    if (valid && submit == "OK")
    {
      var daten = ServiceDaten;
      var r = new ServiceErgebnis(); // TODO FactoryService.LoginService.ChangePassword(daten, daten.MandantNr, daten.BenutzerId, Model.KennwortAlt, Model.KennwortNeu, true);
      if (r != null)
      {
        Get(r);
        if (r.Ok)
        {
          CloseFormular();
          return;
        }
      }
    }
    WriteFormularModel(Model.Nr ?? "0", Model);
    if (submit == nameof(Model.Schliessen))
    {
      CloseFormular();
    }
  }

""");
    if (modalroot != null)
    {
      sbr.Append($$"""

  /// <summary>
  /// Bereitstellen der Tabellen-Daten mit Berücksichtigung der Filterung, Sortierung und Paginierung.
  /// </summary>
  /// <param name="m">Betroffenes TableRowModel.</param>
  /// <param name="messages">Betroffene Fehlermeldungen.</param>
  /// <returns>Tabellen-Daten als Liste.</returns>
  protected override List<{{form}}TableRowModel> TableData(TableModelBase<{{form}}TableRowModel>? m, ValidationMessageStore? messages)
  {
    var rm = m?.ReadModel;
    var daten = ServiceDaten;
    var r = new ServiceErgebnis<List<{{form}}TodoModel>>(new List<{{form}}TodoModel>());
    r.Ergebnis.Add(new {{form}}TodoModel()
    {
{{sbm}}    });
    if (rm != null)
      rm.PageCount = 0;
    // TODO var l0 = Get(FactoryService.PrivateService.GetClientList(daten, rm), messages);
    var l = r.Ergebnis?.Select(a => {{form}}TableRowModel.From(a)).ToList() ?? new List<{{form}}TableRowModel>();
    if (m != null && rm != null)
    {
      m.PageCount = rm.PageCount;
      m.Liste = l;
    }
    return l;
  }

""");
    }
    sbr.Append($$"""

  /// <summary>
  /// Kopieren von Daten im Model, die nicht über Postback gesendet werden.
  /// </summary>
  /// <param name="model">Betroffenes Model, das geändert werden soll.</param>
  /// <param name="model0">Model, aus dem kopiert werden soll.</param>
  protected override void CopyNotPostbackData({{form}}Model model, {{form}}Model model0)
  {
    model.ReadonlyHiddenError = model0.ReadonlyHiddenError;
  }
}

""");
    var path = Path.Combine(genpath, "Components", "Pages", area);
    Directory.CreateDirectory(path);
    File.WriteAllText(Path.Combine(path, $"{form}.razor"), sbr.ToString());
  }

  private static void ParseGlade(Control root, string file, XmlDocument resxml)
  {
    var settings = new XmlReaderSettings { ConformanceLevel = ConformanceLevel.Fragment, IgnoreWhitespace = false, IgnoreComments = true };
    using (var reader = XmlReader.Create(file, settings))
    {
      var cstack = new Stack<Control>();
      var ignore = false;
      cstack.Push(root);
      while (reader.Read())
      {
        if (reader.IsStartElement())
        {
          var n = reader.Name;
          if (ignore || n == "interface" || n == "requires" || n == "packing" || n == "placeholder" || n == "signal")
          {
            Functions.MachNichts();
          }
          else if (n == "GtkTreeSelection")
          {
            Functions.MachNichts();
          }
          else if (n == "child")
          {
            var c = cstack.Peek()?.Children.LastOrDefault();
            if (c != null)
              cstack.Push(c);
          }
          else if (n == "object")
          {
            var parent = cstack.Peek();
            var name = reader.GetAttribute("id") ?? "";
            var type = reader.GetAttribute("class") ?? "";
            if (type == "GtkTreeSelection" || type == "GtkImage")
              ignore = true;
            else if (type == "GtkEntry" && parent.Type == "GtkComboBoxText")
              ignore = true;
            else
            {
              if (type == "GtkButton" && name.EndsWith("Action") && name != "newAction")
                name = name.Substring(0, name.Length - 6);
              var c = new Control(name, type, "", "", parent);
              // if (type == "GtkImage")
              // {
              //   var text = name.Replace("Image", "");
              //   //// c.Text = Functions.ToFirstUpper(text);
              //   c.Tooltip = ReadResource(resxml, $"Action.{text}") ?? Functions.ToFirstUpper(text);
              //   c.Text = c.Tooltip;
              // }
              parent.Children.Add(c);
            }
          }
          else if (n == "property")
          {
            var name = reader.GetAttribute("name");
            var value = reader.ReadElementContentAsString();
            var c = cstack.Peek().Children.Last();
            if (name == "left_attach" || name == "position")
              c.Left = int.Parse(value);
            else if (name == "top_attach")
              c.Top = int.Parse(value);
            else if (name == "width")
              c.Width = int.Parse(value);
            else if (name == "height")
              c.Height = int.Parse(value);
            else if (name == "label")
              c.Text = ReadResource(resxml, value) ?? value;
            else if (name == "tooltip_text")
            {
              c.Tooltip = ReadResource(resxml, value) ?? value;
              if (c.Type == "GtkButton" && string.IsNullOrEmpty(c.Text))
                c.Text = c.Tooltip;
            }
          }
          else
          {
            throw new Exception("Unbekanntes Element: " + reader.Name);
          }
        }
        else if (reader.NodeType == XmlNodeType.EndElement)
        {
          if (reader.Name == "object")
          {
            ignore = false;
          }
          if (reader.Name == "child")
          {
            cstack.Pop();
          }
        }
      }
    }
    // Schließen-Schaltfläche hinzufügen.
    var cs = GetControls(root.Children, a => a.Name == "abbrechen" || a.Name == "schliessen").FirstOrDefault();
    if (cs == null)
    {
      var c = new Control("schliessen", "GtkButton", "Schließen", "Schließen", root);
      root.Children.Add(c);
    }
    // Nr-Felder in Nummer umbenennen.
    cs = GetControls(root.Children, a => a.Name == "nr0").FirstOrDefault();
    if (cs != null)
      cs.Name = "nummer0";
    cs = GetControls(root.Children, a => a.Name == "nr").FirstOrDefault();
    if (cs != null)
      cs.Name = "nummer";
    // Sortieren nach Position sowie Label und Control zusammenführen.
    SortControls(root);
    SetControlSort(root.Children, 1);
  }

  private static List<Control> GetControls(List<Control> controls, Expression<Func<Control, bool>> where)
  {
    // var list = controls.Where(where.Compile()).ToList();
    // list.AddRange(controls.SelectMany(a => GetControls(a.Children, where)));
    var list = controls.SelectMany(a => GetControls(a.Children, where)).ToList();
    list.AddRange(controls.Where(where.Compile()).ToList());
    return list;
  }

  private static int SetControlSort(List<Control> controls, int sort)
  {
    foreach (var c in controls)
    {
      sort = SetControlSort(c.Children, sort);
      c.Sort = sort++;
    }
    return sort;
  }

  private static string? ReadResource(XmlDocument resxml, string key)
  {
    var node = resxml.SelectSingleNode($"/root/data[@name='{key}']/value");
    return node?.InnerText;
  }

  private static void SortControls(Control root)
  {
    // Sortiere die Kinder des aktuellen Controls nach ihrer Position (Top, dann Left)
    root.Children = root.Children.OrderBy(c => c.Top).ThenBy(c => c.Left).ToList();

    // Führe Labels mit den entsprechenden Steuerelementen zusammen
    for (int i = 0; i < root.Children.Count; i++)
    {
      var control = root.Children[i];
      if (control.Type == "GtkLabel")
      {
        var name = control.Name.Substring(0, control.Name.Length - 1); // ohne '0' am Ende.
        var nextControl = GetControls(root.Children, a => a.Name == name).FirstOrDefault();
        if (nextControl != null)
        {
          // Füge das Label-Text zum nächsten Control hinzu.
          if (!string.IsNullOrEmpty(control.Text))
            nextControl.Text = control.Text;
          // Entferne das Label aus der Liste
          root.Children.RemoveAt(i);
          i--; // Korrigiere den Index nach dem Entfernen.
        }
      }
    }

    // Rekursive Sortierung für alle Kinder
    foreach (var child in root.Children)
    {
      SortControls(child);
    }
  }
}
