// <copyright file="Diagram.cs" company="cwkuehl.de">
// Copyright (c) cwkuehl.de. All rights reserved.
// </copyright>

namespace BlazorBp.Components.Controls;

using System;
using System.Collections.Generic;
using System.Linq;
using CSBP.Services.Base;


/// <summary>
/// Function for drawing a diagram.
/// </summary>
public class Diagram
{
  /// <summary>
  /// Initializes a new instance of the <see cref="Diagram"/> class.
  /// </summary>
  public Diagram()
  {
    Functions.MachNichts();
  }

  /// <summary>Draws a diagram.</summary>
  /// <param name="name1">Affected name for values.</param>
  /// <param name="c1">Affected values.</param>
  /// <param name="pc">Affected context.</param>
  /// <param name="w0">Affected diagram width.</param>
  /// <param name="h0">Affected diagram height.</param>
  /// <param name="ww">Affected window width.</param>
  /// <param name="wh">Affected window height.</param>
  /// <param name="name2">Optinal additional information.</param>
  /// <param name="name3">Optinal additional second information.</param>
  public static void Draw(string name1, List<KeyValuePair<string, decimal>> c1, CanvasCompiler pc,
   int w0, int h0, int ww, int wh, string? name2 = null, string? name3 = null)
  {
    var c = c1;
    if (c == null || c.Count <= 1)
      return;
    //// Assumption: Werte >= 0
    decimal xanzahl = c.Count;
    var ymin = c.Min(a => a.Value);
    var ymax = c.Max(a => a.Value);
    if (ymax == ymin)
      ymax++;
    var diff = ymax - ymin;
    var stellen = (decimal)Math.Pow(10, Math.Max(1, Math.Floor(Math.Log10((double)diff))));
    ymin = Math.Floor(ymin / stellen) * stellen;
    ymax = Math.Ceiling(ymax / stellen) * stellen;
    diff = ymax - ymin;
    decimal xgroesse = (ww + wh) / 50; // Box size
    decimal ygroesse = (ww + wh) / 50;
    decimal xlegende = xgroesse * (decimal)Math.Log10((double)diff) / 1.5m; // Legende waagerecht rechts
    decimal ylegende = ygroesse; // Legende waagerecht unten
    var xoffset = xgroesse * 0.5m;
    var yoffset = ygroesse * 0.2m;
    var xstep = (ww - (xoffset * 2) - xlegende) / (c.Count - 1);
    var ystep = (wh - (yoffset * 2) - ylegende) / diff;

    // Farben
    var black = "black";
    var white = "white";
    var red = "red";
    ////var blue = "blue";
    ////var green = "green";
    var lightgray = "#D3D3D3";
    var darkviolet = "#9400D3";

    // Schriftgrößen
    var fontx = $"normal {(int)(ygroesse / 1.0m)}px Times Roman";
    var fontx2 = $"normal {(int)(ygroesse * 2)}px Times Roman";
    var fontplain = $"normal {(int)(ygroesse / 1.5m)}px Times Roman";
    var fontbold = $"bold {(int)(ygroesse / 1.3m)}px Times Roman";
    var font = fontplain;

    // Hintergrund zeichnen
    pc.SetFillStyle(white);
    pc.FillRect(w0, h0, ww, wh);

    var xl = w0 + xoffset;
    var yl = -1m;
    var xl2 = w0 + ww - xoffset - xlegende;
    var yl2 = -1m;
    var val = ymax;

    // Right vertical lines
    DrawLine(pc, w0 + ww - xoffset - xlegende, h0 + yoffset, w0 + ww - xoffset - xlegende, h0 + wh - yoffset - ylegende, lightgray);
    while (val >= ymin)
    {
      yl = (decimal)h0 + (decimal)wh - yoffset - ylegende - ((val - ymin) * ystep);
      //// waagerechte Gitterlinie mit y-Wert
      DrawLine(pc, xl, yl, xl2, yl, lightgray);
      DrawString(pc, xl2 + yoffset, yl + (ygroesse / 3), Functions.ToString(val, 0), fontplain, black);
      val -= stellen;
    }
    xl = -1m;
    yl = -1m;
    xl2 = w0 + xoffset - xstep;
    yl2 = -1m;
    var xbez = w0 + xoffset;
    foreach (var v in c)
    {
      xl2 += (decimal)xstep;
      yl2 = (decimal)h0 + (decimal)wh - yoffset - ylegende - ((v.Value - ymin) * ystep);
      if (xl2 >= xbez && xl2 <= w0 + ww - xoffset - (v.Key.Length * xgroesse / 2.5m))
      {
        // senkrechte Gitterlinie mit x-Wert
        DrawLine(pc, xl2, h0 + yoffset, xl2, h0 + wh - yoffset - ylegende, lightgray);
        DrawString(pc, xl2, h0 + wh - yoffset, v.Key, fontplain, black);
        xbez += v.Key.Length * xgroesse / 2m;
      }
      if (xl != -1)
        DrawLine(pc, xl, yl, xl2, yl2, red);
      DrawCircle(pc, xl2, yl2, 2, red);
      xl = xl2;
      yl = yl2;
    }
    DrawString(pc, w0 + (xoffset * 2), h0 + yoffset + ylegende, name1, fontx, red);
    if (!string.IsNullOrEmpty(name2) || !string.IsNullOrEmpty(name3))
    {
      if (!string.IsNullOrEmpty(name2))
        DrawString(pc, w0 + (xoffset * 2), h0 + (yoffset * 10) + ylegende, name2, fontx2, darkviolet);
      if (!string.IsNullOrEmpty(name3))
        DrawString(pc, w0 + (xoffset * 2), h0 + (yoffset * 19) + ylegende, name3, fontx2, darkviolet);
    }
  }

