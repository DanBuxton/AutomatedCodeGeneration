using System;
using AutomatedCodeGeneration.Library.Data.Diagrams.Abstractions;

namespace AutomatedCodeGeneration.Library.Data.Diagrams
{
    internal class ActorModel : IActor
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
    }
}
