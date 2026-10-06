using EscolaDeCursos.WebApp.Modulos.ModuloAluno.Dominio;
using EscolaDeCursos.WebApp.Modulos.ModuloInstrutor.Dominio;
using EscolaDeCursos.WebApp.Compartilhado.Infraestrutura.Arquivos;
using EscolaDeCursos.WebApp.Modulos.ModuloAluno.Infraestrutura;
using EscolaDeCursos.WebApp.Modulos.ModuloInstrutor.Infraestrutura;
using EscolaDeCursos.WebApp.Modulos.ModuloCurso.Dominio;
using EscolaDeCursos.WebApp.Modulos.ModuloCurso.Infraestrutura;
using Microsoft.EntityFrameworkCore;
using EscolaDeCursos.WebApp.Compartilhado.Infraestrutura.Orm;
using EscolaDeCursos.WebApp.Modulos.ModuloMatricula.Dominio;
using EscolaDeCursos.WebApp.Modulos.ModuloMatricula.Infraestrutura;
using EscolaDeCursos.WebApp.Modulos.ModuloTurma.Dominio;
using EscolaDeCursos.WebApp.Modulos.ModuloTurma.Infraestrutura;

namespace EscolaDeCursos.WebApp.Compartilhado.Infraestrutura;

public static class InjecaoDependencia
{
    public static void AddInfraRepositories(this IServiceCollection services, IConfiguration configuration)
    {

        services.AddDbContext<EscolaDeCursosDbContext>(options =>
        {
            string? connectionString = configuration.GetConnectionString("SqlServer");

            if (string.IsNullOrWhiteSpace(connectionString))
            {
                throw new InvalidOperationException("Connection string 'SqlServer' not found.");
            }

            options.UseSqlServer(connectionString, config =>
            {
                config.EnableRetryOnFailure();
            })
            ;
        }
        );

        services.AddScoped<IRepositorioInstrutor, RepositorioInstrutorEmOrm>();
        services.AddScoped<IRepositorioAluno, RepositorioAlunoEmOrm>();
        services.AddScoped<IRepositorioCurso, RepositorioCursoEmOrm>();
        services.AddScoped<IRepositorioAula, RepositorioAulaEmOrm>();
        services.AddScoped<IRepositorioMatricula, RepositorioMatriculaEmOrm>();
        services.AddScoped<IRepositorioTurma, RepositorioTurmaEmOrm>();
    }
}
