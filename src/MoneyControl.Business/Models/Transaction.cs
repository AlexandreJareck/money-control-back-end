using FluentValidation;

namespace MoneyControl.Business.Models;

public class Transaction : Entity
{
    public string? Description { get; set; }
    public string? Type { get; set; }
    public string? Category { get; set; }
    public decimal? Price { get; set; }
    public DateTime? CreatedAt { get; set; }
}

public class TransactionValidation : AbstractValidator<Transaction>
{
    public TransactionValidation()
    {
        RuleFor(f => f.Description)
                .NotEmpty()
                .WithMessage("O campo {PropertyName} é obrigatório!")
                .Length(3, 100)
                .WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres.");

        RuleFor(f => f.Type)
                .NotEmpty()
                .WithMessage("O campo {PropertyName} é obrigatório!")
                .Length(3, 50)
                .WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres.");

        RuleFor(f => f.Category)
                .NotEmpty()
                .WithMessage("O campo {PropertyName} é obrigatório!")
                .Length(3, 50)
                .WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres.");

        RuleFor(f => f.Price)
                .NotEmpty()
                .WithMessage("O campo {PropertyName} é obrigatório!")
                .GreaterThan(0)
                .WithMessage("O campo {PropertyName} deve ser maior que 0.");
    }
}
