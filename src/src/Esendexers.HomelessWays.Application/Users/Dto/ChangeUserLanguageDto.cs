using System.ComponentModel.DataAnnotations;

namespace Esendexers.HomelessWays.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}