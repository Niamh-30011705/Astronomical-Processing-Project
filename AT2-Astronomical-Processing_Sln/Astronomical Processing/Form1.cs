// Niamh Cavanagh, Application Development Team, Sprint One
// Date: 27 March 2025
// Version: 1.0
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
        static int maxSize = 24;
        // Array of random integers
        int[] myArray = new int[maxSize];

        // Method for Get Data on button click
        private void buttonGetData_Click(object sender, EventArgs e)
        {
            // Create a random number
            Random rand = new Random();
            // Fill array with random numbers
            for (int i = 0; i < maxSize; i++)
            {
                // Random number from 20 to 90
                myArray[i] = rand.Next(20, 91); // 91 is exclusive, so this gives a range from 20 to 90
            }

            // Display array in ListBox
            // Clear ListBox for new data
            listBoxDisplay.Items.Clear();
            for (int i = 0; i < maxSize; i++)
            {
                listBoxDisplay.Items.Add(myArray[i]);
            }
        }

        /* Bubble Sort.
         */
        // Method to perform Bubble Sort
        private void buttonSort_Click(object sender, EventArgs e)
        {

        }

        /* Binary Search. In this procedure, the entire list is divided into two sub-lists.
         * If the item is found in the middle possition, it returns the location.
         * Otherwise it jumps to either left or right sub-list and does the same process again until
         * either the item is found or it exceeds the range.
         */
        // Method to perform Binary Search
        private void buttonSearch_Click(object sender, EventArgs e)
        {

        }

        // Method to Quit and close the program
        private void buttonQuit_Click(object sender, EventArgs e)
        {
            // This closes the current form
            this.Close();
        }
    } // end Form1
} // end namespace
