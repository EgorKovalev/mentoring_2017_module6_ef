using System;
using BusinessLayerAccess.Implementations;
using Domain.Entities;
using BusinessLayerAccess.Interfaces;
using BusinessLayerAccess.Models;

namespace Wrapper
{
    public class Repository : IDisposable
	{
		private DatabaseContext _dbContext = new DatabaseContext();

		private IRepository<Auction> _auctionRepository;
		private IRepository<Bid> _bidRepository;
		private IRepository<Category> _categoryRepository;
        private IRepository<Image> _imageRepository;
        private IRepository<Item> _itemRepository;
        private IRepository<Period> _periodRepository;
        private IRepository<User> _userRepository;
        
        public IRepository<Auction> AuctionRepository
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

        public IRepository<Bid> BidRepository
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

        public IRepository<Category> CategoryRepository
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

        public IRepository<Image> ImageRepository
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

        public IRepository<Item> ItemRepository
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

        public IRepository<Period> PeriodRepository
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

        public IRepository<User> UserRepository
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
