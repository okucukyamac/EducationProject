using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.EntityFramework.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ProgrammersBlogContext _context;
        private EfArticleDal _articleDal;
        private EfCategoryDal _categoryDal;
        private EfCommentDal _commentDal;
        private EfRoleDal _roleDal;
        private EfUserDal _userDal;

        public UnitOfWork(ProgrammersBlogContext content)
        {
            _context = content;
        }

        public IArticleDal Articles => _articleDal ?? new EfArticleDal(_context);

        public ICategoryDal Categories => _categoryDal ?? new EfCategoryDal(_context);

        public ICommentDal Comments => _commentDal ?? new EfCommentDal(_context);

        public IRoleDal Roles => _roleDal ?? new EfRoleDal(_context);

        public IUserDal Users => _userDal ?? new EfUserDal(_context);

        public async ValueTask DisposeAsync()
        {
            await _context.DisposeAsync();
        }

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
