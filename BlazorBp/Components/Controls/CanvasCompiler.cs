// <copyright file="CanvasCompiler.cs" company="cwkuehl.de">
// Copyright (c) cwkuehl.de. All rights reserved.
// </copyright>

namespace BlazorBp.Components.Controls;

using System.Text.Json;

/// <summary>
/// Klasse für die Erstellung von Canvas-Befehlen eines Steuerelements.
/// </summary>
public class CanvasControl
{
  /// <summary>Holt oder setzt die ID des Canvas-Steuerelements, auf das die Befehle angewendet werden sollen.</summary>
  public string Canvasid { get; set; } = "";

  /// <summary>Holt oder setzt die Liste der Canvas-Befehle, die auf das Steuerelement angewendet werden sollen.</summary>
  public List<CanvasCommand> Commands { get; set; } = new();
}

/// <summary>
/// Klasse für die Erstellung eines Canvas-Befehls.
/// </summary>
public class CanvasCommand
{
  /// <summary>Holt oder setzt den Funktionsnamen des Canvas-Befehls.</summary>
  public string Cmd { get; set; } = "";

  /// <summary>Holt oder setzt die Argumente des Canvas-Befehls.</summary>
  public Dictionary<string, object>? Args { get; set; }
}

/// <summary>
/// Klasse für die Erstellung von Canvas-Befehlen für Steuerelemente.
/// Sie ermöglicht das Hinzufügen von Befehlen und die Kompilierung der Befehle in ein JSON-Format, das an die Client-Seite gesendet werden kann.
/// </summary>
public class CanvasCompiler
{
  /// <summary>Holt die Liste der Canvas-Steuerelemente, die die Befehle enthalten.</summary>
  private readonly List<CanvasControl> _controls = new();

  /// <summary>Holt oder setzt das aktuelle Canvas-Steuerelement, auf das die Befehle angewendet werden.</summary>
  private CanvasControl? _control = null;

  /// <summary>
  /// Fügt ein neues Canvas-Steuerelement mit der angegebenen ID hinzu und setzt es als aktuelles Steuerelement, auf das die Befehle angewendet werden.
  /// </summary>
  /// <param name="id">Betroffene Steuerelement-ID</param>
  /// <returns>Eigene Instanz für Methoden-Chaining.</returns>
  public CanvasCompiler AddControl(string id)
  {
    _control = new CanvasControl { Canvasid = id };
    _controls.Add(_control);
    return this;
  }

  /// <summary>
  /// Fügt einen Befehl zum Setzen der Füllfarbe für das aktuelle Canvas-Steuerelement hinzu.
  /// </summary>
  /// <param name="color">Die Füllfarbe als String.</param>
  /// <returns>Eigene Instanz für Methoden-Chaining.</returns>
  public CanvasCompiler SetFillStyle(string color)
  {
    _control?.Commands.Add(new CanvasCommand
    {
      Cmd = "setFillStyle",
      Args = new() { ["color"] = color }
    });
    return this;
  }

  /// <summary>
  /// Fügt einen Befehl zum Zeichnen eines ausgefüllten Rechtecks für das aktuelle Canvas-Steuerelement hinzu.
  /// </summary>
  /// <param name="x">Die x-Koordinate des Rechtecks.</param>
  /// <param name="y">Die y-Koordinate des Rechtecks.</param>
  /// <param name="w">Die Breite des Rechtecks.</param>
  /// <param name="h">Die Höhe des Rechtecks.</param>
  /// <returns>Eigene Instanz für Methoden-Chaining.</returns>
  public CanvasCompiler FillRect(int x, int y, int w, int h)
  {
    _control?.Commands.Add(new CanvasCommand
    {
      Cmd = "fillRect",
      Args = new() { ["x"] = x, ["y"] = y, ["w"] = w, ["h"] = h }
    });
    return this;
  }

  /// <summary>
  /// Fügt einen Befehl zum Zeichnen eines umrandeten Rechtecks für das aktuelle Canvas-Steuerelement hinzu.
  /// </summary>
  /// <param name="x">Die x-Koordinate des Rechtecks.</param>
  /// <param name="y">Die y-Koordinate des Rechtecks.</param>
  /// <param name="w">Die Breite des Rechtecks.</param>
  /// <param name="h">Die Höhe des Rechtecks.</param>
  /// <returns>Eigene Instanz für Methoden-Chaining.</returns>
  public CanvasCompiler StrokeRect(int x, int y, int w, int h)
  {
    _control?.Commands.Add(new CanvasCommand
    {
      Cmd = "strokeRect",
      Args = new() { ["x"] = x, ["y"] = y, ["w"] = w, ["h"] = h }
    });
    return this;
  }

  /// <summary>
  /// Fügt einen Befehl zum Zeichnen von Text für das aktuelle Canvas-Steuerelement hinzu.
  /// </summary>
  /// <param name="text">Der Text, der gezeichnet werden soll.</param>
  /// <param name="x">Die x-Koordinate des Textes.</param>
  /// <param name="y">Die y-Koordinate des Textes.</param>
  /// <returns>Eigene Instanz für Methoden-Chaining.</returns>
  public CanvasCompiler FillText(string text, int x, int y)
  {
    _control?.Commands.Add(new CanvasCommand
    {
      Cmd = "fillText",
      Args = new() { ["text"] = text, ["x"] = x, ["y"] = y }
    });
    return this;
  }

