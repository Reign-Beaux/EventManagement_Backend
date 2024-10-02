namespace Infraestructure.Abstractions
{
    public abstract class UnitOfWorkAbstraction
    {
        protected readonly IDbConnection _dbConnection;
        protected readonly IDbTransaction _dbTransaction;

        protected UnitOfWorkAbstraction(string connectionString)
        {
            _dbConnection = new SqlConnection(connectionString);
            _dbConnection.Open();
            _dbTransaction = _dbConnection.BeginTransaction();
        }

        public void Commit()
        {
            try
            {
                _dbTransaction.Commit();
            }
            catch (Exception)
            {
                _dbTransaction.Rollback();
            }
            finally
            {
                _dbTransaction.Dispose();
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposing)
                return;

            _dbTransaction?.Dispose();
            _dbConnection?.Dispose();
        }

        ~UnitOfWorkAbstraction()
        {
            Dispose(false);
        }
    }
}
