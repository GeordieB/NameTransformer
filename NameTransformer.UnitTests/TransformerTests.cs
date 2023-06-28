using FluentAssertions;

namespace NameTransformer.UnitTests;

public class TransformerTests
{
    [TestCase(null)]
    [TestCase("")]
    [TestCase(" ")]
    public void GivenAnInvalidName_WhenTransformIsCalled_ThenNullIsReturned(string name)
    {
        var result = Transformer.Transform(name);

        result.Should().BeNull();
    }

    [Test]
    public void GivenOnlyAFirstOrLastName_WhenTransformIsCalled_ThenTheStringIsReturnedUnchanged()
    {
        const string name = "Carlos";

        var result = Transformer.Transform(name);

        result.Should().Be(name);
    }

    [TestCase("Carlos Sainz", "Sarlos Cainz")]
    [TestCase("Esteban Ocon", "Osteban Econ")]
    [TestCase("Alex Albon", "Alex Albon")]
    public void GivenAFullName_WhenTransformIsCalled_ThenTheNameIsTransformed(string fullName, string transformedName)
    {
        var result = Transformer.Transform(fullName);

        result.Should().Be(transformedName);
    }

    [TestCase("Lance Stroll", "Strance Loll")]
    [TestCase("Charles Leclerc", "Larles Checlerc")]
    public void GivenAFullNameStartingWithSeveralConsonants_WhenTransformIsCalled_ThenTheNameIsTransformed(string fullName, string transformedName)
    {
        var result = Transformer.Transform(fullName);

        result.Should().Be(transformedName);
    }

    [TestCase("Carlos  Sainz")]
    [TestCase("Carlos Sainz  ")]
    [TestCase("  Carlos Sainz")]
    [TestCase("  Carlos Sainz  ")]
    public void GivenAFullNameWithExtraWhitespace_WhenTransformIsCalled_ThenTheNameIsTransformed(string fullName)
    {
        var result = Transformer.Transform(fullName);

        result.Should().Be("Sarlos Cainz");
    }
}