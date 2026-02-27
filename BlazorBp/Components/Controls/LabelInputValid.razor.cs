using BlazorBp.Models;
using CSBP.Services.Base;
using Microsoft.AspNetCore.Components;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using System.Reflection;

namespace BlazorBp.Components.Controls;

/// <summary>
/// LabelInputValid: Label und Input mit Validierung, Readonly, Hidden, Error, Mandatory, Fokus, Accesskey, Tooltip.
/// </summary>
/// <typeparam name="TItem">Betroffener Datentyp.</typeparam>
public partial class LabelInputValid<TItem> : ComponentBase
{
  /// <summary>Holt oder setzt die Expression für das gebundene Property.</summary>
  [Parameter, EditorRequired]
  public Expression<Func<TItem>> For { get; set; } = default!;

  /// <summary>Holt oder setzt die CSS-Class für die vertikale Anordnung.</summary>
  [Parameter]
  public string? VerticalColClass { get; set; }

  /// <summary>Holt oder setzt einen Wert, der angibt, ob das Label ausgeblendet wird.</summary>
  [Parameter]
  public bool NoLabel { get; set; } = false;

  /// <summary>Holt oder setzt einen Wert, der angibt, ob das Label hinter dem Input angezeigt wird.</summary>
  [Parameter]
  public bool TrailingLabel { get; set; } = false;

  /// <summary>Holt oder setzt einen Wert, der angibt, ob die Validierung ausgeblendet wird.</summary>
  [Parameter]
  public bool NoValidation { get; set; } = false;

  /// <summary>Holt oder setzt einen Wert, der angibt, ob ein Postback bei Änderung des Inputs erfolgt.</summary>
  [Parameter]
  public string? AutoPostback { get; set; }

  /// <summary>Holt oder setzt die Liste für RadioButton, ComboBox und ListBox.</summary>
  [Parameter]
  public IEnumerable<ListItem>? DataList { get; set; }

  /// <summary>Holt oder setzt die übergebenen Attribute.</summary>
  [Parameter(CaptureUnmatchedValues = true)]
  public IDictionary<string, object>? AdditionalAttributes { get; set; }

  /// <summary>Holt oder setzt die zu generierenden Attribute.</summary>
  private IDictionary<string, object>? Attributes2 { get; set; }

  private string? Id { get; set; }

  private string? Accesskey { get; set; }

  private string? Title { get; set; }

  private MarkupString LabelMu { get; set; } = new();

  /// <summary>CSS-Class für Label.</summary>
  private string CssClassLabel { get; set; } = "";

  /// <summary>CSS-Class für Input (Eine Kombination von modified, valid, invalid).</summary>
  private string CssClass { get; set; } = "";

  /// <summary>Step für Input mit Dezimalwerten.</summary>
  private string Step { get; set; } = "";

  /// <summary>Aktueller Wert (public für Reflection).</summary>
  public TItem CurrentValue { get; set; } = default!;

  /// <summary>Aktueller Wert als Datum.</summary>
  private DateTime? CurrentValueAsDateTime
  {
    get
    {
      var v = CurrentValue == null ? null : Convert.ToDateTime(CurrentValue) as DateTime?;
      return v;
    }
  }

  /// <summary>Aktueller Wert als Decimal.</summary>
  private decimal? CurrentValueAsDecimal
  {
    get
    {
      var v = CurrentValue == null ? null : Convert.ToDecimal(CurrentValue) as decimal?;
      return v;
    }
  }

  /// <summary>Wert für Attribut name beim Postback.</summary>
  private string? NameAttributeValue { get; set; }

  /// <summary>Wert für Attribut name beim Postback für submit.</summary>
  private string? NameAttributeValueSubmit { get; set; }

  /// <summary>Wert für Attribut value beim Postback für submit.</summary>
  private string? ValueSubmit { get; set; }

  /// <summary>Type für Input.</summary>
  private string InputType { get; set; } = "text";

  private bool submit = false;

  private bool disabled = false;

  private bool disabledCheckboxTrue = false;

  private bool hidden = false;

  private bool textarea = false;

  private bool combobox = false;

  private bool listbox = false;

  private bool canvas = false;

  private string? accesskey1 = null;

  private string? accesskey2 = null;

  private string? accesskey3 = null;

  private string? onchange = null;

  private string? autofocus = null;

  /// <summary>Anzahl der Nachkommastellen für die Darstellung von Decimal-Werten.</summary>
  private int currency = 0;

  /// <summary>Anzahl der Renderns.</summary>
  private int rendern = 0;

  /// <summary>Holt der leere Ergebnis des Renderns.</summary>
  private string? OnRendering
  {
    get
    {
      rendern++;
      OnInitialized2();
      return "";
    }
  }

