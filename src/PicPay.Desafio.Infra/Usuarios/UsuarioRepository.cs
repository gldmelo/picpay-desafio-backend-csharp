using PicPay.Desafio.Application.Usuarios;
using PicPay.Desafio.Domain.ValueObjects;
using PicPay.Desafio.Infra.Shared;
using PicPay.Desafio.Infra.Usuarios.Models;
using Dapper;

namespace PicPay.Desafio.Infra.Usuarios
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly SqlConnectionFactory _sqlConnectionFactory;

        public UsuarioRepository(SqlConnectionFactory sqlConnectionFactory)
        {
            _sqlConnectionFactory = sqlConnectionFactory;
        }

        public UsuarioDto ObterUsuarioByEmail(string emailUsuario)
        {
            UsuarioModel usuarioModel;
            
            using (var conn = _sqlConnectionFactory.Create())
            {
                usuarioModel = conn.QuerySingle<UsuarioModel>("select id_usuario, email, nome_completo, senha, tipo, documento from Usuario where email = @Email",
                    param: new { Email = emailUsuario });
            }

            return usuarioModel.ConvertToDto();
        }

        public Dinheiro ObterSaldo(int idUsuario)
        {
            var sql = @"select (select sum(quantia) from Transacao where moeda = 'BRL' and id_usuario = @Id and tipo_operacao = 0)
                        - (select sum(quantia) from Transacao where moeda = 'BRL' and id_usuario = @Id and tipo_operacao = 1)";

            using (var conn = _sqlConnectionFactory.Create())
            {
                decimal saldo = conn.QuerySingle<decimal>(sql, param: new { Id = idUsuario });
                return new Dinheiro(saldo, "BRL");
            }
        }
    }
}
