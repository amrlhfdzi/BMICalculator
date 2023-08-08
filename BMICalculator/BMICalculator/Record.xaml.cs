using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace BMICalculator
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Record : ContentPage
    {
        //string fileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "BMIRecord.txt");
        FirebaseHelper firebaseHelper = new FirebaseHelper();
        public Record()
        {
            InitializeComponent();
            //displayRecord.Text = File.ReadAllText(fileName);
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            displayRecord.ItemsSource = await firebaseHelper.GetAllBmiRecord();
        }



    }
}