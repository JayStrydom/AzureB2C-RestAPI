using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace PortalAuthenticationSample
{
    public class Claims
    {
        private readonly IClaimsService _claimsService;
        private readonly IAuthenticationService _authenticationService;

        public Claims(IClaimsService claimsService, IAuthenticationService authenticationService)
        {
            _claimsService = claimsService ?? throw new ArgumentNullException(nameof(claimsService));
            _authenticationService = authenticationService ?? throw new ArgumentNullException(nameof(authenticationService));
        }

        [FunctionName("claims")]
        public async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Function, "post", Route = null)] HttpRequest req, ILogger log)
        {
            try
            {
                _authenticationService.Authenticate(req);

                string requestBody = await new StreamReader(req.Body).ReadToEndAsync();

                if (string.IsNullOrWhiteSpace(requestBody))
                {
                    return new BadRequestObjectResult(new ResponseError() { userMessage = "Request content is empty." });
                }

                log.LogInformation("Request body: " + requestBody);
                var claimsRequest = JsonConvert.DeserializeObject<ClaimsRequest>(requestBody);

                try
                {
                    var response = await _claimsService.GenerateClaims(claimsRequest).ConfigureAwait(false);
                    return new OkObjectResult(response);
                }
                catch (ValidationException validationEx)
                {
                    log.LogError(validationEx, "The user's claims was invalid.");
                    return new BadRequestObjectResult(new ResponseError() { userMessage = validationEx.Message });
                }
            } catch (UnauthorizedAccessException unauthEx)
            {
                log.LogError(unauthEx, "Authentication failed.");
                return new UnauthorizedResult();
            } catch (Exception ex)
            {
                // this isn't good - the user will not be able to login
                log.LogError(ex, "Failed to generate the user claims.");
                return new BadRequestObjectResult(new ResponseError() { userMessage = "Sorry an internal error occured. Please try again or contact support." });
            }
        }
    }
}
