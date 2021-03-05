namespace AutomatedCodeGeneration.DataLayer.Diagrams.Abstractions
{
    internal interface IClassData
    {
        NameTypeModel NameType { get; init; }
        AccessType Access { get; init; }
    }
}