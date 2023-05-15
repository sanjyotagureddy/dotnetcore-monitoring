namespace DotNet.Monitoring.Common.Settings
{
  [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "RCS1102:Make class static.", Justification = "<Pending>")]
  public class ApiSettings
  {
    public static string PayloadLoggingHost { get; set; }

    /// <summary>
    /// comma separated list of urls to be ignore for payload logging
    /// </summary>
    public static string IgnorePayloadUrls { get; set; }
  }
}