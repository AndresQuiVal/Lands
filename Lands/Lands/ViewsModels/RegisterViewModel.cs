using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Lands.ViewsModels
{
    public class RegisterViewModel
    {
        #region Properties
        public ImageSource ImageSource { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Telephone { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        #endregion

        #region Commands
        public ICommand ChangeImageCommand { get; }
        public ICommand RegisterCommand { get; }
        #endregion
    }
}
