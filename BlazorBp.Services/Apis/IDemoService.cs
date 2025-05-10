// <copyright file="IDemoService.cs" company="cwkuehl.de">
// Copyright (c) cwkuehl.de. All rights reserved.
// </copyright>

namespace BlazorBp.Services.Apis;

using BlazorBp.Services.Models;
using CSBP.Services.Base;

/// <summary>
/// Interface für DemoService.
/// </summary>
public interface IDemoService
{
  /// <summary>
  /// Liefert ein Buch.
  /// </summary>
  /// <param name="id">Betroffene ID.</param>
  /// <returns></returns> <summary>
  Book? GetBook(int id);

  /// <summary>
  /// Liefert eine Liste aller Bücher.
  /// </summary>
  /// <param name="filter">Betroffener Filter.</param>
  /// <returns>Liste aller Bücher.</returns>
  List<Book> GetBookList(string? filter = null);

  /// <summary>
  /// Speichern eines Buches.
  /// </summary>
  /// <param name="b">Betroffenes Buch.</param>
  void SaveBook(Book b);

  /// <summary>
  /// Liefert eine Liste aller Objekte.
  /// </summary>
  /// <param name="m">Betroffene Filterung und Sortierung.</param>
  /// <returns>Liste aller Objekte.</returns>
  List<Objekt> GetObjektList(TableReadModel? m = null);

  /// <summary>
  /// Speichern eines Objekts.
  /// </summary>
  /// <param name="o">Betroffenes Objekt.</param>
  /// <returns>Evtl. Fehlermeldungen.</returns>
  ServiceErgebnis SaveObjekt(Objekt o);

  /// <summary>
  /// Löschen eines Objekts.
  /// </summary>
  /// <param name="o">Betroffenes Objekt.</param>
  /// <returns>Evtl. Fehlermeldungen.</returns>
  ServiceErgebnis DeleteObjekt(Objekt o);

  /// <summary>
  /// Liefert eine CSV-Datei mit allen Datensätze des betroffenen Formulars.
  /// </summary>
  /// <param name="page">Betroffenes Formular.</param>
  /// <param name="rm">Betroffene Filterung und Sortierung.</param>
  /// <returns>CSV-Datei als String.</returns>
  string GetCsvString(string page, TableReadModel? rm = null);

  /// <summary>
  /// Speichern aller Objekte aus einer CSV-Datei.
  /// </summary>
  /// <param name="fn">Betroffener Dateiname der CSV-Datei.</param>
  /// <returns>Evtl. Fehlermeldungen.</returns>
  ServiceErgebnis SaveObjektList(string s);
}
