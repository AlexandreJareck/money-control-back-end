using System.ComponentModel.DataAnnotations;

namespace MoneyControl.App.DTOs
{
    public class TransactionDTO
    {
        public const string ErrorMessage = "Campo {0} é obrigatório!";

        public TransactionDTO(Guid id)
        {
            Id = id;
            CreatedAt = DateTime.Now;
        }


        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = ErrorMessage)]
        [StringLength(100, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracateres", MinimumLength = 5)]
        public string? Description { get; set; }

        [Required(ErrorMessage = ErrorMessage)]
        [StringLength(50, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracateres", MinimumLength = 2)]
        public string? Type { get; set; }

        [Required(ErrorMessage = ErrorMessage)]
        [StringLength(50, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracateres", MinimumLength = 2)]
        public string? Category { get; set; }

        [Required(ErrorMessage = ErrorMessage)]
        public decimal? Price { get; set; }

        
        public DateTime? CreatedAt { get; set; }
    }
}
