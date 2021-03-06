﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Lab9.Models;

namespace Lab9.Services
{
    public interface ICourseService
    {
        void AddCourse(Course course);
        void EditCourse(Course course);
        void DeleteCourse(Course course);
        void AddCourseOffering(CourseOffering offering);
        void AddStudent(Student student, CourseOffering offering);

        Course GetCourseById(string id);
        CourseOffering GetCourseOffering(int year, string semester, string id);
        CourseOffering GetCourseOfferingById(string id);

        List<Course> GetAllCourses();
        List<CourseOffering> GetAllCourseOfferings();
        List<Student> GetStudents(CourseOffering offering);
    }
}