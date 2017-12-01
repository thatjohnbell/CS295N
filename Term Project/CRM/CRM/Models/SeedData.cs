using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRM.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new CustContext(
                serviceProvider.GetRequiredService<DbContextOptions<CustContext>>()))
            {
                
                if (context.Customer.Any())
                    {
                        return;   // DB has been seeded
                    }

                context.Customer.AddRange(
                    new Customer
                    {
                        FirstName = "Albert",
                        LastName = "Smith",
                        StreetAddress = "1093 J Street",
                        PhoneNumber = 5415553482,
                        City = "Eugene",
                        State = "OR",
                        LastContact = DateTime.Parse("2017-11-29"),
                        Notes = "",
                        CustomerType = "Customer",
                        ZipCode = 97477,
                        CompanyName = "RST Company",
                        Position = "Manager"


                    },
                    new Customer
                    {
                        FirstName = "Mary",
                        LastName = "Rogers",
                        StreetAddress = "5853 G Street",
                        PhoneNumber = 5415559201,
                        City = "Eugene",
                        State = "OR",
                        LastContact = DateTime.Parse("2017-11-28"),
                        Notes = "",
                        CustomerType = "Customer",
                        ZipCode = 97477,
                        CompanyName = "LMNO Company",
                        Position = "Manager"


                    },
new Customer
{
    FirstName = "Robert",
    LastName = "Douglas",
    StreetAddress = "2929 G Street",
    PhoneNumber = 5415551283,
    City = "Eugene",
    State = "OR",
    LastContact = DateTime.Parse("2017-11-27"),
    Notes = "",
    CustomerType = "Customer",
    ZipCode = 97477,
    CompanyName = "RST Company",
    Position = "Manager"


},
new Customer
{
    FirstName = "Frank",
    LastName = "Wilson",
    StreetAddress = "1482 South R Street",
    PhoneNumber = 5415559999,
    City = "Eugene",
    State = "OR",
    LastContact = DateTime.Parse("2017-11-26"),
    Notes = "",
    CustomerType = "Customer",
    ZipCode = 97402,
    CompanyName = "ASDF Company",
    Position = "Manager"


},
new Customer
{
    FirstName = "Anne",
    LastName = "Griffin",
    StreetAddress = "4029 F Street",
    PhoneNumber = 5415550292,
    City = "Eugene",
    State = "OR",
    LastContact = DateTime.Parse("2017-11-25"),
    Notes = "",
    CustomerType = "Lead",
    ZipCode = 97402,
    CompanyName = "WSAD Company",
    Position = "Manager"


},
new Customer
{
    FirstName = "Chris",
    LastName = "West",
    StreetAddress = "2393 B Street",
    PhoneNumber = 5415551920,
    City = "Eugene",
    State = "OR",
    LastContact = DateTime.Parse("2017-11-24"),
    Notes = "",
    CustomerType = "Lead",
    ZipCode = 97408,
    CompanyName = "FAST Analytics",
    Position = "Owner"
},
new Customer
{
    FirstName = "Sue",
    LastName = "Brown",
    StreetAddress = "3092 C Street",
    PhoneNumber = 5415559828,
    City = "Eugene",
    State = "OR",
    LastContact = DateTime.Parse("2017-11-23"),
    Notes = "",
    CustomerType = "Lead",
    ZipCode = 97405,
    CompanyName = "XYZ Company",
    Position = "Manager"


},
new Customer
{
    FirstName = "Paul",
    LastName = "Robbins",
    StreetAddress = "1982 A Street",
    PhoneNumber = 5415552828,
    City = "Eugene",
    State = "OR",
    LastContact = DateTime.Parse("2017-11-22"),
    Notes = "",
    CustomerType = "Lead",
    ZipCode = 97478,
    CompanyName = "ABC Company",
    Position = "Manager"

}

                );
                context.SaveChanges();
            }
        }
    }
}
