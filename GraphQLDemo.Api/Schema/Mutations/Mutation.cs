using GraphQLDemo.Api.Schema.Subscriptions;
using HotChocolate.Subscriptions;

namespace GraphQLDemo.Api.Schema.Mutations;

public class Mutation
{
    private List<CourseResult> _courses;

    public Mutation()
    {
        _courses = new();
    }
    public async Task<CourseResult> CreateCourse(CourseInputType courseInput, [Service] ITopicEventSender topicEventSender)
    {
        CourseResult courseType = new()
        {
            Id = Guid.NewGuid(),
            Name = courseInput.Name,
            Subject = courseInput.Subject,
            InstructorId = courseInput.InstructorId
        };

        _courses.Add(courseType);
        await topicEventSender.SendAsync(nameof(Subscription.CourseCreated), courseType);

        return courseType;
    }

    public CourseResult UpdateCourse(Guid id, CourseInputType courseInput)
    {
        CourseResult course = _courses.FirstOrDefault(c => c.Id == id);

        if (course == null)
        {
            throw new GraphQLException(new Error("Course not found.", "COURSE_NOT_FOUND"));
        }

        course.Name = courseInput.Name;
        course.Subject = courseInput.Subject;
        course.InstructorId = courseInput.InstructorId;

        return course;
    }

    public bool DeleteCourse(Guid id)
    {
        return _courses.RemoveAll(c => c.Id == id) >= 1;
    }
}
