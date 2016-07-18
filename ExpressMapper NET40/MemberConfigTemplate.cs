
using System;
using System.Linq.Expressions;

namespace ExpressMapper
{
    public class MemberConfigTemplate<TBase, TNBase> : IMemberConfigTemplate<TBase, TNBase>
    {
        public void Configure<T, TN>(IMemberConfiguration<T, TN> configuration) where T : TBase where TN : TNBase
        {

        }

        public IMemberConfiguration<TBase, TNBase> InstantiateFunc(Func<TBase, TNBase> constructor)
        {
            return this;
        }

        public IMemberConfiguration<TBase, TNBase> Instantiate(Expression<Func<TBase, TNBase>> constructor)
        {
            return this;
        }

        public IMemberConfiguration<TBase, TNBase> Before(Action<TBase, TNBase> beforeHandler)
        {
            return this;
        }

        public IMemberConfiguration<TBase, TNBase> After(Action<TBase, TNBase> afterHandler)
        {
            return this;
        }

        public IMemberConfiguration<TBase, TNBase> Member<TBaseMember, TNBaseMember>(Expression<Func<TNBase, TNBaseMember>> dest, Expression<Func<TBase, TBaseMember>> src)
        {
            return this;
        }

        public IMemberConfiguration<TBase, TNBase> Function<TMember, TNMember>(Expression<Func<TNBase, TNMember>> dest, Func<TBase, TMember> src)
        {
            return this;
        }

        public IMemberConfiguration<TBase, TNBase> Value<TNMember>(Expression<Func<TNBase, TNMember>> dest, TNMember value)
        {
            return this;
        }

        public IMemberConfiguration<TBase, TNBase> Ignore<TMember>(Expression<Func<TNBase, TMember>> dest)
        {
            return this;
        }

        public IMemberConfiguration<TBase, TNBase> CaseSensitive(bool caseSensitive)
        {
            return this;
        }

        public IMemberConfiguration<TBase, TNBase> CompileTo(CompilationTypes compilationType)
        {
            return this;
        }
        
        public IMemberConfiguration<TBase, TNBase> Flatten()
        {
            return this;
        }
    }
}
