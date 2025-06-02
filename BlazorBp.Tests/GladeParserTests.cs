using GladeBlazor;

namespace BlazorBp.Tests;

public class GladeParserTests
{
  [Fact]
  public void GenerateBlazor()
  {
    // Generator.Generate(@"/home/wolfgang/cs/csbp/CSBP/GtkGui/AM/AM000Login.glade", null, "/home/wolfgang/cs/csbp/CSBP.Services/Resources/Messages.de.resx", "/home/wolfgang/cs/blazorbp/BlazorBp");
    Generator.Generate(@"/home/wolfgang/cs/csbp/CSBP/GtkGui/FZ/FZ200Bikesxxx.glade", @"/home/wolfgang/cs/csbp/CSBP/GtkGui/FZ/FZ210Bike.glade", "/home/wolfgang/cs/csbp/CSBP.Services/Resources/Messages.de.resx", "/home/wolfgang/cs/blazorbp/BlazorBp");
  }
}
