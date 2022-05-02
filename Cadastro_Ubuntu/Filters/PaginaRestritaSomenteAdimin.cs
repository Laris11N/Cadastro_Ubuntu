//using Cadastro_Ubuntu.Models;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.Filters;
//using Newtonsoft.Json;

//namespace Cadastro_Ubuntu.Filters
//{
//    public class PaginaRestritaSomenteAdimin : ActionFilterAttribute
//    {
//        public override void OnActionExecuting(ActionExecutingContext context)
//        {
//            string sessaoUsuario = context.HttpContext.Session.GetString("sessaoUsuarioLogado");

//            if (string.IsNullOrEmpty(sessaoUsuario))
//            {
//                context.Result = new RedirectToRouteResult(new RouteValueDictionary { {"controller", "login" }, {"action","Index" } });
//            }
//            else
//            {
//                UsuarioModel usuario = JsonConvert.DeserializeObject<UsuarioModel>(sessaoUsuario);

//                if(usuario != null)
//                {
//                    context.Result = new RedirectToRouteResult(new RouteValueDictionary { { "controller", "login" }, { "action", "Index" } });
//                }
//            }

//            base.OnActionExecuting(context);
//        }
//    }
//}
