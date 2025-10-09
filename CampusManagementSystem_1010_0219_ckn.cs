// 代码生成时间: 2025-10-10 02:19:33
using System;
using System.Collections.Generic;
using System.Linq;

namespace CampusManagementSystem
{
    // 学生类
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Grade { get; set; }
    }

    // 教师类
    public class Teacher
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Subject { get; set; }
    }

    // 课程类
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string TeacherId { get; set; }
        public List<string> StudentIds { get; set; } = new List<string>();
    }

    // 校园管理类
    public class CampusManagement
    {
        private List<Student> students;
        private List<Teacher> teachers;
        private List<Course> courses;

        public CampusManagement()
        {
            students = new List<Student>();
            teachers = new List<Teacher>();
            courses = new List<Course>();
        }

        // 添加学生
        public void AddStudent(Student student)
        {
            if (student == null)
                throw new ArgumentNullException(nameof(student));

            students.Add(student);
        }

        // 添加教师
        public void AddTeacher(Teacher teacher)
        {
            if (teacher == null)
                throw new ArgumentNullException(nameof(teacher));

            teachers.Add(teacher);
        }

        // 添加课程
        public void AddCourse(Course course)
        {
            if (course == null)
                throw new ArgumentNullException(nameof(course));

            // 验证教师是否存在
            var teacher = teachers.FirstOrDefault(t => t.Id == course.TeacherId);
            if (teacher == null)
                throw new InvalidOperationException($"教师ID为{course.TeacherId}的教师不存在。");

            courses.Add(course);
        }

        // 获取所有学生
        public List<Student> GetAllStudents()
        {
            return students;
        }

        // 获取所有教师
        public List<Teacher> GetAllTeachers()
        {
            return teachers;
        }

        // 获取所有课程
        public List<Course> GetAllCourses()
        {
            return courses;
        }
    }

    // 程序入口类
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                // 创建校园管理实例
                var campusManagement = new CampusManagement();

                // 添加学生
                campusManagement.AddStudent(new Student { Id = 1, Name = "张三", Grade = "一年级" });
                campusManagement.AddStudent(new Student { Id = 2, Name = "李四", Grade = "二年级" });

                // 添加教师
                campusManagement.AddTeacher(new Teacher { Id = 1, Name = "王五", Subject = "数学" });
                campusManagement.AddTeacher(new Teacher { Id = 2, Name = "赵六", Subject = "物理" });

                // 添加课程
                campusManagement.AddCourse(new Course { Id = 1, Name = "数学", TeacherId = "1" });
                campusManagement.AddCourse(new Course { Id = 2, Name = "物理", TeacherId = "2" });

                // 打印所有学生
                Console.WriteLine("所有学生：");
                foreach (var student in campusManagement.GetAllStudents())
                {
                    Console.WriteLine($"ID：{student.Id}, 姓名：{student.Name}, 年级：{student.Grade}");
                }

                // 打印所有教师
                Console.WriteLine("所有教师：");
                foreach (var teacher in campusManagement.GetAllTeachers())
                {
                    Console.WriteLine($"ID：{teacher.Id}, 姓名：{teacher.Name}, 学科：{teacher.Subject}");
                }

                // 打印所有课程
                Console.WriteLine("所有课程：");
                foreach (var course in campusManagement.GetAllCourses())
                {
                    Console.WriteLine($"ID：{course.Id}, 课程名称：{course.Name}, 教师ID：{course.TeacherId}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"发生异常：{ex.Message}");
            }
        }
    }
}
