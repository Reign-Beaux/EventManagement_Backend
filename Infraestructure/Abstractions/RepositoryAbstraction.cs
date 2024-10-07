namespace Infraestructure.Abstractions
{
    public abstract class RepositoryAbstraction(IDbTransaction dbTransaction)
    {
        protected readonly IDbTransaction _dbTransaction = dbTransaction;
        protected readonly IDbConnection _dbConnection = dbTransaction.Connection!;

        protected async Task<List<T>> QueryAsync<T>(string spString, object? parameters = null)
            => (await _dbConnection.QueryAsync<T>(
                spString,
                parameters,
                commandType: CommandType.StoredProcedure,
                transaction: _dbTransaction)).ToList();

        protected async Task<T?> QuerySingleOrDefaultAsync<T>(string spString, object parameters)
            => await _dbConnection.QuerySingleOrDefaultAsync<T>(
                spString,
                parameters,
                commandType: CommandType.StoredProcedure,
                transaction: _dbTransaction);

        protected async Task ExecuteAsync(string spString, object parameters)
            => await _dbConnection.ExecuteAsync(
                spString,
                parameters,
                commandType: CommandType.StoredProcedure,
                transaction: _dbTransaction);
    }
}
