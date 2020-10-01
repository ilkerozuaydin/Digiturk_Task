using Core.Entities.Abstract;

namespace Entities.Dtos.User
{
    public class UserForAddUpdateDto : IDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}