namespace Contacts.Models.Contact
{
    public class AllContactsQueryModel
    {
        public IEnumerable<ContactInfoViewModel> Contacts { get; set; }
            = new List<ContactInfoViewModel>();
    }
}
