using ReviewManagementApp.BusinessLayer.ViewModels;
using ReviewManagementApp.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ReviewManagementApp.BusinessLayer.Interfaces
{
    public interface IReviewManagementService
    {
        List<Review> GetAllReviews();
        Task<Review> CreateReview(Review review);
        Task<Review> GetReviewById(long id);
        Task<bool> DeleteReviewById(long id);
        Task<Review> UpdateReview(ReviewViewModel model);
    }
}
