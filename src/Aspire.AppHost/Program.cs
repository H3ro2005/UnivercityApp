using Aspire.Hosting;

IDistributedApplicationBuilder builder = DistributedApplication.CreateBuilder(args);

IResourceBuilder<PostgresDatabaseResource> database = builder
    .AddPostgres("database")
    .WithImage("postgres:17")    
    .WithBindMount("../../.containers/db", "/var/lib/postgresql/data")
    .WithHostPort(62226)
    .WithLifetime(ContainerLifetime.Persistent)
    .AddDatabase("clean-architecture");

builder.AddProject<Projects.Web_Api>("web-api")
    .WithEnvironment("ConnectionStrings__Database", database)
    .WithReference(database)
    .WaitFor(database);

builder.Build().Run();
