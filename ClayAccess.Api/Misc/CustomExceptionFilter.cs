using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using System;
using System.Net;

namespace ShopApi.Misc.Exceptions
{
	public class CustomExceptionFilter : IExceptionFilter
	{
		public void OnException(ExceptionContext context)
		{
			HttpStatusCode status = HttpStatusCode.InternalServerError;
			string message = string.Empty;

			Type exceptionType = context.Exception.GetType();
			if (exceptionType == typeof(UnauthorizedAccessException))
			{
				message = @"Unauthorized Access";
				status = HttpStatusCode.Unauthorized;
			}
			else if (exceptionType == typeof(NotImplementedException))
			{
				message = @"API call is not available";
				status = HttpStatusCode.NotImplemented;
			}
			else
			{
				message = context.Exception.Message;
				status = HttpStatusCode.NotFound;
			}
			context.ExceptionHandled = true;

			HttpResponse response = context.HttpContext.Response;
			response.StatusCode = (int)status;
			response.ContentType = @"application/json";
			string result = JsonConvert.SerializeObject(new { error = message, stacktrace = context.Exception.StackTrace });
			response.WriteAsync(result);
		}
	}
}
