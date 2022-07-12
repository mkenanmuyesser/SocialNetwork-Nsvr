using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

namespace NeSever.Data.DataService
{
    public class BaseDataService
    {
        public IQueryable<TEntity> OrderBy<TEntity>(IQueryable<TEntity> source, string orderByProperty, string desc)
        {
            string command;
            if (desc == "Ascending" || desc == "asc")
            {
                command = "OrderBy";
            }
            else
            {
                command = "OrderByDescending";
            }
            var type = typeof(TEntity);
            var property = GetProperty(type, orderByProperty);
            var parameter = Expression.Parameter(type, "p");
            var propertyAccess = Expression.MakeMemberAccess(parameter, property);
            var orderByExpression = Expression.Lambda(propertyAccess, parameter);
            var resultExpression = Expression.Call(typeof(Queryable), command, new Type[] { type, property.PropertyType }, source.Expression, Expression.Quote(orderByExpression));
            return source.Provider.CreateQuery<TEntity>(resultExpression);
        }

        public PropertyInfo GetProperty(Type type, string name)
        {
            if (name.Contains("."))
            {
                string[] split = name.Split(new[] { '.' }, StringSplitOptions.RemoveEmptyEntries);
                if (split.Length > 0)
                {
                    foreach (string item in split)
                    {
                        var property = type.GetProperty(item);
                        if (property != null)
                        {
                            return GetProperty(property.DeclaringType, string.Join(".", split.Skip(1)));
                        }
                    }
                }
            }
            return type.GetProperty(name);
        }
    }
}
