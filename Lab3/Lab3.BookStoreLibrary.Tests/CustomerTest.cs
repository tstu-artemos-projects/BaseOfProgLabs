using Xunit;
using Lab3.BookStoreLibrary;
using System.Collections.Generic;
namespace Lab3.BookStoreLibraryTests;

public class CustomerTest
{
   

    [Theory]
    [InlineData(100, 100, true)] // цена равна пределу
    [InlineData(80, 100, true)] // цена ниже предела
    [InlineData(110, 100, false)] // цена выше предела
    public void CheckPrice_ValidatesCorrectly(decimal salePrice, decimal maxPrice, bool expected)
    //проверяет правильно ли CheckPrice возвращает true - купит или false - слишком дорого значит не купит
    {
        // arrange
        var customer = new Customer(3, RequestType.Genre, null, null, "Sci-Fi", maxPrice);
        // act
        bool result = customer.CheckPrice(salePrice);
        // assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void Serve_SetsCorrectStatus()//проверяет успешную продажу
    {
        // arrange
        var customer = new Customer(4, RequestType.Genre, null, null, "Drama", 300);
        // act
        customer.Serve();
        // assert
        Assert.True(customer.IsServed);
        Assert.False(customer.IsLeaving);
    }

    [Fact]
    public void LeaveUnsatisfied_SetsCorrectStatus()//проверяет уход без покупки
    {
        // arrange
        var customer = new Customer(5, RequestType.SpecificBook, "1984", "Orwell", null, 400);
        // act
        customer.LeaveUnsatisfied();
        // assert
        Assert.False(customer.IsServed);
        Assert.True(customer.IsLeaving);
    }

    [Fact]
    public void CheckBook_ReturnsFalse_IfBookIsNull()//передает null вместо реальной книги
    {
        // arrange
        var customer = new Customer(6, RequestType.Genre, null, null, "Horror", 200);
        // act
        bool result = customer.CheckBook(null);
        // assert
        Assert.False(result);
    }
}
