using DotNet.Monitoring.Common.Exceptions;
using System.Net;

namespace DotNet.Monitoring.Common.Errors;

public partial class ClientSide
{
  public const string ErrorCode = "10010";
  public static BaseApplicationException FieldNullOrEmpty(string fieldName) => new BadRequestException($"{ErrorCode}001", $"Field '{fieldName}'cannot be null or empty", HttpStatusCode.BadRequest);
  public static BaseApplicationException InvalidRequest() => new InternalServerError($"{ErrorCode}002", "Invalid request", HttpStatusCode.BadRequest);
  public static BaseApplicationException ValidationFailure(string serviceName) => new CommunicationException($"{ErrorCode}003", $"Following Validation error occurred:", HttpStatusCode.BadRequest);
}