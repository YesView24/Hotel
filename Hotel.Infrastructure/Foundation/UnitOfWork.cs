using Hotel.Application;

namespace Hotel.Infrastructure.Foundation
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly HotelDbContext _dbContext;

        public UnitOfWork( HotelDbContext dbContext )
        {
            _dbContext = dbContext;
        }

        public void Commit()
        {
            _dbContext.SaveChanges();
        }
    }
}