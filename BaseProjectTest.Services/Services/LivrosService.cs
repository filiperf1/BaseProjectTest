using BaseProjectTest.Models.Data;
using BaseProjectTest.Models.Entities;
using BaseProjectTest.Services.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseProjectTest.Services.Services
{
    
    public class LivrosService : ILivrosService
    {
        private readonly DataContext _dataContext;
        public LivrosService(DataContext context)
        {
            _dataContext = context;
        }

        public async Task<Livros> GetLivrosAsync(int id)
        {
            var result = await _dataContext.Livros.FindAsync(id);
            return result;
        }
        public async Task<IList<Livros>> ListLivrosAsync()
        {
            var livros = await _dataContext.Livros.ToListAsync();
            return livros;
        }

        public async Task AddLivrosAsync(Livros request)
        {
            await _dataContext.Livros.AddAsync(request);
            await _dataContext.SaveChangesAsync();
        }

        public async Task<Livros> UpdateLivro(Livros request)
        {
            var livroResult = _dataContext.Livros.FindAsync(request.Id);

            livroResult.Result.Name = request.Name;
            livroResult.Result.Description = request.Description;
            livroResult.Result.Paginas = request.Paginas;
            await _dataContext.SaveChangesAsync();
            var updateResult = _dataContext.Livros.FindAsync(request.Id);
            
            return updateResult.Result;
        }

        public async Task DeleteLivrosAsync(int id)
        {
            var livroResult = _dataContext.Livros.FindAsync(id);
            _dataContext.Livros.Remove(livroResult.Result);
            await _dataContext.SaveChangesAsync();
        }
    }
}
