﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Scheduler_Assignment
{
    public partial class BasicDataWindow : Form
    {
        private int processesNumber;
        private int insertedNumber = 0;
        private MainWindow mainWindow;
        private List<Process> processList = new List<Process>();

        public BasicDataWindow(int number, MainWindow main)
        {
            InitializeComponent();
            processesNumber = number;
            mainWindow = main;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            float arrivalTime, burstTime;
            if (!float.TryParse(richTextBox1.Text, out float result))
            {
                errorProvider1.SetError(label1, "Please enter a valid number");
            }
            else if (!float.TryParse(richTextBox2.Text, out float result2))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(label2, "Please enter a valid number");
            }
            else {
                arrivalTime = float.Parse(richTextBox1.Text);
                burstTime = float.Parse(richTextBox2.Text);
                if (arrivalTime < 0)
                {
                    errorProvider1.Clear();
                    errorProvider1.SetError(label1, "Arrival time must be nonnegative");
                }
                else if (burstTime <= 0)
                {
                    errorProvider1.Clear();
                    errorProvider1.SetError(label2, "Burst time must be positive");
                }
                else
                {
                    errorProvider1.Clear();
                    insertedNumber++;
                    if (insertedNumber == processesNumber)
                    {
                        insertButton.Enabled = false;
                        drawButton.Enabled = true;
                    }
                    Process p = new Process(arrivalTime, burstTime);
                    processList.Add(p);
                    string[] row = { p.name, p.arrivalTime.ToString(), p.burstTime.ToString() };
                    dataGridView1.Rows.Add(row);
                    richTextBox1.Clear();
                    richTextBox2.Clear();
                }
            }
            
        }

        private void backButton_Click_1(object sender, EventArgs e)
        {
            mainWindow.Show();
            this.Close();
        }
    }
}
