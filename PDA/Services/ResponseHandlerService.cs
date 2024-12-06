using PDA.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net;


namespace VAS_ZODIAC_Services.Response_Handler_Service
{
    public class ResponseHandlerService : IResponseHandlerService
    {
       
       
        public string HandleGenericResponseAsString(int? status, ResponseDetail? responseDetail)
        {
            var details = "";

   

            switch (status)
            {
                case 200:
                    details = string.Join(", ", responseDetail.SuccessDetail.Select(d => d.Message));
                    break;

                case 400:
                case 401:
                case 404:
                    details = responseDetail.ValidationDetail != null && responseDetail.ValidationDetail.Count != 0 ?
                        string.Join(", ", responseDetail.ValidationDetail.Select(d => d.Message)) :
                        string.Join(", ", responseDetail.ErrorDetail.Select(d => d.Message));
                    break;

                default:
                    details = string.Join(", ", responseDetail.ErrorDetail.Select(d => d.Message));
                    break;
            }

            return details;

        }
    }
}