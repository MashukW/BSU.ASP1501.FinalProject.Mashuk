using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using AutoMapper;

namespace SocialNetwork.Helper
{
    public static class HelperConvert
    {
        public static Expression<Func<TOut, bool>> PredicateConvert<TIn, TOut>(Expression<Func<TIn, bool>> predicate)
        {
            BinaryExpression body = (BinaryExpression)predicate.Body;
            //UnaryExpression right = (UnaryExpression)body.Right;
            MemberExpression left = (MemberExpression)body.Left;

            ParameterExpression parameter = Expression.Parameter(typeof(TOut), "param");
            MemberExpression newLeft = Expression.Property(parameter, left.Member.Name);
            BinaryExpression newBody = body.Update(newLeft, body.Conversion, body.Right);

            return Expression.Lambda<Func<TOut, bool>>(newBody, parameter);
        }

        public static TOutput EntityConvert<TInput, TOutput>(TInput source)
        {
            Mapper.CreateMap<TInput, TOutput>();
            return Mapper.Map<TInput, TOutput>(source);
        }

        public static IEnumerable<TOutput> EntityConvert<TInput, TOutput>(IEnumerable<TInput> source)
        {
            Mapper.CreateMap<TInput, TOutput>();
            return Mapper.Map<IEnumerable<TInput>, IEnumerable<TOutput>>(source);
        }
    }
}
