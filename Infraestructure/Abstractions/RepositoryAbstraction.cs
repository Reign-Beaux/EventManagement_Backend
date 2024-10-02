namespace Infraestructure.Abstractions
{
    public abstract class RepositoryAbstraction(IDbTransaction dbTransaction)
    {
        protected readonly IDbTransaction _dbTransaction = dbTransaction;
        protected readonly IDbConnection _dbConnection = dbTransaction.Connection;
    }
}
