namespace Implementation.Entity
{
    public class DemoEntity : IEntity
    {
        public string Id => "entity:demo";

        public string Name => "Demo";

        public IEntity Clone()
        {
            return new DemoEntity();
        }
    }
}
