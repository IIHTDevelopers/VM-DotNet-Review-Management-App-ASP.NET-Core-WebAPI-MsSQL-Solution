
using Moq;
using ReviewManagementApp.BusinessLayer.Services;
using ReviewManagementApp.BusinessLayer.Services.Repository;
using ReviewManagementApp.BusinessLayer.ViewModels;
using ReviewManagementApp.DataLayer;
using ReviewManagementApp.Entities;
using System;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;
using ReviewManagementApp.BusinessLayer.Interfaces;

namespace ReviewManagementApp.Tests.TestCases
{
     public class FunctionalTests
    {
        private readonly ITestOutputHelper _output;
        private readonly ReviewManagementAppDbContext _dbContext;

        private readonly IReviewManagementService  _reviewService;
        public readonly Mock<IReviewManagementRepository> reviewservice= new Mock<IReviewManagementRepository >();

        private readonly Review _review;
        private readonly ReviewViewModel _reviewViewModel;

        private static string type = "Functional";

        public FunctionalTests(ITestOutputHelper output)
        {
             _reviewService = new ReviewManagementService(reviewservice.Object);
           
            _output = output;

            _review = new Review
            {
                ReviewId = 1,
                Comment="Comment",
                SubmissionDate=DateTime.Now,
                Rating=2,
                UserId=1
            };

            _reviewViewModel = new ReviewViewModel
            {
                ReviewId = 1,
                Comment = "Comment",
                SubmissionDate = DateTime.Now,
                Rating = 2,
                UserId = 1
            };
        }
        
       
        [Fact]
        public async Task<bool> Testfor_Create_Review()
        {
            //Arrange
            var res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();

            //Action
            try
            {
                reviewservice.Setup(repos => repos.CreateReview(_review)).ReturnsAsync(_review);
                var result = await  _reviewService.CreateReview(_review);
                //Assertion
                if (result != null)
                {
                    res = true;
                }
            }
            catch (Exception)
            {
                //Assert
                status = Convert.ToString(res);
                _output.WriteLine(testName + ":Failed");
                await CallAPI.saveTestResult(testName, status, type);
                return false;
            }
            status = Convert.ToString(res);
            if (res == true)
            {
                _output.WriteLine(testName + ":Passed");
            }
            else
            {
                _output.WriteLine(testName + ":Failed");
            }
            await CallAPI.saveTestResult(testName, status, type);
            return res;
        }

        
        [Fact]
        public async Task<bool> Testfor_Update_Review()
        {
            //Arrange
            bool res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
           
            //Action
            try
            {
                reviewservice.Setup(repos => repos.UpdateReview(_reviewViewModel)).ReturnsAsync(_review); 
                var result = await  _reviewService.UpdateReview(_reviewViewModel);
                if (result != null)
                {
                    res = true;
                }
            }
            catch (Exception)
            {
                //Assert
                status = Convert.ToString(res);
                _output.WriteLine(testName + ":Failed");
                await CallAPI.saveTestResult(testName, status, type);
                return false;
            }
            status = Convert.ToString(res);
            if (res == true)
            {
                _output.WriteLine(testName + ":Passed");

            }
            else
            {
                _output.WriteLine(testName + ":Failed");
            }
            await CallAPI.saveTestResult(testName, status, type);
            return res;
        }
        
        [Fact]
        public async Task<bool> Testfor_GetReviewById()
        {
            //Arrange
            var res = false;
            int id = 1;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();

            //Action
            try
            {
                reviewservice.Setup(repos => repos.GetReviewById(id)).ReturnsAsync(_review);
                var result = await  _reviewService.GetReviewById(id);
                //Assertion
                if (result != null)
                {
                    res = true;
                }
            }
            catch (Exception)
            {
                //Assert
                status = Convert.ToString(res);
                _output.WriteLine(testName + ":Failed");
                await CallAPI.saveTestResult(testName, status, type);
                return false;
            }
            status = Convert.ToString(res);
            if (res == true)
            {
                _output.WriteLine(testName + ":Passed");
            }
            else
            {
                _output.WriteLine(testName + ":Failed");
            }
            await CallAPI.saveTestResult(testName, status, type);
            return res;
        }

        [Fact]
        public async Task<bool> Testfor_DeleteReviewById()
        {
            //Arrange
            var res = false;
            int id = 1;
            bool response = true;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();

            //Action
            try
            {
                reviewservice.Setup(repos => repos.DeleteReviewById(id)).ReturnsAsync(response);
                var result = await  _reviewService.DeleteReviewById(id);
                //Assertion
                if (result != null)
                {
                    res = true;
                }
            }
            catch (Exception)
            {
                //Assert
                status = Convert.ToString(res);
                _output.WriteLine(testName + ":Failed");
                await CallAPI.saveTestResult(testName, status, type);
                return false;
            }
            status = Convert.ToString(res);
            if (res == true)
            {
                _output.WriteLine(testName + ":Passed");
            }
            else
            {
                _output.WriteLine(testName + ":Failed");
            }
            await CallAPI.saveTestResult(testName, status, type);
            return res;
        }
       
    }
}