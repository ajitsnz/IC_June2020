using FluentAssertions;
using NUnit.Framework;

namespace IC_June2020.Practice
{
    class FluentAssertionPractice
    {
        [Test]
        public void TC1()
        {
            //Framework validation
            Customer expected = new Customer
            {
                company_name = "testing1",
                country = "NZ1",
                currency = "NZ1",
                phone = "12312312321",
                website = "www.yahoo.com1",
                vat_number = "123121",
                default_language = "en1"
            };

            Customer actual = new Customer
            {
                company_name = "testing",
                country = "NZ",
                currency = "NZ",
                phone = "1231231232",
                website = "www.yahoo.com",
                vat_number = "12312",
                default_language = "en"
            };


            actual.Should().BeEquivalentTo(expected);

        }

    }
}
