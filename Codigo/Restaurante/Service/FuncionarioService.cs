using Core;
using Core.DTO;
using Core.Service;
using Microsoft.EntityFrameworkCore;

namespace Service
{
    public class FuncionarioService : IFuncionarioService
    {
        private readonly RestauranteContext _context;

        public FuncionarioService(RestauranteContext context)
        {
            _context = context;
        }

        public uint Create(FuncionarioDTO funcionarioDto)
        {
            var funcionario = new Funcionario
            {
                Nome = funcionarioDto.Nome,
                Cpf = funcionarioDto.Cpf,
                IdRestaurante = funcionarioDto.IdRestaurante,
                IdFuncaoFuncionario = funcionarioDto.IdFuncaoFuncionario
            };
            _context.Add(funcionario);
            _context.SaveChanges();
            return funcionario.Id;
        }

        public void Delete(uint id)
        {
            var funcionario = _context.Funcionarios.Find(id);
            if (funcionario != null)
            {
                _context.Remove(funcionario);
                _context.SaveChanges();
            }
        }

        public void Edit(FuncionarioDTO funcionarioDto)
        {
            var funcionario = _context.Funcionarios.Find(funcionarioDto.Id);
            if (funcionario != null)
            {
                funcionario.Nome = funcionarioDto.Nome;
                funcionario.Cpf = funcionarioDto.Cpf;
                funcionario.IdRestaurante = funcionarioDto.IdRestaurante;
                funcionario.IdFuncaoFuncionario = funcionarioDto.IdFuncaoFuncionario;
                _context.Update(funcionario);
                _context.SaveChanges();
            }
        }

        public FuncionarioDTO? Get(uint id)
        {
            return _context.Funcionarios
                .Include(f => f.IdRestauranteNavigation)
                .Include(f => f.IdFuncaoFuncionarioNavigation)
                .Where(f => f.Id == id)
                .Select(f => new FuncionarioDTO
                {
                    Id = f.Id,
                    Nome = f.Nome,
                    Cpf = f.Cpf,
                    IdRestaurante = f.IdRestaurante,

                    NomeRestaurante = f.IdRestauranteNavigation.Nome,
                    IdFuncaoFuncionario = f.IdFuncaoFuncionario,
                    NomeFuncao = f.IdFuncaoFuncionarioNavigation.Nome
                })
                .FirstOrDefault();
        }

        public IEnumerable<FuncionarioDTO> GetAll()
        {
            return _context.Funcionarios
                .Include(f => f.IdFuncaoFuncionarioNavigation)
                .Include(f => f.IdRestauranteNavigation)
                .Select(f => new FuncionarioDTO
                {
                    Id = f.Id,
                    Nome = f.Nome,
                    Cpf = f.Cpf,
                    IdRestaurante = f.IdRestaurante,
                    NomeRestaurante = f.IdRestauranteNavigation.Nome,
                    IdFuncaoFuncionario = f.IdFuncaoFuncionario,
                    NomeFuncao = f.IdFuncaoFuncionarioNavigation.Nome
                });
        }
    }
}