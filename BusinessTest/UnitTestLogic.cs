using Microsoft.VisualStudio.TestTools.UnitTesting;
using Business.Logic;
using Data.Model;
using static System.Net.WebRequestMethods;

namespace BusinessTest
{
    [TestClass]
    public class UnitTestBusinessLogic
    {
        [TestMethod]
        public async Task TestAnnualSalaryMethod_FirstEmployee()
        {
            HttpClient httpClient = new HttpClient();

            List<string> methods = new List<string>()
            {
               "http://dummy.restapiexample.com/api/v1/employees" ,
               "http://dummy.restapiexample.com/api/v1/employee/" 
            };

            Business.Logic.EmployeeLogic employeeLogic = new EmployeeLogic(httpClient, methods);

            // testing first employee.
            Task<decimal> task = employeeLogic.calculateAnnualSalary(1);

            decimal result =  await task;

            float resultNotExpected = 0;

            Assert.AreNotEqual(resultNotExpected, (float)result, 0);
        }

    }
}