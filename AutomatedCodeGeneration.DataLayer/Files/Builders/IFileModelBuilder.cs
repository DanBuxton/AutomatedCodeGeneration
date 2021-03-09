namespace AutomatedCodeGeneration.DataLayer.Files.Builders
{
    public interface IFileModelBuilder
    {
        public FileModel ModelType { get; }
        FileModel Build();
    }
}