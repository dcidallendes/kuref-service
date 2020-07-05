using System;
using System.Collections.Generic;

namespace Kuref.Service.Dto
{
    public class StationMeasurementsDto
    {
        public int StationId { get; set; }

        public List<MeasurementDto> Measurements { get; set; }
    }
}
