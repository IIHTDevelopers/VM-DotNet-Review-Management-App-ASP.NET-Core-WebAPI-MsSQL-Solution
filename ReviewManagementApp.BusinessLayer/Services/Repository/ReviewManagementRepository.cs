using Microsoft.EntityFrameworkCore;
using ReviewManagementApp.BusinessLayer.ViewModels;
using ReviewManagementApp.DataLayer;
using ReviewManagementApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ReviewManagementApp.BusinessLayer.Services.Repository
{
    public class ReviewManagementRepository : IReviewManagementRepository
    {
        private readonly ReviewManagementAppDbContext _dbContext;
        public ReviewManagementRepository(ReviewManagementAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Review> CreateReview(Review ReviewModel)
        {
            try
            {
                var result = await _dbContext.Reviews.AddAsync(ReviewModel);
                await _dbContext.SaveChangesAsync();
                return ReviewModel;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public async Task<bool> DeleteReviewById(long id)
        {
            try
            {
                _dbContext.Remove(_dbContext.Reviews.Single(a => a.ReviewId== id));
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public List<Review> GetAllReviews()
        {
            try
            {
                var result = _dbContext.Reviews.
                OrderByDescending(x => x.ReviewId).Take(10).ToList();
                return result;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public async Task<Review> GetReviewById(long id)
        {
            try
            {
                return await _dbContext.Reviews.FindAsync(id);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

       
        public async Task<Review> UpdateReview(ReviewViewModel model)
        {
            var Review = await _dbContext.Reviews.FindAsync(model.ReviewId);
            try
            {

                _dbContext.Reviews.Update(Review);
                await _dbContext.SaveChangesAsync();
                return Review;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
    }
}