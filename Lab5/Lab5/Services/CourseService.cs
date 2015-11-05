using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Lab5.Models;
using Lab5.Repositories;

namespace Lab5.Services
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository _courseRepository;
        private readonly ICourseOfferingRepository _courseOfferingRepository;

        public CourseService(ICourseRepository courseRepository, ICourseOfferingRepository courseOfferingRepository)
        {
            _courseRepository = courseRepository;
            _courseOfferingRepository = courseOfferingRepository;
        }

        public void AddCourse(Course course) => _courseRepository.InsertCourse(course);

        public void AddCourseOffering(CourseOffering offering) => _courseOfferingRepository.InsertCourseOffering(offering);

        public void AddStudent(Student student)
        {
            
        }

        public void AddStudentToOffering(Student student)
        {

        }

        public Course GetCourseById(string id) => _courseRepository.GetCourse(id);

        public List<Course> GetAllCourses() => _courseRepository.GetCourses();

        public List<CourseOffering> GetAllCourseOfferings() => _courseOfferingRepository.GetCourseOfferings();

        public List<Student> GetAllStudentsByOffering(CourseOffering offering)
        {
            return null;
        }
    }
}