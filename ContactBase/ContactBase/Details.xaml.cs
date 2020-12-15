using ContactBase.Models;
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
    public partial class Details : ContentPage
    {
        public Details(Contact contact)
        {
            if(contact==null)
                throw new ArgumentNullException();
            BindingContext = contact;
            InitializeComponent();
        }
    }
}