using ContactBase.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ContactBase
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EntryForm : ContentPage
    {
        public  SQLiteAsyncConnection _connection;
        public EntryForm()
        {
            InitializeComponent();
            _connection = DependencyService.Get<ISQLiteDb>().GetConnection();
        }

         void Button_Clicked(object sender, System.EventArgs e)
        {
            var contactToAdd = new Contact();
            contactToAdd.Name = namecell.Text;
            contactToAdd.PhoneNr = phonecell.Text;
            contactToAdd.Email = emailcell.Text;
            contactToAdd.AditionalInfo = additionlcell.Text;
            _connection.InsertAsync(contactToAdd);
            Navigation.PopAsync();
        }

    }
}