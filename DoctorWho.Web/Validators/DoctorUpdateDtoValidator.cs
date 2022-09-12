using DoctorWho.Db.Models;
using FluentValidation;

namespace DoctorWho.Web.Validators
{
    public class DoctorUpdateDtoValidator : AbstractValidator<DoctorUpdateDto>
    {
        public DoctorUpdateDtoValidator()
        {
            RuleFor(c => c.DoctorName).NotEmpty();
            RuleFor(c => c.DoctorNumber).NotEmpty();

            RuleFor(c => c.LastEpisodeDate).Equal(new DateTime())
                .When(c => c.FirstEpisodeDate.Equals(new DateTime()))
                .WithMessage("'lastEpisodeDate' should be empty when 'firstEpisodeDate' is empty");

            RuleFor(c => c.LastEpisodeDate.CompareTo(c.FirstEpisodeDate)).GreaterThan(0)
                .When(c => c.FirstEpisodeDate.CompareTo(new DateTime()) > 0)
                .WithMessage("'firstEpisodeDate' must be earlier than 'lastEpisodeDate'");
        }
    }
}
