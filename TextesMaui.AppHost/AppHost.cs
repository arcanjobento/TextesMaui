var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.TextesMaui>("textesmaui");

builder.Build().Run();
