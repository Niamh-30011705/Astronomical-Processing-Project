// Niamh Cavanagh, Application Development Team, Sprint One
// Date: 28 March 2025
// Version: 1.1
// Astronomical Processing
// A Forms based program to demonstrate the Binary Search and Bubble Sort.
// List inputs, processes, outputs

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
                myArray[i] = rand.Next(20, 91); // 91 is exclusive, so this gives a range from 20 to 90
            }
            DisplayArray();
        }

        /* Bubble Sort.
         */
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

        /* Binary Search. In this procedure, the entire list is divided into two sub-lists.
         * If the item is found in the middle possition, it returns the location.
         * Otherwise it jumps to either left or right sub-list and does the same process again until
         * either the item is found or it exceeds the range.
         */
        // Method to perform Binary Search on button click
        private void buttonSearch_Click(object sender, EventArgs e)
        {
            int min = 0;
            int max = arraySize - 1;
            // Catch error for non integer input
            if (!(Int32.TryParse(inputSearch.Text, out int target)))
            {
                // Display error message to user
                messageBox.Text = "You must enter an integer";
                return;
            }
            // Binary Search
            while (min <= max)
            {
                int mid = (min + max) / 2;
                if (target == myArray[mid])
                {
                    // Display success message to user
                    messageBox.Text = target + " Found at index " + mid;
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
            messageBox.Text = "Not Found, try again.";
            inputSearch.Clear();
            inputSearch.Focus();
        }

        // Method to Select an entry for editing in the listbox
        private void listBoxDisplay_Click(object sender, EventArgs e)
        {
            if (listBoxDisplay.SelectedIndex != -1)
            {
                // Select a record in the Listbox
                string curItem = listBoxDisplay.SelectedItem.ToString();
                // Find the index of the selected item
                int indx = listBoxDisplay.FindString(curItem);
                // Put the Listbox item into the textbox
                inputEdit.Text = myArray[indx].ToString();
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

        }

        // Method to Quit and close the program on button click
        private void buttonQuit_Click(object sender, EventArgs e)
        {
            // This closes the current form
            this.Close();
        }
    } // end Form1
} // end namespace
