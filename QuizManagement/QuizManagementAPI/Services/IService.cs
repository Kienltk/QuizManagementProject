using System.Linq.Expressions;

namespace QuizManagementAPI.Services
{
    public interface IService<TResponse, TRequest>
    {
        IEnumerable<TResponse> GetAll();
        TResponse GetById(int id);
        TResponse Create(TRequest request);
        TResponse Update(int id, TRequest request);
        void Delete(int id);
        IEnumerable<TResponse> Find(Expression<Func<TResponse, bool>> predicate);
    }
}
