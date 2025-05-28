using GraphQLDemo.Api.Schema.Queries;

namespace GraphQLDemo.Api.Schema.Mutations;

public class CourseInputType
{
    public string Name { get; set; }
    public Subject Subject { get; set; }
    public Guid InstructorId { get; set; }
}
