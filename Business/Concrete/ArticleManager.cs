using AutoMapper;
using Business.Abstract;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.ComplexTypes;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ArticleManager : IArticleService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ArticleManager(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;

        }

        public async Task<IDataResult<ArticleDto>> Add(ArticleAddDto articleAddDto, string createdByName)
        {
            var article = _mapper.Map<Article>(articleAddDto);
            article.InsertByName = createdByName;
            article.ModifiedByName = createdByName;
            article.UserId = 1;

            var addedArticle = await _unitOfWork.Articles.AddAsync(article);
            await _unitOfWork.SaveAsync();

            return new DataResult<ArticleDto>(ResultStatus.Success, $"{articleAddDto.Title} başlıklı makale başarıyla eklendi.",new ArticleDto
            {
                Article= addedArticle,
                ResultStatus=ResultStatus.Success,
                Message= $"{articleAddDto.Title} başlıklı makale başarıyla eklendi."
            });
        }

        public async Task<IResult> Delete(int articleId, string modifiedByName)
        {
            var result = await _unitOfWork.Articles.AnyAsync(a => a.Id == articleId);

            if (!result)
                return new Result(ResultStatus.Error, "Böyle bir makale bulunamadı.");

            var article = await _unitOfWork.Articles.GetAsync(a => a.Id == articleId);
            article.IsDeleted = true;
            article.ModifiedByName = modifiedByName;
            article.ModifiedDate = DateTime.Now;

            await _unitOfWork.Articles.UpdateAsync(article);
            await _unitOfWork.SaveAsync();

            return new Result(ResultStatus.Success, $"{article.Title} başlıklı makale başarıyla silindi.");

        }

        public async Task<IDataResult<ArticleDto>> Get(int articleId)
        {
            var article = await _unitOfWork.Articles.GetAsync(a => a.Id == articleId, a => a.User, a => a.Category);

            if (article == null)
                return new DataResult<ArticleDto>(ResultStatus.Error, "Böyle bir makale bulunamadı", null);

            return new DataResult<ArticleDto>(ResultStatus.Success, new ArticleDto
            {
                Article = article,
                ResultStatus = ResultStatus.Success
            });
        }

        public async Task<IDataResult<ArticleListDto>> GetAll()
        {
            var articles = await _unitOfWork.Articles.GetAllAsync(null, a => a.User, a => a.Category);

            if (articles.Count > -1)
            {
                return new DataResult<ArticleListDto>(ResultStatus.Success, new ArticleListDto
                {
                    Articles = articles,
                    ResultStatus = ResultStatus.Success
                });
            }

            return new DataResult<ArticleListDto>(ResultStatus.Error, "Makaleler bulunamadı", null);
        }

        public async Task<IDataResult<ArticleListDto>> GetAllByCategory(int categoryId)
        {
            var result = await _unitOfWork.Categories.AnyAsync(c => c.Id == categoryId);

            if (!result)
                return new DataResult<ArticleListDto>(ResultStatus.Error, "Böyle bir kategori bulunamadı", null);

            var articles = await _unitOfWork.Articles.GetAllAsync(a => a.CategoryId == categoryId && !a.IsDeleted && a.IsActive, a => a.User, a => a.Category);

            if (articles.Count > -1)
            {
                return new DataResult<ArticleListDto>(ResultStatus.Success, new ArticleListDto
                {
                    Articles = articles,
                    ResultStatus = ResultStatus.Success
                });
            }

            return new DataResult<ArticleListDto>(ResultStatus.Error, "Makaleler bulunamadı", null);
        }

        public async Task<IDataResult<ArticleListDto>> GetAllByNonDeleted()
        {
            var articles = await _unitOfWork.Articles.GetAllAsync(a => !a.IsDeleted, a => a.User, a => a.Category);

            if (articles.Count > -1)
            {
                return new DataResult<ArticleListDto>(ResultStatus.Success, new ArticleListDto
                {
                    Articles = articles,
                    ResultStatus = ResultStatus.Success
                });
            }

            return new DataResult<ArticleListDto>(ResultStatus.Error, "Makaleler bulunamadı", null);
        }

        public async Task<IDataResult<ArticleListDto>> GetAllByNonDeletedAndActive()
        {
            var articles = await _unitOfWork.Articles.GetAllAsync(a => !a.IsDeleted && a.IsActive, a => a.User, a => a.Category);

            if (articles.Count > -1)
            {
                return new DataResult<ArticleListDto>(ResultStatus.Success, new ArticleListDto
                {
                    Articles = articles,
                    ResultStatus = ResultStatus.Success
                });
            }

            return new DataResult<ArticleListDto>(ResultStatus.Error, "Makaleler bulunamadı", null);
        }

        public async Task<IResult> HardDelete(int articleId)
        {
            var result = await _unitOfWork.Articles.AnyAsync(a => a.Id == articleId);

            if (!result)
                return new Result(ResultStatus.Error, "Böyle bir makale bulunamadı.");

            var article = await _unitOfWork.Articles.GetAsync(a => a.Id == articleId);

            await _unitOfWork.Articles.DeleteAsync(article);
            await _unitOfWork.SaveAsync();

            return new Result(ResultStatus.Success, $"{article.Title} başlıklı makale başarıyla veritabanından silindi.");
        }

        public async Task<IDataResult<ArticleDto>> Update(ArticleUpdateDto articleUpdateDto, string modifiedByName)
        {
            Article article = _mapper.Map<Article>(articleUpdateDto);
            article.ModifiedByName = modifiedByName;

            var updatedArticle = await _unitOfWork.Articles.UpdateAsync(article);
            await _unitOfWork.SaveAsync();

            return new DataResult<ArticleDto>(ResultStatus.Success, $"{articleUpdateDto.Title} isimli makale başarıyla güncellendi.", new ArticleDto
            {
                Article = updatedArticle,
                ResultStatus = ResultStatus.Success,
                Message = $"{articleUpdateDto.Title} isimli makale başarıyla güncellendi."
            });
        }
    }
}
