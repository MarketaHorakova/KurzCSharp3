namespace ToDoList.Test;

public class UnitTest1
//by šel test tak dotnet clean & dotnet build
{
    [Fact]
    public void Divide_WithoutRemainder_Succeeds()
    {
        //  Arrange
        var calculator = new Calculator();

        //  Act
        var result = calculator.Divide(10, 5);

        //  Assert
        Assert.Equal(2, result);
    }

    [Fact]
    public void DevideFloat_ByZero_ReturnsInfinity()
    {
        //  Arrange
        var calculator = new Calculator();

        //  Act


        //  Assert
        Assert.Throws<DivideByZeroException>(() => calculator.Divide(10, 0));
    }

    [Fact]
    public void UnitTest2()
    {
        //  Arrange
        var calculator = new Calculator();

        //  Act


        //  Assert
        Assert.Throws<DivideByZeroException>(() => calculator.Divide(10, 0));
    }
    [Theory]
    [InlineData(10, 2, 15)]
    [InlineData(1, 2, 3)]
    public void UnitTest3(int dividend, int divisior, int expectedRelust)
    {
        //  Arrange
        var calculator = new Calculator();

        //  Act


        //  Assert
        Assert.Throws<DivideByZeroException>(() => calculator.Divide(10, 0));
    }


}

public class Calculator
{
    public int Divide(int dividend, int divisior)
    {
        return dividend / divisior;
    }
}
