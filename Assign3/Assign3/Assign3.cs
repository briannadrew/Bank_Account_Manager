/* Author: Brianna Drew
Description: This is a program that helps to balance the user's bank account.

Data Dictionary (Variables):
 * transType: char variable that holds what action the user wants to perform (by first letter of either withdrawal, deposit, print, or quit).
 * amount: double variable that holds the amount of money for either withdrawal or deposit the user enters.
 * balance: double variable that holds the total balance of the user's bank account.
 * bonus: double variable used in the Deposit() method to hold the calculated bonus to be added to the deposit if the amount to deposit is greater than $2,000.00 */

using System;
public static class Assign3
{
    public static void Main()
    {
        // defining variables and their data types.
        char transType;
        double amount, balance = 0;

        // introduction to the program.
        Console.WriteLine("Welcome to the Bank Account Manager.");

        do
        {
            // prompt the user to enter the transaction type.
            Console.WriteLine(" ");
            Console.Write("What do you wish to do? Enter W for withdrawal, D for deposit, P for print, or Q to quit. ");
            transType = (Convert.ToChar(Console.ReadLine()));

            switch (transType)
            {
                // if the user chooses to make a withdrawal:
                case'W': case'w':
                    // call the method to get the amount to withdraw, and then call the method to actually perform the withdrawal.
                    amount = GetAmount();
                    Withdrawal(amount, ref balance);
                    break; // exit loop.
                // if the user chooses to make a deposit:
                case'D': case'd':
                    // call the method to get the amount to deposit, and then call the method to actually perform the deposit.
                    amount = GetAmount();
                    Deposit(amount, ref balance);
                    break; // exit loop.
                // if the user chooses to see what their account balance is:
                case'P': case'p':
                    // call the method to output the account balance.
                    Print(balance);
                    break; // exit loop.
                // if the user chooses to quit the program:
                case'Q': case 'q':
                    break; // exit loop.
                // if the enter an invalid transaction type:
                default:
                    // error message.
                    Console.WriteLine(" ");
                    Console.WriteLine("Invalid entry. Please try again.");
                    break; // exit loop.
            }
        }while (transType != 'Q' && transType != 'q'); // stay in the do while loop while the user does not enter 'Q' or 'q' for the transaction type.

        Console.ReadLine();
    }

    // Method: GetAmount
    // Parameters
    //      none
    // Returns: double storing user inputted amount to either withdraw or deposit
    public static double GetAmount()
    {
        double amount;
        do
        {
            // prompt the user to enter an amount to withdraw or deposit.
            Console.WriteLine(" ");
            Console.Write("Enter the amount you wish to withdraw/deposit: ");
            amount = Convert.ToDouble(Console.ReadLine());
        } while (amount < 0.0); // stay in the do while loop if the user were to enter a negative amount (validates input).
        return amount;
    }

    // Method: Withdrawal
    // Parameters
    //      amount: double storing user inputted amount to either withdraw or deposit
    //      balance: double storing the balance of user's bank account
    // Returns: void
    public static void Withdrawal(double amount, ref double balance)
    {
        // add service fee to amount to be withdrawn.
        amount += 1.50;

        // if performing the withdrawal would produce a negative balance.
        if ((balance - amount) < 0.00)
        {
            // error message.
            Console.WriteLine(" ");
            Console.WriteLine("Insufficient balance to perform this amount of withdrawal.");
        }
        else
        {
            // withdraw the amount from the account balance.
            balance -= amount;

            // output a confirmation message.
            Console.WriteLine(" ");
            Console.WriteLine("Withdrawal of {0:C} completed successfully.", amount);
        }
    }

    // Method: Deposit
    // Parameters
    //      amount: double storing user inputted amount to either withdraw or deposit
    //      balance: double storing the balance of user's bank account
    // Returns: void
    public static void Deposit(double amount, ref double balance)
    {
        // define variable and data type.
        double bonus;

        // if the amount to be deposited into the account is $2,000.00 or more:
        if (amount >= 2000.00)
        {
            // calculate the bonus to be applied, add it to the amount to be deposited, add the amount to the total balance of the bank account.
            bonus = amount * 0.01;
            amount += bonus;
            balance += amount;
        }
        else
        {
            // add the amount to be deposited to the total balance of the bank account.
            balance += amount;
        }

        // output a confirmation message.
        Console.WriteLine(" ");
        Console.WriteLine("Deposit of {0:C} completed successfully.", amount);
    }

    // Method: Print
    // Parameters
    //      balance: double storing the balance of user's bank account
    // Returns: void
    public static void Print(double balance)
    {
        // print out the account balance.
        Console.WriteLine(" ");
        Console.WriteLine("Account Balance: {0:C}", balance);
    }
}
