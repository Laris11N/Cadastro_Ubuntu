using cadastro_ubuntu.repository;
using Cadastro_Ubuntu.Data;
using Cadastro_Ubuntu.Models;

namespace Cadastro_Ubuntu.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly _DbContext __DbContext;
        public UsuarioRepository(_DbContext _dbContext)
        {
            this.__DbContext = _dbContext;
        }
        public UsuarioModel BuscarPorLogin(string login)
        {
            return __DbContext.Usuarios.FirstOrDefault(x => x.Login.ToLower() == login.ToLower());
        }
        public UsuarioModel ListarPorId(int id)
        {
            return __DbContext.Usuarios.FirstOrDefault(x => x.Id == id);
        }
        public List<UsuarioModel> BuscarTodos()
        {
            return __DbContext.Usuarios.ToList();
        }

        public UsuarioModel Adicionar(UsuarioModel usuario)
        {
             usuario.DataCadastro = DateTime.Now;
            //gravar no banco de dados
            __DbContext.Usuarios.Add(usuario);
            __DbContext.SaveChanges();
            return usuario;
        }

        public UsuarioModel Atualizar(UsuarioModel usuario)
        {
            UsuarioModel usuarioDb = ListarPorId(usuario.Id);

            if (usuarioDb == null) throw new System.Exception("Houve um erro na atualização do usuário!");

            usuarioDb.Nome = usuario.Nome;
            usuarioDb.Login = usuario.Login;
            usuarioDb.Email = usuario.Email;
            usuarioDb.Perfil = usuario.Perfil;
            usuarioDb.DataAtualizacao = DateTime.Now;


            __DbContext.Usuarios.Update(usuarioDb);
            __DbContext.SaveChanges();

            return usuarioDb;
        }

        public bool Apagar(int id)
        {
            UsuarioModel usuarioDb = ListarPorId(id);

            if (usuarioDb == null) throw new System.Exception("Houve um erro na deleção do usuário!");

            __DbContext.Usuarios.Remove(usuarioDb);
            __DbContext.SaveChanges();

            return true;

        }

       
    }
}
