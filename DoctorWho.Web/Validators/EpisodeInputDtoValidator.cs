using DoctorWho.Db.Models;
using FluentValidation;

namespace DoctorWho.Web.Validators
{
    public class EpisodeInputDtoValidator : AbstractValidator<EpisodeInputDto>
    {
        public EpisodeInputDtoValidator()
        {
            RuleFor(x => x.AuthorId).NotEmpty();
            RuleFor(x => x.DoctorId).NotEmpty();

            // the requirement suppose SeriesNumber is string but my implementation
            // has int, so I will change the requirement to fit the type
            RuleFor(x => x.SeriesNumber).InclusiveBetween(1, 10);
            RuleFor(x => x.EpisodeNumber).GreaterThan(0);
        }
    }
}
