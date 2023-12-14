using ReviewManagementApp.BusinessLayer.Interfaces;
using ReviewManagementApp.BusinessLayer.Services.Repository;
using ReviewManagementApp.BusinessLayer.ViewModels;
using ReviewManagementApp.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ReviewManagementApp.BusinessLayer.Services
{
    public class ReviewManagementService : IReviewManagementService
    {
        private readonly IReviewManagementRepository _repo;

        public ReviewManagementService(IReviewManagementRepository repo)
        {
            _repo = repo;
        }

        public async Task<Review> CreateReview(Review employeeReview)
        {
            return await _repo.CreateReview(employeeReview);
        }

        public async Task<bool> DeleteReviewById(long id)
        {
            return await _repo.DeleteReviewById(id);
        }

        public List<Review> GetAllReviews()
        {
            return  _repo.GetAllReviews();
        }

        public async Task<Review> GetReviewById(long id)
        {
            return await _repo.GetReviewById(id);
        }

        public async Task<Review> UpdateReview(ReviewViewModel model)
        {
           return await _repo.UpdateReview(model);
        }
    }
}
