using System.Data.SqlClient;
using EmployeeManagers;

public class Program
{
    public static void Main(string[] args)
    {
        EmployeManager employe = new ();
        //employe.AddEmployee("adeola", "firstk", 2000);


        employe.UpdateEmployee(2,"shevvy","software",8900);
        employe.GetEmployees();

        employe.DeleteEmployee(7);


    }

}