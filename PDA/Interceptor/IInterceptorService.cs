using RestSharp;
using PDA.Models;


namespace PDA;

public interface IInterceptorService
{
    RestResponse<T> ExecutePost<T>(string requestUrl, object requestBody = null) where T : class;
    RestResponse<T> ExecuteGet<T>(string requestUrl) where T : class;
    string HandleGenericResponseAsString(int? status, ResponseDetail responseDetail);
    Task<RestResponse<T>> ExecuteGetAsync<T>(string requestUrl, string userToken, bool isLogResponse = true) where T : class;

}
