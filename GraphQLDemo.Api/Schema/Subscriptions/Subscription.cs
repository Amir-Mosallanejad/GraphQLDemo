using GraphQLDemo.Api.Schema.Mutations;

namespace GraphQLDemo.Api.Schema.Subscriptions;

public class Subscription
{
    [Subscribe]
    public CourseResult CourseCreated([EventMessage] CourseResult course) => course;
}