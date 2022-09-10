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
                .When(c => c.FirstEpisodeDate.Equals(new DateTime()));

            RuleFor(c => c.LastEpisodeDate.CompareTo(c.FirstEpisodeDate)).GreaterThan(0);
        }
    }
}
