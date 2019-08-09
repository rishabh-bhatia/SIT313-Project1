using System;
namespace NoteApp
{
    public class NoteInfo
    {
        public string Filename { get; set; }//to save the data
        public string noteId { get; set; }//save note ID
        public string noteData { get; set; }//save note data

        public NoteInfo()
        {
        }

        public override string ToString()
        {
            return noteId + " " + noteData;
        }
    }
}
