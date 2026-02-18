using BlazorBp.Base;
using BlazorBp.Models;
using BlazorBp.Models.Tb;
using CSBP.Services.Apis.Models;
using CSBP.Services.Base;
using CSBP.Services.Factory;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace BlazorBp.Components.Pages.Tb;

/// <summary>
/// Code-Behind des Formulars TB100 Tagebuch.
/// </summary>
public partial class TB100 : BlazorComponentBase<TB100Model, TableRowModelBase>
{
  /// <summary>Holt oder setzt das Modal-Model.</summary>
  [SupplyParameterFromForm]
  protected TB100ModalModel ModalModel { get; set; } = default!;

  /// <summary>Betroffener EditContext.</summary>
  protected EditContext? ModalEditContext;

  /// <summary>Betroffener ValidationMessageStore.</summary>
  protected ValidationMessageStore? ModalMessages;

  /// <summary>True, wenn EditContext ohne Fehler.</summary>
  private bool valid;

  /// <summary>
  /// Initialisierung des Models.
  /// </summary>
  /// <param name="id">Betroffene Id.</param>
  /// <param name="model">Evtl. gelesenes Model.</param>
  /// <param name="table">Evtl. gelesenes Table-Model.</param>
  protected override void Init(string? id, TB100Model? model = null, TableModelBase<TableRowModelBase>? table = null)
  {
    var daten = ServiceDaten;
    if (model != null)
      Model = model;
    if (Model == null)
    {
      Model = new TB100Model
      {
        Nr = id,
        Date = daten.Heute,
        OldEntry = new TbEintrag { Positions = [] },
        PositionList = [],
        //Focus = nameof(TB100Model.Entry),
      };
      Model.SetMhrf(DialogTypeEnum.New);
      Model.ClearSearch();
      Model.Date = DateTime.Today;
      Model.OldEntry.Datum = Model.Date.Value;
      BearbeiteEintraege(false);
      SearchEntry(CSBP.Services.Apis.Enums.SearchDirectionEnum.Last);
    }
    Model.Nr = id;
    InitLists();

    if (ModalModel == null)
      ModalModel = new TB100ModalModel
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
  }

  /// <summary>
  /// Aktualisierung nach Undo/Redo.
  /// </summary>
  protected override void Refresh()
  {
    BearbeiteEintraege(false);
  }

  /// <summary>
  /// Initialisierung des Formulars kann wegen EditContext nicht asynchron sein:
  /// -Formular-Manager braucht eine Id, ansonsten Redirect mit neuer Guid.
  /// -Lesen des Models aus der Session, ansonsten Initialisierung des Models.
  /// </summary>
  protected override void OnInitialized()
  {
    if (OnInitializedFormular("TB100", "Tagebuch - TB100", Id, true))
      return;

    // Alle Submit-Aktionen, die vor dem Rendern der Komponenten ausgeführt werden müssen.
    // var submit = Model.Submit ?? "";
    // if (submit == nameof(Model.Import))
    // {
    //   var l = SaveUploadFiles("TB100", "filehochladen");
    // }
  }

  /// <summary>Initialises the lists.</summary>
  private void InitLists()
  {
    var daten = ServiceDaten;
    var rl = Get(FactoryService.DiaryService.GetPositionList(daten));
    Model.AuswahlPosition = InsertEmpty(rl?.Select(a => new ListItem(a.Uid, a.Bezeichnung)).ToList());
    var rl2 = Get(FactoryService.DiaryService.GetPositionList(daten, ext: true));
    Model.AuswahlPosition2 = InsertEmpty(rl2?.Select(a => new ListItem(a.Uid, a.Bezeichnung)).ToList());
  }

