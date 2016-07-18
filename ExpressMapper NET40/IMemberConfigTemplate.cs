namespace ExpressMapper
{
    public interface IMemberConfigTemplate<TBase, TNBase> : IMemberConfiguration<TBase, TNBase>
    {
        void Configure<T, TN>(IMemberConfiguration<T, TN> configuration) where T : TBase where TN : TNBase;
    }
}
