using oee.Captura;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace oee.Oee_Porcentaje
{
  public class OeeAppService : ApplicationService, IOeeAppService
  {
    public OeeAppService(IRepository<Oee, int> repositoryOee)
    {
      RepositoryOee = repositoryOee;
    }

    public IRepository<Oee, int> RepositoryOee { get; }

    public async Task<OeeDto> CreateAsync(OeeDto oeeDto)
    {
      var oee = await RepositoryOee.InsertAsync(
              new Oee
              {
                DescripcionId = oeeDto.DescripcionId,
                Fecha = oeeDto.Fecha,
                GAP_Mins = oeeDto.GAP_Mins,
                GAP_Pzas = oeeDto.GAP_Pzas,
                HoraFinal = oeeDto.HoraFinal,
                HoraInicio = oeeDto.HoraInicio,
                NumeroParte = oeeDto.NumeroParte,
                OE_Porcentaje = oeeDto.OE_Porcentaje,
                Programado = oeeDto.Programado,
                TiempoMuerto = oeeDto.TiempoMuerto,
                TotalReales = oeeDto.TotalReales,
                TurnoId = oeeDto.TurnoId,
              });
      return new OeeDto
      {
        Id = oee.Id,
      };
    }

    public async Task<List<OeeDto>> GetListAsync()
    {
      var items = await RepositoryOee.GetListAsync();
      return items
          .Select(item => new OeeDto
          {
            Id = item.Id,
            TurnoId = item.TurnoId,
            TotalReales = item.TotalReales,
            TiempoMuerto = item.TiempoMuerto,
            Programado = item.Programado,
            OE_Porcentaje = item.OE_Porcentaje,
            NumeroParte = item.NumeroParte,
            HoraInicio = item.HoraInicio,
            HoraFinal = item.HoraFinal,
            DescripcionId = item.DescripcionId,
            Fecha = item.Fecha,
            GAP_Mins = item.GAP_Mins,
            GAP_Pzas = item.GAP_Pzas
          }).ToList();
    }
  }
}
