using cadastro_ubuntu.repository;
using Cadastro_Ubuntu.Data;
using Cadastro_Ubuntu.Models;

namespace Cadastro_Ubuntu.Repository
{
    public class UbuntuRepository : IUbuntuRepository
    {
        private readonly _DbContext __DbContext;
        public UbuntuRepository(_DbContext _dbContext)
        {
            __DbContext = _dbContext;
        }
        public Ubuntu ListarPorId(int id)
        {
            return __DbContext.ubuntus.FirstOrDefault(x => x.Id == id);
        }
        public List<Ubuntu> BuscarTodos()
        {
           return __DbContext.ubuntus.ToList();
        }
        public Ubuntu Adicionar(Ubuntu ubuntu)
        {
            //gravar no banco de dados
            __DbContext.ubuntus.Add(ubuntu);
            __DbContext.SaveChanges();
            return ubuntu;
        }

        public Ubuntu Atualizar(Ubuntu ubuntu)
        {
            Ubuntu ubuntuDb = ListarPorId(ubuntu.Id);

            if (ubuntuDb == null) throw new System.Exception("Houve um erro na atualização do contato!");

            ubuntuDb.Nome = ubuntu.Nome;
            ubuntuDb.Idade = ubuntu.Idade;  
            ubuntuDb.Rg = ubuntu.Rg;

            __DbContext.ubuntus.Update(ubuntuDb);
            __DbContext.SaveChanges();

            return ubuntuDb;
        }

        public bool Apagar(int id)
        {
            Ubuntu ubuntuDb = ListarPorId(id);

            if (ubuntuDb == null) throw new System.Exception("Houve um erro na deleção do contato!");

            __DbContext.ubuntus.Remove(ubuntuDb);
            __DbContext.SaveChanges();

            return true;

        }
    }
}
