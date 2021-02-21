namespace AutomatedCodeGeneration.Library.Data.Diagrams.Abstractions
{
    internal interface IClassData
    {
        NameTypeModel NameType { get; init; }
        AccessModel Access { get; init; }
    }
}