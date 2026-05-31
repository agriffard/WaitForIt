using Bunit;

namespace WaitForIt.Tests;

public sealed class WaitForItComponentTests : TestContext
{
    [Fact]
    public void ShowsLoadingTemplateWhileOperationRuns()
    {
        var completion = new TaskCompletionSource<Person>();

        var component = RenderComponent<global::WaitForIt.WaitForIt<Person>>(parameters => parameters
            .Add(parameter => parameter.Operation, () => completion.Task)
            .Add(parameter => parameter.Loading, builder => builder.AddContent(0, "Loading data"))
            .Add(parameter => parameter.Loaded, person => builder => builder.AddContent(0, person.Name))
            .Add(parameter => parameter.Error, exception => builder => builder.AddContent(0, exception.Message)));

        Assert.Contains("Loading data", component.Markup);
    }

    [Fact]
    public void ShowsLoadedTemplateWhenOperationSucceeds()
    {
        var component = RenderComponent<global::WaitForIt.WaitForIt<Person>>(parameters => parameters
            .Add(parameter => parameter.Operation, () => Task.FromResult(new Person("Ada")))
            .Add(parameter => parameter.Loading, builder => builder.AddContent(0, "Loading data"))
            .Add(parameter => parameter.Loaded, person => builder => builder.AddContent(0, person.Name))
            .Add(parameter => parameter.Error, exception => builder => builder.AddContent(0, exception.Message)));

        component.WaitForAssertion(() => Assert.Contains("Ada", component.Markup));
    }

    [Fact]
    public void ShowsErrorTemplateWhenOperationFails()
    {
        var component = RenderComponent<global::WaitForIt.WaitForIt<Person>>(parameters => parameters
            .Add(parameter => parameter.Operation, () => Task.FromException<Person>(new InvalidOperationException("boom")))
            .Add(parameter => parameter.Loading, builder => builder.AddContent(0, "Loading data"))
            .Add(parameter => parameter.Loaded, person => builder => builder.AddContent(0, person.Name))
            .Add(parameter => parameter.Error, exception => builder => builder.AddContent(0, exception.Message)));

        component.WaitForAssertion(() => Assert.Contains("boom", component.Markup));
    }

    public sealed record Person(string Name);
}
