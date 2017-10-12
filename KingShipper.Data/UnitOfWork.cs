using KingShipper.Data.Repositories;
using KingShipper.Entity;
using System;

namespace KingShipper.Data
{
    public class UnitOfWork : IDisposable
    {
        private readonly KingShipperContext _context = new KingShipperContext();

        private UserRepository _UserRepository;
        
        public UserRepository UserRepository
        {
            get { return _UserRepository ?? (_UserRepository = new UserRepository(_context)); }
        }
       
        public void Save()
        {
            _context.SaveChanges();
        }

        private bool _disposed;

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
