using Core.Entities.Abstract;

namespace Entities.Dtos.User
{
    public class UserForDeleteDto : IDto
    {
        public int Id { get; set; }
    }
}