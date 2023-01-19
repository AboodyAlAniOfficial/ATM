using System;

public class cardHolder
{
    String cardNum;
    int pin;
    String firstName;
    String lastName;
    double balance;

    public cardHolder(string cardNum, int pin, string firstName, string lastName, double balance)
    {
        this.cardNum = cardNum;
        this.pin = pin;
        this.firstName = firstName;
        this.lastName = lastName;
        this.balance = balance;
    }

    public String getCardNum()
    {
        return cardNum;
    }

    public int getPin()
    {
        return pin;
    }
    public String getFirstName()
    {
        return firstName;
    }

    public String getLastName()
    {

        return lastName;
    }

    public double getBalance()
    {
        return balance;
    }

    public void setCardNum(String cardNum)
    {
        this.cardNum = cardNum;
    }


    public void setPin(int pin)
    {
        this.pin = pin;
    }


    public void setFirstName(String firstName)
    {
        this.firstName = firstName;
    }


    public void setLastName(String lastName)
    {
        this.lastName = lastName;

    }

    public void setBalance(double balance)
    {
        this.balance = balance;
    }



    public static void Main(String[] args)
    {
        ;

        void printOptions()
        {

            Console.WriteLine("Please choose from one of the following: ");
            Console.WriteLine("1. Deposit");
            Console.WriteLine("2. Withdraw");
            Console.WriteLine("3. Show Balance");
            Console.WriteLine("4. Exit");
        }

            void deposit(cardHolder currentUser)
            {
                Console.WriteLine("How much money would you like to deposit: ");
                double deposit = double.Parse(Console.ReadLine());
                currentUser.setBalance(deposit + currentUser.balance);
                Console.WriteLine("Thank you for your deposit. YOur new balance is : $" + currentUser.getBalance());
            }

            void withdraw(cardHolder currentUser)
            {
                Console.WriteLine("How much money would you like to withdraw: ");
                double withdrawal = double.Parse(Console.ReadLine());
                //Check if user has enough money to withdraw
                if (currentUser.getBalance() < withdrawal)
                {
                    Console.WriteLine("Insufficient Balance.");

                }
                else
                {
                    currentUser.setBalance(currentUser.getBalance() - withdrawal);
                    Console.WriteLine("Thank you for you withdrawal. Your new balance is : $" + currentUser.getBalance());
                }

            }

            void balance(cardHolder currentUser)
            {
                Console.WriteLine("Current Balance: $" + currentUser.getBalance());
            }


            List<cardHolder> cardHolders = new List<cardHolder>();
            cardHolders.Add(new cardHolder("1111", 1234, "John", "Stones", 1000));
            cardHolders.Add(new cardHolder("4444", 1000, "Jane", "Stones", 1200));
            cardHolders.Add(new cardHolder("0000", 5267, "Mike", "Blokes", 1000000000));


            // Begin game
            Console.WriteLine("Welcome to ATM");
            Console.WriteLine("PLease insert your card number: ");
            String cardNum = "";
            cardHolder currentUser;

            while (true)
            {
                try
                {
                    cardNum = Console.ReadLine(); //check our database
                    currentUser = cardHolders.FirstOrDefault(a => a.cardNum == cardNum);
                    if (currentUser != null)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Card not in our system. Please try again: ");
                    }
                }
                catch
                {
                    Console.WriteLine("Card not in our system. Please try again: ");
                }

            }
            Console.WriteLine("Please enter you PIN: ");
            int userPin = 0;
            while (true)
            {
                try
                {
                    userPin = int.Parse(Console.ReadLine()); //check our database
                    currentUser = cardHolders.FirstOrDefault(a => a.cardNum == cardNum);
                    if (currentUser.getPin() == userPin)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Incorrect PIN. Please try again: ");
                    }
                }
                catch
                {
                    Console.WriteLine("Incorrect PIN. Please try again: ");
                }

            }

            Console.WriteLine("Welcome " + currentUser.getFirstName());
            int option = 0;
            do
            {
                printOptions();
                try
                {
                    option = int.Parse(Console.ReadLine());
                }
                catch { }
                if (option == 1) { deposit(currentUser); }
                else if (option == 2) { withdraw(currentUser); }
                else if (option == 3) { balance(currentUser); }
                else if (option == 4) { break; }
                else { option = 0; }
            }
            while (option != 4);
            Console.WriteLine("Thank you. Have a nice day");


        
    }
}

