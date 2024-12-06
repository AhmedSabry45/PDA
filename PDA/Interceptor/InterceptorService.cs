using RestSharp;
using PDA.Models;
using System.Text.Json;

namespace PDA;

public class InterceptorService : IInterceptorService
{
    private static IConfiguration? _configuration;
    private readonly ILogger<InterceptorService> _logger;
    public InterceptorService(ILogger<InterceptorService> logger,IConfiguration configuration)
    {
        _configuration = configuration;
        _logger = logger;
    }

    public RestResponse<T> ExecutePost<T>(string requestUrl, object requestBody = null!) where T : class
    {
        var baseUrl = _configuration!["ZODIAC_API"];
        string fileName = $"Log - {DateTime.Today:yyyy MM dd}";
        var request = new RestRequest($"{baseUrl}{requestUrl}");
        request.Timeout = -1;
        WriteLogFile.WriteLog(fileName, $">>>Request URL: {baseUrl}{requestUrl} @ {DateTime.Now:yyyy-MM-dd HH:mm:ss}");
        if (requestBody != null)
        {
            WriteLogFile.WriteLog(fileName, $">>>Request Body: {JsonSerializer.Serialize(requestBody)}");
        }
        try
        {
            var loginRequest = new RestRequest("auth/login");

            loginRequest.AddHeader("z.userId", Environment.GetEnvironmentVariable("SV.USER", EnvironmentVariableTarget.User)!);
            loginRequest.AddHeader("z.password", Environment.GetEnvironmentVariable("SV.PASSWORD", EnvironmentVariableTarget.User)!);
            loginRequest.AddHeader("z.apikey", Environment.GetEnvironmentVariable("z.apikey", EnvironmentVariableTarget.User)!);

            //loginRequest.AddHeader("z.userId", "sokzu03");
            //loginRequest.AddHeader("z.password", "welcome");
            //loginRequest.AddHeader("z.apiKey", "A3C6425A6FDB45E48AD3B11EEF48B14F");

            //loginRequest.AddHeader("z.userId", "SAHEL01");
            //loginRequest.AddHeader("z.password", "zefO3R5S");
            //loginRequest.AddHeader("z.apiKey", "E72A23866F744DAFADC59DCCDE12A3FD");

            loginRequest.AddHeader("z.currentDataScope", "SOK");
            loginRequest.AddHeader("Accept", "application/json");

            var loginResponse = RestClientSingleton.Client.ExecutePost<GenericZodiacResponse<LoginResponse>>(loginRequest);
            request.AddHeader("z.sessionToken", loginResponse.Data?.Content?.Token ?? "");
            request.AddHeader("z.ip", "127.0.0.1");
            request.AddHeader("z.locale", "en-US");
            request.AddHeader("z.currentDataScope", "SOK");
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Accept", "application/json");

            if (requestBody != null)
            {
                request.AddJsonBody(requestBody);
            }
            var response = RestClientSingleton.Client.ExecutePost<T>(request);

            WriteLogFile.WriteLog(fileName, $">>>Response Body:  {JsonSerializer.Serialize(response.Data)}");
            return response;
        }
        catch (Exception ex)
        {
            WriteLogFile.WriteLog(fileName, $">>>ExecutePostAsync has been failed due to {ex.Message} @ {DateTime.Now:yyyy-MM-dd HH:mm:ss}");
            WriteLogFile.WriteLog(fileName, $"{ex.Message} - {ex.StackTrace}");

            return new RestResponse<T>(request);
        }
    }

