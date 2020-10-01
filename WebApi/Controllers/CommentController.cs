using Business.Abstract;
using Entities.Dtos.Comment;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ICommentService _commentService;

        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        [Authorize]
        [HttpPost("Add")]
        public async Task<IActionResult> Add(CommentForAddUpdateDto dto)
        {
            var result = await _commentService.Add(dto);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [Authorize]
        [HttpPost("Update")]
        public async Task<IActionResult> Update(CommentForAddUpdateDto dto)
        {
            var result = await _commentService.Update(dto);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [Authorize]
        [HttpPost("Delete")]
        public async Task<IActionResult> Delete(CommentForDeleteDto dto)
        {
            var result = await _commentService.Delete(dto);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [Authorize]
        [HttpGet("GetComment")]
        public async Task<IActionResult> GetComment(CommentForGetDto dto)
        {
            var result = await _commentService.GetComment(dto);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [Authorize]
        [HttpGet("GetCommentList")]
        public async Task<IActionResult> GetCommentList(CommentForGetListDto dto)
        {
            var result = await _commentService.GetCommentList(dto);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}