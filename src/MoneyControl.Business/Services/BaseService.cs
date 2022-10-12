using FluentValidation;
using FluentValidation.Results;
using MoneyControl.Business.Interfaces;
using MoneyControl.Business.Models;
using MoneyControl.Business.Notifications;

namespace MoneyControl.Business.Services;

public abstract class BaseService
{
    private readonly INotifier _notifier;

    public BaseService(INotifier notifier)
    {
        _notifier = notifier;
    }

    protected void Notify(ValidationResult validationResult)
    {
        validationResult.Errors.ForEach(error => Notify(error.ErrorMessage));
    }

    protected void Notify(string message)
    {
        _notifier.Add(new Notification(message));
    }

    protected bool ExecuteValidation<TV, TE>(TV validation, TE entity) where TV : AbstractValidator<TE> where TE : Entity
    {
        var validator = validation.Validate(entity);

        if (validator.IsValid)
            return true;

        Notify(validator);

        return false;
    }
}
