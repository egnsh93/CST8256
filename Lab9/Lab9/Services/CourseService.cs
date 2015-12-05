using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Lab9.Exceptions;
using Lab9.Models;
using Lab9.Repositories;

namespace Lab9.Services
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository _courseRepository;
        private readonly ICourseOfferingRepository _courseOfferingRepository;
        private readonly IStudentRepository _studentRepository;

        public CourseService(ICourseRepository courseRepository, ICourseOfferingRepository courseOfferingRepository, IStudentRepository studentRepository)
        {
            _courseRepository = courseRepository;
            _courseOfferingRepository = courseOfferingRepository;
            _studentRepository = studentRepository;
        }

        public void AddCourse(Course course)
        {
            // If a course offering already exists, throw custom exception
            if (_courseRepository.CourseExists(course))
                throw new CourseExistsException();

            _courseRepository.InsertCourse(course);
            _courseRepository.Save();
        }

        public void EditCourse(Course course)
        {
            _courseRepository.EditCourse(course);
            _courseRepository.Save();
        }

        public void DeleteCourse(Course course)
        {
            _courseRepository.DeleteCourse(course);
            _courseRepository.Save();
        }

        public void AddCourseOffering(CourseOffering offering)
        {
            // If a course offering already exists, throw custom exception
            if (_courseOfferingRepository.CourseOfferingExists(offering))
                throw new CourseOfferingExistsException();

            // Insert the course offering
            _courseOfferingRepository.InsertCourseOffering(offering);
            _courseOfferingRepository.Save();
        }

        public void AddStudent(Student student, CourseOffering offering)
        {
            // Check if the student already exists in the offering
            if (_studentRepository.StudentExists(offering, student.StudentNum))
                throw new StudentExistsException();

            // Insert the student into the offering
            _courseOfferingRepository.InsertStudentIntoCourseOffering(student, offering);
        }

        public Course GetCourseById(string id) => _courseRepository.GetCourse(id);
        public CourseOffering GetCourseOffering(int year, string semester, string id) => _courseOfferingRepository.GetCourseOffering(year, semester, id);
        public CourseOffering GetCourseOfferingById(string id) => _courseOfferingRepository.GetCourseOfferingById(id);

        public List<Course> GetAllCourses() => _courseRepository.GetCourses();

        public List<CourseOffering> GetAllCourseOfferings() => _courseOfferingRepository.GetCourseOfferings();

        public List<Student> GetStudents(CourseOffering offering) => _studentRepository.GetStudents(offering);

    }
}