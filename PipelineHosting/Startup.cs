﻿using System;
using System.IO;

namespace PipelineHosting
{
    public  class Startup
    {
        public void Configure(IApplicationBuilder app)
        {
            app.UseImages(@"c:\images");
        }
    }

    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseImages(this IApplicationBuilder app, string directory)
        {
            Func<RequestDelegate, RequestDelegate> middleware = next =>
            {
                return context =>
                {
                    string fileName = context.Request.Url.LocalPath.TrimStart('/');
                    if (string.IsNullOrEmpty(Path.GetExtension(fileName)))
                    {
                        fileName += ".jpg";
                    }
                    fileName = Path.Combine(directory, fileName);
                    context.Response.WriteFile(fileName, "image/jpg");
                    return next(context);
                };
            };
            return app.Use(middleware);
        }
    }
}
