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
        private readonly ITurmaConfiguracaoBLL _turmaConfiguracaoBLL;

        public VotoSemanalBLL(IVotoSemanalRepository votoSemanalRepository,
                              IPeriodoBLL periodoBLL, 
                              IPeriodoResultadoBLL periodoResultadoBLL,
                              ITurmaConfiguracaoBLL turmaConfiguracaoBLL)
        {
            _votoSemanalRepository = votoSemanalRepository;
            _periodoBLL = periodoBLL;
            _periodoResultadoBLL = periodoResultadoBLL;
            _turmaConfiguracaoBLL = turmaConfiguracaoBLL;
        }

        public void Dispose()
        {
            _votoSemanalRepository?.Dispose();
            _periodoBLL?.Dispose();
            _periodoResultadoBLL?.Dispose();
            _turmaConfiguracaoBLL?.Dispose();
        }

        public async Task<bool> AddVotoSemanal(int IDTurmaAluno, int IDRestaurante, int IDPeriodo)
        {
            var msg = "";
            var periodo = _periodoBLL.GetPeriodoAsync(IDPeriodo).Result;

            // Verificar se existe o periodo passado como parâmetro
            if(periodo != null)
            {
                if (periodo.SNAtivo.Equals('S') && periodo.SNProcessado.Equals('N'))
                {
                    //Validar se aluno já votou
                    var turmaConfig = _turmaConfiguracaoBLL.GetTurmaConfiguracaoAsync(periodo.IDTurma).Result;
                    var qtdVotos = await _turmaConfiguracaoBLL.GetQtdVotacaoSemanal(periodo.IDTurma);
                    var votosAlunoResult = await _votoSemanalRepository.GetAllVotosPeriodoAlunoAsync(IDPeriodo, IDTurmaAluno);

                    if (votosAlunoResult.Count < qtdVotos || votosAlunoResult == null)
                    {
                        //Validar dia e hora de inicio e termino de votação
                        //Validar restaurante já foi votado pelo aluno no periodo.
                        foreach (var votos in votosAlunoResult)
                        {
                            if(votos.IDRestaurante == IDRestaurante)
                            {
                                msg = "O restaurante já foi votado pelo aluno nesse período e não pode ser votado novamente.";
                                throw new Exception(msg);
                            }
                        }

                        //Validar TurmaAluno
                        var votoSemanal = new VotoSemanal(0, IDRestaurante, IDPeriodo, IDTurmaAluno, DateTime.Now);

                        _votoSemanalRepository.AddVotoSemanal(votoSemanal);
                        await _votoSemanalRepository.UnitOfWork.Commit();

                        return true;
                    }
                    msg = "O Aluno já atingiu o limite de votos para o período";
                    throw new Exception(msg);
                }
                msg = "O periodo não esta ativo ou já foi processado.";
                throw new Exception(msg);
            }
            msg = "O período informado não existe.";
            throw new Exception(msg);
        }

        public async Task<bool> CalcResultVotoSemanal(int IDPeriodo)
        {
            //Validar se o horario de votação já encerrou
            
            List<int> li = new List<int>();
            var msg = "";

            var periodo = _periodoBLL.GetPeriodoAsync(IDPeriodo).Result;
            if(periodo != null)
            {
                if(periodo.SNProcessado.Equals('N'))
                {
                    var max = _turmaConfiguracaoBLL.GetQtdVotacaoSemanal(periodo.IDTurma).Result;

                    var result = _votoSemanalRepository.GetAllVotosPeriodoAsync(IDPeriodo).Result;

                    foreach (var a in result)
                    {
                        li.Add(a.IDRestaurante);
                    }

                    var q = li.GroupBy(x => x)
                              .Select(g => new { IDRestaurante = g.Key, Count = g.Count() })
                              .OrderByDescending(x => x.Count);

                    foreach (var x in q)
                    {
                        if (max != 0)
                        {
                            await _periodoResultadoBLL.CreatePeriodoResultado(IDPeriodo, x.IDRestaurante, x.Count);
                        }
                        else
                        {
                            break;
                        }
                    }

                    periodo.SNProcessado = 'S';
                    await _periodoBLL.UpdatePeriodoAsync(periodo);

                    return true;
                }
                msg = "O período informado já esta processado.";
                throw new Exception(msg);

            }
            msg = "O período informado não existe.";
            throw new Exception(msg);
        }

        public async Task<List<VotoSemanal>> GetAllVotosPeriodoAsync(int IDPeriodo)
        {
            return await _votoSemanalRepository.GetAllVotosPeriodoAsync(IDPeriodo);
        }

        public async Task<VotoSemanal> GetVotoSemanal(int IDVotoSemanal)
        {
            return await _votoSemanalRepository.GetVotoSemanal(IDVotoSemanal);
        }

        public async Task<List<VotoSemanal>> GetVotoSemanal(int IDPeriodo, int IDTurmaAluno)
        {
            return await _votoSemanalRepository.GetAllVotosPeriodoAlunoAsync(IDPeriodo, IDTurmaAluno);
        }

    }
}
