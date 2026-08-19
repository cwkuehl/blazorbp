// <copyright file="ChartPane.cs" company="cwkuehl.de">
// Copyright (c) cwkuehl.de. All rights reserved.
// </copyright>

namespace BlazorBp.Components.Controls;

using System;
using CSBP.Services.Base;
using CSBP.Services.Pnf;

/// <summary>
/// Functions for drawing charts.
/// </summary>
public class ChartPane
{
  /// <summary>
  /// Initializes a new instance of the <see cref="ChartPane"/> class.
  /// </summary>
  public ChartPane()
  {
    Functions.MachNichts();
  }

  /// <summary>Draws a Point and Figure charts.</summary>
  /// <param name="c">Affected chart.</param>
  /// <param name="pc">Affected context.</param>
  /// <param name="w0">Affected start x coordinate.</param>
  /// <param name="h0">Affected start y coordinate.</param>
  /// <param name="ww">Affected window width.</param>
  /// <param name="wh">Affected window height.</param>
  public static void DrawChart(PnfChart c, CanvasCompiler pc, int w0, int h0, int ww, int wh)
  {
    decimal xgroesse = c.Xgroesse;
    decimal ygroesse = c.Ygroesse;
    decimal max = c.Posmax;
    var xoffset = xgroesse * 1.5m;
    var yoffset = ygroesse * 3.2m;
    decimal xanzahl = c.Saeulen.Count;
    decimal yanzahl = c.Werte.Count;
    var white = "white";
    var black = "black";
    var red = "red";
    var blue = "blue";
    var green = "green";
    var lightgray = "#D3D3D3";
    var darkviolet = "#9400D3";
    var color = black;

    // Schriftgrößen
    var fontx = $"normal {(int)(ygroesse / 1.0m)}px Times Roman";
    // var fontx2 = $"normal {(int)(ygroesse * 2)}px Times Roman";
    var fontplain = $"normal {(int)(ygroesse / 1.5m)}px Times Roman";
    var fontbold = $"bold {(int)(ygroesse / 1.3m)}px Times Roman";
    var font = fontplain;

    // Hintergrund zeichnen
    pc.SetFillStyle(white);
    pc.FillRect(w0, h0, ww, wh);

    // Columns
    Diagram.DrawString(pc, xoffset, ygroesse * 0.9m, c.Bezeichnung, font, color);
    Diagram.DrawString(pc, xoffset, ygroesse * 1.8m, c.GetBezeichnung2(), font, color);
    var b = xoffset + xgroesse;
    decimal x;
    decimal y;
    decimal h;
    foreach (var s in c.Saeulen)
    {
      h = s.Ypos;
      var array = s.Chars;
      foreach (var xo in array)
      {
        x = b;
        y = ((max - h) * ygroesse) + yoffset;
        if (xo == 'O')
        {
          color = red;
          Diagram.DrawString(pc, x + 1, y - 1, "O", fontx, color);
        }
        else if (xo == 'X')
        {
          color = green;
          Diagram.DrawString(pc, x + 1, y - 1, "X", fontx, color);
        }
        else
        {
          color = black;
          Diagram.DrawString(pc, x + 1, y - 1, xo.ToString(), fontx, color);
        }
        h += 1;
      }
      b += xgroesse;
    }

    // Werte schreiben
    color = lightgray;
    //// gc.SetLineAttributes(1, LineStyle.Solid, CapStyle.Butt, JoinStyle.Bevel);
    x = xoffset + ((xanzahl + 2) * xgroesse);
    y = yoffset + (yanzahl * ygroesse);
    var aktkurs = c.Kurs;
    var iakt = -1;
    var yakt = -1m;
    if (Functions.CompDouble4(aktkurs, 0) > 0)
    {
      var d = c.Max + 1;
      for (int i = 0; i < yanzahl; i++)
      {
        if (Functions.CompDouble4(c.Werte[i], d) < 0
                && Functions.CompDouble4(c.Werte[i], aktkurs) > 0)
        {
          d = c.Werte[i];
          iakt = i;
        }
      }
    }
    for (int i = 0; i < yanzahl + 1; i++)
    {
      if (i < yanzahl)
      {
        if (i == iakt)
        {
          color = black;
          Diagram.DrawString(pc, x + 5, y - ygroesse, Functions.ToString(Functions.Round(aktkurs), 2), fontbold, color);
          color = lightgray;
          yakt = y;
        }
        else
        {
          Diagram.DrawString(pc, x + 5, y - ygroesse, Functions.ToString(Functions.Round(c.Werte[i]), 2), font, color);
        }
      }
      //// Horizontal lines
      Diagram.DrawLine(pc, xoffset, y, x, y, color);
      y -= ygroesse;
    }

    // Writes dates.
    x = xoffset;
    y = yoffset + (yanzahl * ygroesse);
    for (int i = 0; i < xanzahl + 3; i++)
    {
      // Vertical lines.
      Diagram.DrawLine(pc, x, yoffset, x, y);
      if (i % 6 == 0 && i < xanzahl && c.Saeulen[i].Date != null)
      {
        Diagram.DrawString(pc, x + xgroesse, y + (ygroesse * 0.5m), Functions.ToString(c.Saeulen[i].Date), font, color);
      }
      x += xgroesse;
    }

    // Trend lines
    foreach (var t in c.Trends)
    {
      x = ((t.Xpos + 1) * xgroesse) + xoffset;
      y = ((max - t.Ypos) * ygroesse) + yoffset;
      b = t.Laenge * xgroesse;
      if (t.Boxtype == 0)
      {
        b += xgroesse;
        h = 0;
        color = red;
      }
      else if (t.Boxtype == 1)
      {
        h = -t.Laenge * ygroesse;
        color = blue;
      }
      else
      {
        h = t.Laenge * ygroesse;
        y += ygroesse;
        color = blue;
      }
      Diagram.DrawLine(pc, x, y, x + b, y + h, color);
    }

    // Pattern
    color = darkviolet;
    foreach (var pa in c.Pattern)
    {
      x = ((pa.Xpos + 2) * xgroesse) + xoffset;
      y = ((max - pa.Ypos) * ygroesse) + yoffset;
      if (yakt >= 0)
      {
        if (Math.Abs(y - yakt) < ygroesse)
        {
          y -= ygroesse; // Moves up
          if (y < 0)
            y += ygroesse * 2; // Moves down
        }
      }
      Diagram.DrawString(pc, x, y - ygroesse, pa.Bezeichnung, font, color);
    }
  }

  /// <summary>Handles Diagram.</summary>
  /// <param name="pc">Affected context.</param>
  /// <param name="c">Affected chart.</param>
  /// <param name="w">Affected window width.</param>
  /// <param name="h">Affected window height.</param>
  public static void OnChartDraw(CanvasCompiler pc, PnfChart c, int w = 400, int h = 600)
  {
    if (pc == null || c == null)
      return;
    DrawChart(c, pc, 0, 0, w, h);
  }
}
