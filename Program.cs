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

    public String getNum()
    {
        return cardNum;
    }

    public int getPin()
    {
        return pin;
    }

    public string getFirstName()
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

    public void setNum(string newCardNum)
    {
        cardNum = newCardNum;
    }

    public void setPin(int newPin)
    {
        pin = newPin;
    }

    public void setFirstName(string newFirstName)
    {
        firstName = newFirstName;
    }

    public void setLastName(string newLastName)
    {
        lastName = newLastName;
    }
    public void setBalance(double newBalance)
    {
        balance = newBalance;
    }

    public static void Main(String[] args)
    {
        void printOptions()
        {
            Console.WriteLine("Please choose one of the options...");
            Console.WriteLine("1. Deposi t");
            Console.WriteLine("2. Withdraw");
            Console.WriteLine("3. Show Balance");
            Console.WriteLine("4. Exit");
        } 
        
        void deposit(cardHolder currentUser)
        {
            Console.WriteLine("How much would you like to deposit? ");
            double deposit = Double.Parse(Console.ReadLine());
            currentUser.setBalance(currentUser.getBalance() + deposit);
            Console.WriteLine("Thank you for $$. Your ne balance is : " + currentUser.getBalance());
            
        }
        
        void withdraw(cardHolder currentUser)
        {
            Console.WriteLine("How much would you like to take out: ");
            double withdrawal = Double.Parse(Console.ReadLine());
            //check if user has enough money
            if(currentUser.getBalance() < withdrawal)
            {
                Console.WriteLine("Insufficient balance :(");

            }
            else
            {
                
                currentUser.setBalance(currentUser.getBalance() - withdrawal);
                Console.WriteLine("Your new balance is :" + currentUser.getBalance());
                Console.WriteLine("You're good to go! Thank You :)");

            }   

        }
        void Balance(cardHolder currenUser)
        {
            Console.WriteLine("Current balance: " + currenUser.getBalance());
        }

        List<cardHolder> cardHolders = new List<cardHolder>();
        cardHolders.Add(new cardHolder("12345678910", 1234, "John", "Griffith", 150.31));
        cardHolders.Add(new cardHolder("12775678910", 1734, "Ashley", "Jones", 250.31));
        cardHolders.Add(new cardHolder("12348888910", 1294, "Frida", "Dickerson", 130.31));
        cardHolders.Add(new cardHolder("12396778910", 1834, "Muneeb", "Harding", 110.31));
        cardHolders.Add(new cardHolder("12245678910", 1284, "Dawn", "Smith", 189.31));

        //Prompt user
        Console.WriteLine("Welcome to SimpleATM");
        Console.WriteLine("Please insert your debit card: ");
        String debitCardNum = "";
        cardHolder currentUser;

        while(true)
        {
            try
            {
                debitCardNum = Console.ReadLine();
                //check agains our db
                currentUser = cardHolders.FirstOrDefault(a => a.cardNum == debitCardNum);
                if (currentUser != null) { break; }
                else { Console.WriteLine("Card not recognized. Please try again"); }

            }
            catch { Console.WriteLine("Card not recognized. Please try again"); }
        }

        Console.WriteLine("Please enter your pin: ");
        int userPin = 0;
        while (true)
        {
            try
            {
                userPin = int.Parse(Console.ReadLine());
                //check agains our db
                if (currentUser.getPin() == userPin) { break; }
                else { Console.WriteLine("Incorrect pin. Please try again"); }

            }
            catch { Console.WriteLine("Incorrect pin. Please try again"); }
        }
        Console.WriteLine("Welcome " + currentUser.getFirstName() + " :) ");
        int option = 0;
        do
        {
            printOptions();
            try
            {
                option = int.Parse(Console.ReadLine());
            }
            catch (Exception)
            {

                throw;
            }
            if(option == 1) { deposit(currentUser); }
            else if(option == 2) { withdraw(currentUser); }
            else if(option == 3) { Balance(currentUser); }
            else if(option == 4) { break; } 
            else { option = 0; }

        }
        while (option != 4);
        Console.WriteLine("Thank you! Have a nice day");
    }
    

}