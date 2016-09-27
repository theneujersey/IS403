using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresAssignment
{
    class Program
    {
        /* Group 2-1: Wooseok Lee, Johnathan Neu, Eric Pickard, Jacob Peterson
         * Professor G. Anderson, IS 403
         * 9/26/16
         * 
         * This program display a menu with four options to the user, stack, queue, dictionary, and exit.
         * For the three data structures, a user may (1) add a single item of the user's choice, (2) add
         * 2000 generically named items (after clearing the structure), (3) display the contents of the
         * structure, (4) delete a specific item from the structure, (5) clear the entire structure, (6) 
         * search the structure for a specific item, (7) count the number of items in the structure, or
         * (8) exit to the main menu.
         * */
        
        static void Main(string[] args)
        {
            
            //create stopwatch called sw
            System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
            int iAnswer = 0;
            int userInput = 0;
            Boolean bError = false;
            Boolean bStop = false;

            //allows return to main menu after exiting sub menu
            while (iAnswer != 4)
            {
                
                //allows menu to be seen once and then forces user input to be an integer 1-4
                do
                {
                    
                    //displays menu
                    Console.WriteLine("\nPlease enter an integer 1-4.");
                    Console.WriteLine("1. Stack\n2. Queue\n3. Dictionary\n4. Exit\n");

                    //exception handling in case user inputs string instead of int
                    Boolean bException = false;
                    while (bException == false)
                    {
                        try
                        {
                            string sAnswer = Console.ReadLine();
                            iAnswer = Convert.ToInt32(sAnswer);
                            bException = true;
                        }
                        catch
                        {
                            Console.WriteLine("\nPlease enter an integer 1-4.");
                            Console.WriteLine("1. Stack\n2. Queue\n3. Dictionary\n4. Exit\n");
                        }
                    }
                } while (iAnswer < 1 || iAnswer > 4);

                switch (iAnswer)
                {
                    case 1:
                        Console.WriteLine("\nStack");
                        
                        //Eric Pickard
                        //9/27/16
                        //create stack and instantiate variables
                        Stack<string> myStack = new Stack<string>();

                        //dowhile loop to until user enters 8 to return to main menu
                        do
                        {
                            bStop = false;
                            //stack menu
                            Console.WriteLine("1. Add one item to Stack");
                            Console.WriteLine("2. Add Huge List of Items to Stack");
                            Console.WriteLine("3. Display Stack");
                            Console.WriteLine("4. Delete from Stack");
                            Console.WriteLine("5. Clear Stack");
                            Console.WriteLine("6. Search Stack");
                            Console.WriteLine("7. Count Items in Stack");
                            Console.WriteLine("8. Return to Main Menu");
                            Console.WriteLine();

                            do
                            {
                                //put error back at false
                                bError = false;

                                //try, catch
                                try
                                {
                                    //read input
                                    userInput = Convert.ToInt32(Console.ReadLine());

                                    //check for anything not 1 through 8
                                    if (userInput < 1 || userInput > 8)
                                    {
                                        throw new Exception();
                                    }
                                }
                                catch (Exception e)
                                {
                                    bError = true;
                                    Console.WriteLine("\nPlease enter a positive integer between 1 and 8.\n", e);
                                }
                            } while (bError == true);

                            //swtich statement to decided which menu item was selected
                            switch (userInput)
                            {
                                case 1: //add one item
                                    //ask user to enter string
                                    Console.WriteLine("\nPlease enter a string to be inserted into the stack: ");

                                    //enter string into stack
                                    myStack.Push(Console.ReadLine());

                                    //tell the user it was added
                                    Console.WriteLine("\nThe item was added!");
                                    break;
                                case 2: //add huge list of items
                                    //clear stack
                                    myStack.Clear();

                                    //generate 2000 items with value of "New Entry" concatinated with entry number and add to stack
                                    for (int iCount = 0; iCount < 2000; iCount++)
                                    {
                                        myStack.Push("New Entry " + (iCount + 1));
                                    }                                    
                                    
                                    //tell the user it worked
                                    Console.WriteLine("\nThe huge list was added!");
                                    break;
                                case 3:  //display
                                    //reset bError to false
                                    try
                                    {
                                        //see if there is anything in the stack
                                        if (myStack.Count == 0)
                                        {
                                            throw new Exception();
                                        }

                                        //use foreach loop to display content of stack
                                        foreach (string value in myStack)
                                        {
                                            Console.WriteLine(value);
                                        }
                                    }
                                    catch
                                    {
                                        bError = true;
                                        Console.WriteLine("\nThere is nothing in the stack.  Please insert an item into the stack before displaying contents.");
                                    }
                                    break;
                                case 4: //delete from
                                    do
                                    {
                                        //set bError to false
                                        bError = false;

                                        try
                                        {
                                            //see if anything is in the stack to delete
                                            if (myStack.Count() == 0)
                                            {
                                                throw new Exception();
                                            }

                                            //ask what user wants to delete
                                            Console.WriteLine("\nWhat item would you like to delete?: ");
                                            string sDelete = Console.ReadLine();

                                            //see if item is in stack
                                            if (myStack.Contains(sDelete))
                                            {
                                                //create bFound for dowhile loop
                                                Boolean bFound = false;

                                                //create tempStack
                                                Stack<string> tempStack = new Stack<string>();

                                                //loop to see if the top of the stack is the item that needs to be deleted
                                                do
                                                {
                                                    //check to see if top of stack is item to be deleted
                                                    if (myStack.Peek().Equals(sDelete))
                                                    {
                                                        bFound = true;
                                                    }
                                                    else
                                                    {
                                                        tempStack.Push(myStack.Pop());
                                                    }
                                                } while (bFound == false);

                                                //pop off item user requested to be deleted
                                                myStack.Pop();

                                                //create variable for tempStack count
                                                int iTempStackCount = tempStack.Count();

                                                //add back items in tempStack to myStack
                                                for (int iCount = 0; iCount < iTempStackCount; iCount++)
                                                {
                                                    myStack.Push(tempStack.Pop());
                                                }

                                                //tell user item was deleted
                                                Console.WriteLine(sDelete + " was deleted from the stack!");
                                            }
                                            else
                                            {
                                                Console.WriteLine("\n" + sDelete + " is not in the stack. If you would like to try again, type 'y' and hit Enter.  Otherwise, hit enter:  ");
                                                string sAnswer = Console.ReadLine();

                                                if (sAnswer.Equals("y"))
                                                {
                                                    bError = true;
                                                }
                                                else
                                                {
                                                    bError = false;
                                                }
                                            }
                                        }
                                        catch (Exception e)
                                        {
                                            Console.WriteLine("\nThere is nothing in the stack to delete.");
                                        }

                                    } while (bError == true);
                                    break;
                                case 5: //clear
                                    //clear myStack
                                    myStack.Clear();
                                    
                                    //tell user it worked
                                    Console.WriteLine("\nThe stack was cleared!");
                           
                                    break;
                                case 6: //search


                                    //ask what user want to search for
                                    Console.WriteLine("\nWhat do you want to search for?: ");
                                    string sUserInput = Console.ReadLine();

                                    //start stopwatch
                                    sw.Start();

                                    //search myStack
                                    Boolean bContains = myStack.Contains(sUserInput);

                                    //stop stopwatch
                                    sw.Stop();

                                    //return whether or not it was found
                                    if (bContains)
                                    {
                                        Console.WriteLine("\nThe item was found in the stack.");
                                    }
                                    else
                                    {
                                        Console.WriteLine("\nThe item was not found in the stack.");
                                    }

                                    //return how long it took to search
                                    Console.WriteLine("The search took " + (sw.ElapsedTicks * 100) + " nanoseconds.");

                                    break;
                                case 7: //Count
                                    //write count of stack to screen
                                    if (myStack.Count() == 1)
                                    {
                                        Console.WriteLine("\nThere is 1 item in the stack");
                                    }
                                    else
                                    {
                                        Console.WriteLine("\nThere are " + myStack.Count() + " items in the stack");
                                    }

                                    break;
                                case 8: //return
                                    bStop = true;
                                    break;
                            }
                            //add blank line for readabilty when repeating menu
                            Console.WriteLine();
                        } while (bStop == false);

                        break;
                    case 2:
                        Console.WriteLine("\nQueue");
                        
                        //Wooseok Lee, 2-1, create Queue menu.
                        Queue<string> myQueue = new Queue<string>();

                        int menuChoice = 0; bool inputError; string deleteInput;
                        string searchInput; bool returnMainMenu; bool bDelete; string firstItem;

                        //do while loop for returning main menu;
                        do
                        {
                            returnMainMenu = false;

                            Console.WriteLine("1. Add one time to Queue");
                            Console.WriteLine("2. Add Huge List of Items to Queue");
                            Console.WriteLine("3. Display Queue");
                            Console.WriteLine("4. Delete from Queue");
                            Console.WriteLine("5. Clear Queue");
                            Console.WriteLine("6. Search Queue");
                            Console.WriteLine("7. Count Items in Queue");
                            Console.WriteLine("8. Return to Main Menu");
                            Console.WriteLine();

                            //do while loop for checking input error;
                            do
                            {
                                inputError = false;
                                try
                                {
                                    menuChoice = Int32.Parse(Console.ReadLine());
                                    Console.WriteLine();

                                    //This is for when user input wrong integer
                                    if (menuChoice < 1 || menuChoice > 8)
                                    {
                                        throw new Exception("You have to choose a positive integer between 1 and 8. Try again!");
                                    }
                                }

                                //This is for when user input no integer such as alphabets
                                catch (FormatException ex1)
                                {
                                    Console.WriteLine("You have to choose a positive integer between 1 and 8, not letters or characters. Try again!", ex1);
                                    inputError = true;
                                }
                                catch (Exception ex2)
                                {
                                    Console.WriteLine(ex2.Message);
                                    inputError = true;
                                }
                            } while (inputError == true);

                            //switch is used to select menu
                            switch (menuChoice)
                            {
                                //add one item in Queue
                                case 1:
                                    {
                                        Console.WriteLine("Enter a string that you want to add: ");
                                        myQueue.Enqueue(Console.ReadLine());
                                        Console.WriteLine("\nThe item was added!\n");
                                        break;
                                    }
                                //add huge list of items in Queue
                                case 2:
                                    {
                                        myQueue.Clear();
                                        for (int listCount = 1; listCount <= 2000; listCount++)
                                        {
                                            myQueue.Enqueue("New Entry " + listCount);
                                        }
                                        Console.WriteLine("A huge list of items was successfully added to the queue.\n");
                                        break;
                                    }
                                //display Queue
                                case 3:
                                    {
                                        try
                                        {
                                            //This is for when nothing is in Queue
                                            if (myQueue.Count == 0)
                                            {
                                                throw new Exception("There is nothing to display in the queue.\n");
                                            }
                                            else
                                            {
                                                //foreach loop is used to display Queue
                                                foreach (var mylist in myQueue)
                                                {
                                                    Console.WriteLine(mylist);
                                                }
                                                Console.WriteLine();
                                            }
                                        }
                                        catch (Exception ex3)
                                        {
                                            Console.WriteLine(ex3.Message);

                                        }
                                        break;
                                    }

                                //delete from Queue
                                case 4:
                                    {
                                        if (myQueue.Count == 0)
                                        {
                                            Console.WriteLine("There is nothing to delete in the queue.\n");
                                        }

                                        else
                                        {
                                            Console.WriteLine("What do you want to delete from the queue?: ");
                                            deleteInput = Console.ReadLine();

                                            try
                                            {
                                                //This is for when nothing is in Queue
                                                if (myQueue.Count == 0)
                                                {
                                                    throw new Exception("\nThere is nothing to delete in the queue.\n");
                                                }

                                                //check whether item is in Queue
                                                else if (!myQueue.Contains(deleteInput))
                                                {
                                                    throw new Exception("\nThere is no such item in the queue.\n");
                                                }
                                                else
                                                {
                                                    bDelete = false;
                                                    //firstItem representing the top of Queue before deleting
                                                    firstItem = myQueue.Peek();
                                                    //while loop is continued until deleting item from the top of Queue
                                                    while (bDelete == false)
                                                    {
                                                        //when found out the right item from the top of Queue
                                                        if (myQueue.Peek() == deleteInput)
                                                        {
                                                            myQueue.Dequeue();
                                                            Console.WriteLine("\n" + deleteInput + " was succesfully deleted.\n");
                                                            //to stop while loop
                                                            bDelete = true;
                                                        }
                                                        else
                                                        {
                                                            //Delete the item from the top of Queue and add it to the bottom
                                                            myQueue.Enqueue(myQueue.Dequeue());
                                                        }
                                                    }
                                                    //This is for correcting order after deleting the item.
                                                    while (myQueue.Peek() != firstItem && deleteInput != firstItem)
                                                    {
                                                        myQueue.Enqueue(myQueue.Dequeue());
                                                    }


                                                }
                                            }
                                            catch (Exception ex5)
                                            {
                                                Console.WriteLine(ex5.Message);

                                            }
                                        }
                                        break;
                                    }

                                //Clear Queue
                                case 5:
                                    {
                                        myQueue.Clear();
                                        Console.WriteLine("The queue was successfully cleared!\n");
                                        break;
                                    }
                                //search Queue
                                case 6:
                                    {
                                        Console.WriteLine("What do you want to search from the queue?: ");
                                        searchInput = Console.ReadLine();

                                        //start stopwatch
                                        sw.Start();

                                        //check wheter it was found or not
                                        if (myQueue.Contains(searchInput))
                                        {
                                            //stop stopwatch
                                            sw.Stop();
                                            Console.WriteLine("\n" + searchInput + " was found and it took " + sw.Elapsed + " to search.\n");
                                        }
                                        else
                                        {
                                            //stop stopwatch
                                            sw.Stop();
                                            Console.WriteLine("\n" + searchInput + " was not found and it took " + sw.Elapsed + " to search.\n");
                                        }

                                        break;
                                    }
                                case 7: //Count
                                        {
                                            if (myQueue.Count() == 1) 
                                            {
                                                Console.WriteLine("There is 1 item in the queue.\n");
                                            }
                                            else 
                                            {
                                                Console.WriteLine("There are " + myQueue.Count() + " items in the queue.\n");
                                            }
                                            break;
                                        }
                                    //return main menu
                                case 8:
                                    {
                                        returnMainMenu = true;
                                        break;
                                    }
                            }
                        } while (returnMainMenu == false);

                        break;
                    case 3:
                        Console.WriteLine("\nDictionary");
                        
                        //Jacob Peterson
                        //9/26/16
                        //create dictionary and instantiate variables

                        Dictionary<String, int> myDictionary = new Dictionary<string, int>();


                        //dowhile loop to until user enters 7 to return to main menu
                        do
                        {
                            bStop = false;
                            //Dictionary menu
                            Console.WriteLine("1. Add one item to Dictionary");
                            Console.WriteLine("2. Add Huge List of Items to Dictionary");
                            Console.WriteLine("3. Display Dictionary");
                            Console.WriteLine("4. Delete from Dictionary");
                            Console.WriteLine("5. Clear Dictionary");
                            Console.WriteLine("6. Search Dictionary");
                            Console.WriteLine("7. Count items in Dictionary");
                            Console.WriteLine("8. Return to Main Menu");
                            Console.WriteLine();

                            do
                            {
                                //put error back at false
                                bError = false;

                                //try/catch
                                try
                                {
                                    //read input
                                    userInput = Convert.ToInt32(Console.ReadLine());

                                    //check for anything not 1 through 7
                                    if (userInput < 1 || userInput > 8)
                                    {
                                        throw new Exception();
                                    }
                                }
                                catch (Exception e)
                                {
                                    bError = true;
                                    Console.WriteLine("\nPlease enter a positive integer between 1 and 8.\n", e);
                                }
                            } while (bError == true);

                            //swtich statement to decided which menu item was selected
                            switch (userInput)
                            {
                                case 1: //add one item
                                    //ask user to enter string
                                    Console.WriteLine("\nPlease enter a string to be inserted into the dictionary: ");

                                    //add to dict if not already there
                                    try
                                    {
                                        //enter string into Dictionary. If it's already there it will throw an exeption
                                        myDictionary.Add(Console.ReadLine(), 1);
                                        Console.WriteLine("\nThe item was added!");

                                    }
                                    catch
                                    {
                                        Console.WriteLine("It looks like that key is already in the dictionary. You may add another by selecting '1'.");
                                    }

                                    break;
                                case 2: //add huge list of items
                                    //clear Dictionary
                                    myDictionary.Clear();

                                    //generate 2000 items with value of "New Entry" concatinated with entry number and add to Dictionary
                                    for (int iCount = 0; iCount < 2000; iCount++)
                                    {
                                        myDictionary.Add("New Entry " + (iCount + 1),(iCount + 1));
                                    }
                                     Console.WriteLine("\nHuge list of items successfully added to dictionary!");
                                    break;
                                case 3:  //display
                                    //reset bError to false
                                    try
                                    {
                                        //see if there is anything in the Dictionary
                                        if (myDictionary.Count == 0)
                                        {
                                            throw new Exception();
                                        }

                                        Console.WriteLine("Key\tValue");
                                        //use foreach loop to display content of Dictionary
                                        foreach (KeyValuePair<String,int> entry in myDictionary)
                                        {
                                            Console.WriteLine(entry.Key + "\t" + entry.Value);
                                        }
                                    }
                                    catch
                                    {
                                        bError = true;
                                        Console.WriteLine("\nThere is nothing in the dictionary.  Please insert an item into the dictionary before displaying contents.");
                                    }
                                    break;
                                case 4: //delete from
                                    do
                                    {
                                        //set bError to false
                                        bError = false;

                                        try
                                        {
                                            //see if anything is in the Dictionary to delete
                                            if (myDictionary.Count() == 0)
                                            {
                                                throw new Exception();
                                            }

                                            //ask what user wants to delete
                                            Console.WriteLine("\nWhat item would you like to delete (input a key): ");
                                            string sDelete = Console.ReadLine();

                                            //see if item is in Dictionary
                                            if (myDictionary.ContainsKey(sDelete))
                                            {
                                               //Delete the item
                                                myDictionary.Remove(sDelete);

                                                //tell user item was deleted
                                                Console.WriteLine("\n" + sDelete + " and its value were deleted from the dictionary!");
                                            }
                                            else
                                            {
                                                Console.WriteLine("\n" + sDelete + " is not in the dictionary. If you would like to try again, type 'y' and hit Enter.  Otherwise, hit enter:  ");
                                                string sAnswer = Console.ReadLine();

                                                if (sAnswer.Equals("y"))
                                                {
                                                    bError = true;
                                                }
                                                else
                                                {
                                                    bError = false;
                                                }
                                            }
                                        }
                                        catch (Exception e)
                                        {
                                            Console.WriteLine("\nThere is nothing in the dictionary to delete");
                                        }

                                    } while (bError == true);
                                    break;
                                case 5: //clear
                                    //clear myDictionary
                                    myDictionary.Clear();
                                    Console.WriteLine("\nThe dictionary was cleared!");
                                    break;
                                case 6: //search


                                    //ask what user want to search for
                                    Console.WriteLine("\nWhat key do you want to search for?: ");
                                    string sUserInput = Console.ReadLine();

                                    //start stopwatch
                                    sw.Start();

                                    //search myDictionary
                                    Boolean bContains = myDictionary.ContainsKey(sUserInput);

                                    //stop stopwatch
                                    sw.Stop();

                                    //return whether or not it was found
                                    if (bContains)
                                    {
                                        Console.WriteLine("\nThe item was found in the dictionary. It's value is " + myDictionary[sUserInput]);
                                    }
                                    else
                                    {
                                        Console.WriteLine("\nThe item was not found in the dictionary.");
                                    }

                                    //return how long it took to search
                                    Console.WriteLine("The search took " + (sw.ElapsedTicks * 100) + " nanoseconds.");

                                    break;
                                case 7: //count stuff
                                    Console.WriteLine("\nThe dictionary contains " +  myDictionary.Count + " item(s).");
                                    break;
                                case 8: //return
                                    bStop = true;
                                    break;
                            }
                            //add blank line for readabilty when repeating menu
                            Console.WriteLine();
                        } while (bStop == false);

                        break;
                    case 4:
                        System.Environment.Exit(1);
                        break;
                    default:
                        Console.WriteLine("Please enter an integer 1-4.");
                        Console.WriteLine("1. Stack\n2. Queue\n3. Dictionary\n4. Exit");
                        break;
                }
            }
            string sEnd = Console.ReadLine();
        }
    }
}
