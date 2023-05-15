using System.Runtime.Serialization;

namespace DotNet.Monitoring.Contracts.PayloadLogging.Enum
{
  public enum PayloadType
  {
    /// <summary>
    /// Enum Request for request
    /// </summary>
    [EnumMember(Value = "request")]
    Request = 1,

    /// <summary>
    /// Enum Response for response
    /// </summary>
    [EnumMember(Value = "response")]
    Response = 2,

    /// <summary>
    /// Enum Custom for custom
    /// </summary>
    [EnumMember(Value = "custom")]
    Custom = 3
  }
}