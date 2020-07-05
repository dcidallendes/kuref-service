using System;
using System.Collections.Generic;

namespace Kuref.Service.Dto
{
    public class StationMeasurementsDto
    {
        public int StationId { get; set; }

        public Dictionary<int, List<MeasurementDto>> Measurements { get; set; }
    }
}
