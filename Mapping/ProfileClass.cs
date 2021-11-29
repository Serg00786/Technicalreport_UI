using AutoMapper;
using TechnicalReport.Models;
using TechnicalReport_BL.DTO;
using TechnicalReport_Data.Models.FE;

namespace TechnicalReport.Mapping
{
    public class ProfileClass :Profile
    {
        public ProfileClass()
        {
            CreateMap<ProcDowntimeViewModel, ProcessDowntimes>();
            CreateMap<Date, DateDTO>();

        }
        
    }

}
