namespace Implementation.Inputs
{
    public interface IMouseEventHandlerCollection
    {
        public void AddHandler(IMouseEventHandler handler);

        public void RemoveHandler(IMouseEventHandler handler);
    }
}
