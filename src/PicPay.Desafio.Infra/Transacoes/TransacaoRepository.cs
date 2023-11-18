using Dapper;
using FluentResults;
using PicPay.Desafio.Domain.Transacoes;
using PicPay.Desafio.Infra.Shared;

namespace PicPay.Desafio.Infra.Transacoes
{
    public class TransacaoRepository : ITransacaoRepository
    {
        private readonly SqlConnectionFactory _sqlConnectionFactory;

        public TransacaoRepository(SqlConnectionFactory sqlConnectionFactory)
        {
            _sqlConnectionFactory = sqlConnectionFactory;
        }

        public Result RegistrarTransacao(List<TransacaoItem> operacoes)
        {
            using (var conn = _sqlConnectionFactory.Create())
            {
                conn.Open();
                var t1 = conn.BeginTransaction();

                try
                {
                    foreach (var item in operacoes)
                    {
                        var sql = @"insert Transacao (id_usuario, data_transacao, quantia, moeda, tipo_operacao, status, id_extrato)
                                        values (@id_usuario, @data_transacao, @quantia, @moeda, @tipo_operacao, 1, @id_extrato)";

                        conn.Execute(sql, param: new
                        {
                            id_usuario = item.IdUsuario,
                            data_transacao = item.DataTransacao,
                            quantia = item.Quantia.Quantia,
                            moeda = item.Quantia.Moeda,
                            tipo_operacao = item.IsLancamentoCredito,
                            id_extrato = (int)item.TipoLancamento
                        },
                        transaction: t1);
                    }

                    t1.Commit();
                }
                catch (Exception ex)
                {
                    t1.Rollback();
                    return Result.Fail($"Erro ao persistir os dados: {ex.Message}");
                }
                finally
                {
                    conn.Close();
                }
            }

            return Result.Ok();
        }
    }
}
