using System.Linq;
using Xunit;


public class MappingFinderAutoPropertiesAndDodgyField
{
    [Fact]
    public void Run()
    {
        var memberMappings = ModuleWeaver.GetMappings(DefinitionFinder.FindType<ClassWithAutoPropertiesAndDodgyField>()).ToList();
        Assert.Equal("<Property1>k__BackingField", memberMappings.Single(x => x.PropertyDefinition.Name == "Property1").FieldDefinition.Name);
        Assert.Equal("<Property2>k__BackingField", memberMappings.Single(x => x.PropertyDefinition.Name == "Property2").FieldDefinition.Name);
    }

    public class ClassWithAutoPropertiesAndDodgyField
    {
#pragma warning disable 169
        string _property2;
#pragma warning restore 169
        public string Property1 { get; set; }
        public string Property2 { get; set; }
    }
}