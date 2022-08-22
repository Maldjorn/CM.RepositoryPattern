namespace CM.Customers
{
    interface IRepository<TEntity>
    {
        void Create(TEntity entity);
        TEntity Read(int entityCode);
        void Update(TEntity entity);
        void Delete(int entityCode);
    }
}
