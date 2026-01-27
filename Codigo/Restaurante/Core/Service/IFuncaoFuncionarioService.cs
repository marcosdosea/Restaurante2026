using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Service
{
    public interface IFuncaoFuncionarioService
    {
        uint Create(Funcaofuncionario funcaoFuncionario);
        void Edit(Funcaofuncionario funcaoFuncionario);
        void Delete(uint id);
        Funcaofuncionario? Get(uint id);
        IEnumerable<Funcaofuncionario> GetAll();
        IEnumerable<Funcaofuncionario> GetByNome(string nome);
    }
}
