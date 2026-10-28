# Neues Formular in `BlazorBp.Forms`

Ein Formular besteht üblicherweise aus einem Model und einer Razor-Seite. Die Seite erbt von `BlazorComponent<T, TV>` und initialisiert Model sowie `EditContext`. Die Route wird über `@page` festgelegt; `FormsModule.GetForms()` registriert das Formular im Formular-Manager.

Im folgenden Beispiel heißt das Formular `DM900` und liegt im Bereich `Dm`.

## 1. Model anlegen

Datei `Models/Dm/DM900Model.cs`:

```csharp
namespace BlazorBp.Forms.Models.Dm;

using System.ComponentModel.DataAnnotations;
using BlazorSpa.Core.Base;

[Serializable]
public class DM900Model : PageModelBase
{
  [Display(Name = "_Bezeichnung")]
  [Required(ErrorMessage = "Die Bezeichnung muss angegeben werden.")]
  public string? Bezeichnung { get; set; }

  [Display(Name = "_OK")]
  public string? Ok { get; set; }

  [Display(Name = "A_bbrechen")]
  public string? Abbrechen { get; set; }
}
```

`PageModelBase` liefert unter anderem Formular-ID und Submit-Zustand. `Display` steuert Beschriftungen; Data-Annotations werden durch `DataAnnotationsValidator` ausgewertet. Für Formulare mit Pflichtfeldern, versteckten oder schreibgeschützten Controls kann das Model zusätzlich `SetMandatoryHiddenReadonly(...)` verwenden.

## 2. Razor-Seite erstellen

Datei `Components/Pages/Dm/DM900.razor`:

```razor
@page "/dm/dm900/{id?}"
@using BlazorBp.Forms.Models.Dm
@inherits BlazorComponent<DM900Model, TableRowModelBase>
@attribute [Authorize(Roles = "User, Admin, Superadmin")]

<SectionContent SectionName="title">@Title</SectionContent>
<PageTitle>@Title</PageTitle>

<EditForm Enhance method="post" EditContext="EditContext"
          OnSubmit="Submit" FormName="dm900">
  <DataAnnotationsValidator />
  <ValidationSummary class="text-danger" />
  <InputText type="hidden" @bind-Value="Model!.Nr" />
  <input type="hidden" name="SubmitControl" />

  <div class="row mt-1">
    <LabelInputValid AutoPostback=""
                     For="@(() => Model!.Bezeichnung)"
                     VerticalColClass="form-group col-md-4" />
  </div>
  <div class="modal-footer mt-2">
    <SubmitButton class="btn btn-primary" For="@(() => Model!.Ok)" />
    <SubmitButton class="btn btn-secondary" For="@(() => Model!.Abbrechen)" />
  </div>
</EditForm>

@code {
  protected override void Init(
      string? id,
      DM900Model? model = null,
      TableModelBase<TableRowModelBase>? table = null)
  {
    Model = model ?? new DM900Model();
    Model.Nr = id;
    InitEditContext(Model);
  }

  protected override void OnInitialized()
  {
    if (OnInitializedFormular("DM900", "Beispiel - DM900", Id))
      return;
  }

  protected override bool Submit(string? submit)
  {
    if (Valid && submit == nameof(Model.Ok))
    {
      // Model fachlich speichern, z. B. über einen injizierten Service.
      return true;
    }

    return submit == nameof(Model.Abbrechen);
  }
}
```

`Init` übernimmt ein wiederhergestelltes Model oder erzeugt ein neues und richtet den `EditContext` ein. `OnInitializedFormular` verwaltet Formular-ID, Titel und Postback. `Submit` wird nach der Validierung aufgerufen: Bei erfolgreichem Speichern bzw. Abbrechen `true` zurückgeben, damit das Formular geschlossen wird; sonst `false`.

## 3. Namespace und Formular-Manager ergänzen

Den Model-Namespace entweder wie oben mit `@using` in der Seite angeben oder in `Components/_Imports.razor` ergänzen:

```razor
@using BlazorBp.Forms.Models.Dm
```

In `FormsModule.GetForms()` einen Eintrag ergänzen. Schlüssel und Action-Namen müssen zur Formular-ID bzw. zur Route passen:

```csharp
{ "DM900", new Formular { Action = "dm900", Area = "dm", Name = "Beispiel" } },
```

Damit kennt der Formular-Manager die Action und den Bereich. Die Seite wird durch ihre `@page`-Direktive geroutet. Die Assembly von `BlazorBp.Forms` ist in der Anwendung bereits als zusätzliche Razor-Assembly registriert; für eine weitere Seite in diesem Projekt ist daher keine Änderung an `Program.cs` oder `Routes.razor` nötig.

## 4. Optional: Menüeintrag ergänzen

Soll das Formular über die Navigation erreichbar sein, in `FormsModule.GetMainMenues()` im passenden Menü einen Eintrag aufnehmen:

```csharp
new("Beispiel", "Beispielformular", "/dm/dm900", "bi bi-dot-nav-menu"),
```

Der Menüpfad muss zur Route in `@page` passen. Für ein rein direkt aufrufbares Formular ist kein Menüeintrag erforderlich.
