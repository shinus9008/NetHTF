using NetHTF.Devices.Diagrams;
using NetHTF.Devices.Diagrams.Metadata.Box;

namespace Sample.Common
{
    /// <summary>
    /// PowerSupply => R1 => IN.A | OUT.C => DI.0
    ///             => R2 => IN.B | 
    /// </summary>
    public static class ExampleDeviceDiagram
    {
        public static DiagramEntity GetDiagram()
        {
            // Create diagram
            var diagram = new DiagramEntity("Example diagram");

            // Add Components
            diagram.Components.Add(GetComponentPowerSupply());
            diagram.Components.Add(GetComponentR1());
            diagram.Components.Add(GetComponentR2());
            diagram.Components.Add(GetComponentBlackBox());
            diagram.Components.Add(GetComponentDigitalInput());

            return diagram;
        }

        private static DiagramComponent GetComponentPowerSupply()
        {
            var component = new DiagramComponent("Power Supply");

            return component;
        }
        private static DiagramComponent GetComponentR1()
        {
            var component = new DiagramComponent("R1");

            return component;
        }
        private static DiagramComponent GetComponentR2()
        {
            var component = new DiagramComponent("R2");

            return component;
        }
        private static DiagramComponent GetComponentBlackBox()
        {
            var component = new DiagramComponent("Black box");

            var metadata = new BoxMetadata("AND");
            metadata.Sockets.Add(Socket.WithePin("IN", "A", "B"));
            metadata.Sockets.Add(Socket.WithePin("OUT", "C"));

            //TODO: Simplify
            component.Metadata.Add(typeof(BoxMetadata),metadata);

            return component;
        }
        private static DiagramComponent GetComponentDigitalInput()
        {
            var component = new DiagramComponent("Digital input");

            var metadata = new BoxMetadata("");
                metadata.Sockets.Add(Socket.WithePin("IDI", "A", "B"));
            

            //TODO: Simplify
            component.Metadata.Add(typeof(BoxMetadata), metadata);

            return component;
        }
    }
}
