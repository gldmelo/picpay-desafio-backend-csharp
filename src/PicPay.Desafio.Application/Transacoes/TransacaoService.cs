using FluentResults;
using PicPay.Desafio.Application.Usuarios;
using PicPay.Desafio.Domain.Transacoes;
using PicPay.Desafio.Domain.ValueObjects;

namespace PicPay.Desafio.Application.Transacoes
{
    public class TransacaoService : ITransacaoService
    {
        readonly IUsuarioRepository _usuarioRepository;
        readonly IAutorizadorExterno _autorizadorExterno;
        readonly Transacao _transacaoAggregate;

        public TransacaoService(IUsuarioRepository usuarioRepository, IAutorizadorExterno autorizadorExterno, Transacao transacaoAggregate)
        {
            _usuarioRepository = usuarioRepository;
            _autorizadorExterno = autorizadorExterno;
            _transacaoAggregate = transacaoAggregate;
        }

        public Result EnviarDinheiro(TransacaoDto transacaoDto)
        {
            var saldoRemetente = _usuarioRepository.ObterSaldo(transacaoDto.IdRemetente);
            var remetente = UsuarioDtoMapper.ConvertToDomain(_usuarioRepository.ObterUsuarioById(transacaoDto.IdRemetente), saldoRemetente);

            if (!_autorizadorExterno.AutorizarTransacao(transacaoDto).IsSuccess)
                return Result.Fail("Erro ao enviar dinheiro! Falha na Autorização Externa!");

            var destinatario = UsuarioDtoMapper.ConvertToDomain(_usuarioRepository.ObterUsuarioByEmail(transacaoDto.EmailDestinatario), new Dinheiro(0, transacaoDto.Moeda));
            var resultEnviarDinheiro = _transacaoAggregate.EnviarDinheiro(remetente, destinatario, new Dinheiro(transacaoDto.Quantia));
            // criar Mock de envio de notificação
            return resultEnviarDinheiro.IsSuccess
                ? Result.Ok()
                : Result.Fail("Erro ao enviar dinheiro! Falha no envio!");
        }

        public Result DepositarDinheiro(TransacaoDto transacaoDto)
        {
            var usuarioDepositante = UsuarioDtoMapper.ConvertToDomain(_usuarioRepository.ObterUsuarioById(transacaoDto.IdRemetente));

            var dinheiroADepositar = new Dinheiro(transacaoDto.Quantia, transacaoDto.Moeda);
            var resultEnviarDinheiro = _transacaoAggregate.DepositarDinheiro(usuarioDepositante, dinheiroADepositar);

            return resultEnviarDinheiro.IsSuccess
                ? Result.Ok()
                : Result.Fail(resultEnviarDinheiro.Errors[0]);
        }
    }
}