  /// <summary>
  /// Fügt einen Befehl zum Setzen der Strichfarbe für das aktuelle Canvas-Steuerelement hinzu.
  /// </summary>
  /// <param name="color">Die Strichfarbe als String.</param>
  /// <returns>Eigene Instanz für Methoden-Chaining.</returns>
  public CanvasCompiler SetStrokeStyle(string color)
  {
    _control?.Commands.Add(new CanvasCommand
    {
      Cmd = "setStrokeStyle",
      Args = new() { ["color"] = color }
    });
    return this;
  }

  /// <summary>
  /// Startet einen Pfad für das aktuelle Canvas-Steuerelement.
  /// </summary>
  /// <returns>Eigene Instanz für Methoden-Chaining.</returns>
  public CanvasCompiler BeginPath()
  {
    _control?.Commands.Add(new CanvasCommand
    {
      Cmd = "beginPath",
      Args = new()
    });
    return this;
  }

  /// <summary>
  /// Bewegt den aktuellen Pfad zum angegebenen Punkt.
  /// </summary>
  /// <param name="x">Die x-Koordinate des Punktes.</param>
  /// <param name="y">Die y-Koordinate des Punktes.</param>
  /// <returns>Eigene Instanz für Methoden-Chaining.</returns>
  public CanvasCompiler MoveTo(decimal x, decimal y)
  {
    _control?.Commands.Add(new CanvasCommand
    {
      Cmd = "moveTo",
      Args = new() { ["x"] = x, ["y"] = y }
    });
    return this;
  }

  /// <summary>
  /// Zeichnet eine Linie vom aktuellen Pfad zum angegebenen Punkt.
  /// </summary>
  /// <param name="x">Die x-Koordinate des Punktes.</param>
  /// <param name="y">Die y-Koordinate des Punktes.</param>
  /// <returns>Eigene Instanz für Methoden-Chaining.</returns>
  public CanvasCompiler LineTo(decimal x, decimal y)
  {
    _control?.Commands.Add(new CanvasCommand
    {
      Cmd = "lineTo",
      Args = new() { ["x"] = x, ["y"] = y }
    });
    return this;
  }

  /// <summary>
  /// Zeichnet den aktuellen Pfad für das aktuelle Canvas-Steuerelement.
  /// </summary>
  /// <returns>Eigene Instanz für Methoden-Chaining.</returns>
  public CanvasCompiler Stroke()
  {
    _control?.Commands.Add(new CanvasCommand
    {
      Cmd = "stroke",
      Args = new()
    });
    return this;
  }

  /// <summary>
  /// Fügt einen Befehl zum Setzen der Schriftart für das aktuelle Canvas-Steuerelement hinzu.
  /// </summary>
  /// <param name="font">Die Schriftart als String, z.B. bold 40px Arial.</param>
  /// <returns>Eigene Instanz für Methoden-Chaining.</returns>
  public CanvasCompiler SetFont(string font)
  {
    _control?.Commands.Add(new CanvasCommand
    {
      Cmd = "setFont",
      Args = new() { ["font"] = font }
    });
    return this;
  }

  /// <summary>
  /// Dreht das aktuelle Canvas-Steuerelement um den angegebenen Winkel.
  /// </summary>
  /// <param name="angle">Der Winkel in Radiant.</param>
  /// <returns>Eigene Instanz für Methoden-Chaining.</returns>
  public CanvasCompiler Rotate(decimal angle)
  {
    _control?.Commands.Add(new CanvasCommand
    {
      Cmd = "rotate",
      Args = new() { ["angle"] = angle }
    });
    return this;
  }

  /// <summary>
  /// zeichnet einen Bogen zum angegebenen Punkt mit dem aktuellen Pfad für das aktuelle Canvas-Steuerelement.
  /// </summary>
  /// <param name="x">Die x-Koordinate des Punktes.</param>
  /// <param name="y">Die y-Koordinate des Punktes.</param>
  /// <param name="radius">Der Radius des Bogens.</param>
  /// <param name="startangle">Der Startwinkel des Bogens in Radiant.</param>
  /// <param name="endangle">Der Endwinkel des Bogens in Radiant.</param>
  /// <param name="anticlockwise">Gibt an, ob der Bogen im Uhrzeigersinn oder gegen den Uhrzeigersinn gezeichnet wird.</param>
  /// <returns>Eigene Instanz für Methoden-Chaining.</returns>
  public CanvasCompiler Arc(decimal x, decimal y, decimal radius, decimal startangle, decimal endangle, bool anticlockwise = false)
  {
    _control?.Commands.Add(new CanvasCommand
    {
      Cmd = "arc",
      Args = new() { ["x"] = x, ["y"] = y, ["radius"] = radius, ["startangle"] = startangle, ["endangle"] = endangle, ["anticlockwise"] = anticlockwise }
    });
    return this;
  }

  /// <summary>
  /// Kompiliert die hinzugefügten Befehle in ein JSON-Format, das an die Client-Seite gesendet werden kann.
  /// </summary>
  /// <returns>Die JSON-Serialisierung der Canvas-Steuerelemente mit ihren Befehlen.</returns>
  public string Compile()
  {
    return JsonSerializer.Serialize(_controls);
  }
}
