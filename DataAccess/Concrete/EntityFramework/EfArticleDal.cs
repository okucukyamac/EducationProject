using Core.DataAccess.Abstract;
using Core.DataAccess.Concrete.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class ArticleDal : EfEntityRepositoryBase<Article>, IArticleDal
    {
        public ArticleDal(DbContext context) : base(context)
        {
        }
    }
}
