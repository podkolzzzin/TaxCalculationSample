namespace TaxCalculationSample.UnitTests;

    // Tax Rules:
    //     - In Taxes there is 17% tax for income
    //     - In California there is 32% tax for income
    //     - In Alaska there is 15% tax for income
    //     - There is 22% tax for all user states
    //     - In Arizona there income that is less than 30k USD per year is free from all taxes
    //     - In Pennsylvania you have 5% tax discount if you are younger than 31 and (7% tax discount if you are older than 76 and your total income is less than 40k)
    //     - In Montana there is a progressive tax scale:
    //         - 22% for all incomes less than or equal 100k
    //         - 25% for all incomes which are higher than 100k and less than 230k
    //         - 37% for all incomes which are higher than 230k and less than 720k
    //         - 54% for all incomes which are higher than 720k 
    //    - In Delaware there is a tax discount 10% for all incomes which are less than 60k

    // Test Cases:
    // Taxes, 100k, 17k
    // California, 100k, 32k
    // Alaska, 100k, 15k
    // Arizona, 100k, 22k
    // Arizona, 20k, 0
    // Utah, 100k, 22k
    // Pennsylvania, 100k, 22k, 40 years old
    // Pennsylvania, 100k, 18k, 25 years old
    // Pennsylvania, 40k, 6k, 80 years old
    // Montana, 100k, 22k
    // Montana, 200k, 50k
    // Montana, 500k, 185k
    // Montana, 1M, 540k


public class TaxCalculatorTests
{
  [Theory]
  [InlineData("Taxes", 100000, 17000)]
  [InlineData("California", 100000, 32000)]
  [InlineData("Alaska", 100000, 15000)]
  [InlineData("Arizona", 100000, 22000)]
  [InlineData("Arizona", 20000, 0)]
  [InlineData("Utah", 100000, 22000)]
  [InlineData("Pennsylvania", 100000, 22000, 40)]
  [InlineData("Pennsylvania", 100000, 20900, 25)]
  [InlineData("Pennsylvania", 40000, 8800, 80)]
  [InlineData("Montana", 100000, 22000)]
  [InlineData("Montana", 200000, 50000)]
  [InlineData("Montana", 500000, 185000)]
  [InlineData("Montana", 1000000, 540000)]
  [InlineData("Delaware", 100000, 22000)]
  [InlineData("Delaware", 50000, 9900)]
  [InlineData("Maryland", 100_000, 40_001)]
  public void When_TheStateAndIncomeSet_CalculateTax_Succeed(string state, int income, int expectedTax, int age = 0)
  {
    // Arrange
    var taxCalculator = new TaxCalculator();

    // Act
    var actualTax = taxCalculator.CalculateTax(new Citizen(state, income, age));

    // Assert
    Assert.Equal(expectedTax, actualTax);
  }
}