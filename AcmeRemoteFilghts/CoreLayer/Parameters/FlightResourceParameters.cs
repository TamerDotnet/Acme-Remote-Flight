using AcmeRemoteFilghts.CoreLayer.SourceValidators;
using FluentValidation.Attributes;
using System;

namespace AcmeRemoteFilghts.CoreLayer.Parameters
{
    [Validator(typeof(FlightResourceValidators))]
    public class FlightResourceParameters
    {  
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int numberOfTicketsRequested { get; set; }
    }
}
