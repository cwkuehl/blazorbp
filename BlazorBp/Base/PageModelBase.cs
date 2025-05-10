// <copyright file="PageModelBase.cs" company="cwkuehl.de">
// Copyright (c) cwkuehl.de. All rights reserved.
// </copyright>

namespace BlazorBp.Base;

using CSBP.Services.Base;

/// <summary>
/// Basis-Klasse für alle Models in PageModels zur Behandlung von Postbacks.
/// </summary>
[Serializable]
public class PageModelBase
{
  /// <summary>Holt oder setzt die eindeutige Nummer des Models.</summary>
  public string? Nr { get; set; } = default;

  /// <summary>Holt oder setzt den Namen des Submit-auslösenden Controls.</summary>
  ////[BindProperty(Name="submitcontrol")]
  public string? SubmitControl { get; set; } = default;

  /// <summary>Holt oder setzt den Namen der Submit-auslösenden Schaltfläche.
  /// Mit BindProperty-Attribut kann diese Klasse nicht in BlazorBp.Services.Base.
  /// Der Wert wird in Funktion GetSubmit manuell gesetzt.
  /// </summary>
  //// [BindProperty(Name="handler")]
  public string? Handler { get; set; } = default!;

  /// <summary>Holt oder setzt die Art des modalen Dialogs (Neu, Bearbeiten, Löschen).</summary>
  public string? ModalArt { get; set; }

  private string? _modalId = null;

  /// <summary>Holt oder setzt die Id im modalen Dialogs.</summary>
  public string? ModalId
  {
    get { return _modalId; }
    set
    {
      if (value == "3")
        Functions.MachNichts();
      _modalId = value;
    }
  }

  /// <summary>Holt oder setzt das Control mit dem Fokus. (Bezeichnung aus Model)</summary>
  public string? Focus { get; set; } = default;

  /// <summary>Holt oder setzt die gesperrten, versteckten oder fehlerhaften Controls.</summary>
  public string? ReadonlyHiddenError { get; set; } = default;

  /// <summary>Holt oder setzt den Namen der Submit-auslösenden Schaltfläche.</summary>
  public string? Submit
  {
    get { return string.IsNullOrWhiteSpace(SubmitControl) ?  Handler : SubmitControl; }
  }

  /// <summary>Lesen der Submit-auslösenden Schaltfläche und des Submit-Controls aus dem Request.</summary>
  /// <param name="Request">Betroffener Request.</param>
  public void GetSubmit(HttpRequest Request)
  {
    Handler ??= Request.Query["handler"];
    if (Request.Method == "POST")
    {
      SubmitControl ??= Request.Form["SubmitControl"]; // input hidden name="SubmitControl"
      SubmitControl ??= Request.Form["Model.SubmitControl"]; // SubmitButton
    }
  }

  /// <summary>Ist Steuerelement gesperrt?</summary>
  /// <param name="control">Betroffenes Steuerelement.</param>
  /// <returns>Ist das Steuerelement gesperrt?</returns>
  public bool IsReadonly(string control)
  {
    var ro = $"#{control}#R";
    return ReadonlyHiddenError?.Contains(ro) ?? false;
  }

  /// <summary>Ein Steuerelement wird gesperrt oder entsperrt, aber nicht versteckt.</summary>
  /// <param name="control">Betroffenes Steuerelement.</param>
  /// <param name="readwrite">Soll das Steuerelement geändert werden?</param>
  public void SetReadonly(string control, bool readwrite = false)
  {
    ReadonlyHiddenError ??= "";
    var ro = $"#{control}#R";
    var hd = $"#{control}#H";
    ReadonlyHiddenError = ReadonlyHiddenError.Replace(hd, "");
    if (ReadonlyHiddenError.Contains(ro))
    {
      if (readwrite)
        ReadonlyHiddenError = ReadonlyHiddenError.Replace(ro, "");
    }
    else if (!readwrite)
      ReadonlyHiddenError += ro;
  }

  /// <summary>Ein Steuerelement wird versteckt.</summary>
  /// <param name="control">Betroffenes Steuerelement.</param>
  public void SetHidden(string control)
  {
    ReadonlyHiddenError ??= "";
    var ro = $"#{control}#R";
    var hd = $"#{control}#H";
    ReadonlyHiddenError = ReadonlyHiddenError.Replace(ro, "");
    if (!ReadonlyHiddenError.Contains(hd))
      ReadonlyHiddenError += hd;
  }

