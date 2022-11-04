using System.Net;
using System.Runtime.Serialization;

namespace DotNet.Monitoring.Common.Exceptions;

public class InvalidOperationException : BaseApplicationException
{
  public InvalidOperationException(string errorCode, string message, HttpStatusCode httpStatusCode) : base(errorCode, message, httpStatusCode)
  {
  }

  protected InvalidOperationException(SerializationInfo info, StreamingContext context, string errorCode, HttpStatusCode httpStatusCode) : base(info, context, errorCode, httpStatusCode)
  {
  }

  public InvalidOperationException(string? message, string errorCode) : base(message, errorCode)
  {
  }

  public InvalidOperationException(string? message, Exception? innerException, string errorCode) : base(message, innerException, errorCode)
  {
  }
}