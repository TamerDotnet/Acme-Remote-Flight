using AcmeRemoteFilghts.PresentaionLayer.Models;
using FluentValidation;
using System;

namespace AcmeRemoteFilghts.PresentaionLayer.Validators
{
    public class FlightViewModelValidator : AbstractValidator<FlightViewModel>
    {
        public FlightViewModelValidator()
        {
            RuleFor(x => x.ArriveTime).Must(BeAValidDate).WithMessage("Start Date should be a valid date");
            RuleFor(x => x.DepartTime).Must(BeAValidDate).WithMessage("End Date should be a valid date");
            RuleFor(x => x.MaxPassangers).GreaterThan(0).WithMessage("Please provide Max number of passangers for the flight");
        }

        private bool BeAValidDate(DateTime date)
        {
            return !date.Equals(default(DateTime));
        }
    }
}
