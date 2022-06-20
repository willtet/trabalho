namespace ProjetoPadraoLideranca.Apresentacao.Util
{
    public class RetornoJson
    {
        public object Retorno(bool sucesso, string mensagem, int codigo)
        {
            return new { Success = sucesso, Message = mensagem, Codigo = codigo };
        }

        public object Retorno(bool sucesso, object mensagem, int codigo)
        {
            return new { Success = sucesso, Message = mensagem, Codigo = codigo };
        }

        public object Retorno(bool sucesso, object mensagem, object mensagem2, int codigo)
        {
            return new { Success = sucesso, Message = mensagem, Message2 = mensagem2, Codigo = codigo };
        }

        public object Retorno(bool sucesso, object mensagem, object mensagem2, object mensagem3, int codigo)
        {
            return new { Success = sucesso, Message = mensagem, Message2 = mensagem2, Message3 = mensagem3, Codigo = codigo };
        }
    }
}