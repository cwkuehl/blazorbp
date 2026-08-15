using GladeBlazor;

namespace BlazorBp.Tests;

public class GladeParserTests
{
  [Fact]
  public void GenerateBlazor()
  {
    var basepath = @"/home/wolfgang/cs/csbp/CSBP/GtkGui";
    var genpath = @"/home/wolfgang/cs/blazorbp/BlazorBp";
    var resfile = @"/home/wolfgang/cs/csbp/CSBP.Services/Resources/Messages.de.resx";
    // Generator.Generate($"{basepath}/AM/AM000Login.glade", null, resfile, genpath);
    // Generator.Generate($"{basepath}/FZ/FZ250Mileagesxxx.glade", $"{basepath}/FZ/FZ260Mileage.glade", resfile, genpath);
    // Generator.Generate($"{basepath}/TB/TB100Diary.glade", null, resfile, genpath);
    // Generator.Generate($"{basepath}/TB/TB200Positions.glade", $"{basepath}/TB/TB210Position.glade", resfile, genpath);
    // Generator.Generate($"{basepath}/WP/WP200Stocks.glade", $"{basepath}/WP/WP210Stock.glade", resfile, genpath);
    // Generator.Generate($"{basepath}/WP/WP300Configurations.glade", $"{basepath}/WP/WP310Configuration.glade", resfile, genpath);
    // Generator.Generate($"{basepath}/WP/WP250Investments.glade", $"{basepath}/WP/WP260Investment.glade", null, resfile, genpath);
    // Generator.Generate($"{basepath}/WP/WP500Prices.glade", null, $"{basepath}/WP/WP510Price.glade", resfile, genpath);
    Generator.Generate($"{basepath}/WP/WP100Chart.glade", null, null, resfile, genpath);
  }
}
