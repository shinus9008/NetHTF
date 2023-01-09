using System.Reactive.Linq;
using System.Reactive.Subjects;

namespace SampleConsole.Models
{
    /// <summary>
    /// Example black box. AND function.
    /// </summary>   
    public class BlackboxModel
    {
        private readonly BehaviorSubject<bool> In1;
        private readonly BehaviorSubject<bool> In2;

        public IObservable<bool> Out { get; }

        public BlackboxModel()
        {
            In1 = new BehaviorSubject<bool>(false);
            In2 = new BehaviorSubject<bool>(false);
            Out = Observable
                .CombineLatest(In1, In2, (in1, in2) => in1 & in2 )
                .Publish()
                .Retry(1);
        }
    }
}
