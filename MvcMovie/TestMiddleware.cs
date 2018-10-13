using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcMovie
{
    public static class CultureMiddlewareExtensions
    {
        #region Methods

        public static IApplicationBuilder UseTestMiddleware(
            this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<TestMiddleware>();
        }

        #endregion
    }

    public class TestMiddleware
    {
        #region Fields

        private readonly RequestDelegate _next;

        #endregion

        #region Ctor

        /// <summary>
        /// Ctor
        /// </summary>
        public TestMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Invoke middleware actions
        /// </summary>
        /// <param name="context">HTTP context</param>
        /// <param name="userManager">User manager</param>
        /// <returns>Task</returns>
        public Task InvokeAsync(HttpContext context)
        {
            var req = context.Request;
            Console.WriteLine("Test: " + req.Query);
            //call the next middleware in the request pipeline
            return _next(context);
        }

        #endregion
    }
}
