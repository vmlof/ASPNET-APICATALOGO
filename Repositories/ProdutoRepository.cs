using APICatalogo.Context;
using APICatalogo.Models;
using APICatalogo.Pagination;

namespace APICatalogo.Repositories;

public class ProdutoRepository : Repository<Produto>, IProdutoRepository
{
    public ProdutoRepository(AppDbContext context) : base(context)
    {
    }

    // public IEnumerable<Produto> GetProdutos(ProdutosParameters produtosParameters)
    // {
    //     return GetAll()
    //         .OrderBy(p => p.Nome)
    //         .Skip((produtosParameters.PageNumber - 1) * produtosParameters.PageSize)
    //         .Take(produtosParameters.PageSize).ToList();
    // }

    public async Task<PagedList<Produto>> GetProdutosAsync(ProdutosParameters produtosParameters)
    {
        var produtos = GetAllAsQueryable().OrderBy(p => p.ProdutoId);

        return await PagedList<Produto>.ToPagedListAsync(produtos, produtosParameters.PageNumber,
            produtosParameters.PageSize);
    }

    public async Task<PagedList<Produto>> GetProdutosFiltroPrecoAsync(ProdutosFiltroPreco produtosFiltroParams)
    {
        var produtos = GetAllAsQueryable();

        if (produtosFiltroParams.Preco.HasValue && !string.IsNullOrEmpty(produtosFiltroParams.PrecoCriterio))
        {
            if (produtosFiltroParams.PrecoCriterio.Equals("maior", StringComparison.OrdinalIgnoreCase))
            {
                produtos = produtos.Where(p => p.Preco > produtosFiltroParams.Preco.Value).OrderBy(p => p.Preco);
            }
            else if (produtosFiltroParams.PrecoCriterio.Equals("menor", StringComparison.OrdinalIgnoreCase))
            {
                produtos = produtos.Where(p => p.Preco < produtosFiltroParams.Preco.Value).OrderBy(p => p.Preco);
            }
            else if (produtosFiltroParams.PrecoCriterio.Equals("igual", StringComparison.OrdinalIgnoreCase))
            {
                produtos = produtos.Where(p => p.Preco == produtosFiltroParams.Preco.Value).OrderBy(p => p.Preco);
            }
        }

        return await PagedList<Produto>.ToPagedListAsync(
            produtos,
            produtosFiltroParams.PageNumber,
            produtosFiltroParams.PageSize
        );
    }

    public async Task<IEnumerable<Produto>> GetProdutosPorCategoriaAsync(int id)
    {
        var produtos = await GetAllAsync();
        var produtosCategoria = produtos.Where(p => p.CategoriaId == id);
        return produtosCategoria;
    }
}