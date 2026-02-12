using BlazorBp.Base;
using BlazorBp.Models;
using BlazorBp.Models.Tb;
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
        // TODO Mandant = daten.MandantNr,
      };
      Model.SetMhrf(DialogTypeEnum.New);
    }
    Model.Nr = id;
    var l0 = Get(FactoryService.DiaryService.GetPositionList(daten));
    Model.AuswahlPosition = InsertEmpty(l0?.Select(a => new ListItem(a.Uid, a.Bezeichnung)).ToList());
    Model.AuswahlPositions = new List<ListItem> { new("MX", "Mexico"), new("CA", "Canada"), new("US", "USA") };
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
    // if (submit == "TODO z.B. Import")
    // {
    //   var l = SaveUploadFiles("TB100", "filehochladen");
    // }
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
    WriteFormularModel(Model.Nr ?? "0", Model);
    if (submit == "Schließen")
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
  }
}
