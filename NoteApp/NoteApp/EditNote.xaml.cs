using System;
using System.Collections.Generic;
using System.IO;
//using Java.Lang;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NoteApp
{
    public partial class EditNote : ContentPage
    {
        string _fileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Info.txt");
        public EditNote()
        {
            InitializeComponent();
        }

                //get the binding context.
        async void buttonPressed(object sender, EventArgs e)
        {
            var noteInfo = (NoteInfo)BindingContext;

            if (string.IsNullOrWhiteSpace(noteInfo.Filename))//if it is a new note

            {

                var fileName = Path.Combine(App.FolderPath, $"{Path.GetRandomFileName()}.Info.txt"); //create a new file for new note
                noteInfo.Filename = fileName; //save the file path
                File.WriteAllText(fileName, noteInfo.ToString()); //write information
                DependencyService.Get<Toast>().Show("On back pressed if!");
            }

            else //if we are updating note info
            {

                File.WriteAllText(noteInfo.Filename, noteInfo.ToString());

            }
            DependencyService.Get<Toast>().Show("Saved!");//To display toast notification
            await Navigation.PopAsync();
        }

        /*protected override bool OnBackButtonPressed()//object sender, EventArgs e)
        {
            if (OnBackButtonPressed())
            {
                buttonpressed();
                return false;
            }
            return false;
        }*/



        

        async void onDelete(object sender, EventArgs e)

        {

            var noteInfo = (NoteInfo)BindingContext; //get the binding context
            if (File.Exists(noteInfo.Filename)) //check if data exists
            {

                File.Delete(noteInfo.Filename); //delete file
                DependencyService.Get<Toast>().Show(" Delete pressed");

            }
            DependencyService.Get<Toast>().Show(" Deleted!");//To display toast notification
            await Navigation.PopAsync();
            //DependencyService.Get<Toast>().Show(" Delete pressed");
        }
    }
}