using Newtonsoft.Json;
using System.Text.RegularExpressions;

namespace DotNet.Monitoring.Common.Extensions
{
  public static class StringExtensions
  {
    public static string ToSnakeCase(this string input)
    {
      if (string.IsNullOrEmpty(input)) { return input; }

      var startUnderscores = Regex.Match(input, "^_+");

      return startUnderscores + Regex.Replace(input, "([a-z0-9])([A-Z])", "$1_$2").ToLower();
    }

    /// <summary>
    /// Remove all the unwanted tabs, new lines  and indentations
    /// </summary>
    /// <param name="jsonText">Serialized Json text</param>
    /// <returns></returns>
    public static string MinifyJsonText(this string jsonText)
    {
      if (string.IsNullOrWhiteSpace(jsonText)) { return jsonText; }
      var deserializeObject = JsonConvert.DeserializeObject(jsonText);
      return JsonConvert.SerializeObject(deserializeObject, Formatting.None);
    }
  }
}