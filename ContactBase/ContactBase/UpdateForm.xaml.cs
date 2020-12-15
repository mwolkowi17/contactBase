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
    public partial class UpdateForm : ContentPage
    {
        public SQLiteAsyncConnection _connection;

        public UpdateForm(Contact contact)
        {
            if (contact == null)
                throw new ArgumentNullException();
            
            _connection = DependencyService.Get<ISQLiteDb>().GetConnection();
            BindingContext = contact;
            
            InitializeComponent();
        }

        async void Button_Clicked(object sender, System.EventArgs e)
        {
            var menuitem = sender as Button;
            var contactselected = menuitem.CommandParameter as Contact;
            contactselected.Name = namecell.Text;
            contactselected.PhoneNr = phonecell.Text;
            contactselected.AditionalInfo = additionlcell.Text;
            contactselected.Email = emailcell.Text;

            await _connection.UpdateAsync(contactselected);
            await Navigation.PopAsync();
        }
    }
}