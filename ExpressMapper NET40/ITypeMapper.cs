﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;

namespace ExpressMapper
{
    public interface ITypeMapper
    {
        Expression QueryableGeneralExpression { get; }
        Func<object, object, object> GetNonGenericMapFunc();
        Tuple<List<Expression>, ParameterExpression, ParameterExpression> GetMapExpressions();
        void Compile(CompilationTypes compilationtype, bool forceByDemand = false);
    }

    /// <summary>
    /// Interface that implements internals of mapping
    /// </summary>
    /// <typeparam name="T">source</typeparam>
    /// <typeparam name="TN">destination</typeparam>
    public interface ITypeMapper<T, TN> : ITypeMapper
    {
        Expression<Func<T, TN>> QueryableExpression { get; }
        CompilationTypes MapperType { get; }

        TN MapTo(T src, TN dest);
        void Ignore<TMember>(Expression<Func<TN, TMember>> left);
        void Ignore(PropertyInfo left);
        void CaseSensetiveMemberMap(bool caseSensitive);
        void CompileTo(CompilationTypes compileType);
        void MapMember<TMember, TNMember>(Expression<Func<TN, TNMember>> left, Expression<Func<T, TMember>> right);
        void MapMemberFlattened(MemberExpression left, Expression right);
        void MapFunction<TMember, TNMember>(Expression<Func<TN, TNMember>> left, Func<T, TMember> right);
        void InstantiateFunc(Func<T,TN> constructor);
        void Instantiate(Expression<Func<T,TN>> constructor);
        void BeforeMap(Action<T,TN> beforeMap);
        void AfterMap(Action<T,TN> afterMap);
        void Flatten();

        ITypeMapper<TChild, TNChild> Clone<TChild, TNChild>();
    }
}
