namespace TaxCalculationSample;

public class Citizen
{
  public string State { get; set; }
  public int Age { get; set; }
  public int Income { get; set; }

  public Citizen(string state, int income, int age)
  {
    State = state;
    Income = income;
    Age = age;
  }
}

public class TaxCalculator
{

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
  public double CalculateTax(Citizen citizen)
  {
    return citizen.State switch
    {
      "Taxes" => citizen.Income * 0.17,
      "California" => citizen.Income * 0.32,
      "Alaska" => citizen.Income * 0.15,
      "Arizona" => citizen.Income < 30000 ? 0 : citizen.Income * 0.22,
      "Pennsylvania" when citizen.Age < 31 => citizen.Income * 0.22 * 0.95,
      "Pennsylvania" when citizen.Age > 76 && citizen.Income < 40000 => citizen.Income * 0.22 * 0.93,
      "Pennsylvania" => citizen.Income * 0.22,
      "Montana" => citizen.Income switch
      {
        <= 100000 => citizen.Income * 0.22,
        > 100000 and <= 230000 => citizen.Income * 0.25,
        > 230000 and <= 720000 => citizen.Income * 0.37,
        _ => citizen.Income * 0.54
      },
      "Delaware" when citizen.Income < 60000 => citizen.Income * 0.22 * 0.9,
      "Delaware" => citizen.Income * 0.22,
      "Maryland" => citizen.Income * 0.40,
      _ => citizen.Income * 0.22
    };
  }
}