using Core;
using Core.Service;
using Microsoft.EntityFrameworkCore;

namespace Service
{
    public class FuncaoFuncionarioService : IFuncaoFuncionarioService
    {
        private readonly RestauranteContext context;

        public FuncaoFuncionarioService(RestauranteContext context)
        {
            this.context = context;
        }
        /// <summary>
        /// Adiciona uma nova entidade Funcaofuncionario ao DbContext e aplica as alterações no banco de dados.
        /// </summary>
        /// <param name="funcaoFuncionario">Entidade Funcaofuncionario a ser adicionada. Não pode ser nula.</param>
        /// <returns>Identificador único atribuído à entidade Funcaofuncionario recém-criada.</returns>
        public uint Create(Funcaofuncionario funcaoFuncionario)
        {
            context.Add(funcaoFuncionario);
            context.SaveChanges();
            return funcaoFuncionario.Id;
        }

        /// <summary>
        /// Atualiza a entidade Funcaofuncionario especificada no armazenamento de dados.
        /// </summary>
        /// <param name="funcaoFuncionario">Entidade Funcaofuncionario a ser atualizada. Não pode ser nula.</param>
        public void Edit(Funcaofuncionario funcaoFuncionario)
        {
            context.Update(funcaoFuncionario);
            context.SaveChanges();
        }

        /// <summary>
        /// Exclui o registro de função do funcionário com o identificador especificado, se existir.
        /// </summary>
        /// <param name="id">Identificador único do registro de função do funcionário a ser excluído.</param>
        public void Delete(uint id)
        {
            var funcaoFuncionario = context.Funcaofuncionarios.Find(id);
            if (funcaoFuncionario != null)
            {
                context.Funcaofuncionarios.Remove(funcaoFuncionario);
                context.SaveChanges();
            }
        }

        /// <summary>
        /// Recupera uma entidade Funcaofuncionario pelo seu identificador único.
        /// </summary>
        /// <param name="id">Identificador único da entidade Funcaofuncionario a ser recuperada.</param>
        /// <returns>
        /// A entidade Funcaofuncionario com o identificador especificado,
        /// ou null caso nenhuma entidade correspondente exista.
        /// </returns>
        public Funcaofuncionario? Get(uint id)
        {
            return context.Funcaofuncionarios.Find(id);
        }

        /// <summary>
        /// Recupera todas as entidades Funcaofuncionario da fonte de dados.
        /// </summary>
        /// <remarks>
        /// As entidades retornadas não são rastreadas pelo contexto.
        /// Alterações feitas nos objetos retornados não serão persistidas,
        /// a menos que sejam explicitamente anexadas ao contexto.
        /// </remarks>
        /// <returns>
        /// Uma coleção enumerável de todas as entidades Funcaofuncionario.
        /// A coleção estará vazia caso nenhuma entidade seja encontrada.
        /// </returns>
        public IEnumerable<Funcaofuncionario> GetAll()
        {
            return context.Funcaofuncionarios.AsNoTracking();
        }

        /// <summary>
        /// Recupera todas as entidades Funcaofuncionario cujo nome contém a substring especificada.
        /// </summary>
        /// <param name="nome">
        /// Substring a ser pesquisada na propriedade Nome de cada entidade Funcaofuncionario.
        /// Não pode ser nula </param>
        /// <returns>
        /// Uma coleção de entidades Funcaofuncionario cuja propriedade Nome contém a substring especificada.
        /// Retorna uma coleção vazia caso nenhuma correspondência seja encontrada.
        /// </returns>
        public IEnumerable<Funcaofuncionario> GetByNome(string nome)
        {
            return context.Funcaofuncionarios
                          .Where(FuncaoFuncionario => FuncaoFuncionario.Nome.Contains(nome))
                          .ToList();
        }

    }
}
