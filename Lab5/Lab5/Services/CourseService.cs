using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Lab5.Exceptions;
using Lab5.Models;
using Lab5.Repositories;

namespace Lab5.Services
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

        public void AddCourse(Course course) => _courseRepository.InsertCourse(course);

        public void AddCourseOffering(CourseOffering offering)
        {
            // If a course offering already exists, throw custom exception
            if (_courseOfferingRepository.CourseOfferingExists(offering))
                throw new CourseOfferingExistsException();

            // Insert the course offering
            _courseOfferingRepository.InsertCourseOffering(offering);
        }

        public void AddStudent(Student student, CourseOffering offering)
        {
            // If the student does not yet exist
            if (!_studentRepository.StudentExists(student.Number))
            {
                // Insert the student into the DB
                _studentRepository.InsertStudent(student);

                // Register the student to the course offering
                _studentRepository.RegisterStudent(student, offering);
            }
            else
            {
                // Check if student is registered in offering
                var studentExists = _studentRepository.GetStudentsByOffering(offering).Find(s => s.Number == student.Number);

                // If student is not registered
                if (studentExists == null)

                    // Register the student
                    _studentRepository.RegisterStudent(student, offering);
            }   
        }

        public Course GetCourseById(string id) => _courseRepository.GetCourse(id);
        public CourseOffering GetCourseOffering(string id, int year, string semester) => _courseOfferingRepository.GetCourseOffering(id, year, semester);
        public CourseOffering GetCourseOfferingById(string id) => _courseOfferingRepository.GetCourseOfferingById(id);

        public List<Course> GetAllCourses() => _courseRepository.GetCourses();

        public List<CourseOffering> GetAllCourseOfferings() => _courseOfferingRepository.GetCourseOfferings();

        public List<Student> GetAllStudentsByOffering(CourseOffering offering) => _studentRepository.GetStudentsByOffering(offering);

    }
}