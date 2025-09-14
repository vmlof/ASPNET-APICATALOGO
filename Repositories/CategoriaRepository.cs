using APICatalogo.Context;
using APICatalogo.Models;
using APICatalogo.Pagination;

namespace APICatalogo.Repositories;

public class CategoriaRepository : Repository<Categoria>, ICategoriaRepository
{
    public CategoriaRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<PagedList<Categoria>> GetCategoriasAsync(CategoriasParameters categoriasParameters)
    {
        var categorias = GetAllAsQueryable().OrderBy(c => c.CategoriaId);

        return await PagedList<Categoria>.ToPagedListAsync(categorias, categoriasParameters.PageNumber,
            categoriasParameters.PageSize);
    }

    public async Task<PagedList<Categoria>> GetCategoriasFiltroNomeAsync(CategoriasFiltroNome categoriasParams)
    {
        var categorias = GetAllAsQueryable();

        if (!string.IsNullOrEmpty(categoriasParams.Nome))
        {
            categorias = categorias.Where(c => c.Nome.Contains(categoriasParams.Nome));
        }

        return await PagedList<Categoria>.ToPagedListAsync(
            categorias,
            categoriasParams.PageNumber,
            categoriasParams.PageSize
        );
    }
}