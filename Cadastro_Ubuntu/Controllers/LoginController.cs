using cadastro_ubuntu.repository;
using Cadastro_Ubuntu.Helper;
using Cadastro_Ubuntu.Models;
using Microsoft.AspNetCore.Mvc;

namespace Cadastro_Ubuntu.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly ISessao _sessao;
        public LoginController(IUsuarioRepository usuarioRepository,
                               ISessao sessao)
        {
            _usuarioRepository = usuarioRepository;    //injeção de independencia
            _sessao = sessao;
        }

        public IActionResult Index()
        {
            //Se o usuario estiver logado redirecionar para a home

            if(_sessao.BuscarSessaoDoUsuario() != null) return RedirectToAction("Index", "Home");

            return View();
        }

        public IActionResult Sair()
        {
            _sessao.RemoverSessaoDoUsuario();

            return RedirectToAction("Index", "Login");
        }

        [HttpPost]
        public IActionResult Entrar(LoginModel loginModel)//verificação de senha e usuario
        {
            try
            {
                if (ModelState.IsValid)
                {
                    UsuarioModel usuario = _usuarioRepository.BuscarPorLogin(loginModel.Login);

                    if (usuario != null)
                    {
                        if (usuario.SenhaValida(loginModel.Senha))
                        {
                            _sessao.CriarSessaoDoUsuario(usuario);
                            return RedirectToAction("Index", "Home");
                        }

                        TempData["MensagemErro"] = $"Senha inválidda. Por favor, tente novamente.";

                    }
                    TempData["MensagemErro"] = $"Usuário e/ou senha inváliddo(s). Por favor, tente novamente.";
                }

                return View("Index");
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, não conseguimos realizar seu login, tente novamente,  detalhe do erro:{erro.Message} ";
                return RedirectToAction("Index");
            }
        }
    }
}
