using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace NoteApp
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        //Function runs when Create note button is clicked. This button creates or saves edited note.
        async void createNote(object sender, EventArgs e)
        {

            await Navigation.PushAsync(new EditNote

            {

                BindingContext = new NoteInfo()

            });

        }

        //Funtion runs everytime delete button is clicked. This button deletes a note
        async void showNote(object sender, EventArgs e)
        {

            await Navigation.PushAsync(new ShowNotes { });

        }
    }
}
