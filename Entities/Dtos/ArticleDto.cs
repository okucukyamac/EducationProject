using Core.Entittes.Abstract;
using Core.Utilities.Results.ComplexTypes;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos
{
    public class ArticleDto:DtoGetBase
    {
        public Article Article{ get; set; }

    }
}
