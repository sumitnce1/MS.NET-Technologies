using SeconMvcApp.Models;

namespace SeconMvcApp
{
    public class UtilsDB
    {
        public static List<EmployeeViewModel> userList = new List<EmployeeViewModel>(); 
        public List<EmployeeViewModel> GetEmployeeViews()
        { 
            return userList; 
        }
        public static void AddEmployee(EmployeeViewModel employeeView)
        {
            userList.Add(employeeView);
        }
        public static EmployeeViewModel? GetEmployee(int EmpId)
        {
            EmployeeViewModel? employeeViewModel = userList.Where(x => x.EmpId == EmpId).FirstOrDefault();
            if (employeeViewModel != null)
            {
                return employeeViewModel;
            }
            else
            {
                return null;
            }
        }
        public static void DeleteEmployee(EmployeeViewModel employeeView)
        {
            EmployeeViewModel employeeViewModel = userList.Where(x => x.EmpId == employeeView.EmpId).First();
            if(employeeViewModel != null)
            {
                userList.Remove(employeeView);
            }
        }

        public static void UpdateEmployee(EmployeeViewModel employeeView)
        {
            EmployeeViewModel? employeeViewModel = userList.Where(x => x.EmpId == employeeView.EmpId).FirstOrDefault();
            employeeViewModel.EmployeeName = employeeView.EmployeeName;
            employeeViewModel.FatherName = employeeView.FatherName;
            employeeViewModel.MobileNo = employeeView.MobileNo;            
        }
    }
}
