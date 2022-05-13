using cadastro_ubuntu.repository;
using Cadastro_Ubuntu.Models;
using Microsoft.AspNetCore.Mvc;

namespace Cadastros_Ubuntu.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioController(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;

        }
        public IActionResult Index()
        {
            List<UsuarioModel> usuario = _usuarioRepository.BuscarTodos();

            return View(usuario);
        }
        public IActionResult Create()
        {

            return View();

        }
        public IActionResult Edit(int Id)
        {
            UsuarioModel usuario = _usuarioRepository.ListarPorId(Id);

            return View(usuario);
        }
        public IActionResult Delete(int Id)
        {
            UsuarioModel usuario = _usuarioRepository.ListarPorId(Id);
            return View(usuario);
        }
        public IActionResult Apagar(int Id)
        {
            try
            {
                bool apagado = _usuarioRepository.Apagar(Id);

                if (apagado)
                {
                    TempData["MensagemSucesso"] = "Usuario apagado com sucesso!";
                }
                else
                {
                    TempData["MensagemErro"] = "Erro ao apagar o usuario!";
                }

                return RedirectToAction("Index");
            }
            catch (System.Exception erro)
            {

                TempData["MensagemErro"] = $"Erro ao apagar o usuario, detalhes do erro:{erro.Message}";
                return RedirectToAction("Index");
            }
        }


        [HttpPost]
        public IActionResult Create(UsuarioModel usuario)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _usuarioRepository.Adicionar(usuario);
                    TempData["MensagemSucesso"] = "Usuario cadastrado com sucesso!";
                    return RedirectToAction("Index");
                }

                return View(usuario);
            }
            catch (System.Exception erro)
            {

                TempData["MensagemErro"] = $"Ops, não foi possivel cadastrar o usuario, detalhe do erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult Alterar(UsuarioSemSenhaModel usuarioSemSenha)
        {
            try
            {
                UsuarioModel usuario = null;
                if (ModelState.IsValid)
                {
                    usuario = new UsuarioModel()
                    {
                        Id = usuarioSemSenha.Id,
                        Nome = usuarioSemSenha.Nome,
                        Email = usuarioSemSenha.Email,
                        Login = usuarioSemSenha.Login,
                        Perfil = usuarioSemSenha.Perfil
                    };

                    usuario = _usuarioRepository.Atualizar(usuario);
                    TempData["MensagemSucesso"] = "Usuario alterado com sucesso!";
                    return RedirectToAction("Index");
                }
                return View(usuario);

            }
            catch (System.Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, não foi possivel alterar o usuario, detalhe do erro: {erro.Message}";
                return RedirectToAction("Index");

            }
        }
    }
}




//using cadastro_ubuntu.repository;
////using Cadastro_Ubuntu.Filters;
//using Cadastro_Ubuntu.Models;
//using Microsoft.AspNetCore.Mvc;

//namespace Cadastro_Ubuntu.Controllers
//{
//   // [PaginaRestritaSomenteAdimin]
//    public class UsuarioController : Controller
//    {
//        private readonly IUsuarioRepository _usuarioRepository;
//        public UsuarioController(IUsuarioRepository usuarioRepository)
//        {
//            _usuarioRepository = usuarioRepository;
//        }

//        public IActionResult Index()
//        {
//            List<UsuarioModel> usuarios = _usuarioRepository.BuscarTodos();

//            return View(usuarios);
//        }
//        public IActionResult Create()
//        {
//            return View();
//        }
//        public IActionResult Edit(int id)
//        {
//            UsuarioModel usuario = _usuarioRepository.ListarPorId(id);
//            return View(usuario);
//        }


//        [HttpPost]
//        public IActionResult Create(UsuarioModel usuario)
//        {
//            try
//            {
//                if (ModelState.IsValid)
//                {
//                    _usuarioRepository.Adicionar(usuario);
//                    TempData["MensagemSucesso"] = "Usuario Salvo com sucesso";
//                    return RedirectToAction("Index");
//                }

//                return View(usuario);
//            }
//            catch (System.Exception erro)
//            {

//                TempData["MensagemErro"] = $"Ops, não conseguimos cadastrar o Usuario, tente novamente, detalhe do erro: {erro.Message}";
//                return RedirectToAction("Index");
//            }
//        }
//        public IActionResult Delete(int id)
//        {
//            UsuarioModel usuario = _usuarioRepository.ListarPorId(id);
//            return View(usuario);
//        }
//        public IActionResult Apagar(int id)
//        {
//            try
//            {
//                bool apagado = _usuarioRepository.Apagar(id);

//                if (apagado)
//                {
//                    TempData["MensagemSucesso"] = "Usuário apagado com sucesso!";
//                }
//                else
//                {
//                    TempData["MensagemErro"] = "Ops, não conseguimos apagar o seu usuário, tente novamente";
//                }

//                return RedirectToAction("Index");
//            }
//            catch (Exception erro)
//            {
//                TempData["MensagemErro"] = $"Ops, não conseguimos apagar o seu usuário, tente novamente, mais detalhes do erro:{erro.Message} ";
//                return RedirectToAction("Index");
//            }
//        }
//        [HttpPost]
//        public IActionResult Alterar(UsuarioSemSenhaModel usuarioSemSenhaModel)
//        {

//            try
//            {
//                UsuarioModel usuario = null;

//                if (ModelState.IsValid)
//                {
//                    usuario = new UsuarioModel()
//                    {
//                        Id = usuarioSemSenhaModel.Id,
//                        Nome = usuarioSemSenhaModel.Nome,
//                        Login = usuarioSemSenhaModel.Login,
//                        Email = usuarioSemSenhaModel.Email,
//                        Perfil = usuarioSemSenhaModel.Perfil
//                    };

//                   usuario = _usuarioRepository.Atualizar(usuario);
//                    TempData["MensagemSucesso"] = "Usuário foi alterado com sucesso!";
//                    return RedirectToAction("Index");
//                }
//                return View("Alterar",usuario);

//            }
//            catch (System.Exception erro)
//            {
//                TempData["MensagemErro"] = $"Ops, não conseguimos atualizar o seu usuário, tente novamente, detalhe do erro: {erro.Message}";
//                return RedirectToAction("Index");

//            }
//        }
//    }
//}
