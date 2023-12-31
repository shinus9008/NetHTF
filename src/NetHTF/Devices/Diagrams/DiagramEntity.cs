﻿namespace NetHTF.Devices.Diagrams
{
    /// <summary>
    /// Device diagram
    /// </summary>
    public class DiagramEntity
    {
        public DiagramEntity(string name)
        {
            Name       = name;
            Components = new List<DiagramComponent>();
            Connects   = new List<DiagramConnect>();
        }

        /// <summary>
        /// Device diagram name
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Diagram components
        /// </summary>
        //TODO: Read only
        public List<DiagramComponent> Components { get; }

        /// <summary>
        /// Diagram connects
        /// </summary>
        public List<DiagramConnect> Connects { get; }
    }
}
