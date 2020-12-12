using System.ComponentModel.DataAnnotations;

namespace Safenet.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}