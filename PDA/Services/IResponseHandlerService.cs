using PDA.Models;
using Microsoft.AspNetCore.Mvc;


namespace VAS_ZODIAC_Services.Response_Handler_Service
{
    public interface IResponseHandlerService
    {
    
        string HandleGenericResponseAsString(int? status, ResponseDetail? responseDetail);
    }
}
