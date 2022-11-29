namespace AutomatedCodeGeneration.DataLayer.Diagrams.Abstractions;

internal interface IClassData
{
    NameTypeModel NameType { get; init; }
    Enums.AccessType Access { get; init; }
}