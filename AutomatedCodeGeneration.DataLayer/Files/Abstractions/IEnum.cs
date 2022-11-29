using System.Collections;
using System.Collections.Generic;

namespace AutomatedCodeGeneration.DataLayer.Files.Abstractions;

public interface IEnum
{
    string Name { get; }
    IList<string> TagName { get; }
    IDictionary<string, object> Values { get; }
}