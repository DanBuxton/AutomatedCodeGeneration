namespace AutomatedCodeGeneration.DataLayer.Diagrams.Abstractions;

internal interface IUseCaseModel : IDiagram
{
    ActorModel Actor { get; set; }
    UseCaseModel Extends { get; set; }
    UseCaseModel Includes { get; set; }
    string Title { get; set; }
}