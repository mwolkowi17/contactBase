using ContactBase.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ContactBase
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListOfContacts : ContentPage
    {
        public SQLiteAsyncConnection _connection;
        public ObservableCollection<Contact> _contacts;

        public ListOfContacts()
        {
            InitializeComponent();
            _connection = DependencyService.Get<ISQLiteDb>().GetConnection();
        }

        protected override async void OnAppearing()
        {
            await _connection.CreateTableAsync<Contact>();
            var contacts = await _connection.Table<Contact>().ToListAsync();
            _contacts = new ObservableCollection<Contact>(contacts);
            contactListView.ItemsSource = _contacts;
            base.OnAppearing();
        }

         void OnAdd(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new EntryForm());
        }

        void Delete(object sender, System.EventArgs e)
        {

        }

       async private void contactListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
                return;
            var contactselected = e.SelectedItem as Contact;
            await Navigation.PushAsync(new Details(contactselected));
            contactListView.SelectedItem = null;
        }

       async private void MenuItem_Clicked(object sender, EventArgs e)
        {
           
            var menuitem= sender as MenuItem;

            var contactselected = menuitem.CommandParameter as Contact;
            await _connection.DeleteAsync(contactselected);
            var contacts = await _connection.Table<Contact>().ToListAsync();
            _contacts = new ObservableCollection<Contact>(contacts);


            contactListView.ItemsSource = _contacts;
        }

         private void MenuItem_Clicked_1(object sender, EventArgs e)
        {
            var menuitem = sender as MenuItem;

            var contactselected = menuitem.CommandParameter as Contact;

            Navigation.PushAsync(new UpdateForm(contactselected));

        }
    }
}