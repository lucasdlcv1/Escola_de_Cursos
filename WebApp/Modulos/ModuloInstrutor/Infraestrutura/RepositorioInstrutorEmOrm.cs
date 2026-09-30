namespace EscolaDeCursos.WebApp.Modulos.ModuloInstrutor.Infraestrutura;

using EscolaDeCursos.WebApp.Modulos.ModuloInstrutor.Dominio;

public sealed class RepositorioInstrutorEmOrm : IRepositorioInstrutor
{
    private readonly EscolaDeCursosDbContext dbContext;

    public RepositorioInstrutorEmOrm(EscolaDeCursosDbContext dbContext)
    {
        this.dbContext = dbContext;
    }
    public void Cadastrar(Instrutor entidade)
    {
        dbContext.Instrutores.Add(entidade);
        dbContext.SaveChanges();
    }

    public bool Editar(Guid idSelecionado, Instrutor entidadeAtualizada)
    {
        Instrutor? instrutor = SelecionarPorId(idSelecionado);

        if (instrutor == null)
            return false;

        instrutor.Atualizar(entidadeAtualizada);

        dbContext.SaveChanges();
        return true;
    }

    public bool Excluir(Guid idSelecionado)
    {
        Instrutor? instrutor = SelecionarPorId(idSelecionado);

        if (instrutor == null)
            return false;

        dbContext.Instrutores.Remove(instrutor);

        dbContext.SaveChanges();

        return true;
    }

    public bool ExisteComNome(string nome, Guid? idIgnorado = null)
    {
        throw new NotImplementedException();
    }

    public Instrutor? SelecionarPorId(Guid idSelecionado)
    {
        return dbContext.Instrutores.FirstOrDefault(i => i.Id == idSelecionado);
    }

    public List<Instrutor> SelecionarTodos()
    {
        return dbContext.Instrutores.ToList();
    }
}
