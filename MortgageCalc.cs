using System;

class MortgageCalculator
{
    static void Main(string[] args)
    {
        double homeprice;
        double fivepercent, fifteenpercent, twentypercent, tenpercent; 
        double mortage5, mortage10, mortage15, mortage20; 
        double amortizationperiod, mortgagerate; 
        string frequency;
        char calculator;
        double downpayment;
        double mortgagerequired;

        Console.WriteLine("\t\t\t\t\tMortgage Calculator\t\t\t\t\t");
        Console.WriteLine("");
        Console.Write("Mortgage Amount: ");
        homeprice = double.Parse(Console.ReadLine());
        Console.Write("Down Payment: ");
        downpayment = double.Parse(Console.ReadLine());

        mortgagerequired = homeprice - downpayment;

        Console.WriteLine("");
        Console.WriteLine($"Mortgage Required:{mortgagerequired} ");
        Console.WriteLine("\n");
        do
        {
            Console.Write("Amortization Period (Min 5 - Max 30): ");
            amortizationperiod = double.Parse(Console.ReadLine()); 
            if (amortizationperiod < 5 || amortizationperiod > 30)
            {
                Console.WriteLine("Invalid Input, Try Again!");
            }
        }
        while (amortizationperiod < 5 || amortizationperiod > 30);

        Console.Write("Mortgage Rate: ");
        mortgagerate = double.Parse(Console.ReadLine());
        Console.WriteLine("");
        do
        {
            Console.Write("Frequency (B - Bi-weekly|M - Monthly): "); 
            frequency = Console.ReadLine();

            if (frequency == "b" || frequency == "B")
            {
                double biweeklyPaymentsPerYear = 26;
                double biweeklyInterestRate = (mortgagerate / 100) / biweeklyPaymentsPerYear;
                double biweeklyPeriods = amortizationperiod * biweeklyPaymentsPerYear;
                double biweeklyMortgageAmount = mortgagerequired; 

                double biweeklyMortgagePayment = (biweeklyMortgageAmount * biweeklyInterestRate) /
                    (1 - Math.Pow(1 + biweeklyInterestRate, -biweeklyPeriods));

                Console.WriteLine($"Total Mortgage Payment: {biweeklyMortgagePayment * biweeklyPaymentsPerYear:C}");
            }
            else if (frequency == "m" || frequency == "M")
            {
                double monthlyPaymentsPerYear = 12;
                double monthlyInterestRate = (mortgagerate / 100) / monthlyPaymentsPerYear;
                double monthlyPeriods = amortizationperiod * monthlyPaymentsPerYear;
                double monthlyMortgageAmount = mortgagerequired;

                double monthlyMortgagePayment = (monthlyMortgageAmount * monthlyInterestRate) /
                    (1 - Math.Pow(1 + monthlyInterestRate, -monthlyPeriods));

                Console.WriteLine($"Total Mortgage Payment: {monthlyMortgagePayment:C}");
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter 'B' for bi-weekly or 'M' for monthly");
            }
        }
        while (frequency != "b" && frequency != "B" && frequency != "m" && frequency != "M");
    }
}
