using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfAppGit1.Models;

namespace WpfAppGit1.ViewModels
{
    public class ShellViewModel : Conductor<object> //Screen
    {
        public ShellViewModel()
        {
            People.Add(new PersonModel { FirstName = "jason", LastName = "chen" });
            People.Add(new PersonModel { FirstName = "jason2", LastName = "chen2" });
            People.Add(new PersonModel { FirstName = "jason3", LastName = "chen3" });
        }

        //public string FirstName { get; set; } = "Jason";
        private string _firstName = "jason";

        public string FirstName
        {
            get { return _firstName; }
            set 
            { 
                _firstName = value;
                NotifyOfPropertyChange(() => FirstName);
                NotifyOfPropertyChange(() => FullName);
            }
        }

        private string _lastName = "chen";

        public string LastName
        {
            get { return _lastName; }
            set
            {
                _lastName = value;
                NotifyOfPropertyChange(() => LastName);
                NotifyOfPropertyChange(() => FullName);
            }
        }

        public string FullName { get { return $"{FirstName} {LastName}"; } }


        private BindableCollection<PersonModel> _people = new BindableCollection<PersonModel>();

        public BindableCollection<PersonModel> People
        {
            get { return _people; }
            set { _people = value; }
        }

        private PersonModel _selectedPerson;

        public PersonModel SelectedPerson
        {
            get { return _selectedPerson; }
            set
            {
                _selectedPerson = value;
                NotifyOfPropertyChange(() => SelectedPerson);
            }
        }

        public bool CanClearText(string firstName, string lastName) //=> !string.IsNullOrWhiteSpace(firstName) && !string.IsNullOrWhiteSpace(lastName);
        {
            //throw new NotImplementedException();
            return !string.IsNullOrWhiteSpace(firstName) && !string.IsNullOrWhiteSpace(lastName);
        }

        public void ClearText(string firstName, string lastName)
        {
            FirstName = "";
            LastName = "";
        }


        public void LoadPageOne()
        {
            ActivateItem(new FirstChildViewModel());
        }

        public void LoadPageTWo()
        {
            ActivateItem(new SecondChildViewModel());
        }
    }
}
