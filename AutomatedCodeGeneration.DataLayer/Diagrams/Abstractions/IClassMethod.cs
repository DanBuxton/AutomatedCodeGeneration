using System.Collections.Generic;

namespace AutomatedCodeGeneration.DataLayer.Diagrams.Abstractions
{
    internal interface IClassMethod
    {
        NameTypeModel NameType { get; init; }
        AccessType Access { get; init; }
        List<NameTypeModel> Params { get; init; }
    }
}