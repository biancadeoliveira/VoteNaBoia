using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VoteNaBoia.Entities;

namespace VoteNaBoia.BLL.Infra
{
    public interface IPeriodoResultadoBLL : IDisposable
    {
        Task CreatePeriodoResultado(int IDPeriodo, int IDRestaurante, int NOVotos);
        Task UpdateSNVisitado(int IDPeriodoResultado);
        Task<List<PeriodoResultado>> GetAllRestaurantesPeriodoAsync(int IDPeriodo);
        Task<List<PeriodoResultado>> GetAllRestaurantesVisitadosAsync(int IDPeriodo);
        Task<List<PeriodoResultado>> GetAllRestaurantesNVisitadosAsync(int IDPeriodo);
        bool IsRestaurantePeriodoVisitado(int IDPeriodoResultado, int IDRestaurante = 0, int IDPeriodo = 0);
        bool ExistsPeriodoResultado(int IDPeriodoResultado, int IDRestaurante = 0, int IDPeriodo = 0);
    }
}
