using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace P4___Temperature_Converter
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            LoadComboBoxes();
        }

        private void LoadComboBoxes()
        {
            cmbFrom.Items.AddRange(new string[] { "Celsius", "Fahrenheit", "Kelvin" });
            cmbTo.Items.AddRange(new string[] { "Celsius", "Fahrenheit", "Kelvin" });
            cmbFrom.SelectedIndex = 0;
            cmbTo.SelectedIndex = 1;
        }

        private void btnConvert_Click(object sender, EventArgs e)
        {
            double inputTemp;
            if (!double.TryParse(txtInput.Text, out inputTemp))
            {
                MessageBox.Show("Please enter a valid number!", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string fromUnit = cmbFrom.SelectedItem.ToString();
            string toUnit = cmbTo.SelectedItem.ToString();
            double result = ConvertTemperature(inputTemp, fromUnit, toUnit);

            lblResult.Text = $"Result: {result:F2} {toUnit}";

        }

        private double ConvertTemperature(double temp, string from, string to)
        {
            double tempInCelsius;

            switch (from)
            {
                case "Fahrenheit":
                    tempInCelsius = (temp - 32) * 5 / 9;
                    break;
                case "Kelvin":
                    tempInCelsius = temp - 273;
                    break;
                default: // "Celsius"
                    tempInCelsius = temp;
                    break;
            }

            switch (to)
            {
                case "Fahrenheit":
                    return (tempInCelsius * 9 / 5) + 32;
                case "Kelvin":
                    return tempInCelsius + 273;
                default: // "Celsius"
                    return tempInCelsius;
            }
        }

    }

}
