using SeconMvcApp.Models;

namespace SeconMvcApp
{
    public class StudentDB
    {
        public static List<StudentViewModel> studentList = new List<StudentViewModel>();
        public List<StudentViewModel> GetStudentViews()
        {
            return studentList;
        }
        public static void AddStudent(StudentViewModel StudentView)
        {
            studentList.Add(StudentView);
        }
        public static StudentViewModel? GetStudent(int StdId)
        {
            StudentViewModel? StudentViewModel = studentList.Where(x => x.StdId == StdId).FirstOrDefault();
            if (StudentViewModel != null)
            {
                return StudentViewModel;
            }
            else
            {
                return null;
            }
        }
        public static void DeleteStudent(StudentViewModel StudentView)
        {
            StudentViewModel StudentViewModel = studentList.Where(x => x.StdId == StudentView.StdId).First();
            if (StudentViewModel != null)
            {
                studentList.Remove(StudentView);
            }
        }

        public static void UpdateStudent(StudentViewModel StudentView)
        {
            StudentViewModel? StudentViewModel = studentList.Where(x => x.StdId == StudentView.StdId).FirstOrDefault();
            StudentViewModel.StudentName = StudentView.StudentName;
            StudentViewModel.Course = StudentView.Course;
            StudentViewModel.MobileNo = StudentView.MobileNo;
            StudentViewModel.City = StudentView.City;
        }
    }
}
