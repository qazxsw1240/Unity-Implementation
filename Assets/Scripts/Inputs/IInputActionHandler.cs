using System.Collections.Generic;

namespace Implementation.Inputs
{
    public interface IInputActionHandler
    {
        public bool Handle(IList<InputEvent> inputEvents);
    }
}
