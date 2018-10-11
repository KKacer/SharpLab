using System.ComponentModel;
using System.Text;
using SharpLab.Runtime.Internal;

public static class SharpLabObjectExtensions {
    // LinqPad/etc compatibility only
    [EditorBrowsable(EditorBrowsableState.Never)]
    public static T Dump<T>(this T value) 
        => value.Inspect(title: "Dump");

    public static T Inspect<T>(this T value, string title = "Inspect") {
        var builder = new StringBuilder();
        ObjectAppender.Append(builder, value);
        var data = new SimpleInspectionResult(title, builder);
        Output.Write(data);
        return value;
    }
}