  // /// <summary>
  // /// Es wird höchstens zweimal gerendert, vor und nach Submit.
  // /// </summary>
  // /// <returns>True, wenn noch einmal gerendert werden soll.</returns>
  // protected override bool ShouldRender()
  // {
  //   return rendern < 3; // nur höchstens zweimal rendern.
  // }

  /// <summary>
  /// Setzen von Accesskey, des Tooltips und des Labels mit Accesskey.
  /// Der Label kann direkt gesetzt werden.
  /// Ansonsten werden die Werte für Label und Tooltip aus dem Display-Attributs des For-Property bestimmt.
  /// Relevante Attribute: id, name, accesskey, title, value.
  /// </summary>
  protected void OnInitialized2()
  {
    object? obj = "";
    AdditionalAttributes ??= new Dictionary<string, object>();
    AdditionalAttributes.TryGetValue("class", out obj);
    CssClass = obj?.ToString() ?? "";
    AdditionalAttributes.TryGetValue("id", out obj);
    Id = obj?.ToString() ?? "";
    if (string.IsNullOrEmpty(Id))
      Id = Guid.NewGuid().ToString();
    AdditionalAttributes.TryGetValue("label", out obj);
    var lbl = obj?.ToString() ?? "";
    AdditionalAttributes.TryGetValue("accesskey", out obj);
    Accesskey = obj?.ToString() ?? "";
    AdditionalAttributes.TryGetValue("title", out obj);
    Title = obj?.ToString() ?? "";
    var name = "";
    AdditionalAttributes.TryGetValue("type", out obj);
    InputType = obj?.ToString() ?? "";
    submit = InputType == "submit";
    var checkbox = InputType == "checkbox";
    var radio = InputType == "radio";
    combobox = InputType == "combobox";
    listbox = InputType == "listbox";
    canvas = InputType == "canvas";
    hidden = InputType == "hidden";
    AdditionalAttributes.TryGetValue("step", out obj);
    Step = obj?.ToString() ?? "";
    currency = Step == "0.1" ? 1 : Step == "0.01" ? 2 : Step == "0.001" ? 3 : Step == "0.0001" ? 4 : Step == "0.00001" ? 5 : 0;
    AdditionalAttributes.TryGetValue("rows", out obj);
    var textarearows = obj?.ToString() ?? "";
    AdditionalAttributes.TryGetValue("cols", out obj);
    var textareacols = obj?.ToString() ?? "";
    AdditionalAttributes.TryGetValue("size", out obj);
    var listboxsize = obj?.ToString() ?? "";
    AdditionalAttributes.TryGetValue("multiple", out obj);
    var multiple = obj?.ToString();
    if (!string.IsNullOrWhiteSpace(listboxsize))
      listbox = true;
    if (listbox && listboxsize == "1")
    {
      listbox = false;
      combobox = true;
    }
    if (combobox)
    {
      listboxsize = "1";
      multiple = null;
    }
    if (listbox && string.IsNullOrWhiteSpace(listboxsize))
      listboxsize = "5"; // Standardwert

    // Initialisierung für Mehrfach-Rendering.
    autofocus = null;
    CssClassLabel = "";
    disabled = false;

    if (string.IsNullOrEmpty(InputType))
    {
      if(typeof(TItem) == typeof(DateTime?) || typeof(TItem) == typeof(DateTime))
        InputType = "date";
      else if (typeof(TItem) == typeof(int?) || typeof(TItem) == typeof(int) || typeof(TItem) == typeof(long?) || typeof(TItem) == typeof(long) || typeof(TItem) == typeof(decimal?) || typeof(TItem) == typeof(decimal))
        InputType = "number";
      else // if(typeof(TItem) == typeof(DateTime?) || typeof(TItem) == typeof(DateTime))
        InputType = "text";
    }
    if (InputType == "text" && (!string.IsNullOrWhiteSpace(textarearows) || !string.IsNullOrWhiteSpace(textareacols)))
    {
      textarea = true;
      if (string.IsNullOrWhiteSpace(textarearows))
        textarearows = "5"; // Standardwert
      if (string.IsNullOrWhiteSpace(textareacols))
        textareacols = "30"; // Standardwert
    }
    else
    {
      textarearows = null;
      textareacols = null;
    }
    CssClass = (checkbox || radio ? "form-check-input" : combobox || listbox ? "form-select" : "form-control")
      + Functions.Iif(string.IsNullOrEmpty(CssClass), "", " ") + CssClass;
    if (For?.Body is MemberExpression me)
    {
      var mb = me.Member;
      name = mb.Name ?? "";
      var dp = mb.GetCustomAttribute(typeof(DisplayAttribute)) as DisplayAttribute;
      if (dp != null)
      {
        if (string.IsNullOrEmpty(lbl))
          lbl = dp.GetName() ?? "";
        if (string.IsNullOrEmpty(Title))
          Title = dp.Description ?? "";
      }
      if (string.IsNullOrEmpty(lbl))
        lbl = name;
      var modeltype = mb.DeclaringType;
      var modelprop = modeltype?.GetProperty(name);
      var fex = me.Expression as MemberExpression;
      var cex = fex?.Expression as ConstantExpression;
      var fld = fex?.Member as PropertyInfo;
      var model = fld?.GetValue(cex?.Value);
      var v = modelprop?.GetValue(model);
      var cvprop = this.GetType().GetProperty("CurrentValue");
      if (typeof(TItem) == v?.GetType())
      {
        cvprop?.SetValue(this, v);
      }
      else if (typeof(TItem) == typeof(string))
      {
        cvprop?.SetValue(this, v == null ? null : v.ToString());
      }
      else if (typeof(TItem) == typeof(int))
      {
        cvprop?.SetValue(this, Convert.ToInt32(v));
      }
      else if (typeof(TItem) == typeof(int?))
      {
        cvprop?.SetValue(this, v == null ? null : Convert.ToInt32(v));
      }
      else if (typeof(TItem) == typeof(decimal?))
      {
        cvprop?.SetValue(this, v == null ? null : Convert.ToDecimal(v));
        // cvprop?.SetValue(this, v == null ? null : Functions.ToDecimal(v.ToString(), 2, true));
      }
      else if (typeof(TItem) == typeof(DateTime))
      {
        cvprop?.SetValue(this, Convert.ToDateTime(v));
      }
      else if (typeof(TItem) == typeof(DateTime?))
      {
        var v2 = v == null ? null : Convert.ToDateTime(v) as DateTime?;
        cvprop?.SetValue(this, v2);
      }
      else
        throw new Exception($"LabelInputValid: Keine Konvertierung für Typ {typeof(TItem)} bei {name}.");
      if ((radio || combobox || listbox) && (DataList == null || !DataList.Any()))
        throw new Exception($"LabelInputValid: Parameter DataList darf nicht leer sein bei {name}.");
      var modelname = fld?.Name ?? "Model";
      NameAttributeValueSubmit = $"{modelname}.SubmitControl";
      NameAttributeValue = submit ? NameAttributeValueSubmit : $"{modelname}.{name}";
      if (model != null && !string.IsNullOrEmpty(name))
      {
        // Readonly, Hidden, Error, Mandatory
        var rheprop = modeltype?.GetProperty("ReadonlyHiddenError");
        var rhe = rheprop?.GetValue(model) as string ?? "";
        if (rhe.Contains($"#{name}#H"))
        {
          hidden = true;
          // SetAttribute(AdditionalAttributes, "hidden", "");
        }
        else
        {
          if (rhe.Contains($"#{name}#R"))
          {
            disabled = true;
          }
          if (rhe.Contains($"#{name}#E"))
          {
            CssClassLabel += Functions.Iif(string.IsNullOrEmpty(CssClass), "", " ") + "text-danger";
            CssClass += Functions.Iif(string.IsNullOrEmpty(CssClass), "", " ") + "border-danger";
          }
          if (rhe.Contains($"#{name}#M"))
          {
            if (submit)
              CssClass += Functions.Iif(string.IsNullOrEmpty(CssClass), "", " ") + "fw-bold";
            CssClassLabel += Functions.Iif(string.IsNullOrEmpty(CssClassLabel), "", " ") + "fw-bold";
          }
          if (rhe.Contains($"#{name}#C1"))
          {
            CssClass += Functions.Iif(string.IsNullOrEmpty(CssClass), "", " ") + "text-bg-success"; // grün
          }
          if (rhe.Contains($"#{name}#C2"))
          {
            CssClass += Functions.Iif(string.IsNullOrEmpty(CssClass), "", " ") + "text-bg-warning"; // gelb
          }
          if (rhe.Contains($"#{name}#C3"))
          {
            CssClass += Functions.Iif(string.IsNullOrEmpty(CssClass), "", " ") + "text-bg-danger"; // rot
          }
        }
        // Fokus
        var focusprop = modeltype?.GetProperty("Focus");
        var focus = focusprop?.GetValue(model) as string ?? "";
        if (!string.IsNullOrEmpty(focus) && name.EndsWith(focus))
          autofocus = "";
        if (!string.IsNullOrWhiteSpace(AutoPostback))
        {
          // CssClass += Functions.Iif(string.IsNullOrEmpty(CssClass), "", " ") + "autopostback";
          onchange = "submitc($(this));";
        }
      }
    }
    if (string.IsNullOrEmpty(lbl))
      lbl = "Label";
    if (checkbox)
      lbl += "&nbsp;&nbsp;";
    if (InputType == "date" && !string.IsNullOrEmpty(Accesskey) && Accesskey.Length > 3)
    {
      accesskey1 = Functions.TrimNull(Accesskey.Substring(1, 1));
      accesskey2 = Functions.TrimNull(Accesskey.Substring(2, 1));
      accesskey3 = Functions.TrimNull(Accesskey.Substring(3, 1));
      Accesskey = Functions.TrimNull(Accesskey.Substring(0, 1));
    }
    if (string.IsNullOrEmpty(Accesskey))
    {
      var i = lbl.IndexOf("_");
      if (i >= 0 && i < lbl.Length - 1)
        Accesskey = lbl.Substring(i + 1, 1);
    }
    if (string.IsNullOrEmpty(Accesskey))
      LabelMu = new MarkupString(lbl);
    else
    {
      if (lbl.Contains($"_{Accesskey}"))
        LabelMu = new MarkupString(lbl.Replace($"_{Accesskey}", $"<u>{Accesskey}</u>"));
      else
      {
        var i = lbl.ToLower().IndexOf(Accesskey.ToLower());
        if (i >= 0)
          LabelMu = new MarkupString($"{lbl.Substring(0, i)}<u>{lbl.Substring(i, 1)}</u>{lbl.Substring(i+1)}");
        else
          LabelMu = new MarkupString($"{lbl} (<u>{Accesskey}</u>)");
      }
    }
    Attributes2 = new Dictionary<string, object>();
    foreach (var e in AdditionalAttributes.ToList())
      Attributes2.Add(e.Key, e.Value);
    ValueSubmit = name;
    SetAttribute(Attributes2, "value", submit ? ValueSubmit : null);
    SetAttribute(Attributes2, "label", null);
    if (textarea || combobox || listbox)
      SetAttribute(Attributes2, "type", null);
    SetAttribute(Attributes2, "name", NameAttributeValue);
    if (hidden)
    {
      if (textarea || combobox || listbox)
        SetAttribute(Attributes2, "hidden", "");
      else if (submit || checkbox || radio)
      {
        SetAttribute(Attributes2, "type", canvas ? null : InputType);
        SetAttribute(Attributes2, "hidden", "");
      }
      else
        SetAttribute(Attributes2, "type", "hidden");
    }
    else
    {
      SetAttribute(Attributes2, "class", CssClass);
      SetAttribute(Attributes2, "type", canvas ? null : InputType);
      SetAttribute(Attributes2, submit || checkbox || radio || combobox || listbox ? "disabled" : "readonly", disabled ? "" : null);
      SetAttribute(Attributes2, "id", Id);
      SetAttribute(Attributes2, "accesskey", canvas ? null : Accesskey);
      SetAttribute(Attributes2, "title", Title);
      if (InputType == "text")
        SetAttribute(Attributes2, "placeholder", lbl.Replace("_", ""));
      SetAttribute(Attributes2, "rows", textarearows);
      SetAttribute(Attributes2, "cols", textareacols);
      SetAttribute(Attributes2, "multiple", multiple);
      SetAttribute(Attributes2, "onchange", onchange);
      SetAttribute(Attributes2, "autofocus", autofocus);
    }
    if (InputType == "date")
      SetAttribute(Attributes2, "value", Functions.ToString(CurrentValueAsDateTime));
    else if (currency > 0)
      SetAttribute(Attributes2, "value", Functions.ToString(CurrentValueAsDecimal, currency, Functions.CultureInfoEn));
    if (checkbox)
    {
      SetAttribute(Attributes2, "value", true.ToString());
      disabledCheckboxTrue = false;
      if (CurrentValue is Boolean cv && cv)
      {
        SetAttribute(Attributes2, "checked", "");
        disabledCheckboxTrue = disabled;
      }
    }
    if (radio)
      SetAttribute(Attributes2, "id", null);
    if (canvas)
      SetAttribute(Attributes2, "id", name);
    if (InputType == "number" && !string.IsNullOrEmpty(Step))
    {
      SetAttribute(Attributes2, "step", Step);
      SetAttribute(Attributes2, "lang", "de");
    }
  }

  private bool TryParseValueFromString(string? value, out string result, out string validationErrorMessage)
  {
    result = value ?? "";
    validationErrorMessage = "";
    return true;
  }

  private static void SetAttribute(IDictionary<string, object>? AdditionalAttributes, string key, string? value)
  {
    if (AdditionalAttributes == null)
      return;
    if (AdditionalAttributes.TryGetValue(key, out var attr))
    {
      if (value == null)
        AdditionalAttributes.Remove(key);
      else
        AdditionalAttributes[key] = value;
    }
    else if (value != null)
      AdditionalAttributes.Add(key, value);
  }
}
