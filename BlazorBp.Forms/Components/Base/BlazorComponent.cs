// <copyright file="BlazorComponent.cs" company="cwkuehl.de">
// Copyright (c) cwkuehl.de. All rights reserved.
// </copyright>

namespace BlazorBp.Forms.Components.Base;

using BlazorSpa.Core.Base;
using CSBP.Services.Base;

/// <summary>
/// Abgeleitete Klasse für alle Blazor-Formulare.
/// </summary>
/// <typeparam name="T">Typ des Models.</typeparam>
/// <typeparam name="TV">Typ des Table-Models.</typeparam>
public class BlazorComponent<T, TV> : BlazorComponentBase<T, TV>
  where T : PageModelBase
  where TV : TableRowModelBase
{
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
}
