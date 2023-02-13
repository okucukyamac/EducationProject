using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IUnitOfWork:IAsyncDisposable
    {
        IArticleDal Articles { get; } //IUnitOfWork.Articles
        ICategoryDal Categories { get; }
        ICommentDal Comments { get; }
        IRoleDal Roles { get; }
        IUserDal Users { get; } //_unitOfWork.Categories.AddAsync();
        //_unitOfWork.Categories.AddAsync(category);
        //_unitOfWork.Users.AddAsync(user);
        //_unitOfWork.SaveAsync();

        Task<int> SaveAsync();
    }
}
