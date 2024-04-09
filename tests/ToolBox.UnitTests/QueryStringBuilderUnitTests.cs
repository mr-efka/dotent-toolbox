using MrEfka.ToolBox.QueryString;
using MrEfka.ToolBox.QueryString.Configuration;

namespace ToolBox.UnitTests;

[TestClass]
public class QueryStringBuilderUnitTests
{
    [TestMethod]
    public void BuildQueryString_WithPrimitiveNumber_Success()
    {
        // Arrange
        QueryStringHelper factory = new();
        var data = 1;
        const string key = "sample";

        // Act
        var qs = factory.BuildQueryString(data, key);
        
        // Assert
        Assert.AreEqual("sample=1", qs);
    }
    
    [TestMethod]
    public void BuildQueryString_WithPrimitiveBoolean_Success()
    {
        // Arrange
        QueryStringHelper factory = new();
        var data = true;
        const string key = "isSample";

        // Act
        var qs = factory.BuildQueryString(data, key);
        
        // Assert
        Assert.AreEqual("isSample=True", qs);
    }
    
    [TestMethod]
    public void BuildQueryString_WithPrimitiveCollection_Success()
    {
        // Arrange
        QueryStringHelper factory = new(new QueryStringHelperConfiguration()
        {
            UseArrayIndex = false,
            EncodeUriComponents = false
        });
        var data = new[] {"red", "blue", "green"};
        const string key = "colors";

        // Act
        var qs = factory.BuildQueryString(data, key);
        
        // Assert
        Assert.AreEqual("colors=[red,blue,green]", qs);
    }   
    
    [TestMethod]
    public void BuildQueryString_WithPrimitiveCollectionIndexed_Success()
    {
        // Arrange
        QueryStringHelper factory = new();
        var data = new [] {"red", "blue", "green"};
        const string key = "colors";

        // Act
        var qs = factory.BuildQueryString(data, key);
        
        // Assert
        Assert.AreEqual("colors[0]=red&colors[1]=blue&colors[2]=green", qs);
    }
    
        
    [TestMethod]
    public void BuildQueryString_WithEmptyClassObject_Success()
    {
        // Arrange
        QueryStringHelper factory = new();
        var data = new QueryStringBuilderUnitTests();
        const string key = "colors";

        // Act
        var qs = factory.BuildQueryString(data, key);
        
        // Assert
        Assert.AreEqual("", qs);
    }

        
    [TestMethod]
    public void BuildQueryString_WithClassObjectAndNestedObjectNull_Success()
    {
        // Arrange
        QueryStringHelper factory = new();
        var data = new QsBuilderTestingModel()
        {
            Id = 1,
            Name = "Sampolo",
            Filters = null
        };

        // Act
        var qs = factory.BuildQueryString(data);
        
        // Assert
        Assert.AreEqual("Id=1&Name=Sampolo", qs);
    }
    
    [TestMethod]
    public void BuildQueryString_WithClassObjectAndNestedObjectNotNull_Fails()
    {
        // Arrange
        QueryStringHelperConfiguration config = new QueryStringHelperConfiguration()
        {
            EmptyCollectionHandling = EmptyCollectionHandlingStrategy.AlwaysEmpty,
            NamingPolicy = QueryStringNamingPolicy.CamelCase,
            NestingStrategy = QueryStringNestingStrategy.ArrayLike,
            UseArrayIndex = false,
            EncodeUriComponents = false,
        };
        
        QueryStringHelper helper = new(config);
        var data = new QsBuilderTestingModel()
        {
            Id = 1,
            Name = "Sampolo",
            Filters = new QsBuilderTestingModel.NestedClass()
            {
                Date = "2023-12-01",
                Name = "John",
                CategoryIds = new [] { "id", "SluG", "sku", "web uri" },
                Array = Array.Empty<int>(),
                Points = new QsBuilderTestingModel.Point[] { new() { X = 1, Y = 1 }, new() { X = 2, Y = 2 } }
            }
        };

        // Act
        string baseName = "searchCriteria";
        var qs = helper.BuildQueryString(o: data, name: baseName);
        
        // Assert
        Assert.AreNotEqual("Id=1&Name=Sampolo&Filters.Name=John&Filters.Date=2023-12-01", qs);
        Assert.IsTrue(qs.Length > baseName.Length);
        Assert.AreEqual(baseName, qs[..baseName.Length]);
    }
    
    class QsBuilderTestingModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public NestedClass? Filters { get; set; }

        public class NestedClass
        {
            public string Name { get; set; }
            public string Date { get; set; }
            public string[] CategoryIds { get; set; }
            public int[] Array { get; set; }

            public Point[] Points { get; set; }
        }
        
        public class Point
        {
            public int X { get; set; }
            public int Y { get; set; }
        }
    }
}