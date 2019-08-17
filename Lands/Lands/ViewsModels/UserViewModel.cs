using Lands.Helpers;
using Lands.Models;
using Lands.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Lands.ViewsModels
{
    public class UserViewModel : BaseViewModel
    {
        #region Services
        ApiService apiService;
        #endregion

        #region Constructors
        public UserViewModel(UserInfo user)
        {
            apiService = new ApiService();
            localUser = user;
            this.LoadUserContent();
        }
        #endregion

        #region Properties
        public ImageSource ImageSource
        {
            get { return this.imageSource; }
            set { SetValue(ref this.imageSource, value); }
        }
        public string FullName
        {
            get { return this.fullName; }
            set { SetValue(ref this.fullName, value); }
        }
        public string FirstName
        {
            get { return this.firstName; }
            set { SetValue(ref this.firstName, value); }
        }
        public string LastName
        {
            get { return this.lastName; }
            set { SetValue(ref this.lastName, value); }
        }
        public string Email
        {
            get { return this.email; }
            set { SetValue(ref this.email, value); }
        }
        public string PhoneNumber
        {
            get { return this.phoneNumber; }
            set { SetValue(ref this.phoneNumber, value); }
        }
        #endregion

        #region Attributes
        private ImageSource imageSource;
        private UserInfo localUser;
        private string fullName;
        private string firstName;
        private string lastName;
        private string email;
        private string phoneNumber;
        #endregion

        #region Methods
        public void LoadUserContent()
        {
            if (localUser.ImagePath == null)
                ImageSource = "cameraImage";
            else
                ImageSource = localUser.ImageFullPath;

            FullName = localUser.FullName;
            FirstName = localUser.FirstName;
            LastName = localUser.LastName;
            Email = localUser.Email;
            PhoneNumber = localUser.Telephone;
        }
        #endregion
    }
}