    public RestResponse<T> ExecuteGet<T>(string requestUrl) where T : class
    {
        var baseUrl = _configuration!["ZODIAC_API"];
        string fileName = $"Log - {DateTime.Today:yyyy MM dd}";
        var request = new RestRequest($"{baseUrl}{requestUrl}");
        request.Timeout = -1;
        WriteLogFile.WriteLog(fileName, $">>>Request URL: {baseUrl}{requestUrl} @ {DateTime.Now:yyyy-MM-dd HH:mm:ss}");
        try
        {
            var loginRequest = new RestRequest("auth/login");


            loginRequest.AddHeader("z.userId", Environment.GetEnvironmentVariable("SV.USER", EnvironmentVariableTarget.Machine)!);
            loginRequest.AddHeader("z.password", Environment.GetEnvironmentVariable("SV.PASSWORD", EnvironmentVariableTarget.Machine)!);
            loginRequest.AddHeader("z.apikey", Environment.GetEnvironmentVariable("z.apikey", EnvironmentVariableTarget.Machine)!);


            //loginRequest.AddHeader("z.userId", "sokzu03");
            //loginRequest.AddHeader("z.password", "welcome");
            //loginRequest.AddHeader("z.apiKey", "A3C6425A6FDB45E48AD3B11EEF48B14F");

            //loginRequest.AddHeader("z.userId", "SAHEL01");
            //loginRequest.AddHeader("z.password", "zefO3R5S");
            //loginRequest.AddHeader("z.apiKey", "E72A23866F744DAFADC59DCCDE12A3FD");
            loginRequest.AddHeader("z.currentDataScope", "SOK");


            loginRequest.AddHeader("Accept", "application/json");

            var loginResponse = RestClientSingleton.Client.ExecutePost<GenericZodiacResponse<LoginResponse>>(loginRequest);
            request.AddHeader("z.sessionToken", loginResponse.Data?.Content?.Token ?? "");
            request.AddHeader("z.ip", "127.0.0.1");
            request.AddHeader("z.locale", "en-US");
            request.AddHeader("z.currentDataScope", "SOK");
            var response = RestClientSingleton.Client.ExecuteGet<T>(request);

            WriteLogFile.WriteLog(fileName, $">>>Response Body content: {response.Content}");

            return response;
        }
        catch (Exception ex)
        {
            WriteLogFile.WriteLog(fileName, $">>>ExecuteGet has been failed due to {ex.Message} @ {DateTime.Now:yyyy-MM-dd HH:mm:ss}");
            WriteLogFile.WriteLog(fileName, $"{ex.Message} - {ex.StackTrace}");
            return new RestResponse<T>(request);
        }
    }

    public async Task<RestResponse<T>> ExecuteGetAsync<T>(string requestUrl, string userToken, bool isLogResponse = true) where T : class
    {
        var requestTraceId = Guid.NewGuid();
        var client = new RestClient(_configuration.GetValue<string>("ZodiacBaseUrl"));
        var request = new RestRequest(requestUrl, Method.Get);
        request.Timeout = int.MaxValue;
        _logger.LogInformation($"=> {requestTraceId} - Request URL: {_configuration.GetValue<string>("ZodiacBaseUrl")}{request.Resource}");

        request.AddHeader("z.sessionToken", userToken);
        request.AddHeader("z.ip", "127.0.0.1");
        request.AddHeader("z.locale", "en-US");
        request.AddHeader("z.currentDataScope", "SOK");
        request.AddHeader("Content-Type", "application/json");

        var response = await client.ExecuteAsync<T>(request);

        if (isLogResponse)
        {
            _logger.LogInformation($"=> {requestTraceId} - Response Body: {response.Content}");
        }

        if (response.ErrorMessage != null)
        {
            _logger.LogError($"=> {requestTraceId} - Error from RestSharp: {response.ErrorMessage}");
        }
        return response;
    }


    public string HandleGenericResponseAsString(int? status, ResponseDetail? responseDetail)
    {
        var details = "";

        if (status == 200)
        {
            details = string.Join(", ", responseDetail?.SuccessDetail?.Select(d => d.Message)!);

            return details;
        }
        else if (status == 400 || status == 401 || status == 404)
        {
            details = string.Join(", ", responseDetail?.ValidationDetail?.Select(d => d.Message)!);
            details += string.Join(", ", responseDetail?.ErrorDetail?.Select(d => d.Message)!);

            return details;
        }
        else
        {
            details = string.Join(", ", responseDetail?.ErrorDetail?.Select(d => d.Message)!);
            details += string.Join(", ", responseDetail?.ValidationDetail?.Select(d => d.Message)!);

            return details;
        }
    }

  
}


public class RestClientSingleton
{
    private static readonly RestClient _client = new RestClient(new RestClientOptions(new ConfigurationBuilder()
                                                    .SetBasePath(Directory.GetCurrentDirectory())
                                                    .AddJsonFile("appsettings.json")
                                                    .Build()["ZODIAC_API"])
    {
        RemoteCertificateValidationCallback = (sender, certificate, chain, sslPolicyErrors) => true
    });
    public static RestClient Client => _client;
}


public class WriteLogFile
{
    public static bool WriteLog(string strFileName, string strMessage)
    {
        try
        {
            var _logDirectory = Directory.GetCurrentDirectory() + "\\Logs";
            Directory.CreateDirectory(_logDirectory);
            var filePath = Path.Combine(_logDirectory, strFileName);

            using (StreamWriter streamWriter = File.AppendText(filePath))
            {
                streamWriter.WriteLine($"{DateTime.Now:yyyy-MM-dd HH:mm:ss} - {strMessage}");
            }

            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }
}
