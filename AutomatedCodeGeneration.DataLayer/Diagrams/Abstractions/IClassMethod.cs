using System.Collections.Generic;

namespace AutomatedCodeGeneration.DataLayer.Diagrams.Abstractions
{
    internal interface IClassMethod
    {
        NameTypeModel NameType { get; init; }
        AccessModel Access { get; init; }
        List<NameTypeModel> Params { get; init; }
    }
}