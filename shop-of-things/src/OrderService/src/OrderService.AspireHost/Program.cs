var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.OrderService_Web>("web");

builder.Build().Run();