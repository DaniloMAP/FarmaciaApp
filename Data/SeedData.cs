using FarmaciaApp.Models;
using Microsoft.EntityFrameworkCore;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new ApplicationContext(
            serviceProvider.GetRequiredService<DbContextOptions<ApplicationContext>>()))
        {
            // Verifique se já existem fabricantes
            if (!context.Fabricantes.Any())
            {
                context.Fabricantes.AddRange(
                    new Fabricante { Nome = "Fabricante 1" },
                    new Fabricante { Nome = "Fabricante 2" },
                    new Fabricante { Nome = "Fabricante 3" }
                    // Adicione mais fabricantes conforme necessário
                );
                context.SaveChanges();
            }
        }
    }
}
