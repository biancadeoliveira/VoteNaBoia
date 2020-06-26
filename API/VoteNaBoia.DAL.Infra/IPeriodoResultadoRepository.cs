using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VoteNaBoia.Entities;

namespace VoteNaBoia.DAL.Infra
{
    public interface IPeriodoResultadoRepository : IRepository
    {        
        void CreatePeriodoResultado(PeriodoResultado periodoResultado);
        void UpdatePeriodoResultado(PeriodoResultado periodoResultado);
        Task<List<PeriodoResultado>> GetAllRestaurantesPeriodoAsync(int IDPeriodo);
        Task<List<PeriodoResultado>> GetAllRestaurantesVisitadosAsync(int IDPeriodo);
        Task<List<PeriodoResultado>> GetAllRestaurantesNVisitadosAsync(int IDPeriodo);
        Task<PeriodoResultado> GetPeriodoResultadoAsync(int IDRestaurante, int IDPeriodo);
        Task<PeriodoResultado> GetPeriodoResultadoAsync(int IDPeriodoResultado);
    }
}
