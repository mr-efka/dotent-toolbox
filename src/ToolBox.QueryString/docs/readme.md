# ToolBox.Querystring

## Introduction

ToolBox.Querystring string is a module of the MrEka.ToolBox, which provides a simple interface to easily generate query strings in .Net applications.
"What a useless package is that again !!!??" you may think, and you are right. On [NuGet](https://nuget.org) they are thousands of libraries providing strong, robust and efficient ways to generate query strings.
But unfortunately, I've found none which fits my needs.

I've started developing this package because I was supposed to consume a Web Api where filters (querystring key-values) where defined in an object with nested properties where those properties could also be objects themselves. 

The goal of this module is to generate querystring from an object relying on some identified `PrimitiveType`s.

> If you intend to use this package for an [AspNetCore](https://learn.microsoft.com/en-us/aspnet/core/introduction-to-aspnet-core) application, better install the [MrEfka.ToolBox.QueryString.IoC](https://www.nuget.org/packages/MrEfka.ToolBox.QueryString.IoC) package, which provide useful methods to register the helper in you services collection.

## Primitive Types

In the context of this module, a primitive type is one that instances can be directly written in a querystring without any transformation.
In .Net, our supported primitive types can be grouped in three main categories called `Primitive Type Classes` :

* **Booleans** : `bool` (**true** or **false**);
* **Numbers** : `sbyte`, `byte`, `short`, `ushort`, `int`, `uint`, `nint`, `nuint`, `long`, `ulong`, `decimal`, `float`, `double`;
* **Literals** : `char`, `string`.

## How to use ?

The **ToolBox.QueryString** package expose only two classes :
* `QueryStringHelper` : The main class used to generate query strings from .Net objects;
* `QueryStringHelperConfiguration`: A configuration class to change the behaviour of the **QueryStringHelper** and customize the final output.

### Helper initialization

You can create helper instances using one of the following constructors :

* `QueryStringHelper()` : Initializes a new instance of **QueryStringHelper** with its default configuration. See the next section for default configuration values.
* `QueryStringHelper(QueryStringHelperConfiguration cfg)` : Creates a new instance of **QueryStringHelper** with the given configuration. 

### Helper configuration

You can configure the helper behaviour by passing instance of **QueryStringHelperConfiguration** to the constructor.

QueryStringHelperConfiguration exposes the following properties to customize the output of the resulting strings.

* **NestingStrategy** : Controls how the helper will hierarchically nest properties/values while building the query string.
  * Type : enum `MrEfka.ToolBox.QueryString.Configuration.QueryStringNestingStrategy`
  * Possible values :
    * `DotNotation` : Use OOP dot notation to nest properties/values
    * `ArrayLike` : Use square brackets to nest properties/values
  * Default value : `QueryStringNestingStrategy.DotNotation`

* **NamingPolicy** : Determines the naming policy used to convert a string-based name to another format, such as a camel-casing or snake-casing formats.
  * Type : abstract class `MrEfka.ToolBox.QueryString.Configuration.QueryStringNamingPolicy`
  * Built-in strategies :
    * `QueryStringNamingPolicy.Identity` : means the names in won't be changed; they will be render as they are read
    * `QueryStringNamingPolicy.CamelCase` : the naming policy for camel-casing
    * `QueryStringNamingPolicy.UpperCamelCase` : the naming policy for upper-camel-casing
    * `QueryStringNamingPolicy.SnakeCase` : the naming policy for snake-casing
  * Default value : `QueryStringNamingPolicy.Identity`

* **UseArrayIndex** : sets a value indicating whether collection will be rendered in index-like mode (array[0]=value0 and array[1]=value1) or collection set (array=[value0, value1])
  * Type : **bool**
  * Possible value : **true**, **false**
  * Default value : **true**

* **UseQuotedStrings** : sets a value indicating whether strings should be enclosed with double quotes
  * Type : **bool**
  * Possible value : **true**, **false**
  * Default value : **false**

* **NullValueHandling** : Controls how the helper handles `null` values while building the query string
  * Type : enum `MrEfka.ToolBox.QueryString.Configuration.NullValueHandlingStrategy`
  * Possible values :
    * `Ignore` : Null value field will not be append to the resulting query string.
    * `Always` : Null value field will be added to the resulting query string without value.
    * `TextLower` : Null value field will be added to the resulting query string with value `null` as text.
    * `TextUpper` : Null value field will be added to the resulting query string with value `NULL` as text.
  * Default value : `NullValueHandlingStrategy.Ignore`

* **EmptyCollectionHandling** : Controls how the helper handles empty collections while building the query string
  * Type : enum `MrEfka.ToolBox.QueryString.Configuration.EmptyCollectionHandlingStrategy`
  * Possible values :
    * `Ignore` : Empty collections field will not be append to the resulting query string.
    * `Always` : Null value or empty collections field will be added to the resulting query string without value.
    * `AlwaysEmpty` : Null value or empty collections field will be added to the resulting query string with empty array value `[]`.
  * Default value : `EmptyCollectionHandlingStrategy.DotNotation`
  * Remarks : This configuration works only when building querystring with either a not null collection object or not null object which type's is not considered as a primitive type. In other cases, defined `NullValueHandling` will be applied.

* **EncodeUriComponents** : sets a value indicating whether uri components should be encoded or raw strings will be returned
  * Type : **bool**
  * Possible value : **true**, **false**
  * Default value : **false**
  * Remarks : Setting this value to `false` may lead to unwanted behaviours when running in production. Please change this flag only for testing and debugging purposes.

### Available APIs

```csharp
///<summary>Builds query string from the provided data source <paramref name="o"/>.</summary>
///<param name="o">Source object to load query string values from.</param>
///<param name="name">If <paramref name="o"/> is a valid primitive type, this value should contain the key name of the query string entry. Otherwise, this value contains the root name for all elements/properties in <paramref name="o"/>. That means elements/properties will be nested according to this value.</param>
///<returns>Generated query string</returns>
string BuildQueryString(object o, [string name])
    
///<summary>Builds query string from the provided key-value map.</summary>
///<remarks> This API assumes the values in the map are valid supported primitive types. </remarks>
///<param name="data">Key-Value map to build query string from.</param>
///<exception cref="T:System.InvalidCastException">If at least one value in data map is not a valid supported primitive type</exception>
///<exception cref="T:System.ArgumentException">If at least one key in data map is <see langword="null"/> or empty (<see cref="System.String.Empty"/>).</exception>
///<returns>Generated query string</returns>
string BuildQueryString(IDictionary<string, object> data)
```

### Examples

* Test class Model :
```csharp
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
```

* Case 1 : Primitive type value
```csharp
  QueryStringHelper factory = new();
  var data = 1;
  const string key = "sample";

  var qs = factory.BuildQueryString(data, key);
  
  System.Console.WriteLine("Output : {0}", qs);
  
  // Output : sample=1
```

* Case 2 : Collection of primitive type values
```csharp
  QueryStringHelper factory = new QueryStringHelper(new QueryStringHelperConfiguration()
  {
      UseArrayIndex = false,
      EncodeUriComponents = false // Debug::To prevent encoding commas
  });
  var data = new object [] {"red", true, 7.5D, 'Q'};
  const string key = "items";

  var qs = factory.BuildQueryString(data, key);
  
  System.Console.WriteLine("Output : {0}", qs);
  
  // Output : items=red&items=True&items=7,5&items=Q
```

* Case 3 : Empty class object
```csharp
  QueryStringHelper factory = new();
  var data = new QueryStringBuilderUnitTests();
  const string key = "colors";

  var qs = factory.BuildQueryString(data, key);
  
  System.Console.WriteLine("Output : {0}", qs);
  
  // Output :  (Empty string)
```

* Case 4 : Class object with nested object null
```csharp
  QueryStringHelper factory = new();
  var data = new QsBuilderTestingModel()
  {
      Id = 1,
      Name = "Sampolo",
      Filters = null
  };

  var qs = factory.BuildQueryString(data, key);
  
  System.Console.WriteLine("Output : {0}", qs);
  
  // Output : Id=1&Name=Sampolo
```

*  Full of customizations
```csharp
  QueryStringHelperConfiguration config = new QueryStringHelperConfiguration()
  {
    EmptyCollectionHandling = EmptyCollectionHandlingStrategy.AlwaysEmpty,
    NamingPolicy = QueryStringNamingPolicy.SnakeCase,
    NestingStrategy = QueryStringNestingStrategy.ArrayLike,
    UseArrayIndex = true,
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

  System.Console.WriteLine("Output : {0}", qs);

  // Output : search_criteria[id]=1&search_criteria[name]=Sampolo&search_criteria[filters][name]=John&search_criteria[filters][date]=2023-12-01&search_criteria[filters][category_ids][0]=id&search_criteria[filters][category_ids][1]=SluG&search_criteria[filters][category_ids][2]=sku&search_criteria[filters][category_ids][3]=web uri&search_criteria[filters][array]=[]&search_criteria[filters][points][0][x]=1&search_criteria[filters][points][0][y]=1&search_criteria[filters][points][1][x]=2&search_criteria[filters][points][1][y]=2
```

### Customizations

#### 1. Properties exclusion
At some points, you may not want all attributes in your model to be involved in querystring generation.
If you are lazy enough - like me :sweat_smile: - or you just don't want to create new objects (anonymous or additional model class) to pass to the **QueryStringHelper**, you can use the `QsIgnore` attribute to exclude all the properties you don't need in the querystring.

Example :
Let's consider the following class as our model

```csharp
  class QsAttrsTestingModel
  {
      public int Id { get; set; }
      public float Single { get; set; }
      [QsIgnore]
      public QsBuilderTestingModel Model { get; set; }
      [QsIgnore]
      public char PrimitiveIgnored { get; set; }
  }
```
The minimal code for generating querystring with this model can look like :
```csharp
  var data = new QsAttrsTestingModel()
  {
      Id = 1, Single = 2f, Model = new()
  };
  var helper = new QueryStringHelper();

  var qs = helper.BuildQueryString(data);
  
  System.Console.WriteLine("Output : {0}", qs);

  // Output : Id=1&Single=2

```
The presence of the **QsIgnore** attribute on *Model* and *PrimitiveIgnored* properties, notifies the helper to slightly ignore them.

## Authors

- **Mr Efka** - _Initial work_ - [Mr efka](https://github.com/mr-efka)

## License

This project is licensed under the BSD 2-Clause License - see the [LICENSE](LICENSE) file for details.