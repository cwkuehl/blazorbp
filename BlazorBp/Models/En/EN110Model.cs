// <copyright file="EN110Model.cs" company="cwkuehl.de">
// Copyright (c) cwkuehl.de. All rights reserved.
// </copyright>

namespace BlazorBp.Models.En;

using System.ComponentModel.DataAnnotations;
using BlazorBp.Base;
using CSBP.Services.Apis.Models;
using CSBP.Services.Base;
using static BlazorBp.Base.DialogTypeEnum;

/// <summary>
/// Model-Klasse für das modale Formular EN110 Abfrage-Parameter.
/// </summary>
[Serializable]
public class EN110Model : PageModelBase
{
  /// <summary>Holt oder setzt Nr..</summary>
  [Display(Name = "Nr.", Description = "Abfrage-Nr.")]
  //// [Required(ErrorMessage = "Nr. muss angegeben werden.")]
  public string? Nummer { get; set; }

  /// <summary>Holt oder setzt Bezeichnung.</summary>
  [Display(Name = "_Bezeichnung", Description = "Bezeichnung")]
  [Required(ErrorMessage = "Bezeichnung muss angegeben werden.")]
  [MaxLength(255, ErrorMessage = "Bezeichnung darf maximal {1} Zeichen lang sein.")]
  public string? Bezeichnung { get; set; }

  /// <summary>Holt oder setzt die Sortierung.</summary>
  [Display(Name = "_Sortierung", Description = "Sortierung")]
  [Required(ErrorMessage = "Sortierung muss angegeben werden.")]
  [MaxLength(10, ErrorMessage = "Sortierung darf maximal {1} Zeichen lang sein.")]
  public string? Sortierung { get; set; }

  /// <summary>Holt oder setzt die Auswahlliste von Art.</summary>
  public List<ListItem>? AuswahlArt { get; set; } = default!;

  /// <summary>Holt oder setzt die Art.</summary>
  [Display(Name = "_Art", Description = "Art der Abfrage, z.B. Modbus-Tcp oder JSON.")]
  [Required(ErrorMessage = "Art muss angegeben werden.")]
  public string? Art { get; set; }

  /// <summary>Holt oder setzt Host-URL.</summary>
  [Display(Name = "Host-URL", Description = "Host:Port für Modbus-TCP oder URL für JSON.")]
  [Required(ErrorMessage = "Host-URL muss angegeben werden.")]
  [MaxLength(255, ErrorMessage = "Host-URL darf maximal {1} Zeichen lang sein.")]
  public string? HostUrl { get; set; }

  /// <summary>Holt oder setzt die Auswahlliste von Datentyp.</summary>
  public List<ListItem>? AuswahlDatentyp { get; set; } = default!;

  /// <summary>Holt oder setzt den Datentyp.</summary>
  [Display(Name = "_Datentyp", Description = "Datentyp der Abfrage.")]
  [Required(ErrorMessage = "Datentyp muss angegeben werden.")]
  public string? Datentyp { get; set; }

  /// <summary>Holt oder setzt die Aufzählung.</summary>
  [Display(Name = "_Aufzählung", Description = "Aufzählung der möglichen Werte als Text im Format '1=Text1;2=Text2;3=Text3'.")]
  [MaxLength(240, ErrorMessage = "Aufzählung darf maximal {1} Zeichen lang sein.")]
  public string? Enum { get; set; }

  /// <summary>Holt oder setzt die Schreibbarkeit.</summary>
  [Display(Name = "Schreibbar_keit", Description = "Schreibbarkeit des Wertes.")]
  //// [Required(ErrorMessage = "Schreibbarkeit muss angegeben werden.")]
  public bool Schreibbarkeit { get; set; }

  /// <summary>Holt oder setzt die Einheit.</summary>
  [Display(Name = "_Einheit", Description = "Einheit des Wertes.")]
  [MaxLength(50, ErrorMessage = "Einheit darf maximal {1} Zeichen lang sein.")]
  public string? Einheit { get; set; }

  /// <summary>Holt oder setzt den Param1.</summary>
  [Display(Name = "Param_1", Description = "UnitID bei Modbus, z.B. 1; Start-Muster bei JSON.")]
  [Required(ErrorMessage = "Parameter 1 muss angegeben werden.")]
  [MaxLength(50, ErrorMessage = "Parameter 1 darf maximal {1} Zeichen lang sein.")]
  public string? Param1 { get; set; }

  /// <summary>Holt oder setzt den Param2.</summary>
  [Display(Name = "Param_2", Description = "Registeradresse bei Modbus, z.B. 1004; Ende-Muster bei JSON.")]
  [Required(ErrorMessage = "Parameter 2 muss angegeben werden.")]
  [MaxLength(50, ErrorMessage = "Parameter 2 darf maximal {1} Zeichen lang sein.")]
  public string? Param2 { get; set; }

  /// <summary>Holt oder setzt den Param3.</summary>
  [Display(Name = "Param_3", Description = "Anzahl bei Modbus, meist 1 für 2 Bytes; unbenutzt bei JSON.")]
  [MaxLength(50, ErrorMessage = "Parameter 3 darf maximal {1} Zeichen lang sein.")]
  public string? Param3 { get; set; }

