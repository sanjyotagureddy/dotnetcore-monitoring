using System.Net;
using System.Runtime.Serialization;

namespace DotNet.Monitoring.Common.Exceptions;

[Serializable]
public class BaseApplicationException : Exception
{
  public string ErrorCode { get; }
  public HttpStatusCode HttpStatusCode { get; }
  public List<Info> Info { get; } = new();

  public BaseApplicationException(string errorCode, string message, HttpStatusCode httpStatusCode)
    : base(message)
  {
    ErrorCode = errorCode ?? throw new ArgumentNullException(nameof(errorCode));
    HttpStatusCode = httpStatusCode;
  }

  public override void GetObjectData(SerializationInfo info, StreamingContext context)
  {
    if (info == null) throw new ArgumentNullException(nameof(info));
    info.AddValue(nameof(ErrorCode), ErrorCode);
    info.AddValue(nameof(HttpStatusCode), HttpStatusCode);
    info.AddValue(nameof(Info), Info);
    base.GetObjectData(info, context);
  }

  protected BaseApplicationException(SerializationInfo info, StreamingContext context, string errorCode,
    HttpStatusCode httpStatusCode) : base(info, context)
  {
    ErrorCode = errorCode ?? throw new ArgumentNullException(nameof(errorCode));
    HttpStatusCode = httpStatusCode;
  }

  public BaseApplicationException(string? message, string errorCode) 
    : base(message)
  {
    ErrorCode = errorCode;
  }

  public BaseApplicationException(string? message, Exception? innerException, string errorCode) 
    : base(message, innerException)
  {
    ErrorCode = errorCode;
  }
}

public sealed class Info
{
  public string Code { get; set; }
  public string Message { get; set; }

  public Info(string code, string message)
  {
    if (string.IsNullOrWhiteSpace(code))
      throw new ArgumentNullException(nameof(code));
    if (string.IsNullOrWhiteSpace(message))
      throw new ArgumentNullException(nameof(message));

    Code = code;
    Message = message;
  }
}