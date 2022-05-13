using Cadastro_Ubuntu.Models;

namespace cadastro_ubuntu.repository
{
    public interface IUbuntuRepository
    {
        Ubuntu ListarPorId(int id);
        List<Ubuntu> BuscarTodos();
        Ubuntu Adicionar(Ubuntu ubuntu);
        Ubuntu Atualizar(Ubuntu ubuntu);
       // Ubuntu Visualizar(Ubuntu ubuntu);
        bool Apagar(int id);
      
    }
}
