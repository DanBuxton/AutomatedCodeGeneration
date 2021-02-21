using System.Collections.Generic;

namespace AutomatedCodeGeneration.Library.Data.Diagrams.Abstractions
{
    internal interface IClassMethod
    {
        NameTypeModel NameType { get; init; }
        AccessModel Access { get; init; }
        List<NameTypeModel> Params { get; init; }
    }
}