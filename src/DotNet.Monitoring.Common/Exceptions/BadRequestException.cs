using System.Net;
using System.Runtime.Serialization;

namespace DotNet.Monitoring.Common.Exceptions;

[Serializable]
public class BadRequestException : BaseApplicationException
{
  public BadRequestException(string errorCode, string message, HttpStatusCode httpStatusCode) : base(errorCode, message, httpStatusCode)
  {
  }

  protected BadRequestException(SerializationInfo info, StreamingContext context, string errorCode, HttpStatusCode httpStatusCode) : base(info, context, errorCode, httpStatusCode)
  {
  }

  public BadRequestException(string? message, string errorCode) : base(message, errorCode)
  {
  }

  public BadRequestException(string? message, Exception? innerException, string errorCode) : base(message, innerException, errorCode)
  {
  }
}