using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VoteNaBoia.BLL.Infra;
using VoteNaBoia.DAL.Infra;
using VoteNaBoia.Entities;

namespace VoteNaBoia.BLL
{
    public class VotoDiarioBLL : IVotoDiarioBLL
    {
        private readonly IVotoDiarioRepository _votoDiarioRepository;
        private readonly IRestauranteBLL _restauranteBLL;
        private  IPeriodoResultadoBLL _periodoResultadoBLL;
        private readonly IPeriodoBLL _periodoBLL;
        private readonly IPeriodoDiarioBLL _periodoDiarioBLL;
        private readonly ITurmaAlunoBLL _turmaAlunoBLL;

        public VotoDiarioBLL(IVotoDiarioRepository votoDiarioRepository, 
            IRestauranteBLL restauranteBLL, IPeriodoResultadoBLL periodoResultadoBLL, 
            IPeriodoBLL periodoBLL, IPeriodoDiarioBLL periodoDiarioBLL,
            ITurmaAlunoBLL turmaAlunoBLL)
        {
            _votoDiarioRepository = votoDiarioRepository;
            _restauranteBLL = restauranteBLL;
            _periodoResultadoBLL = periodoResultadoBLL;
            _periodoBLL = periodoBLL;
            _periodoDiarioBLL = periodoDiarioBLL;
            _turmaAlunoBLL = turmaAlunoBLL;
        }
        public void Dispose()
        {
            _votoDiarioRepository?.Dispose();
        }

        public async Task<Restaurante> GetResultadoVotoDiarioAsync(int idTurma) //// resultado da votação
        {
         //   var turmaAluno = await _turmaAlunoBLL.GetTurmaAlunoAsync(idAluno, idTurma); //pega idTurmaAluno
            var ultimoPeriodoTurma = await _periodoBLL.GetUltimoPeriodoAsync(idTurma); // pega idPeriodo
            var periodoDiario =await  _periodoDiarioBLL.GetUltimoPeriodoDiarioAsync(ultimoPeriodoTurma.IDPeriodo);
            var idPeriodoResultado =   _votoDiarioRepository.GetResultadoVotoDiarioAsync(periodoDiario.IDPeriodoDiario);
            var periodoResultado = await _periodoResultadoBLL.GetPeriodo(idPeriodoResultado);

            await _periodoResultadoBLL.UpdateSNVisitado(periodoResultado.IDPeriodoResultado);
            return await _restauranteBLL.GetRestauranteByIdAsync(periodoResultado.IDRestaurante); // restaurante
            

        }

        public async Task InsertVotoDiarioAsync(Voto voto)/// idAluno, idTurma,idRestaurante
        {
            var msg = "";
            var turmaAluno = await  _turmaAlunoBLL.GetTurmaAlunoAsync(voto.idAluno, voto.idTurma); //pega idTurmaAluno
            var ultimoPeriodoTurma = await _periodoBLL.GetUltimoPeriodoAsync(voto.idTurma); // pega idPeriodo

            if (await _periodoBLL.IsPeriodoAbertoAsync(ultimoPeriodoTurma.IDPeriodo)) //valida se período está aberto
            {
                await _periodoDiarioBLL.AbrirPeriodoDiario(ultimoPeriodoTurma.IDPeriodo);

                //idTurmaAluno idPeriodoResultado (id rest + id_periodo) // pegar o periodo resultado
                var periodoResultado = await _periodoResultadoBLL.GetPeriodo(0, voto.idRestaurante, ultimoPeriodoTurma.IDPeriodo);
                if (periodoResultado != null)
                {
                    // pegar ultimo periodo diario e validar se está aberto
                    var periodoDiario = await _periodoDiarioBLL.GetUltimoPeriodoDiarioAsync(periodoResultado.IDPeriodo);
                    if (await _periodoDiarioBLL.IsPeriodoAbertoAsync(periodoDiario.IDPeriodoDiario))
                    {
                        // validar se aluno (idTurmaAluno) já existe na tabela de voto diário
                        if (await this.IsAlunoJaVotouAsync(periodoDiario.IDPeriodoDiario, turmaAluno.IDTurmaAluno))
                        {
                            msg = "Aluno já votou!";
                            throw new Exception(msg);
                        }
                        else
                        {
                            var data = DateTime.Now;
                            var votoDiario = new VotoDiario(id: 0, periodoResultado.IDPeriodoResultado, turmaAluno.IDTurmaAluno, data, periodoDiario.IDPeriodoDiario);
                            _votoDiarioRepository.InsertVotoDiarioAsync(votoDiario);
                            await _votoDiarioRepository.UnitOfWork.Commit();
                        }
                    }
                    else
                    {
                        msg = "Não existe período aberto para votação";
                        throw new Exception(msg);
                    }
                }
                else
                {
                    msg = "Restaurante informado não pertence a esse período/turma";
                    throw new Exception(msg);
                }
            }
            else
            {
                msg = "Período de votação semanal ainda está aberto";
                throw new Exception(msg);
            }
           
            
        }

        public async Task<List<Restaurante>> GetVotoDiarioRestaurantesAsync(int idTurma) // pega restaurantes disponíveis para votação
        {
            List<Restaurante> restaurantes;
            restaurantes = new List<Restaurante>();
            var periodo = await _periodoBLL.GetUltimoPeriodoAsync(idTurma);//pega o último período da turma iniformada
            if (await _periodoBLL.IsPeriodoAbertoAsync(periodo.IDPeriodo)) {// testa se o último período está aberto
                var resultados = await _periodoResultadoBLL.GetAllRestaurantesNVisitadosAsync(periodo.IDPeriodo);//pega os restaurantes não visitados
                foreach(var resultado in resultados) //percorre cada resultado para pegar os dados do restaurante
                { //adiciona o restaurante numa lista
                    restaurantes.Add(await _restauranteBLL.GetRestauranteByIdAsync(resultado.IDRestaurante));
                }
            }
            else
            {
                var msg = "Não existe período aberto para votação";
                throw new Exception(msg);
            }
            return restaurantes; // retorna a lista de restaurantes
        }

        public async Task<bool> IsAlunoJaVotouAsync(int idPeriodoDiario, int idTurmaAluno)
        {
            var votoDiario = await _votoDiarioRepository.GetVotoDiarioAsync(idPeriodoDiario,idTurmaAluno);
            if(votoDiario != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
