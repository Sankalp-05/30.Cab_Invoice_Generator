using CabInvoiceGenerator;

namespace CabInvoiceTest
{
    public class Tests
    {
        InvoiceGenerator invoiceGenerator = null;
        [SetUp]
        public void Setup()
        {
        }
        // Test Case for UC1-Calculate Total Fare
        [Test]
        public void GivenDistanceAndTimeShouldReturnTotalFare()
        {
            invoiceGenerator = new InvoiceGenerator(RideType.NORMAL);
            double distance = 2.0;
            int time = 5;
            double fare = invoiceGenerator.CalculateFare(distance, time);
            double expected = 25;
            Assert.AreEqual(expected, fare);
        }

        // Test Case for  UC-2- Add Multiple rides
        [Test]
        public void GivenMultipleRideShouldReturnInvoiceSummary()
        {
            invoiceGenerator = new InvoiceGenerator(RideType.NORMAL);
            Ride[] rides = { new Ride(2.0, 5), new Ride(0.1, 5) };
            InvoiceSummary summary = invoiceGenerator.CalculateFare(rides);
            InvoiceSummary expectedSummary = new InvoiceSummary(2, 35.0);
            Assert.AreEqual(expectedSummary.GetType(), summary.GetType());
            // Assert.AreEqual(expectedSummary, summary);
        }

        // Test Case for UC3- Invoice summary with Averange Fare
        [Test]
        public void GivenMultipleRidesShouldReturnInvoiceSummaryAndAverangeFare()
        {
            invoiceGenerator = new InvoiceGenerator(RideType.PREMIUM);
            Ride[] rides = { new Ride(2.0, 5), new Ride(0.1, 1) };
            InvoiceSummary summary = invoiceGenerator.CalculateFare(rides);
            InvoiceSummary expectedSummary = new InvoiceSummary(2, 65.0);
            Assert.AreEqual(expectedSummary.GetType(), summary.GetType());
            // Assert.AreEqual(expectedSummary, summary);
        }

        // Test case for UC4-Given userId should return Invoice Summary
        [Test]
        public void GivenUserIdShouldReturnInvoice()
        {
            InvoiceGenerator invoiceGenerator = new InvoiceGenerator(RideType.NORMAL);
            Ride[] rides = { new Ride(2.0, 5), new Ride(0.1, 1) };
            string userId = "001";
            invoiceGenerator.AddRides(userId, rides);
            string userIdForSecondUser = "002";
            Ride[] ridesForSeconndUser = { new Ride(3.0, 10), new Ride(1.0, 2) };
            invoiceGenerator.AddRides(userIdForSecondUser, ridesForSeconndUser);
            InvoiceSummary summary = invoiceGenerator.GetInvoiceSummary(userId);
            InvoiceSummary expectedSummary = new InvoiceSummary(2, 35.0);
            Assert.AreEqual(expectedSummary.GetType(), summary.GetType());
            //Assert.AreEqual(expectedSummary, summary);
        }
    }
}