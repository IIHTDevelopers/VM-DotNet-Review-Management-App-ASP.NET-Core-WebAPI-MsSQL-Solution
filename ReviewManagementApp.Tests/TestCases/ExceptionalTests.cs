

using Moq;
using ReviewManagementApp.BusinessLayer.Services.Repository;
using ReviewManagementApp.BusinessLayer.Services;
using ReviewManagementApp.BusinessLayer.ViewModels;
using ReviewManagementApp.DataLayer;
using ReviewManagementApp.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;
using ReviewManagementApp.BusinessLayer.Interfaces;

namespace ReviewManagementApp.Tests.TestCases
{
    public class ExceptionalTests
    {
        private readonly ITestOutputHelper _output;
        private readonly ReviewManagementAppDbContext _dbContext;

        private readonly IReviewManagementService  _reviewService;
        public readonly Mock<IReviewManagementRepository> reviewservice = new Mock<IReviewManagementRepository>();

        private readonly Review _review;
            
        private readonly ReviewViewModel _reviewViewModel;

        private static string type = "Exception";

        public ExceptionalTests(ITestOutputHelper output)
        {
             _reviewService = new ReviewManagementService(reviewservice.Object);

            _output = output;

            _review = new Review
            {
                ReviewId = 1,
                Comment = "Comment",
                SubmissionDate = DateTime.Now,
                Rating = 2,
                UserId = 1
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
        public async Task<bool> Testfor_Validate_ifInvalidReviewIdIsPassed()
        {
            //Arrange
            bool res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();

            //Action
            try
            {
                reviewservice.Setup(repo => repo.CreateReview(_review)).ReturnsAsync(_review);
                var result = await  _reviewService.CreateReview(_review);
                if (result != null || result.ReviewId !=0)
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
        public async Task<bool> Testfor_Validate_ifInvalidReviewRatingIsPassed()
        {
            //Arrange
            bool res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();

            //Action
            try
            {
                reviewservice.Setup(repo => repo.CreateReview(_review)).ReturnsAsync(_review);
                var result = await _reviewService.CreateReview(_review);
                if (result != null || result.Rating != 0)
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