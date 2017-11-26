
using CrossBackEnd.CrossPlatform.Abstractions.Controllers;
using CrossBackEnd.CrossPlatform.Abstractions.Navigation;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace CrossBackEnd.CrossPlatform.Core.Controllers
{
    public class BaseController : IBaseController
    {
        private string title;
        private string icon;
        private bool isBusy;
        public INavigationService Navigation { get; private set; }
        public event PropertyChangedEventHandler PropertyChanged;

        #region Gets and Sets

        public bool IsBusy
        {
            get { return isBusy; }
            set { SetProperty(ref isBusy, value); }
        }

        public string Icon
        {
            get { return icon; }
            set { SetProperty(ref icon, value); }
        }

        public string Title
        {
            get { return title; }
            set { SetProperty(ref title, value); }
        }
        
        #endregion

        public BaseController()
        {

        }
        /*
        public BaseController(INavigationService navigationService) : base()
        { this.Navigation = navigationService; }
        */

        public bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(storage, value))
                return false;

            storage = value;
            //this.PropertyChanged?.Invoke()

            return true;
        }
    }
}