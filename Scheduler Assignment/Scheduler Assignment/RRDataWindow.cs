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
    public partial class RRDataWindow : Form
    {
        private int processesNumber;
        private int insertedNumber = 0;
        private MainWindow mainWindow;
        private List<Process> processList = new List<Process>();

        public RRDataWindow(int number, MainWindow main)
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
            int arrivalTime = int.Parse(richTextBox1.Text);
            int burstTime = int.Parse(richTextBox2.Text);
            insertedNumber++;
            if (insertedNumber == processesNumber) {
                insertButton.Enabled = false;
                richTextBox3.Enabled = true;
            }
            Process p = new Process(arrivalTime, burstTime);
            processList.Add(p);
            string[] row = {p.name, p.arrivalTime.ToString(), p.burstTime.ToString()};
            dataGridView1.Rows.Add(row);
        }

        private void backButton_Click_1(object sender, EventArgs e)
        {
            mainWindow.Show();
            this.Close();
        }
    }
}
