// <copyright file="BlazorComponent.cs" company="cwkuehl.de">
// Copyright (c) cwkuehl.de. All rights reserved.
// </copyright>

namespace BlazorBp.Core.Base;

using BlazorBp.Base;
using CSBP.Services.Base;

/// <summary>
/// Abgeleitete Klasse für alle Blazor-Formulare.
/// </summary>
public class BlazorComponent<T, V> : BlazorComponentBase<T, V>
  where T : PageModelBase where V : TableRowModelBase
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
