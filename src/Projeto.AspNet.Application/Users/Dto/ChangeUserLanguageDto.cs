using System.ComponentModel.DataAnnotations;

namespace Projeto.AspNet.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}