using System.Reflection;
using System.Reflection.Emit;

namespace ArchitectureTests;

public class DomainTests
{
    private static Assembly DomainAssembly = Assembly.GetAssembly(typeof(Domain.Catalog.Types.Author));

    [Fact]
    public void DomainProject_ShouldNotHaveAnyDependencies()
    {
        var result = Types
        .InAssembly(DomainAssembly)
        .ShouldNot()
        .HaveDependencyOnAny()
        .GetResult();

        result.IsSuccessful.Should().BeTrue();
    }

    [Fact]
    public void ClassesAndRecordsWhichAreNotAbstractOrInterfaces_ShouldBeSealed()
    {
        var result = Types
        .InAssembly(DomainAssembly)
        .That()
        .AreNotAbstract()
        .Or()
        .AreNotInterfaces()
        .Should()
        .BeSealed()
        .GetResult();

        result.IsSuccessful.Should().BeTrue();
    }
}
