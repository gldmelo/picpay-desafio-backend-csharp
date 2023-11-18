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

        public int ObterIdUsuarioByEmail(string emailUsuario)
        {
            using (var conn = _sqlConnectionFactory.Create())
            {
                return conn.QuerySingle<int>("select id_usuario from Usuario where email = @Email",
                    param: new { Email = emailUsuario });
            }
        }

        public UsuarioDto ObterUsuarioById(int idUsuario)
        {
            UsuarioModel usuarioModel;

            using (var conn = _sqlConnectionFactory.Create())
            {
                usuarioModel = conn.QuerySingle<UsuarioModel>("select id_usuario, email, nome_completo, senha, tipo, documento from Usuario where id_usuario = @Id",
                    param: new { Id = idUsuario });
            }

            return usuarioModel.ConvertToDto();
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
            var sql = @"select (select sum(quantia) from Transacao where moeda = 'BRL' and id_usuario = @Id and tipo_operacao = 1)
                        - (select sum(quantia) from Transacao where moeda = 'BRL' and id_usuario = @Id and tipo_operacao = 0)";

            using (var conn = _sqlConnectionFactory.Create())
            {
                decimal saldo = conn.QuerySingle<decimal>(sql, param: new { Id = idUsuario });
                return new Dinheiro(saldo, "BRL");
            }
        }
    }
}
