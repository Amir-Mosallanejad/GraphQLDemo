using GraphQLDemo.Api.Schema.Mutations;
using GraphQLDemo.Api.Schema.Queries;
using GraphQLDemo.Api.Schema.Subscriptions;
using GraphQLDemo.Api.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddGraphQLServer()
    .AddQueryType<Query>()
    .AddMutationType<Mutation>()
    .AddSubscriptionType<Subscription>()
    .AddInMemorySubscriptions();

builder.Services.AddPooledDbContextFactory<SchoolDbContext>(opts => opts.UseSqlite("Data Source=school.db"));

var app = builder.Build();

app.UseWebSockets();

app.MapGraphQL();

app.Run();
