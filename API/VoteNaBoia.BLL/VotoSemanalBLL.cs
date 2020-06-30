using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VoteNaBoia.BLL.Infra;
using VoteNaBoia.DAL.Infra;
using VoteNaBoia.Entities;

namespace VoteNaBoia.BLL
{
    public class VotoSemanalBLL : IVotoSemanalBLL
    {
        private readonly IVotoSemanalRepository _votoSemanalRepository;
        private readonly IPeriodoBLL _periodoBLL;
        private readonly IPeriodoResultadoBLL _periodoResultadoBLL;

        public VotoSemanalBLL(IVotoSemanalRepository votoSemanalRepository, IPeriodoBLL periodoBLL, IPeriodoResultadoBLL periodoResultadoBLL)
        {
            _votoSemanalRepository = votoSemanalRepository;
            _periodoBLL = periodoBLL;
            _periodoResultadoBLL = periodoResultadoBLL;
        }

        public void Dispose()
        {
            _votoSemanalRepository?.Dispose();
            _periodoBLL?.Dispose();
        }

        public async Task<bool> AddVotoSemanal(int IDTurmaAluno, int IDRestaurante, int IDPeriodo)
        {
            //Validar se aluno já votou
            
            var periodo = _periodoBLL.GetPeriodoAsync(IDPeriodo).Result;

            // Verificar se existe o periodo passado como parâmetro
            if(periodo != null)
            {
                if (periodo.SNAtivo.Equals('S'))
                {
                    //Validar Limite votação semanal
                    //Validar restaurante periodo.I
                    //Validar TurmaAluno
                    var votoSemanal = new VotoSemanal(0, IDRestaurante, IDPeriodo, IDTurmaAluno, DateTime.Now);

                    _votoSemanalRepository.AddVotoSemanal(votoSemanal);
                    await _votoSemanalRepository.UnitOfWork.Commit();
                    
                    return true;
                }
                return false;
            }
            return false;
        }

        public async Task<bool> CalcResultVotoSemanal(int IDPeriodo)
        {
            //Validar se o horario de votação já encerrou
            var result = _votoSemanalRepository.GetAllVotosPeriodoAsync(IDPeriodo).Result;
            List<int> li = new List<int>();

            foreach (var a in result)
            {
                li.Add(a.IDRestaurante);
            }

            var q = li.GroupBy(x => x)
                      .Select(g => new { IDRestaurante = g.Key, Count = g.Count() })
                      .OrderByDescending(x => x.Count);
            
            foreach(var x in q)
            {
                await _periodoResultadoBLL.CreatePeriodoResultado(IDPeriodo, x.IDRestaurante, x.Count);
            }

            return true;
        }

        public Task<List<VotoSemanal>> GetAllVotosPeriodoAsync(int IDPeriodo)
        {
            throw new NotImplementedException();
        }

        public Task<VotoSemanal> GetVotoSemanal(int IDVotoSemanal)
        {
            throw new NotImplementedException();
        }

        public Task<VotoSemanal> GetVotoSemanal(int IDPeriodo, int IDTurmaAluno)
        {
            throw new NotImplementedException();
        }
    }
}
