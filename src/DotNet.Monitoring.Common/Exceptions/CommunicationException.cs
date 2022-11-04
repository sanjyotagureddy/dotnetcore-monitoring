using System.Net;
using System.Runtime.Serialization;

namespace DotNet.Monitoring.Common.Exceptions;

public class CommunicationException : BaseApplicationException
{
  public CommunicationException(string errorCode, string message, HttpStatusCode httpStatusCode) : base(errorCode, message, httpStatusCode)
  {
  }

  protected CommunicationException(SerializationInfo info, StreamingContext context, string errorCode, HttpStatusCode httpStatusCode) : base(info, context, errorCode, httpStatusCode)
  {
  }

  public CommunicationException(string? message, string errorCode) : base(message, errorCode)
  {
  }

  public CommunicationException(string? message, Exception? innerException, string errorCode) : base(message, innerException, errorCode)
  {
  }
}