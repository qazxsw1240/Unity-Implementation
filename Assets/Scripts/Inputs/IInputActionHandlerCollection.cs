namespace Implementation.Inputs
{
    public interface IInputActionHandlerCollection
    {
        public void AddAction(IInputActionHandler handler);

        public void RemoveAction(IInputActionHandler handler);
    }
}