  /// <summary>
  /// Loads the diary entries from date.
  /// </summary>
  /// <param name="d">Affected date.</param>
  /// <returns>Service result and possibly errors.</returns>
  private ServiceErgebnis LadeEintraege(DateTime? d)
  {
    var daten = ServiceDaten;
    var r = new ServiceErgebnis();
    if (!d.HasValue || Model == null || Model.OldEntry == null || Model.OldEntry.Positions == null || Model.PositionList == null)
      return r;
    var tb = r.Get(FactoryService.DiaryService.GetEntry(daten, d.Value.AddDays(-1)));
    Model.Before1 = tb?.Eintrag;
    tb = r.Get(FactoryService.DiaryService.GetEntry(daten, d.Value.AddMonths(-1)));
    Model.Before2 = tb?.Eintrag;
    tb = r.Get(FactoryService.DiaryService.GetEntry(daten, d.Value.AddYears(-1)));
    Model.Before3 = tb?.Eintrag;
    tb = r.Get(FactoryService.DiaryService.GetEntry(daten, d.Value, true));
    Model.Entry = tb?.Eintrag;
    Model.PositionList = tb?.Positions;
    Model.OldEntry.Positions.Clear();
    if (tb == null)
    {
      Model.OldEntry.Eintrag = "";
      Model.Angelegt = "";
      Model.Geaendert = "";
    }
    else
    {
      Model.OldEntry.Eintrag = tb.Eintrag;
      Model.OldEntry.Positions.AddRange(tb.Positions);
      Model.Angelegt = ModelBase.FormatDateOf(tb.Angelegt_Am, tb.Angelegt_Von);
      Model.Geaendert = ModelBase.FormatDateOf(tb.Geaendert_Am, tb.Geaendert_Von);
    }
    Model.OldEntry.Datum = d.Value;
    Model.Entry = Model.OldEntry.Eintrag;
    tb = r.Get(FactoryService.DiaryService.GetEntry(daten, d.Value.AddDays(1)));
    Model.After1 = tb?.Eintrag;
    tb = r.Get(FactoryService.DiaryService.GetEntry(daten, d.Value.AddMonths(1)));
    Model.After2 = tb?.Eintrag;
    tb = r.Get(FactoryService.DiaryService.GetEntry(daten, d.Value.AddYears(1)));
    Model.After3 = tb?.Eintrag;
    InitPositions( Model.OldEntry.Positions);
    // TODO if (!before1.Visible)
    //   ShowWeather();
    return r;
  }

  /// <summary>
  /// Initialises the position list.
  /// </summary>
  /// <param name="list">New list.</param>
  private void InitPositions(List<TbEintragOrt>? list = null)
  {
    if (Model == null || Model.PositionList == null)
       return;
    if (list != null)
    {
      Model.PositionList.Clear();
      foreach (var p in list)
        Model.PositionList.Add(ServiceBase.Clone(p));
    }
    //// No.;Description;Latitude_r;Longitude_r;From;To;Changed at;Changed by;Created at;Created by
    Model.AuswahlPositions = Model.PositionList.Select(a => new ListItem(a.Ort_Uid, $"{a.Description} ({a.Latitude:0.00000}, {a.Longitude:0.00000}) {a.Datum_Von:dd.MM.yyyy}-{a.Datum_Bis:dd.MM.yyyy}")).ToList();
  }

  /// <summary>
  /// Loads the diary entry from date. Optionally the current entry is saved before.
  /// </summary>
  /// <param name="speichern">Saves before or not.</param>
  /// <param name="laden">Loads the entry or not.</param>
  private void BearbeiteEintraege(bool speichern = true, bool laden = true)
  {
    if (Model == null || Model.OldEntry == null || Model.OldEntry.Positions == null || Model.PositionList == null)
       return;
    var daten = ServiceDaten;
    var r = new ServiceErgebnis();
    //// Prohibits rekursion.
    if (speichern && Model.OldLoaded)
    {
      // Alten Eintrag von vorher merken.
      var oldentry = Model.OldEntry.Eintrag;
      var p0 = Model.OldEntry.Positions.OrderBy(a => a.Ort_Uid).Select(a => a.Hash()).Aggregate("", (c, n) => c + n);
      var p = Model.PositionList.OrderBy(a => a.Ort_Uid).Select(a => a.Hash()).Aggregate("", (c, n) => c + n);
      //// Nur speichern, wenn etwas geändert ist.
      if (string.IsNullOrEmpty(oldentry) || Functions.CompString(oldentry, Model.Entry) != 0 || Functions.CompString(p0, p) != 0)
      {
        var pos = Model.PositionList.Select(a => new Tuple<string, DateTime, DateTime>(a.Ort_Uid, a.Datum_Von, a.Datum_Bis)).ToList();
        r.Get(FactoryService.DiaryService.SaveEntry(daten, Model.OldEntry.Datum, Model.Entry, pos));
      }
    }
    if (laden)
    {
      var d = Model.Date;
      r.Get(LadeEintraege(d));
      //// LoadMonth(d);
      Model.OldLoaded = true;
    }
    Get(r);
  }

