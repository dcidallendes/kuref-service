using System;
namespace Kuref.Service.Dto
{
    public class MeasurementDto
    {
        public int MeasurementTypeId { get; set; }
        public double Value { get; set; }
        public DateTime MeasurementTime { get; set; }
    }
}
