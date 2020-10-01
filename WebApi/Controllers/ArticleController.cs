using Business.Abstract;
using Entities.Dtos.Article;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticleController : ControllerBase
    {
        private readonly IArticleService _articleService;

        public ArticleController(IArticleService articleService)
        {
            _articleService = articleService;
        }

        [Authorize]
        [HttpPost("Add")]
        public async Task<IActionResult> Add(ArticleForAddUpdateDto dto)
        {
            var result = await _articleService.Add(dto);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [Authorize]
        [HttpPost("Update")]
        public async Task<IActionResult> Update(ArticleForAddUpdateDto dto)
        {
            var result = await _articleService.Update(dto);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [Authorize]
        [HttpPost("Delete")]
        public async Task<IActionResult> Delete(ArticleForDeleteDto dto)
        {
            var result = await _articleService.Delete(dto);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [Authorize]
        [HttpPost("GetArticle")]
        public async Task<IActionResult> GetArticle(ArticleForGetDto dto)
        {
            var result = await _articleService.GetArticle(dto);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [Authorize]
        [HttpPost("GetArticleList")]
        public async Task<IActionResult> GetArticleList(ArticleForGetListDto dto)
        {
            var result = await _articleService.GetArticleList(dto);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}