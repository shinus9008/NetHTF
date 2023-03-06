using NetHTF.Devices.Diagrams;
using ReactiveUI;
using Sample.Common;
using System.Linq;

namespace WpfAppDiagramEntity
{
    public class MainViewModel : ReactiveObject
    {
        public MainViewModel()
        {
            Diagram = new DiagramViewModel(
                ExampleDeviceDiagram.GetDiagram().Components.Select(item => new ComponentViewModel() { Size = 100, X = 0, Y = 0, Text = item.Name }));

            
        }

        public DiagramViewModel Diagram { get; }
    }
}
