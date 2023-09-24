using LanchonteSponja.Models;
using Microsoft.EntityFrameworkCore;

namespace LanchonteSponja.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base (options)
        {//classe ira ser responsavel por carregar todas as configuraçoes da classe DbContext
        }
        //propriedades DbSet
        //classes que seram mapeadas para a tabela 
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Lanche> Lanches { get; set;}//tabela lanches
        //mapeamento entre intidade e tabela abaixo:?
        public DbSet<CarrinhoCompraItem> CarrinhoCompraItens { get; set; }

        public DbSet<Pedido> Pedidos {  get; set; }
        public DbSet<PedidoDetalhe> PedidosDetalhes { get; set; }
    }
}
