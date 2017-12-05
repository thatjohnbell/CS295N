using CRM;
using System;
using Xunit;

namespace CRMxUnitTest
{

    


    public class UnitTest1
    {

        public Customer TestCust = new Customer
        {
            FirstName = "First Name",
            LastName = "Last Name",
            CompanyName = "Company Test",
            Position = "Test Position",
            PhoneNumber = 5555555555,
            StreetAddress = "88 Test Street",
            City = "Test City",
            ZipCode = 88888,
            State = "TS",
            CustomerType = "Lead",
        };



        [Fact]
        public void TestGetFirstName()
        {
            Assert.Equal("First Name", TestCust.FirstName);
        }

        [Theory]
        [InlineData("First Name")]
        public void TestTheoryFirstName(string val)
        {
            Assert.Equal(val, TestCust.FirstName);
        }

    }
}
