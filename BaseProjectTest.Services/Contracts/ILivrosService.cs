using BaseProjectTest.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseProjectTest.Services.Contracts
{
    public interface ILivrosService
    {

        Task<IList<Livros>> ListLivrosAsync();
        Task AddLivrosAsync(Livros request);
        Task DeleteLivrosAsync(int id);
        Task<Livros> UpdateLivro(Livros request);

    }
}
