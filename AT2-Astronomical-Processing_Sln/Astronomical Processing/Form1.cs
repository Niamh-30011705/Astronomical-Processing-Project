// Niamh Cavanagh, Application Development Team, Sprint One
// Date: 29 March 2025
// Version: 1.2
// Astronomical Processing
// A Forms based program to demonstrate the Binary Search and Bubble Sort.

// Inputs
// Random Numbers (buttonGetData_Click): Generates random integers between 10 and 90 and fills the array.
// User Inputs:
// TextBox (inputSearch): Used to input the search term for the binary search (buttonSearch_Click).
//                        The user inputs an integer to be searched in the array.
// TextBox (inputEdit): Used to input a new value to replace an existing value in the array (buttonEdit_Click).
//                      The user edits an array element.
// ListBox (listBoxDisplay): The user selects an entry from the list to edit or view its value (listBoxDisplay_Click).
// Processes
// Data Initialization (buttonGetData_Click): Fills the array with random integers between 10 and 90 using rand.Next(10, 91).
// Display Data (DisplayArray): Clears the ListBox (listBoxDisplay) and displays the current values of the array.
// Sorting (buttonSort_Click): Implements a Bubble Sort alorithm to sort the array is ascending order. It
//                             repeatedly compares adjacent elements and swaps them if they are out of
//                             order. After each pass, the list is partially sorted.
// Searching (buttonSearch_Click): Performs a binary search to find a target value (inputSearch.Text). It compares
//                                 the value with the middle of the array and keeps dividing the array into two
//                                 halves until the target is found or the range is exhausted.
// Editing Data:
// ListBox (listBoxDisplay_Click): When an item in the List Box is clicked, it displays the selected item in the
//                                 inputEdit textbox for editing.
// Edit Button (buttonEdit_Click): Updates the selected entry in the array with a new value entered in inputEdit.
//                                 The array is then re-displayed.
// Closing the Program (buttonQuit_Click): Closes the application when the "Quit" button is clicked.
// Outputs
    // Display of Array (DisplayArray): Updates the ListBox (listBoxDisplay) to show the current contents of the array
    //                                  whenever it is called.
    // Messages: Success or error messages are shown in the message box
    //           (e.g., "Bubble Sort Complete", "Search Successful", "Data updated successfully", etc.).
    // ListBox Selection: When an item in the ListBox is clicked (listBoxDisplay_Click), the corresponding value is displayed
    //                    in the inputEdit TextBox.
    // Search Results: The binary search results are shown in the messageBox. If the target is found, the message says
    //                 "Search Successful" along with the index. If not found, it displays "Search item not Found".
    // Edit Results: When the data is successfully edited, the ListBox is refreshed with the updated value, and the message
    //               "Data updated successfully!" is shown.
    // Application Termination: The program closes when buttonQuit_Click is triggered.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Astronomical_Processing
{
    public partial class Form1: System.Windows.Forms.Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // Global Variables
        // Declare number of data entries to be created
        static int arraySize = 24;
        // Array of random integers
        int[] myArray = new int[arraySize];
        // Create a random number
        Random rand = new Random();

        // Method to display array (called in multiple other methods)
        private void DisplayArray()
        {
            // Display array in ListBox
            // Clear ListBox for new data
            listBoxDisplay.Items.Clear();
            for (int i = 0; i < arraySize; i++)
            {
                listBoxDisplay.Items.Add(myArray[i]);
            }
        }

        // Method for Get Data on button click
        private void buttonGetData_Click(object sender, EventArgs e)
        {
            // Fill array with random numbers
            for (int i = 0; i < arraySize; i++)
            {
                // Random number from 20 to 90
                myArray[i] = rand.Next(10, 91); // 91 is exclusive, so this gives a range from 10 to 90
            }
            DisplayArray();
        }

        // Method to perform Bubble Sort on button click
        private void buttonSort_Click(object sender, EventArgs e)
        {
            int numLength = arraySize;
            bool flag = true;
            for (int i = 1; (i <= (numLength - 1)) && flag; i++)
            {
                flag = false;
                for (int j = 0; j < (numLength - 1); j++)
                {
                    Application.DoEvents();
                    Thread.Sleep(10);
                    DisplayArray();
                    if (myArray[j + 1] < myArray[j])
                    {
                        int temp = myArray[j];
                        myArray[j] = myArray[j + 1];
                        myArray[j + 1] = temp;
                        flag = true;
                    }
                }
            }
            // Display success message to user
            messageBox.Text = "Bubble Sort Complete";
        }

        // Method to perform Binary Search on button click
        private void buttonSearch_Click(object sender, EventArgs e)
        {
            int min = 0;
            int max = arraySize - 1;
            // Catch error for non integer input
            if (!(Int32.TryParse(inputSearch.Text, out int target)))
            {
                // Display error message to user
                messageBox.Text = "Input is invalid or textbox is empty. Please enter an integer before searching.";
                return;
            }
            // Binary Search
            while (min <= max)
            {
                int mid = (min + max) / 2;
                if (target == myArray[mid])
                {
                    // Display success message to user
                    messageBox.Text = "Search Successful: " + target + " Found at index " + mid;
                    inputSearch.Clear();
                    inputSearch.Focus();
                    return;
                }
                else if (myArray[mid] >= target)
                {
                    max = mid - 1;
                }
                else
                {
                    min = mid + 1;
                }
            }
            // Display error message to user
            messageBox.Text = "Search item not Found, please try again.";
            inputSearch.Clear();
            inputSearch.Focus();
        }

        // Method to Select an entry for editing in the listbox
        private void listBoxDisplay_Click(object sender, EventArgs e)
        {
            // Check if the user has selected an item from the ListBox
            if (listBoxDisplay.SelectedIndex != -1)
            {
                // Select a record in the Listbox
                string curItem = listBoxDisplay.SelectedItem.ToString();
                // Directly use the selected index to display the item in the textbox
                inputEdit.Text = myArray[listBoxDisplay.SelectedIndex].ToString();
            }
            else
            {
                // Display error message to user
                messageBox.Text = "Please select a record from the List Box";
            }
        }

        // Method to Edit selected data in listbox on button click
        private void buttonEdit_Click(object sender, EventArgs e)
        {
            // Check if the user has selected an item from the ListBox
            if (listBoxDisplay.SelectedIndex != -1)
            {
                // Try to parse the input from the text box to an integer
                if (Int32.TryParse(inputEdit.Text, out int newValue))
                {
                    // Get the index of the selected item
                    int selectedIndex = listBoxDisplay.SelectedIndex;
                    // Update the array with the new value at the selected index
                    myArray[selectedIndex] = newValue;
                    // Refresh the ListBox to reflect the changes
                    DisplayArray();
                    // Display success message to user
                    messageBox.Text = "Data updated successfully!";
                }
                else
                {
                    // Display error message to user if the input is not a valid integer
                    messageBox.Text = "Please enter a valid integer.";
                }
                // Clear Edit Textbox for new data
                inputEdit.Clear();
                inputEdit.Focus();
            }
            else
            {
                // Display error message to user if no item is selected
                messageBox.Text = "Please select a record from the List Box to edit.";
            }
            // Clear Edit Textbox for new data
            inputEdit.Clear();
            inputEdit.Focus();
        }

        // Method to Quit and close the program on button click
        private void buttonQuit_Click(object sender, EventArgs e)
        {
            // This closes the current form
            this.Close();
        }
    } // end Form1
} // end namespace
