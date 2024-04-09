using MrEfka.ToolBox.QueryString.Core;

namespace ToolBox.UnitTests;

[TestClass]
public class PrimitiveTypeUnitTests
{
    [TestMethod]
    public void PrimitiveType_EqualsTest_DifferentTypes_Fails()
    {
        // Arrange
        PrimitiveType intValue = new(1);
        PrimitiveType charValue = new('1');

        // Act + Assert
        Assert.IsFalse(intValue.Equals(charValue));
    }    
    
    [TestMethod]
    public void PrimitiveType_EqualsTest_DifferentTypes2_Fails()
    {
        // Arrange
        PrimitiveType intValue = new(0);
        PrimitiveType charValue = new(false);

        // Act + Assert
        Assert.IsFalse(intValue.Equals(charValue));
    }
    
    [TestMethod]
    public void PrimitiveType_EqualsTest_SameTypeDiffValues_Fails()
    {
        // Arrange
        PrimitiveType intValue = new(0);
        PrimitiveType charValue = new(1);

        // Act + Assert
        Assert.IsFalse(intValue.Equals(charValue));
    }
        
    [TestMethod]
    public void PrimitiveType_EqualsTest_SameTypeSameValues_Succeed()
    {
        // Arrange
        PrimitiveType intValue = new(1);
        PrimitiveType charValue = new(1);

        // Act + Assert
        Assert.IsTrue(intValue.Equals(charValue));
    }  
    
    [TestMethod]
    public void PrimitiveType_IsPrimitiveWithTypeTest_ValueType_Fails()
    {
        // Arrange
        var type = typeof(DateTime);

        // Act + Assert
        Assert.IsFalse(PrimitiveType.IsPrimitive(type));
    }
    
    [TestMethod]
    public void PrimitiveType_IsPrimitiveWithTypeTest_ValueType_Succeed()
    {
        // Arrange
        var type = typeof(int?);

        // Act + Assert
        Assert.IsTrue(PrimitiveType.IsPrimitive(type));
    }
        
    [TestMethod]
    public void PrimitiveType_IsPrimitiveWithTypeTest_RefType_Fails()
    {
        // Arrange
        var type = typeof(Exception);

        // Act + Assert
        Assert.IsFalse(PrimitiveType.IsPrimitive(type));
    }
            
    [TestMethod]
    public void PrimitiveType_IsPrimitiveWithValueTest_RefType_Fails()
    {
        // Arrange
        var o = new Exception();

        // Act + Assert
        Assert.IsFalse(PrimitiveType.IsPrimitive(o));
    }  
    
    [TestMethod]
    public void PrimitiveType_IsPrimitiveWithValueTest_Null_Succeed()
    {
        // Arrange
        Exception? o = null!;

        // Act + Assert
        Assert.IsTrue(PrimitiveType.IsPrimitive(o));
    }
    
    [TestMethod]
    public void PrimitiveType_ParseTest_NullableEmpty_Fails()
    {
        // Arrange
        int? number = new Nullable<int>(); // Empty nullable int; results to null.
        PrimitiveType numberPrimitive = new(number); // Primitive value with previously created nullable int.

        // Act
        PrimitiveType type = PrimitiveType.Parse(number!); // Parse value
        
        // Assert
        Assert.IsTrue(type.IsNull());
        // Are not equals because when parsing, null values are considered as string.
        // But <numberPrimitive> was instantiated as number.
        // Therefore, those two `null` values are considered as not equal.
        Assert.AreNotEqual(numberPrimitive, type); 
    }
}