using MrEfka.ToolBox.QueryString;
using MrEfka.ToolBox.QueryString.DataAnnotation;

namespace ToolBox.UnitTests;

[TestClass]
public class QsAttributesUnitTests
{
    [TestMethod]
    public void QsIgnoreTest_Succeed()
    {
        // Arrange
        QsAttrsTestingModel data = new()
        {
            ToIgnore = new QsAttrsTestingModel.NestedClass() { Name = "John", Date = "2024-01-01" },
            Item = new QsAttrsTestingModel.NestedClass() { Name = "Jeanne" },
            PrimitiveIgnored = 'E',
            Single = 1f
        };
        QueryStringHelper helper = new();

        Type type = data.GetType();

        // Act
        var qs = helper.BuildQueryString(data);

        // Assert
        Assert.AreEqual("Item.Name=Jeanne&Single=1", qs);
    }
    
    class QsAttrsTestingModel
    {
        public int? Id { get; set; }
        public float Single { get; set; }
        [QsIgnore]
        public NestedClass ToIgnore { get; set; }
        [QsIgnore]
        public char PrimitiveIgnored { get; set; }
        public NestedClass Item { get; set; }

        public class NestedClass
        {
            public string Name { get; set; }
            public string Date { get; set; }
            [QsIgnore]
            public string[] CategoryIds { get; set; }
            public int[] Array { get; set; }
        }
    }
}