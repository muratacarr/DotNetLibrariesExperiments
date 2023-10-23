﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Razor.Compilation;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace ErrorHandlingApp.Filters
{
    public class CustomExceptionFilterAttribute : ExceptionFilterAttribute
    {
        public string ErrorPage { get; set; } = "Error";
        public override void OnException(ExceptionContext context)
        {
            var result=new ViewResult() { ViewName=ErrorPage };
            result.ViewData=new ViewDataDictionary(new EmptyModelMetadataProvider(),context.ModelState);

            result.ViewData.Add("Exception",context.Exception);
            result.ViewData.Add("Url", context.HttpContext.Request.Path.Value);

            context.Result=result;

        }
    }
}
