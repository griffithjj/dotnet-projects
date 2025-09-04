var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.ProductService_Web>("web");

builder.Build().Run();