  /// <summary>
  /// Draws a string.
  /// </summary>
  /// <param name="pc">Affected context.</param>
  /// <param name="x">Affected x coordinate.</param>
  /// <param name="y">Affected y coordinate.</param>
  /// <param name="str">Affectd string.</param>
  /// <param name="font">Affected font.</param>
  /// <param name="color">Affected color.</param>
  /// <param name="vertikal">Is it a vertical text or not.</param>
  private static void DrawString(CanvasCompiler pc, decimal x, decimal y, string str,
      string? font = null, string? color = null, bool vertikal = false)
  {
    // Position links unten
    if (string.IsNullOrEmpty(str))
      return;
    if (color != null)
      pc.SetFillStyle(color);
    if (font != null)
      pc.SetFont(font);
    if (vertikal)
      pc.Rotate((decimal)-Math.PI / 2); // Drehe den Canvas um -90 Grad (vertikal)
    pc.FillText(str, (int)x, (int)y);
  }

  /// <summary>
  /// Draws a line.
  /// </summary>
  /// <param name="pc">Affected context.</param>
  /// <param name="x">Affected x coordinate.</param>
  /// <param name="y">Affected y coordinate.</param>
  /// <param name="x2">Affected x2 coordinate of target.</param>
  /// <param name="y2">Affected yy coordinate or target.</param>
  /// <param name="color">Affected color.</param>
  private static void DrawLine(CanvasCompiler pc, decimal x, decimal y, decimal x2, decimal y2, string? color = null)
  {
    // Position links oben
    if (color != null)
      pc.SetStrokeStyle(color);
    pc.BeginPath();
    pc.MoveTo((int)x, (int)y);
    pc.LineTo((int)x2, (int)y2);
    pc.Stroke();
  }

  /// <summary>
  /// Draws a circle.
  /// </summary>
  /// <param name="pc">Affected context.</param>
  /// <param name="x">Affected x coordinate.</param>
  /// <param name="y">Affected y coordinate.</param>
  /// <param name="radius">Affected radius.</param>
  /// <param name="color">Affected color.</param>
  private static void DrawCircle(CanvasCompiler pc, decimal x, decimal y, int radius, string? color = null)
  {
    // Position links oben
    if (color != null)
      pc.SetFillStyle(color);
    pc.MoveTo((int)x, (int)y);
    pc.Arc((int)x, (int)y, radius, 0, (decimal)(2 * Math.PI));
    pc.Stroke();
  }

  /// <summary>Handles Diagram.</summary>
  /// <param name="pc">Affected context.</param>
  /// <param name="label">Affected label.</param>
  /// <param name="list">Affected list.</param>
  /// <param name="label2">Affected second label.</param>
  /// <param name="label3">Affected third label.</param>
  public static void OnDiagramaDraw(CanvasCompiler pc, string label, List<KeyValuePair<string, decimal>>? list, string? label2 = null, string? label3 = null)
  {
    if (list == null)
      return;
    var w = 400; // da.Window.Width;
    var h = 200; // da.Window.Height;
    Diagram.Draw(label, list, pc, 0, 0, w, h, label2, label3);
  }
}