  /// <summary>
  /// Searches for next fitting entry in search direction.
  /// </summary>
  /// <param name="stelle">Affected search direction.</param>
  private void SearchEntry(CSBP.Services.Apis.Enums.SearchDirectionEnum stelle)
  {
    if (Model == null)
      return;
    BearbeiteEintraege(true, false);
    var daten = ServiceDaten;
    var d = Get(FactoryService.DiaryService.SearchDate(daten, stelle, Model.Date ?? daten.Heute, Model.GetSearchArray(),
      Model.Position2, Model.From ?? daten.Heute, Model.To ?? daten.Heute));
    if (d.HasValue)
    {
      Model.Date = d;
      BearbeiteEintraege(false);
    }
  }

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
    var msubmit = ModalModel.Submit ?? "";
    if (!string.IsNullOrEmpty(submit))
    {
      valid = EditContext?.Validate() ?? false;
    }
    if (submit == nameof(Model.Copy))
    {
      Model.Kopie = Model.Entry;
    }
    else if (submit == nameof(Model.Paste))
    {
      Model.Entry = Model.Kopie;
      BearbeiteEintraege(true, false);
    }
    else if (submit == nameof(Model.Weather))
    {
      // TODO Wetterdaten anzeigen.
      Model.Weathervisible = !Model.Weathervisible;
    }
    else if (submit == nameof(Model.Download))
    {
      // Importieren der Rabp-Daten ins Tagebuch.
      // Das ist nun nicht mehr notwendig, weil die Erfassung direkt in BlazorBp erfolgt.
      // var d = date.ValueNn;
      // var t = Get(FactoryService.DiaryService.GetApiDiaryList(ServiceDaten, d));
      // if (t == null)
      //   return;
      // if (t.Item2.Count() <= 0)
      // {
      //   // Translate messages.
      //   ShowInfo("Keine Rabp-Daten gefunden.");
      //   return;
      // }
      // var sb = new StringBuilder();
      // sb.AppendLine(@$"""Rabp-Version {t.Item1}  {t.Item2.Count()} {Functions.Iif(t.Item2.Count() == 1, "Eintrag", "Einträge")} vor {d:yyyy-MM-dd}""");
      // foreach (var item in t.Item2)
      // {
      //   sb.AppendLine($"{item.Datum:yyyy-MM-dd} {item.Eintrag}");
      // }
      // sb.AppendLine("Importieren der Rabp-Daten ins Tagebuch?");
      // if (ShowYesNoQuestion(sb.ToString()))
      // {
      //   BearbeiteEintraege(); // Save
      //   if (!Get(FactoryService.DiaryService.ReplicateDiaryList(ServiceDaten, t.Item2)))
      //     return;
      //   BearbeiteEintraege(false); // Reload
      // }
      // var s = @$"Löschen der Rabp-Daten?";
      // if (ShowYesNoQuestion(s))
      //   Get(FactoryService.DiaryService.GetApiDiaryList(ServiceDaten, d, true));
    }
    else if (submit == nameof(Model.Save))
    {
      // Wird momentan nicht gebraucht: Bericht erzeugen mit Link.
      // BearbeiteEintraege(true, false);
      // var puid = GetText(position2);
      // var pfad = ParameterGui.TempPath;
      // var datei = Functions.GetDateiname(M0(TB005), true, true, "txt");
      // var daten = ServiceDaten;
      // UiTools.SaveFile(daten, Get(FactoryService.DiaryService.GetDiaryReport(daten, GetSearchArray(),
      //   puid, from.Value, to.Value)), pfad, datei);
      // var statusMessage = "";
      // var client = CSBP.Services.NonService.HttpClientFactory.CreateClient();
      // var uri = new Uri(Navigation.Uri);
      // var baseUrl = $"{uri.Scheme}://{uri.Host}{(uri.IsDefaultPort ? "" : $":{uri.Port}")}";
      // client.BaseAddress = new Uri(baseUrl);
      // try
      // {
      //     // Hier könntest du auch eine externe API oder einen internen Endpunkt ansprechen.
      //     var response = client.GetAsync($"/download/TB100/{Model.Nr}").GetAwaiter().GetResult();
      //     if (response.IsSuccessStatusCode)
      //       statusMessage = "API call successful!";
      //     else
      //       statusMessage = "API call failed with status: " + response.StatusCode;
      // }
      // catch (Exception ex)
      // {
      //   statusMessage = "Error: " + ex.Message;
      // }
    }
    else if (IsDateMhp(submit, nameof(Model.Date), Model.Date, out var d))
    {
      if (d.HasValue)
        Model.Date = d;
      BearbeiteEintraege();
      if (submit == nameof(Model.Date))
        Model.Focus = nameof(Model.Date);
    }
    else if (submit == nameof(Model.New))
    {
      // TODO Formular TB210 Position öffnen
      // Start(typeof(TB210Position), TB210_title, DialogTypeEnum.New, null, csbpparent: this);
    }
    else if (submit == nameof(Model.Remove) && Model.PositionList != null)
    {
      // Position entfernen.
      var uid = Model.Positions;
      if (!string.IsNullOrEmpty(uid) && Model.PositionList.Any(a => a.Ort_Uid == uid))
      {
        Model.PositionList = Model.PositionList.Where(a => a.Ort_Uid != uid).ToList();
        InitPositions();
      }
    }
    else if (submit == nameof(Model.Posbefore) && Model.Date.HasValue && Model.PositionList != null)
    {
      // Positionen vom Vortag übernehmen
      var yd = Model.Date.Value.AddDays(-1);
      var r = FactoryService.DiaryService.GetEntry(ServiceDaten, yd, true);
      if (r.Ok && r.Ergebnis != null)
      {
        foreach (var p in r.Ergebnis.Positions ?? new List<TbEintragOrt>())
        {
          if (Model.PositionList.FirstOrDefault(a => a.Ort_Uid == p.Ort_Uid) == null)
          {
            if (p.Datum_Bis == yd)
              p.Datum_Bis = p.Datum_Bis.AddDays(1);
            Model.PositionList.Add(p);
          }
        }
        InitPositions();
      }
    }
    else if (submit == nameof(Model.Add) && Model.Date.HasValue && Model.PositionList != null)
    {
      var uid = Model.Position;
      if (!string.IsNullOrEmpty(uid))
      {
        var o = Model.PositionList.FirstOrDefault(a => a.Ort_Uid == uid);
        if (o != null)
        {
          if (string.IsNullOrEmpty(msubmit))
          {
            // Formular TB110 Date öffnen
            ModalModel.SetMhrf(DialogTypeEnum.New);
            ModalModel.From(o);
            Model.ModalArt = "Table_New";
            Model.ModalId = o.Ort_Uid;
          }
          else if (msubmit == nameof(ModalModel.Ok))
          {
            // InitModal("tb100", "Table_New", o.Ort_Uid);
            var to = ModalModel.Datum;
            if (to.HasValue)
            {
              if (to.Value >= Model.Date.Value)
                o.Datum_Bis = to.Value;
              else
                o.Datum_Von = to.Value;
            }
            InitPositions();
            //// Formular TB110 Date schließen.
            Model.ModalArt = null;
            Model.ModalId = null;
          }
          else if (IsDateMhp(msubmit, nameof(ModalModel.Datum), ModalModel.Datum, out var dm))
          {
            ModalModel.Datum = dm;
          }
          else
          {
            // Formular TB110 Date schließen.
            Model.ModalArt = null;
            Model.ModalId = null;
          }
        }
        else
        {
          var k = Get(FactoryService.DiaryService.GetPosition(ServiceDaten, uid));
          if (k != null)
          {
            var p = new TbEintragOrt
            {
              Mandant_Nr = k.Mandant_Nr,
              Ort_Uid = k.Uid,
              Datum_Von = Model.Date.Value,
              Datum_Bis = Model.Date.Value,
              Description = k.Bezeichnung,
              Latitude = k.Breite,
              Longitude = k.Laenge,
              Height = k.Hoehe,
              Memo = k.Notiz,
            };
            Model.PositionList.Add(p);
            InitPositions();
          }
        }
      }
    }
    else if (submit == nameof(Model.Search))
    {
      Model.Searchvisible = !Model.Searchvisible;
      Model.SetMhrf(DialogTypeEnum.Edit);
    }
    else if (submit == nameof(Model.Clear))
    {
      Model.ClearSearch();
      BearbeiteEintraege(true, false);
    }
    else if (submit == nameof(Model.First))
    {
      SearchEntry(CSBP.Services.Apis.Enums.SearchDirectionEnum.First);
    }
    else if (submit == nameof(Model.Back))
    {
      SearchEntry(CSBP.Services.Apis.Enums.SearchDirectionEnum.Back);
    }
    else if (submit == nameof(Model.Forward))
    {
      SearchEntry(CSBP.Services.Apis.Enums.SearchDirectionEnum.Forward);
    }
    else if (submit == nameof(Model.Last))
    {
      SearchEntry(CSBP.Services.Apis.Enums.SearchDirectionEnum.Last);
    }
    else if (IsDateMhp(submit, nameof(Model.From), Model.From, out var df))
    {
      if (df.HasValue)
        Model.From = df;
    }
    else if (IsDateMhp(submit, nameof(Model.To), Model.To, out var dt))
    {
      if (dt.HasValue)
        Model.To = dt;
    }
    WriteFormularModel(Model.Nr ?? "0", Model);
    if (submit == nameof(Model.Schliessen))
    {
      CloseFormular();
    }
  }

  /// <summary>
  /// Kopieren von Daten im Model, die nicht über Postback gesendet werden.
  /// </summary>
  /// <param name="model">Betroffenes Model, das geändert werden soll.</param>
  /// <param name="model0">Model, aus dem kopiert werden soll.</param>
  protected override void CopyNotPostbackData(TB100Model model, TB100Model model0)
  {
    model.ReadonlyHiddenError = model0.ReadonlyHiddenError;
    model.Kopie = model0.Kopie;
    model.Weathervisible = model0.Weathervisible;
    model.Searchvisible = model0.Searchvisible;
    model.OldLoaded = model0.OldLoaded;
    model.OldEntry = model0.OldEntry;
    model.PositionList = model0.PositionList;
    model.AuswahlPositions = model0.AuswahlPositions;
  }
}
