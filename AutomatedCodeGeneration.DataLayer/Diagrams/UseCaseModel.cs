using System;
using System.ComponentModel.DataAnnotations.Schema;
using AutomatedCodeGeneration.DataLayer.Diagrams.Abstractions;

namespace AutomatedCodeGeneration.DataLayer.Diagrams;

public class UseCaseModel : IUseCaseModel
{
    public Guid Id { get; set; }
    public virtual SystemModel System { get; set; }

    public virtual ActorModel Actor { get; set; }

    [ForeignKey("FK_UseCase_Extends")]
    public virtual UseCaseModel Extends { get; set; }
    
    [ForeignKey("FK_UseCase_Includes")]
    public virtual UseCaseModel Includes { get; set; }
    public string Title { get; set; }
}
