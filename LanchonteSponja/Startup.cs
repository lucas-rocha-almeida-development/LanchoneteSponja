using LanchonteSponja.Context;
using LanchonteSponja.Models;
using LanchonteSponja.Repositories;
using LanchonteSponja.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LanchonteSponja;

    public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddDbContext<AppDbContext>(options=>options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
       
        services.AddTransient<ILancheRepository,LancheRepository>();
        services.AddTransient<ICategoriaRepository, CategoriaRepository>();
        services.AddTransient<IPedidoRepository, PedidoRepository>();

        services.AddControllersWithViews();
        //recurso para acessar o HttpContext// obtendo request e response/autenticação
        services.AddSingleton<IHttpContextAccessor,HttpContextAccessor>();
        //addScoped trabalha nivel de requisição ( 2 clientes fazendo pedidos, instancia diferentes)
        services.AddScoped(sp => CarrinhoCompra.GetCarrinho(sp));//registrando e criando carrinho
        //middleware
        services.AddMemoryCache();
        services.AddSession();
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())//ira verificar se esta em uma ambiente de desenvolvimento
        {
            app.UseDeveloperExceptionPage();
        }
        else
        {
            app.UseExceptionHandler("/Home/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }
        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();
        app.UseSession();

        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {//primeira rota
        endpoints.MapControllerRoute(

                name:"categoriaFiltro",
                pattern:"Lanche/{action}/{categoria?}",
                defaults: new {Controller="Lanche",Action="List"});

           
           
            endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
        });
    }
}

