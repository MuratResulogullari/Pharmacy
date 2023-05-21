using Microsoft.AspNetCore.Mvc.ModelBinding;
using Pharmacy.Core.DataTransferObjects;

namespace Pharmacy.Business.Mvc.ModelHandler
{
    public static class InvalidModelHandler
    {
        public static RequestResult GetErrorMessages(ModelStateDictionary modelState)
        {
            RequestResult result = new RequestResult();
            result.Success = false;
            var errors = modelState
                        .Values
                        .SelectMany(sm => sm.Errors)
                        .Select(s => s.ErrorMessage)
                        .ToList();

            //Yeni satır olarak eklesin diye koydum ileride duruma göre değiştiririz.
            result.Message = string.Join(Environment.NewLine, errors);
            return result;
        }
    }
}