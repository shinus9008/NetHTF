using static SampleConsole.Controllers.BlackboxController;

namespace SampleConsole.Controllers
{
    [BlackboxRow(In1 = true,  In2 = true,  Out = true)]
    [BlackboxRow(In1 = true,  In2 = false, Out = false)]
    [BlackboxRow(In1 = false, In2 = true,  Out = false)]
    [BlackboxRow(In1 = false, In2 = false, Out = false)]
    public class BlackboxController : Controller<BlackboxRow>
    {

        public void Do()
        {
            //Do relay connection
        }

        [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
        public sealed class BlackboxRow : Attribute
        {
            public bool In1 { get; init; }
            public bool In2 { get; init; }
            public bool Out { get; init; }
        }
    }








    public abstract class Controller
    {
    }
    public abstract class Controller<T>
    {
        public T Model { get; private set; }
    }
}
