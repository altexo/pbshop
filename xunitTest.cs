using Xunit;
using System;
using pbshop_web.Controllers;
using pbshop_web.Models;
using Microsoft.AspNetCore.Mvc;
using Xunit.Abstractions;

public class xunitTest{

    private readonly ITestOutputHelper _testOutputHelper;

    [Theory]
    [InlineData("alecs")]
    [InlineData("alecs@gmail.com")]
    [InlineData("alecs@...")]
    public void validateClientEmail(string email)
    {
        //Arrange
        var clients = new ClientController();
        //Act
        var validate = clients.validateEmail(email);
        //Assert
        Assert.True(validate);
    }
    //Prueba que verifique email
    [Fact]
    public void MustCreateAnEmployee(){
        //Arrange
        var emp = new CreateEmployeeModel();
        emp.name = "Rene";
        emp.lastName = "Perez";
        emp.phone = "6673292929";
        var employee = new EmployeesController();
        
        //Act
        var result = employee.Create(emp);


        Assert.NotNull(result);

    }

    // public void debeCrearUnNuevoCliente(){

    // }

}