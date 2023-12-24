using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReviewManagementApp.BusinessLayer.Interfaces;
using ReviewManagementApp.BusinessLayer.ViewModels;
using ReviewManagementApp.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using ReviewManagementApp.Entities;

namespace ReviewManagementApp.Controllers
{
    [ApiController]
    public class ReviewManagementController : ControllerBase
    {
        private readonly IReviewManagementService  _reviewService;
        public ReviewManagementController(IReviewManagementService reviewservice)
        {
             _reviewService = reviewservice;
        }

        [HttpPost]
        [Route("create-review")]
        [AllowAnonymous]
        public async Task<IActionResult> CreateReview([FromBody] Review model)
        {
            var ReviewExists = await  _reviewService.GetReviewById(model.ReviewId);
            if (ReviewExists != null)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Review already exists!" });
            var result = await  _reviewService.CreateReview(model);
            if (result == null)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Review creation failed! Please check details and try again." });

            return Ok(new Response { Status = "Success", Message = "Review created successfully!" });

        }


        [HttpPut]
        [Route("update-review")]
        public async Task<IActionResult> UpdateReview([FromBody] ReviewViewModel model)
        {
            var Review = await  _reviewService.UpdateReview(model);
            if (Review == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response
                { Status = "Error", Message = $"Review With Id = {model.ReviewId} cannot be found" });
            }
            else
            {
                var result = await  _reviewService.UpdateReview(model);
                return Ok(new Response { Status = "Success", Message = "Review updated successfully!" });
            }
        }

      
        [HttpDelete]
        [Route("delete-review")]
        public async Task<IActionResult> DeleteReview(long id)
        {
            var Review = await  _reviewService.GetReviewById(id);
            if (Review == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response
                { Status = "Error", Message = $"Review With Id = {id} cannot be found" });
            }
            else
            {
                var result = await  _reviewService.DeleteReviewById(id);
                return Ok(new Response { Status = "Success", Message = "Review deleted successfully!" });
            }
        }


        [HttpGet]
        [Route("get-review-by-id")]
        public async Task<IActionResult> GetReviewById(long id)
        {
            var Review = await  _reviewService.GetReviewById(id);
            if (Review == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response
                { Status = "Error", Message = $"Review With Id = {id} cannot be found" });
            }
            else
            {
                return Ok(Review);
            }
        }

        [HttpGet]
        [Route("get-all-reviews")]
        public async Task<IEnumerable<Review>> GetAllReviews()
        {
            return   _reviewService.GetAllReviews();
        }
    }
}
