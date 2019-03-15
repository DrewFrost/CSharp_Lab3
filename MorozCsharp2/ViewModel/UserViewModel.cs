using System;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using MorozCsharp2.Models;
using MorozCsharp2.Tools;
using MorozCsharp2.Tools.Manager;

namespace MorozCsharp2.ViewModel
{
    internal class UserViewModel : BaseViewModel
    {
        private string _name;
        private string _surname;
        private string _email;
        private DateTime _birthdayDate;


        #region Command

        private RelayCommand<object> _startCommand;


        #endregion

        #region Properties

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged();

            }
        }


        public string Surname
        {
            get { return _surname; }
            set
            {
                _surname = value;
                OnPropertyChanged();
            }
        }

        public string Email
        {
            get { return _email; }
            set
            {
                _email = value;
                OnPropertyChanged();
            }
        }



        public DateTime BirthdayDate
        {
            get { return _birthdayDate; }
            set
            {
                _birthdayDate = value;
                OnPropertyChanged();
            }
        }


        #endregion

        public RelayCommand<object> StartCommand
        {
            get
            {
                return _startCommand ?? (_startCommand = new RelayCommand<object>(
                           NewUser, o => CanExecuteCommand()));
            }
        }

        private async void NewUser(object o)
        {
            if (_birthdayDate > DateTime.Today)
            {
                MessageBox.Show("You don't even exist yet, don't lie to me");
            }
            else if (DateTime.Today.Year - _birthdayDate.Year > 135)
            {
                MessageBox.Show("Go take your pills old man");
            }
            else if (!IsValidEmailAddress(_email))
            {
                MessageBox.Show("Enter valid Email");
            }
            else
            {

                await Task.Run((() =>
                {


                    User user = new User(_name, _surname, _email, _birthdayDate);
                    MessageBox.Show(
                        $"Your name is {user.Name}\n" +
                        $"Your surname is {user.Surname}\n" +
                        $"Your email is {user.Email}\n" +
                        $"Your are {user.Age} years old\n" +
                        $"{user.Adult}\n" +
                        $"{user.Birthday}\n" +
                        $"Your Western Zodiac Sign is {user.WesternZodiac}\n" +
                        $"Your Chinese Zodiac Sign is {user.ChineseZodiac}\n" +
                        $"Your Sun Zodiac Sign is {user.SunZodiac}\n"
                    );
                    CleanInput();


                }));



            }

        }


        public static bool IsValidEmailAddress( string s)
       {
           Regex regex = new Regex(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$");
           return regex.IsMatch(s);
       }
   


       private void CleanInput()
       {
           Name = "";
           Surname = "";
           Email = "";

       }


        public bool CanExecuteCommand()
        {
            return !string.IsNullOrWhiteSpace(_name) && !string.IsNullOrWhiteSpace(_surname) && !string.IsNullOrWhiteSpace(_email) && !(_birthdayDate == default(DateTime));
        }



    }
}

