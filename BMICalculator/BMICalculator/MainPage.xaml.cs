﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.IO;

namespace BMICalculator
{
    public partial class MainPage : ContentPage
    {
        FirebaseHelper firebaseHelper = new FirebaseHelper();
        //string fileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "BMIRecord.txt");
        public MainPage()
        {
            InitializeComponent();
        }

        void OnCalculateBMI(object sender, EventArgs e)
        {
            var weight = 0.0;
            var height = 0.0;
            var bmiresult = 0.0;

            if ((Double.TryParse(inputWeight.Text, out weight)) && (Double.TryParse(inputHeight.Text, out height)))
            {
                bmiresult = weight / (height * height);
                outputResult.Text = string.Format("{0:##.00}", bmiresult);

            }
            else
            {
                outputResult.Text = "Please enter a valid value";
            }

            if (bmiresult < 18.5)
            {
                outputBmiStatus.Text = "Underweight";
                outputBmiStatus.BackgroundColor = Color.Yellow;
            }
            else if ((bmiresult >= 18.5) && (bmiresult < 25))
            {
                outputBmiStatus.Text = "Normal";
                outputBmiStatus.BackgroundColor = Color.White;
            }
            else if ((bmiresult >= 18.5) && (bmiresult < 30))
            {
                outputBmiStatus.Text = "Overweight";
                outputBmiStatus.BackgroundColor = Color.White;
            }
            else
            {
                outputBmiStatus.Text = "Obese";
                outputBmiStatus.BackgroundColor = Color.White;
            }







        }

        void OnReset(object sender, EventArgs e)
        {
            inputWeight.Text = null;
            inputHeight.Text = null;
            outputResult.Text = "0.00";

            outputBmiStatus.Text = "Not Available";
            outputBmiStatus.BackgroundColor = Color.Transparent;
            outputBmiStatus.TextColor = default;

        }

        void onDatePickerSelected(object sender, DateChangedEventArgs e)
        {
            var selectedDate = e.NewDate.ToString();
        }

        async void OnSaveRecord(object sender, EventArgs e)
        {
            /*var writerRecord = selectDate.Date.ToString("dd/MM/yyyy") +
                "\nWeight: " + inputWeight.Text + "kg" +
                "\nBMI Value: " + outputResult.Text +
                "\nBMI Status: " + outputBmiStatus.Text +
                "\n";
            File.AppendAllText(fileName, writerRecord + Environment.NewLine);*/

            var selectdate = selectDate.Date.ToString("dd/MM/yyyy");
            var weight = Double.Parse(inputWeight.Text);
            var bmiresult = Double.Parse(outputResult.Text);
            string bmistatus = outputBmiStatus.Text;
            await firebaseHelper.AddRecord(selectdate, weight, bmiresult, bmistatus);

            await DisplayAlert("Record Saved", "BMI Record has been saved", "OK");


        }




    }
}
