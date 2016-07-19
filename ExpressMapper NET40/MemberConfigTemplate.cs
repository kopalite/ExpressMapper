
using ExpressMapper;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ExpressMapper
{
    public class MemberConfigTemplate<TBase, TNBase> : IMemberConfigTemplate<TBase, TNBase>
    {
        public MemberConfigTemplate()
        {
            _members = new List<TemplateMemberCouple<TBase, TNBase>>();
        }

        public void Configure<T, TN>(IMemberConfiguration<T, TN> configuration) where T : TBase where TN : TNBase
        {
            configuration.Before((t, tn) => _beforeHandler(t, tn));

            configuration.After((t, tn) => _afterHandler(t, tn));

            foreach (var member in _members)
            {
                member.Configure(configuration);
            }
        }

        public IMemberConfiguration<TBase, TNBase> InstantiateFunc(Func<TBase, TNBase> constructor)
        {
            //TODO: Not sure if constructor should be used for base class.
            throw new NotImplementedException();
        }

        public IMemberConfiguration<TBase, TNBase> Instantiate(Expression<Func<TBase, TNBase>> constructor)
        {
            //TODO: Not sure if constructor should be used for base class.
            throw new NotImplementedException();
        }

        private Action<TBase, TNBase> _beforeHandler;

        public IMemberConfiguration<TBase, TNBase> Before(Action<TBase, TNBase> beforeHandler)
        {
            _beforeHandler = beforeHandler;
            return this;
        }

        private Action<TBase, TNBase> _afterHandler;

        public IMemberConfiguration<TBase, TNBase> After(Action<TBase, TNBase> afterHandler)
        {
            _afterHandler = afterHandler;
            return this;
        }

        private List<TemplateMemberCouple<TBase, TNBase>> _members;

        public IMemberConfiguration<TBase, TNBase> Member<TBaseMember, TNBaseMember>(Expression<Func<TNBase, TNBaseMember>> dest, Expression<Func<TBase, TBaseMember>> src)
        {
            _members.Add(TemplateMemberCouple<TBase, TNBase>.Create(dest, src));
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
