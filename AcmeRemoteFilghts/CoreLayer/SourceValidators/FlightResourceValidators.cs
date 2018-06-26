using AcmeRemoteFilghts.CoreLayer.Parameters;
using FluentValidation;
using System;

namespace AcmeRemoteFilghts.CoreLayer.SourceValidators
{
    public class FlightResourceValidators : AbstractValidator<FlightResourceParameters>
    {
        public FlightResourceValidators()
        {
            RuleFor(x => x.StartDate).Must(BeAValidDate).WithMessage("Start Date should be a valid date");
            RuleFor(x => x.EndDate).Must(BeAValidDate).WithMessage("End Date should be a valid date");
            RuleFor(x => x.numberOfTicketsRequested).GreaterThan(0).WithMessage("Please provide number of passangers need bookings");
        }

        private bool BeAValidDate(DateTime date)
        {
            return !date.Equals(default(DateTime));
        }
    }
}
