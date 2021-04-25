using System.Collections.Generic;

namespace AutomatedCodeGeneration.DataLayer.Diagrams.Abstractions
{
    internal interface IClassMethod
    {
        NameTypeModel NameType { get; init; }
        Enums.AccessType Access { get; init; }
        List<NameTypeModel> Params { get; init; }
    }
}