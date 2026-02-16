using BlazorBp.Base;
using BlazorBp.Models;
using BlazorBp.Models.Tb;
using CSBP.Services.Apis.Models;
using CSBP.Services.Base;
using CSBP.Services.Factory;

namespace BlazorBp.Components.Pages.Tb;

/// <summary>
/// Code-Behind des Formulars TB100 Tagebuch.
/// </summary>
public partial class TB100 : BlazorComponentBase<TB100Model, TableRowModelBase>
{
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
      ClearSearch();
      Model.Date = DateTime.Today;
      Model.OldEntry.Datum = Model.Date.Value;
      BearbeiteEintraege(false);
      SearchEntry(CSBP.Services.Apis.Enums.SearchDirectionEnum.Last);
    }
    Model.Nr = id;
    InitLists();
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
      //// No.;Description;Latitude_r;Longitude_r;From;To;Changed at;Changed by;Created at;Created by
      Model.AuswahlPositions = Model.PositionList.Select(a => new ListItem(a.Ort_Uid, a.Description)).ToList();
    }
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
  /// Clears the search data.
  /// </summary>
  private void ClearSearch()
  {
    Model.Search1 = "%%";
    Model.Search2 = "%%";
    Model.Search3 = "%%";
    Model.Search4 = null;
    Model.Search5 = "%%";
    Model.Search6 = "%%";
    Model.Search7 = "%%";
    Model.Search8 = null;
    Model.Search9 = "%%";
    Model.Search100 = "%%";
    Model.Search110  = "%%";
    Model.Search120 = null;
    Model.Position2 = null;
    Model.From = Functions.IsLinux() ? DateTime.Today.AddYears(-1) : null;
    Model.To = DateTime.Today;
  }

  /// <summary>
  /// Gets the search array.
  /// </summary>
  /// <returns>Search array.</returns>
  private string?[] GetSearchArray()
  {
    var search = new string?[] { Model?.Search1, Model?.Search2, Model?.Search3, Model?.Search5, Model?.Search6, Model?.Search7, Model?.Search9, Model?.Search100, Model?.Search110 };
    return search;
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
    var puid = Model.Position2;
    var d = Get(FactoryService.DiaryService.SearchDate(daten, stelle, Model.Date ?? daten.Heute, GetSearchArray(),
      puid, Model.From ?? daten.Heute, Model.To ?? daten.Heute));
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
    else if (submit == nameof(Model.Copy))
    {
      Model.Kopie = Model.Entry;
    }
    else if (submit == nameof(Model.Paste))
    {
      Model.Entry = Model.Kopie;
    }
    else if (IsDateMhp(submit, nameof(Model.Date), Model.Date, out var d))
    {
      if (d.HasValue)
        Model.Date = d;
      BearbeiteEintraege();
      if (submit == nameof(Model.Date))
        Model.Focus = nameof(Model.Date);
    }
    else if (submit == nameof(Model.Search))
    {
      Model.Searchvisible = !Model.Searchvisible;
      Model.SetMhrf(DialogTypeEnum.Edit);
    }
    else if (submit == nameof(Model.Clear))
    {
      ClearSearch();
      BearbeiteEintraege(true, false);
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
    model.Searchvisible = model0.Searchvisible;
    model.OldLoaded = model0.OldLoaded;
    model.OldEntry = model0.OldEntry;
    model.PositionList = model0.PositionList;
    model.AuswahlPositions = model0.AuswahlPositions;
    model.Kopie = model0.Kopie;
  }
}
