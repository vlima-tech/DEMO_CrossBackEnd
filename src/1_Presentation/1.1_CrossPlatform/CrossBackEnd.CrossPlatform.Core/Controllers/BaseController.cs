
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

using CrossBackEnd.CrossPlatform.Abstractions.Controllers;
using CrossBackEnd.CrossPlatform.Abstractions.Interactions;
using CrossBackEnd.CrossPlatform.Abstractions.Navigation;

namespace CrossBackEnd.CrossPlatform.Core.Controllers
{
    public class BaseController : IBaseController
    {
        private string title;
        private string icon;
        private bool isBusy;
        private bool isNotBusy;
        
        public INavigationService Navigation { get; private set; }
        private IInteractionService _interactionService { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        #region Gets and Sets

        public bool IsBusy
        {
            get { return isBusy; }
            set
            {
                this.isNotBusy = !value;

                SetProperty(ref isBusy, value);
                OnPropertyChanged(() => IsNotBusy);
            }
        }

        public bool IsNotBusy
        {
            get { return isNotBusy; }
            set
            {
                this.isBusy = !value;

                SetProperty(ref isNotBusy, value);

                OnPropertyChanged(() => IsBusy);
            }
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

        public BaseController(INavigationService navigationService) : base()
        {
            this.Navigation = navigationService;
        }

        public BaseController(INavigationService navigationService, IInteractionService interactionService) : base()
        {
            this.Navigation = navigationService;
            this._interactionService = interactionService;
        }
        
        public bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(storage, value))
                return false;

            storage = value;

            OnPropertyChanged(propertyName);

            return true;
        }

        /// <summary>
        /// Return a string name of a any property.
        /// Use "() => Property_Name"
        /// </summary>
        /// <typeparam name="TValue">Your object</typeparam>
        /// <param name="propertyName">User () => Property_Name</param>
        /// <returns></returns>
        protected virtual void OnPropertyChanged<TValue>(Expression<Func<TValue>> propertyName)
        {
            var propName = ((MemberExpression)propertyName.Body).Member.Name;

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public Task<string> DisplayActionSheet<TController>(string title, string cancel, string destruction, params string[] buttons)
            where TController : IBaseController
        {
            return this._interactionService?.DisplayActionSheet<TController>(title, cancel, destruction, buttons);
        }

        public Task DisplayAlert<TController>(string title, string message, string cancel) 
            where TController : IBaseController
        {
            return this._interactionService?.DisplayAlert<TController>(title, message, cancel);
        }

        Task<bool> DisplayAlert<TController>(string title, string message, string accept, string cancel) 
            where TController : IBaseController
        {
            return this._interactionService?.DisplayAlert<TController>(title, message, accept, cancel);
        }
    }
}