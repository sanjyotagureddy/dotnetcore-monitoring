using System.Net;
using System.Runtime.Serialization;

namespace DotNet.Monitoring.Common.Exceptions;

public class InternalServerError : BaseApplicationException
{
  public InternalServerError(string errorCode, string message, HttpStatusCode httpStatusCode) : base(errorCode, message, httpStatusCode)
  {
  }

  protected InternalServerError(SerializationInfo info, StreamingContext context, string errorCode, HttpStatusCode httpStatusCode) : base(info, context, errorCode, httpStatusCode)
  {
  }

  public InternalServerError(string? message, string errorCode) : base(message, errorCode)
  {
  }

  public InternalServerError(string? message, Exception? innerException, string errorCode) : base(message, innerException, errorCode)
  {
  }
}