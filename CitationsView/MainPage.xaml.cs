﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Essentials;

namespace FIrebaseTest2
{
    public partial class MainPage : ContentPage
    {
        readonly FirebaseHelper firebaseHelper = new FirebaseHelper();
        public MainPage()
        {
            InitializeComponent();
        }

        /*
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            var person = await firebaseHelper.GetPerson(Convert.ToInt32(txtVin.Text));
            showResult.Text = person.Name;
        }
        

        public async void BtnAdd_Clicked(object sender, EventArgs e)
        {
            await firebaseHelper.AddPerson(Convert.ToInt32(txtId.Text), txtName.Text, Convert.ToInt64(txtVin.Text), txtVehicle.Text);
            txtId.Text = string.Empty;
            txtName.Text = string.Empty;
            txtVin.Text = string.Empty;
            txtVehicle.Text = string.Empty;
            await DisplayAlert("Success", "Person Added Sucessfully", "Ok");
            //var allPersons = await firebaseHelper.GetAllPersons();
            //lstPersons.ItemsSource = allPersons;
        }
        */

        private async void BtnRetrive_Clicked(object sender, EventArgs e)
        {
            var person = await firebaseHelper.GetPerson(searchLisencePlate.Text);
            if (!IsVinValid())
            {
                await DisplayAlert("Error", "Required Field Incorrect or Missing", "Ok");
                return;
            }
            else if (person != null)
            {
                personName.Text = person.Name;
                vinNumber.Text = person.LisencePlate;
                vehicleInfo.Text = person.VehicleInformation;

                //lstPerson.ItemsSource = person.Name;
                //await DisplayAlert("Sucess", "Person Retrieve Successfully", "Ok");
            }
            else
            {
                await DisplayAlert("Error", "No Person Available", "Ok");
            }
        }

        public async void OnButtonClickAddCitation(object sender, EventArgs e)
        {
            if (citationReason.SelectedItem == null)
            {
                await DisplayAlert("Error", "Required Field Incorrect or Missing", "Ok");
                return;
            }
            else
            {
                var person = await firebaseHelper.GetPerson(searchLisencePlate.Text);
                await firebaseHelper.AddCitation(vehicleInfo.Text,
                                                 searchLisencePlate.Text,
                                                 person.PersonId,
                                                 personName.Text,
                                                 citationReason.SelectedItem.ToString());

                //NAVIGATE TO PREVIOUS PAGE

                await DisplayAlert("Confirmation", "Citation Submitted", "Ok");
            }
        }

        //private bool IsFormValid() => IsVinValid() && IsReasonValid();

        private bool IsVinValid() => (searchLisencePlate.Text).Length == 7 && !string.IsNullOrWhiteSpace(searchLisencePlate.Text);


    }
}
