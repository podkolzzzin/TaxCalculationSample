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
    if (citizen.State == "Taxes")
      return citizen.Income * 0.17;
    else if (citizen.State == "California")
      return citizen.Income * 0.32;
    else if (citizen.State == "Alaska")
      return citizen.Income * 0.15;
    else if (citizen.State == "Arizona")
      return citizen.Income < 30000 ? 0 : citizen.Income * 0.22;
    else if (citizen.State == "Pennsylvania")
    {
      if (citizen.Age < 31)
        return citizen.Income * 0.22 * 0.95;
      else if (citizen.Age > 76 && citizen.Income < 40000)
        return citizen.Income * 0.22 * 0.93;
      else
        return citizen.Income * 0.22;
    }
    else if (citizen.State == "Montana")
    {
      if (citizen.Income <= 100000)
        return citizen.Income * 0.22;
      else if (citizen.Income > 100000 && citizen.Income <= 230000)
        return citizen.Income * 0.25;
      else if (citizen.Income > 230000 && citizen.Income <= 720000)
        return citizen.Income * 0.37;
      else
        return citizen.Income * 0.54;
    }
    return citizen.Income * 0.22;
  }
}