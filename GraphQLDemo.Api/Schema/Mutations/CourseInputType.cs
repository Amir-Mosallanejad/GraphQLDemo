﻿using GraphQLDemo.Api.Models;

namespace GraphQLDemo.Api.Schema.Mutations;

public class CourseInputType
{
    public string Name { get; set; }
    public Subject Subject { get; set; }
    public Guid InstructorId { get; set; }
}
