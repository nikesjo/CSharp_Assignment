using Addressbook.Views;

namespace Addressbook
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(AddContactPage), typeof(AddContactPage));
            Routing.RegisterRoute(nameof(ContactListPage), typeof(ContactListPage));
            Routing.RegisterRoute(nameof(ContactDetailsPage), typeof(ContactDetailsPage));
            Routing.RegisterRoute(nameof(RemoveContactPage), typeof(RemoveContactPage));
            Routing.RegisterRoute(nameof(UpdateContactPage), typeof(UpdateContactPage));
        }
    }
}
