using Xunit;
using System;
using pbshop_web.Controllers;
using pbshop_web.Models;
using Microsoft.AspNetCore.Mvc;
using Xunit.Abstractions;

public class xunitTest{

    // private readonly ITestOutputHelper _testOutputHelper;

    [Theory]
    [InlineData("alecs")]
    [InlineData("@gmail.com")]
    [InlineData("alecs@...")]
    public void ExpectedFalseValidationClientEmail(string email)
    {
        //Arrange
        var clients = new ClientController();
        //Act
        var validate = clients.validateEmail(email);
        //Assert
        Assert.False(validate);
    }

    [Theory]
    [InlineData("mas@hotmail.com")]
    [InlineData("alecs@gmail.com")]
    [InlineData("jejeje@live.com.mx")]
    public void ExpectedTrueValidationClientEmail(string email)
    {
        //Arrange
        var clients = new ClientController();
        //Act
        var validate = clients.validateEmail(email);
        //Assert
        Assert.True(validate);
    }



    //Prueba que verifique employee phone
    [Theory]
    [InlineData("5526182831")]
    [InlineData("6671342617")]
    public void ExpectedNotUniqueEmployeePhoneNumber(string phone){
        //Arrange
        var employee = new EmployeesController();

        //Act
        var result = employee.verifyEmployeeUniquePhone(phone);

        //Assert
        Assert.False(result);
        
    }
    [Theory]
    [InlineData("5561161616")]
    [InlineData("6674129510")]
    public void ExpectedUniqueEmployeePhoneNumber(string phone){
        //Arrange
        var employee = new EmployeesController();

        //Act
        var result = employee.verifyEmployeeUniquePhone(phone);

        //Assert
        Assert.True(result);
        //Assert.Same(phone, result);
    }




}