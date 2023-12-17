Edited now
using System.Text.RegularExpressions;
using DSCEmiratiAPI.Data.Repositories;
using DSCData.Dtos;
using FluentValidation;

namespace DSCEmiratiAPI.Validators;

public partial class EventEmiratiRegistrationCreateValidator
    : AbstractValidator
{
    public EventEmiratiRegistrationCreateValidator(IEventRepo eventRepo)
    {
        RuleFor(x => x.EventID)
            .NotNull()
            .WithMessage("EventID is required")
            .MustAsync(
                async (eventID, cancellation) =>
                {
                    return await eventRepo.GetAsync(eventID) != null;
                }
            )
            .WithMessage("EventID is invalid")
            .MustAsync(
                async (eventID, cancellation) =>
                {
                    return !await eventRepo.IsEventFullAsync(eventID);
                }
            )
            .WithMessage("Event is full");

        RuleFor(x => x.FullName).NotNull().WithMessage("FullName is required");

        RuleFor(x => x.Email)
            .NotNull()
            .WithMessage("Email is required")
            .EmailAddress()
            .WithMessage("Email is invalid");

        RuleFor(x => x.Mobile)
            .NotNull()
            .WithMessage("Mobile is required")
            .Matches(PhoneNumber())
            .WithMessage("Mobile is invalid");

        RuleFor(x => x.EmiratesID).NotNull().WithMessage("EmiratesID is required");
    }

    [GeneratedRegex("^\\d{10}$")]
    private static partial Regex PhoneNumber();
}
