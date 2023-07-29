namespace WebApplication1.Repository
{
    public interface IEntity<t>
    {
        public Task<t> Add(t entity);
        public Task<t> Update(t entity);
        public Task<t> Delete(t entity);
        public Task<t> GetById(int id);
        public Task<List<t>> GetAll();
    }
}
