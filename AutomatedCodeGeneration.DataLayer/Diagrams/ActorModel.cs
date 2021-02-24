using System;
using AutomatedCodeGeneration.DataLayer.Diagrams.Abstractions;

namespace AutomatedCodeGeneration.DataLayer.Diagrams
{
    public class ActorModel : IActor
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
    }
}
