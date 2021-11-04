namespace CarService.Models.Application.Interface
{
    public interface IUnitOfWork
    {
        public void Commit();

        public void RollBack();
    }
}