  /// <summary>Holt oder setzt den Param4.</summary>
  [Display(Name = "Param_4", Description = "Faktor für Werte bei Modbus, z.B. 0,1 für 1/10; unbenutzt bei JSON.")]
  [MaxLength(50, ErrorMessage = "Parameter 4 darf maximal {1} Zeichen lang sein.")]
  public string? Param4 { get; set; }

  /// <summary>Holt oder setzt den Param5.</summary>
  [Display(Name = "Param_5", Description = "Formatierung des Werts, z.B. N, N1, N2, unbenutzt bei JSON.")]
  [MaxLength(50, ErrorMessage = "Parameter 5 darf maximal {1} Zeichen lang sein.")]
  public string? Param5 { get; set; }

  /// <summary>Holt oder setzt die Auswahlliste von Status.</summary>
  public List<ListItem>? AuswahlStatus { get; set; } = default!;

  /// <summary>Holt oder setzt Status.</summary>
  [Display(Name = "_Status", Description = "Status für Berechnung")]
  [Required(ErrorMessage = "Status muss angegeben werden.")]
  public string? Status { get; set; }

  /// <summary>Holt oder setzt Notiz.</summary>
  [Display(Name = "Notiz", Description = "")]
  public string? Notiz { get; set; }

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
  /// <param name="daten">Service-Daten für den Datenbankzugriff.</param>
  /// <returns>Das kopierte Model.</returns>
  public EnAbfrage To(ServiceDaten daten) => new()
  {
    Mandant_Nr = daten.MandantNr,
    Uid = Nummer,
    Bezeichnung = Bezeichnung,
    Sortierung = Sortierung,
    Art = Art,
    Host_Url = HostUrl,
    SplitDatatype = (Datentyp, Enum),
    Schreibbarkeit = Schreibbarkeit ? "RW" : "R",
    Einheit = Einheit,
    Param1 = Param1,
    Param2 = Param2,
    Param3 = Param3,
    Param4 = Param4,
    Param5 = Param5,
    Status = Status,
    Notiz = Notiz,
  };

  /// <summary>Kopiert die Werte aus einem Model.</summary>
  /// <param name="m">Zu kopierendes Model.</param>
  public void From(EnAbfrage m)
  {
    var parts = m.SplitDatatype;
    (
      Nummer,
      Bezeichnung,
      Sortierung,
      Art,
      HostUrl,
      Datentyp,
      Enum,
      Schreibbarkeit,
      Einheit,
      Param1,
      Param2,
      Param3,
      Param4,
      Param5,
      Status,
      Notiz,
      Angelegt,
      Geaendert
    ) = (
      m.Uid,
      m.Bezeichnung,
      m.Sortierung,
      m.Art,
      m.Host_Url,
      parts.Datatype,
      parts.Enum,
      m.Schreibbarkeit != null && m.Schreibbarkeit.Contains("W"),
      m.Einheit,
      m.Param1,
      m.Param2,
      m.Param3,
      m.Param4,
      m.Param5,
      m.Status,
      m.Notiz,
      ModelBase.FormatDateOf(m.Angelegt_Am, m.Angelegt_Von),
      ModelBase.FormatDateOf(m.Geaendert_Am, m.Geaendert_Von)
    );
  }

  /// <summary>Setzt die Werte und Modi für das Model.</summary>
  /// <param name="mode">Betroffener Modus.</param>
  public void SetMhrf(DialogTypeEnum mode)
  {
    if (mode == New || mode == Copy)
    {
      Nummer = "";
    }
    SetMandatoryHiddenReadonly(nameof(Nummer), false, false, true, false);
    SetMandatoryHiddenReadonly(nameof(Bezeichnung), true, false, mode == Delete, mode != New);
    SetMandatoryHiddenReadonly(nameof(Sortierung), true, false, mode == Delete, false);
    SetMandatoryHiddenReadonly(nameof(Art), true, false, mode == Delete, false);
    SetMandatoryHiddenReadonly(nameof(HostUrl), true, false, mode == Delete, false);
    SetMandatoryHiddenReadonly(nameof(Datentyp), true, false, mode == Delete, false);
    SetMandatoryHiddenReadonly(nameof(Schreibbarkeit), false, false, mode == Delete, false);
    SetMandatoryHiddenReadonly(nameof(Einheit), false, false, mode == Delete, false);
    SetMandatoryHiddenReadonly(nameof(Param1), true, false, mode == Delete, false);
    SetMandatoryHiddenReadonly(nameof(Param2), true, false, mode == Delete, false);
    SetMandatoryHiddenReadonly(nameof(Param3), false, false, mode == Delete, false);
    SetMandatoryHiddenReadonly(nameof(Param4), false, false, mode == Delete, false);
    SetMandatoryHiddenReadonly(nameof(Param5), false, false, mode == Delete, false);
    SetMandatoryHiddenReadonly(nameof(Status), true, false, mode == Delete, false);
    SetMandatoryHiddenReadonly(nameof(Notiz), false, false, mode == Delete, false);
    SetMandatoryHiddenReadonly(nameof(Angelegt), false, mode == New, true);
    SetMandatoryHiddenReadonly(nameof(Geaendert), false, mode == New, true);
    SetMandatoryHiddenReadonly(nameof(Ok), false, false, false, mode == Delete);
  }
}
