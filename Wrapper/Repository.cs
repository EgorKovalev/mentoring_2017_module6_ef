using System;
using Model.Implementations;
using Domain.Entities;

namespace Wrapper
{
    public class Repository : IDisposable
	{
		private DatabaseContext _dbContext = new DatabaseContext();

		private EfGenericRepository<Auction> _auctionRepository;
		private EfGenericRepository<Bid> _bidRepository;
		private EfGenericRepository<Category> _categoryRepository;
        private EfGenericRepository<Image> _imageRepository;
        private EfGenericRepository<Item> _itemRepository;
        private EfGenericRepository<Period> _periodRepository;
        private EfGenericRepository<User> _userRepository;

        public EfGenericRepository<Auction> AuctionRepository
		{
			get
			{
				if (this._auctionRepository == null)
				{
					this._auctionRepository = new EfGenericRepository<Auction>(_dbContext);
				}
				return _auctionRepository;
			}
		}

        public EfGenericRepository<Bid> BidRepository
        {
            get
            {
                if (this._bidRepository == null)
                {
                    this._bidRepository = new EfGenericRepository<Bid>(_dbContext);
                }
                return _bidRepository;
            }
        }

        public EfGenericRepository<Category> CategoryRepository
        {
            get
            {
                if (this._categoryRepository == null)
                {
                    this._categoryRepository = new EfGenericRepository<Category>(_dbContext);
                }
                return _categoryRepository;
            }
        }

        public EfGenericRepository<Image> ImageRepository
        {
            get
            {
                if (this._imageRepository == null)
                {
                    this._imageRepository = new EfGenericRepository<Image>(_dbContext);
                }
                return _imageRepository;
            }
        }

        public EfGenericRepository<Item> ItemRepository
        {
            get
            {
                if (this._itemRepository == null)
                {
                    this._itemRepository = new EfGenericRepository<Item>(_dbContext);
                }
                return _itemRepository;
            }
        }

        public EfGenericRepository<Period> PeriodRepository
        {
            get
            {
                if (this._periodRepository == null)
                {
                    this._periodRepository = new EfGenericRepository<Period>(_dbContext);
                }
                return _periodRepository;
            }
        }

        public EfGenericRepository<User> UserRepository
        {
            get
            {
                if (this._userRepository == null)
                {
                    this._userRepository = new EfGenericRepository<User>(_dbContext);
                }
                return _userRepository;
            }
        }

        public void CommitChanges()
		{
			_dbContext.SaveChanges();
		}

		private bool disposed = false;

		protected virtual void Dispose(bool disposing)
		{
			if (!this.disposed)
			{
				if (disposing)
				{
					_dbContext.Dispose();
				}
			}
			this.disposed = true;
		}

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}
	}
}
