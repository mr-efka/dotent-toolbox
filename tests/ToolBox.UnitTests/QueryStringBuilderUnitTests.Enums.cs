using MrEfka.ToolBox.QueryString;
using MrEfka.ToolBox.QueryString.Configuration;
using MrEfka.ToolBox.QueryString.DataAnnotation;

namespace ToolBox.UnitTests;

public partial class QueryStringBuilderUnitTests
{
    [TestMethod]
    public void BuildQueryString_WithEnumData_OutputEnumNumberValue()
    {
        // Arrange
        var data = new QsEnumTestngModel()
        {
            Id = 1,
            Enum = QueryBuilderTestEnum.Three
        };

        var helper = new QueryStringHelper();

        // Act
        var qs = helper.BuildQueryString(data);

        // Assert
        Assert.IsFalse(string.IsNullOrEmpty(qs));
        Assert.AreEqual("Id=1&Enum=3", qs);
    }

    [TestMethod]
    public void BuildQueryString_WithEnumData_OutputEnumNameValue()
    {
        // Arrange
        var data = new QsEnumTestngModel()
        {
            Id = 1,
            Enum = QueryBuilderTestEnum.Two
        };

        var helper = new QueryStringHelper(new () { RenderEnumNames = true});

        // Act
        var qs = helper.BuildQueryString(data);

        // Assert
        Assert.IsFalse(string.IsNullOrEmpty(qs));
        Assert.AreEqual("Id=1&Enum=Two", qs);
    }

    class QsEnumTestngModel
    {
        public int Id { get; set; }
        public QueryBuilderTestEnum Enum { get; set; }
    }

    enum QueryBuilderTestEnum
    {
        One = 1,
        Two = 2,
        Three = 3
    }
}