using Cadastro_Ubuntu.Models;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace Cadastro_Ubuntu.Helper
{
    public class Sessao : ISessao
    {
        private readonly IHttpContextAccessor _httpContext;

        public Sessao(IHttpContextAccessor httpContext)
        {
            _httpContext = httpContext;
        }
        public UsuarioModel BuscarSessaoDoUsuario()
        {
            string sessaoUsuario = _httpContext.HttpContext.Session.GetString("sessaoUsuarioLogado");

            if(string.IsNullOrEmpty(sessaoUsuario)) return null;

            return JsonConvert.DeserializeObject<UsuarioModel>(sessaoUsuario);
        }

        public void CriarSessaoDoUsuario(UsuarioModel usuario)
        {
            string Valor= JsonConvert.SerializeObject(usuario);//converti o usuario para string aqui usando o Json

            _httpContext.HttpContext.Session.SetString("sessaoUsuarioLogado", Valor); //nao aceitava meu usuario aqui
        }

        public void RemoverSessaoDoUsuario()
        {
            _httpContext.HttpContext.Session.Remove("sessaoUsuarioLogado");
        }
    }
}
