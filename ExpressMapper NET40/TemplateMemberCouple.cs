using System;
using System.Linq.Expressions;

namespace ExpressMapper
{
    public abstract class TemplateMemberCouple<TBase, TNBase>
    {
        private TemplateMemberCouple<TBase, TNBase> _instance;

        public static TemplateMemberCouple<TBase, TNBase> Create<TBaseMember, TNBaseMember>(Expression<Func<TNBase, TNBaseMember>> destMember, Expression<Func<TBase, TBaseMember>> sourceMember)
        {
            return new TemplateMemberCouple<TBase, TBaseMember, TNBase, TNBaseMember>(destMember, sourceMember);
        }

        public abstract void Configure<T, TN>(IMemberConfiguration<T, TN> configuration) where T : TBase where TN : TNBase;
    }

    public class TemplateMemberCouple<TBase, TBaseMember, TNBase, TNBaseMember> : TemplateMemberCouple<TBase, TNBase>
    {
        private Expression<Func<TNBase, TNBaseMember>> _destMember;
        private Expression<Func<TBase, TBaseMember>> _sourceMember;

        public TemplateMemberCouple(Expression<Func<TNBase, TNBaseMember>> destMember, Expression<Func<TBase, TBaseMember>> sourceMember)
        {
            _destMember = destMember;
            _sourceMember = sourceMember;
        }

        public override void Configure<T, TN>(IMemberConfiguration<T, TN> configuration)
        {
            var method = GetType().GetMethod("Member").MakeGenericMethod(typeof(T), typeof(TN)); ;
            method.Invoke(this, new object[] { _destMember, _sourceMember });
        }
    }
}
