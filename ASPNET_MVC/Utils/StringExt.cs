using Microsoft.AspNetCore.Components.Forms;

namespace ASPNET_MVC.Utils;

public static class StringExt
{
    public static string ToSlug(this string s)
    {
        return s.ToLower().Replace(" ", "-");
    }
}