  /// <summary>Einen Steuerelement werden alle Farben entfernt.</summary>
  /// <param name="control">Betroffenes Steuerelement.</param>
  public void SetNoColor(string control)
  {
    ReadonlyHiddenError ??= "";
    var c1 = $"#{control}#C1";
    var c2 = $"#{control}#C2";
    var c3 = $"#{control}#C3";
    ReadonlyHiddenError = ReadonlyHiddenError.Replace(c1, "").Replace(c2, "").Replace(c3, "");
  }

  /// <summary>Ein Steuerelement wird mit Farbe 1 versehen.</summary>
  /// <param name="control">Betroffenes Steuerelement.</param>
  public void SetColor1(string control)
  {
    ReadonlyHiddenError ??= "";
    var c1 = $"#{control}#C1";
    var c2 = $"#{control}#C2";
    var c3 = $"#{control}#C3";
    ReadonlyHiddenError = ReadonlyHiddenError.Replace(c2, "").Replace(c3, "");
    if (!ReadonlyHiddenError.Contains(c1))
      ReadonlyHiddenError += c1;
  }

  /// <summary>Ein Steuerelement wird mit Farbe 2 versehen.</summary>
  /// <param name="control">Betroffenes Steuerelement.</param>
  public void SetColor2(string control)
  {
    ReadonlyHiddenError ??= "";
    var c1 = $"#{control}#C1";
    var c2 = $"#{control}#C2";
    var c3 = $"#{control}#C3";
    ReadonlyHiddenError = ReadonlyHiddenError.Replace(c1, "").Replace(c3, "");
    if (!ReadonlyHiddenError.Contains(c2))
      ReadonlyHiddenError += c2;
  }

  /// <summary>Ein Steuerelement wird mit Farbe 3 versehen.</summary>
  /// <param name="control">Betroffenes Steuerelement.</param>
  public void SetColor3(string control)
  {
    ReadonlyHiddenError ??= "";
    var c1 = $"#{control}#C1";
    var c2 = $"#{control}#C2";
    var c3 = $"#{control}#C3";
    ReadonlyHiddenError = ReadonlyHiddenError.Replace(c1, "").Replace(c2, "");
    if (!ReadonlyHiddenError.Contains(c3))
      ReadonlyHiddenError += c3;
  }

  /// <summary>Ein Steuerelement wird als fehlerhaft gekennzeichnet.</summary>
  /// <param name="control">Betroffenes Steuerelement.</param>
  /// <param name="noerror">Soll der Fehler zurückgesetzt werden?</param>
  public void SetError(string control, bool noerror = false)
  {
    ReadonlyHiddenError ??= "";
    var er = $"#{control}#E";
    if (ReadonlyHiddenError.Contains(er))
    {
      if (noerror)
        ReadonlyHiddenError = ReadonlyHiddenError.Replace(er, "");
    }
    else if (!noerror)
      ReadonlyHiddenError += er;
  }

  /// <summary>Ein Steuerelement wird als verpflichtend gekennzeichnet.</summary>
  /// <param name="control">Betroffenes Steuerelement.</param>
  /// <param name="notmandatory">Soll die Verpflichtung zurückgesetzt werden?</param>
  public void SetMandatory(string control, bool notmandatory = false)
  {
    ReadonlyHiddenError ??= "";
    var md = $"#{control}#M";
    if (ReadonlyHiddenError.Contains(md))
    {
      if (notmandatory)
        ReadonlyHiddenError = ReadonlyHiddenError.Replace(md, "");
    }
    else if (!notmandatory)
      ReadonlyHiddenError += md;
  }

  /// <summary>Ein Steuerelement wird mit Eigenschaften versehen.</summary>
  /// <param name="control">Betroffenes Steuerelement.</param>
  /// <param name="m">Ist das Steuerelement verpflichtend?</param>
  /// <param name="h">Ist das Steuerelement versteckt?</param>
  /// <param name="ro">Ist das Steuerelement gesperrt?</param>
  /// <param name="focus">Soll das Steuerelement den Fokus erhalten?</param>
  public void SetMandatoryHiddenReadonly(string control, bool m, bool h, bool ro, bool focus = false)
  {
    SetMandatory(control, !m);
    if (h)
      SetHidden(control);
    else
      SetReadonly(control, !ro);
    if (focus)
      Focus = control;
  }
}