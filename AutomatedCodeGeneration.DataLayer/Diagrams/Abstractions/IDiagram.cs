using System;

namespace AutomatedCodeGeneration.DataLayer.Diagrams.Abstractions;

internal interface IDiagram
{
    Guid Id { get; set; }
    public SystemModel System { get; set; }
}