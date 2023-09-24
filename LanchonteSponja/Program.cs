namespace LanchonteSponja;
public class Program
{
    public static void Main(string[] args)
    {//responsavel por configurar e iniciar aplicação netcore
        CreateHostBuilder(args)
            .Build()
            .Run();
       

    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder =>
            {//irar configurar um host para utilizarmos as configuraçoes padroes
                webBuilder.UseStartup<Startup>();//classe startup

            });
}