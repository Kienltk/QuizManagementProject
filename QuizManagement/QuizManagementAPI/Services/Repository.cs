
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using QuizManagementAPI.Data;
using System;
using System.Linq.Expressions;

namespace QuizManagementAPI.Services
{
    public class Repository<TResponse, TRequest, TEntity> : IService<TResponse, TRequest>
    where TEntity : class
    {
        private readonly AppDbContext _context;
        private readonly DbSet<TEntity> _dbSet;
        private readonly IMapper _mapper;

        public Repository(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
            _mapper = mapper;
        }

        public IEnumerable<TResponse> GetAll()
        {
            var entities = _dbSet.ToList();
            return _mapper.Map<IEnumerable<TResponse>>(entities);
        }

        public TResponse GetById(int id)
        {
            var entity = _dbSet.Find(id);
            return entity != null ? _mapper.Map<TResponse>(entity) : default;
        }

        public TResponse Create(TRequest request)
        {
            var entity = _mapper.Map<TEntity>(request);
            _dbSet.Add(entity);
            _context.SaveChanges();
            return _mapper.Map<TResponse>(entity);
        }

        public TResponse Update(int id, TRequest request)
        {
            var entity = _dbSet.Find(id);
            if (entity != null)
            {
                _mapper.Map(request, entity);
                _context.SaveChanges();
                return _mapper.Map<TResponse>(entity);
            }
            return default;
        }

        public void Delete(int id)
        {
            var entity = _dbSet.Find(id);
            if (entity != null)
            {
                _dbSet.Remove(entity);
                _context.SaveChanges();
            }
        }

        public IEnumerable<TResponse> Find(Expression<Func<TResponse, bool>> predicate)
        {
            var entities = _dbSet.AsQueryable().ToList();
            var mappedEntities = _mapper.Map<IEnumerable<TResponse>>(entities);
            return mappedEntities.AsQueryable().Where(predicate.Compile());
        }
    }
}
