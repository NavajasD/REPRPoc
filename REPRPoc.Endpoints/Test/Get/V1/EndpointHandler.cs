﻿using FastEndpoints;
using Microsoft.AspNetCore.Http;
namespace REPRPoc.Endpoints.Test.Get.V1
{
    public class EndpointHandler : Endpoint<Request, Response>
    {
        public override void Configure()
        {
            Get("/test");
            Version(1);
            AllowAnonymous();
        }

        public override async Task HandleAsync(Request req, CancellationToken ct)
        {
            await SendResultAsync(Results.Ok(new Response
            {
                FullName = req.FirstName + " " + req.LastName,
                IsOver18 = req.Age > 18
            }));
        }
    }
}
