﻿using FastEndpoints;
using Microsoft.AspNetCore.Http;
namespace REPRPoc.Endpoints.ValidationTest.Post.V0
{
    public class EndpointHandler : Endpoint<Request, Response>
    {
        public override void Configure()
        {
            Post("/validationtest");
            Roles("Manager");
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
