using AvaloniaApplication1.Models;

namespace AvaloniaApplication1;

public class Helper
{
    private static Models.Gr601MaevlContext db;
    public static Models.Gr601MaevlContext GetContext() => db ??= new Gr601MaevlContext();
}