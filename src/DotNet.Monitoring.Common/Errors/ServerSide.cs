using System.Net;
using DotNet.Monitoring.Common.Exceptions;
using InvalidOperationException = DotNet.Monitoring.Common.Exceptions.InvalidOperationException;

namespace DotNet.Monitoring.Common.Errors;

public partial class ServerSide
{
  public const string ErrorCode = "10020";
  public static BaseApplicationException TimeOut() => new CommunicationException($"{ErrorCode}001", "Time out exception occurred.", HttpStatusCode.GatewayTimeout);
  public static BaseApplicationException InternalServerError() => new InternalServerError($"{ErrorCode}002", "Error occurred while processing the request.", HttpStatusCode.InternalServerError);
  public static BaseApplicationException CommunicationError(string serviceName) => new CommunicationException($"{ErrorCode}003", $"Error occurred while communicating with {serviceName} service", HttpStatusCode.InternalServerError);
  public static BaseApplicationException RecordNotFound() => new NotFoundException($"{ErrorCode}004", "Not record found", HttpStatusCode.NotFound);
  public static BaseApplicationException RecordNotFound(string message) => new NotFoundException($"{ErrorCode}005", message, HttpStatusCode.NotFound);
  public static BaseApplicationException RecordNotFound(string fieldName, string value) => new NotFoundException($"{ErrorCode}006", $"Entity not found for field '{fieldName}' value '{value}'", HttpStatusCode.NotFound);
}