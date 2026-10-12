
using System.ComponentModel.DataAnnotations;

namespace demoWebApplication1.Models
{
    public class Question
    {
        public int Id { get; set; }

        [Required]
        [StringLength(1000)]
        public string Text { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        public string Subject { get; set; } = string.Empty;

        [Required]
        [StringLength(500)]
        public string OptionA { get; set; } = string.Empty;

        [Required]
        [StringLength(500)]
        public string OptionB { get; set; } = string.Empty;

        [Required]
        [StringLength(500)]
        public string OptionC { get; set; } = string.Empty;

        [Required]
        [StringLength(500)]
        public string OptionD { get; set; } = string.Empty;

        [Required]
        [RegularExpression("^[A-D]$",
            ErrorMessage = "CorrectOption must be A, B, C, or D.")]
        public string CorrectOption { get; set; } = string.Empty;
    }
}
