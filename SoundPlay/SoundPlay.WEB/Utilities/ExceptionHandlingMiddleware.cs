﻿using System.Net;

namespace SoundPlay.WEB.Utilities
{
    public class ExceptionHandlingMiddleware:IMiddleware
    {
        #region Own fields

        //private readonly ILogger<ExceptionHandlingMiddleware> _logger;

        #endregion

        #region Ctor

        //public ExceptionHandlingMiddleware(ILogger<ExceptionHandlingMiddleware> logger)
        //{
        //    _logger= logger;
        //}

        public ExceptionHandlingMiddleware() { }

        #endregion

        #region Methods

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }

            catch (ObjectNotFoundException ex)
            {
                context.Response.StatusCode=(int)HttpStatusCode.NotFound;
                //_logger.LogError($"{context.GetEndpoint()} {ex.Message}");
                await context.Response.WriteAsync(ex.Message);
            }

            catch (Exception ex)
            {
                context.Response.StatusCode=(int)HttpStatusCode.BadRequest;
                //_logger.LogError($"{context.GetEndpoint()} {ex.Message}");
                await context.Response.WriteAsync(ex.Message);
            }
        }

        #endregion
    }
}
