namespace NetHTF.Devices.Diagrams
{
    public class DiagramConnect
    {
        public DiagramConnect(string name, string targetSocket1, string targetPin1, string targetSocket2, string targetPin2)
        {
            Name            = name;
            TargetSocket1   = targetSocket1;
            TargetPin1      = targetPin1;
            TargetSocket2   = targetSocket2;
            TargetPin2      = targetPin2;
        }

        public string Name { get; }
        public string TargetSocket1 { get; }
        public string TargetPin1 { get; }
        public string TargetSocket2 { get; }
        public string TargetPin2 { get; }
    }
}
