namespace GraphQLDemo.Api.Schema.Mutations;

public class Mutation
{
    private List<CourseResult> _courses;

    public Mutation()
    {
        _courses = new();
    }
    public CourseResult CreateCourse(CourseInputType courseInput)
    {
        CourseResult courseType = new()
        {
            Id = Guid.NewGuid(),
            Name = courseInput.Name,
            Subject = courseInput.Subject,
            InstructorId = courseInput.InstructorId
        };

        _courses.Add(courseType);

        return courseType;
    }
}
