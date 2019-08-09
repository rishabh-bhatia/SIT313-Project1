using System;
using System.Collections.Generic;
using System.IO;
using Xamarin.Forms;

namespace NoteApp
{
    public partial class ShowNotes : ContentPage
    {
        public ShowNotes()
        {
            InitializeComponent();
        }

        protected override void OnAppearing() //load the data in listview

        {

            base.OnAppearing();

            List<NoteInfo> allInfo = new List<NoteInfo>();//this will be the data source for list view

            var files = Directory.EnumerateFiles(App.FolderPath, "*.Info.txt");//get files for all notes
            foreach (var filename in files)
            {

                NoteInfo note = new NoteInfo(); //get each noteInfo object
                note.Filename = filename;
                string str = File.ReadAllText(filename);// read the information
                string[] splitStr = str.Split(' ');//tokenize the data
                note.noteId = splitStr[0];

                //generate the allinfo string for listview

                note.noteData = note.noteId;
                allInfo.Add(note);
            }

            listView.ItemsSource = allInfo.ToArray(); //specify the data source

        }

        async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)

        {

            if (e.SelectedItem != null)

            {
                //if(e.SelectedItem != )

                NoteInfo s = e.SelectedItem as NoteInfo;

                //now split the data to fill out the NoteInfo object

                string[] str = s.noteData.Split(' ');
                s.noteId = str[0];

                await Navigation.PushAsync(new EditNote

                {

                    BindingContext = s //specify the binding context

                });

            }

        }

      
    }
}
