using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Core.Specifications;

namespace Core
{
    public class BaseSpecification<T> : ISpecification<T>
    {
        public BaseSpecification()
        {
            
        }

        public BaseSpecification(Expression<Func<T,bool>> criteria)
        {
            Critiria=criteria;
        }

        public BaseSpecification(Expression<Func<T,bool>> criteria,
            List<Expression<Func<T,Object>>> includes)
        {
                Critiria=criteria;
                Includes=includes;
        }

        public Expression<Func<T, bool>> Critiria {get;}

        public List<Expression<Func<T, object>>> Includes {get;}

        protected  void AddInclude(Expression<Func<T,Object>> inlcudeExpression)
        {
            Includes.Add(inlcudeExpression);
        }
    }
}