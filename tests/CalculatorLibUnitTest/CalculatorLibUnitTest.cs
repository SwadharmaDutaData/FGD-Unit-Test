using System;
using CalculatorLib;
using Xunit;

namespace CalculatorLibUnitTest
{
    public class CalculatorLibUnitTest
    {
        [Fact]
        public void Add_PositiveNumber_AreEqual()
        {
            // Arange (Given) => Set up the test, along with all variable, input, etc
            var calculator = new Calculator(); 

            int num1 = 1;
            int num2 = 2;

            // Act (When) => Executing the action
            var result = calculator.Add(num1, num2);
            
            // Assert (Then) => Verify the unit test
            Assert.Equal(3, result);
        }
        
        [Theory]
        [InlineData(1, 2, 3)]
        [InlineData(-4, -6, -10)]
        [InlineData(-2, 2, 0)]
        [InlineData(int.MinValue, -1, int.MaxValue)]
        public void AddTheory(int num1, int num2, int expected)
        {
            // Arange (Given) => Set up the test, along with all variable, input, etc
            var calculator = new Calculator(); 
            
            // Act (When) => Executing the action
            var result = calculator.Add(num1, num2);
            
            // Assert (Then) => Verify the unit test
            Assert.Equal(expected, result);
        }
    }
}
