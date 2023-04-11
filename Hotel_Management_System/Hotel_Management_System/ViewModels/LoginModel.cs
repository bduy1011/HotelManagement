using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using Hotel_Management_System.Models;
using Hotel_Management_System.Repositories;

namespace Hotel_Management_System.ViewModels
{
    public class LoginModel:ViewModelBase
    {
        //Fields
        private string _userName="Username";
        private SecureString _password;
        private string _errorMessage;
        public bool _isViewVisible = true;

        private IUserRepository userRepository; 
        //Thuoc tinh
        public string Username
        {
            get { return _userName; }
            set { _userName = value; OnPropertyChanged(nameof(Username)); }
        }
        public SecureString Password
        {
            get { return _password; }
            set { _password = value; OnPropertyChanged(nameof(Password)); }
        }
        public string ErrorMessage
        {
            get { return _errorMessage; }
            set { _errorMessage = value; OnPropertyChanged(nameof(ErrorMessage)); }
        }
        public bool IsViewVisible
        {
            get { return _isViewVisible; }
            set { _isViewVisible = value; OnPropertyChanged(nameof(IsViewVisible)); }
        }

        public ICommand LoginCommand { get; }
        public ICommand RecoverPasswordCommand { get; }
        public ICommand ShowPasswordCommand { get; }
        public ICommand RememberPasswordCommand { get; }
        //Constructors
        public LoginModel()
        {
            userRepository = new UserRepository();
            LoginCommand = new RelayCommand(ExcuteLoginCommand, CanExcuteLoginCommand);
            RecoverPasswordCommand = new RelayCommand(p=>ExcuteRecoverPassCommand("",""));
        }
        private bool CanExcuteLoginCommand(object obj)
        {
            bool validData;
            if (string.IsNullOrWhiteSpace(Username) || Username.Length < 3 || Password == null || Password.Length < 3)
                validData = false;
            else
                validData = true;
            return validData;
        }
        private void ExcuteLoginCommand(object obj)
        {
            var isValidUser = userRepository.AuthenticateUser(new System.Net.NetworkCredential(Username, Password));
            if(isValidUser)
            {
                Thread.CurrentPrincipal = new GenericPrincipal(
                    new GenericIdentity(Username), null);
                IsViewVisible = false;
            }
            else
            {
                ErrorMessage = "* Invalid username or password";
            }
        }
        private void ExcuteRecoverPassCommand(string username, string email)
        {
            throw new NotImplementedException();
        }

    }
}
