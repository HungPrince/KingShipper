using KingShipper.Data.Repositories;
using KingShipper.Entity;
using System;

namespace KingShipper.Data
{
    public class UnitOfWork : IDisposable
    {
        private readonly KingShipperContext _context = new KingShipperContext();

        private UserRepository _UserRepository;
        private BusinessRepository _BusinessRepository;
        private PermissionRepository _PermissionRepository;
        private UserBusinessRepository _UserBusinessRepository;
        private UserPermissionRepository _UserPermissionRepository;
        private CategoryRepository _CategoryRepository;

        public UserRepository UserRepository
        {
            get { return _UserRepository ?? (_UserRepository = new UserRepository(_context)); }
        }

        public BusinessRepository BusinessRepository
        {
            get { return _BusinessRepository ?? (_BusinessRepository = new BusinessRepository(_context)); }
        }

        public PermissionRepository PermissionRepository
        {
            get { return _PermissionRepository ?? (_PermissionRepository = new PermissionRepository(_context)); }
        }

        public UserBusinessRepository UserBusinessRepository
        {
            get { return _UserBusinessRepository ?? (_UserBusinessRepository = new UserBusinessRepository(_context)); }
        }

        public UserPermissionRepository UserPermissionRepository
        {
            get { return _UserPermissionRepository ?? (_UserPermissionRepository = new UserPermissionRepository(_context)); }
        }

        public CategoryRepository CategoryRepository
        {
            get { return _CategoryRepository ?? (_CategoryRepository = new CategoryRepository(_context)); }
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
