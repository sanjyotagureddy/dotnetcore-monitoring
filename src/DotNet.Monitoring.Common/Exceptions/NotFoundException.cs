using System.Net;
using System.Runtime.Serialization;

namespace DotNet.Monitoring.Common.Exceptions;

public class NotFoundException : BaseApplicationException
{
  public NotFoundException(string errorCode, string message, HttpStatusCode httpStatusCode) : base(errorCode, message, httpStatusCode)
  {
  }

  protected NotFoundException(SerializationInfo info, StreamingContext context, string errorCode, HttpStatusCode httpStatusCode) : base(info, context, errorCode, httpStatusCode)
  {
  }

  public NotFoundException(string? message, string errorCode) : base(message, errorCode)
  {
  }

  public NotFoundException(string? message, Exception? innerException, string errorCode) : base(message, innerException, errorCode)
  {
  }
}