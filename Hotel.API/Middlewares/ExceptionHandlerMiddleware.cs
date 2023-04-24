using System.Net;
using Hotel.Application.Exceptions.Conflict;
using Hotel.Application.Exceptions.NotFound;
using Hotel.Application.HttpResponses;
using Microsoft.AspNetCore.Diagnostics;

namespace Hotel.API.Middlewares
{
    public static class ExceptionHandlerMiddleware
    {
        public static void AddExceptionHandler( this WebApplication app )
        {
            app.UseExceptionHandler( appError =>
            {
                appError.Run( async context =>
                {
                    context.Response.StatusCode = ( int )HttpStatusCode.InternalServerError;
                    context.Response.ContentType = "application/json";

                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    if ( contextFeature != null )
                    {
                        context.Response.StatusCode = contextFeature.Error switch
                        {
                            NotFoundException => StatusCodes.Status404NotFound,
                            ConflictException => StatusCodes.Status409Conflict,
                            _ => StatusCodes.Status500InternalServerError
                        };

                        await context.Response.WriteAsync( new ErrorDetails()
                        {
                            StatusCode = context.Response.StatusCode,
                            Message = contextFeature.Error.Message,
                        }.ToString() );
                    }
                } );
            } );
        }
    }
}