namespace Examarbeta.Helperfunction
{
    public  static class HtmlHelperExtensions
    {
        public static string RemoveHtmlTags(this string input)
        {
            if (string.IsNullOrWhiteSpace(input)) return string.Empty;
            return System.Text.RegularExpressions.Regex.Replace(input, "<.*?>", string.Empty);
        }

    }
}
