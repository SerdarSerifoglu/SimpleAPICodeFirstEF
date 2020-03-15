using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UdeAPI.API.DTOs;
using UdeAPI.Core.Services;

namespace UdeAPI.API.Filters
{
    /// <summary>
    /// İşleme başlamadan önce yollanan id'li kayıt db'de var mı yok mu kontrolünü sağlayan filter
    /// </summary>
    public class NotFoundFilter : ActionFilterAttribute
    {
        private readonly IProductService _productService;
        public NotFoundFilter(IProductService productService)
        {
            _productService = productService;
        }

        public async override Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            int id = (int)context.ActionArguments.Values.FirstOrDefault();

            var product = await _productService.GetByIdAsync(id);

            if (product != null)
            {
                //ActionFilter eklenmiş metodun işleminin devam etmesini sağladık.
                await next();
            }
            else
            {
                ErrorDto errorDto = new ErrorDto();
                errorDto.Status = 404;
                errorDto.Errors.Add($"id'si {id} olan kayıt veritabanında bulunamadı");

                context.Result = new NotFoundObjectResult(errorDto);
            }
        }


    }
}
