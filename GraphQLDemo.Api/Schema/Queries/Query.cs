using System.Threading.Tasks;
using Bogus;
using GraphQLDemo.Api.DTOs;
using GraphQLDemo.Api.Models;
using GraphQLDemo.Api.Services.Courses;

namespace GraphQLDemo.Api.Schema.Queries;

public class Query
{
    private readonly CoursesRepository _coursesRepository;

    public Query(CoursesRepository coursesRepository)
    {
        _coursesRepository = coursesRepository;
    }

    [GraphQLDeprecated("This query is no longer avalable")]
    public string GetText => "this is for test";

    public async Task<IEnumerable<CourseType>> GetCourses()
    {
        IEnumerable<CourseDTO> courseDTOs = await _coursesRepository.GetAll();
        return courseDTOs.Select(c => new CourseType()
        {
            Id = c.Id,
            Name = c.Name,
            Subject = c.Subject,
            Instructor = new InstructorType()
            {
                Id = c.Instructor.Id,
                FirstName = c.Instructor.FirstName,
                LastName = c.Instructor.LastName,
                Salary = c.Instructor.Salary,
            }
        });
    }

    public async Task<CourseType> GetCourseById(Guid id)
    {
        CourseDTO courseDTO = await _coursesRepository.GetById(id);

        return new CourseType()
        {
            Id = courseDTO.Id,
            Name = courseDTO.Name,
            Subject = courseDTO.Subject,
            Instructor = new InstructorType()
            {
                Id = courseDTO.Instructor.Id,
                FirstName = courseDTO.Instructor.FirstName,
                LastName = courseDTO.Instructor.LastName,
                Salary = courseDTO.Instructor.Salary,
            }
        };
    }
}
