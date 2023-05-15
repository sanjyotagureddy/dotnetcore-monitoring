using Microsoft.AspNetCore.Http;

namespace DotNet.Monitoring.Common.Extensions
{
  public static class RestRequestExtensions
  {
    /// <summary>
    /// Convert IHeaderDictionary to IDictionary&lt;string, string&gt;
    /// </summary>
    /// <param name="headers">IHeaderDictionary from RestRequest</param>
    /// <returns>Dictionary of type &lt;string, string&gt; </returns>
    public static IDictionary<string, string> ToStringDictionary(this IHeaderDictionary headers)
    {
      if (headers == null) { return null; }
      var dictionary = new Dictionary<string, string>();
      foreach (var (key, value) in headers)
      {
        dictionary.TryAdd(key, value);
      }

      return dictionary;
    }

    /// <summary>
    /// Convert IDictionary into a single line string representation
    /// </summary>
    /// <param name="dictionary">IDictionary&lt;string, string&gt;</param>
    /// <returns></returns>
    /// <example>"{string1 : value1, string2 : value2}"</example>
    public static string ToStringValue(this IDictionary<string, string> dictionary)
    {
      if (dictionary?.Any() != true)
      {
        return string.Empty;
      }
      var dictionaryString = dictionary.Aggregate("{", (current, keyValues) => current + ($"'{keyValues.Key}':'{ keyValues.Value }', "));
      return dictionaryString.TrimEnd(',', ' ') + "}";
    }

    /// <summary>
    /// Convert IQueryCollection to IDictionary&lt;string, string&gt;
    /// </summary>
    /// <param name="queryCollection">IQueryCollection</param>
    /// <returns>Dictionary of type &lt;string, string&gt; </returns>
    public static IDictionary<string, string> ToStringDictionary(this IQueryCollection queryCollection)
    {
      if (queryCollection == null) { return null; }
      var dictionary = new Dictionary<string, string>();
      foreach (var (key, value) in queryCollection)
      {
        dictionary.TryAdd(key, value);
      }

      return dictionary;
    }
  }
}