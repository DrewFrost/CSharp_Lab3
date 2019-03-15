using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using MorozCsharp2.Tools;

namespace MorozCsharp2.Models
{
    class User : BaseViewModel
    {
        private string _name;
        private string _surname;
        private string _email;
        private DateTime _birthdayDate;
        private readonly int _age;
        private readonly string _birthday;
        private readonly string _adult;
        private readonly string _westernZodiac;
        private readonly string _chineseZodiac;
        private readonly string _sunZodiac;

        public User(string name, string surname, string email, DateTime birthdayDate)
        {
            _name = name;
            _surname = surname;
            _email = email;
            _birthdayDate = birthdayDate;
            _age = UsersAge();
            _birthday = IsBirthday();  
            _adult = IsAdult();
            _westernZodiac = WesternZodiacSign();
            _chineseZodiac = ChineseZodiacSign();
            _sunZodiac = SunZodiacSign();
        }

        public User(string name, string surname, DateTime birthdayDate)
        {

        }
        public User(string name, string surname, string email)
        {

        }



        #region Properties
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }




        public string Surname
        {
            get { return _surname; }
            set { _surname = value;  }
        }


        public string Email
        {
            get { return _email; }
            set
            {
                _email = value;
               
            }
        }


        public DateTime BirthdayDate
        {
            get { return _birthdayDate; }
            set
            {
                _birthdayDate = value;
            }
        }


        public int Age
        {
            get { return _age; }
          
        }

        public string Birthday
        {
            get { return _birthday;  }
        }

        public string WesternZodiac
        {
            get { return _westernZodiac; }

        }

        public string ChineseZodiac
        {
            get { return _chineseZodiac; }
            
        }

        public string SunZodiac
        {
            get { return _sunZodiac; }
        }

        public string Adult
        {
            get { return _adult; }

        }
        #endregion



        private int UsersAge()
        {
            return DateTime.Today.Year - _birthdayDate.Year -
                   (BirthdayDate.DayOfYear> DateTime.Today.DayOfYear ? 1:0);
        }

        private string IsBirthday()
        {
            if (_birthdayDate.DayOfYear == DateTime.Today.DayOfYear)
            {
                return $"Ohh, guess who have a birthday today";
            }

            return $"Unfortunately you don't a birthday today :(";
        }

        private string IsAdult()
        {
            if (UsersAge() <= 17)
            {
                return $"You are young";
            }

            return $"You are adult";
        }

        private string WesternZodiacSign()
        {
            switch (_birthdayDate.Month)
            {
                case 1:
                    return _birthdayDate.Day <= 19 ? "Capricorn" : "Aquarius";
                case 2:
                    return _birthdayDate.Day <= 17 ? "Aquarius" : "Pisces";
                case 3:
                    return _birthdayDate.Day <= 19 ? "Pisces" : "Aries";
                case 4:
                    return _birthdayDate.Day <= 19 ? "Aries" : "Taurus";
                case 5:
                    return _birthdayDate.Day <= 20 ? "Taurus" : "Gemini";
                case 6:
                    return _birthdayDate.Day <= 20 ? "Gemini" : "Cancer";
                case 7:
                    return _birthdayDate.Day <= 22 ? "Cancer" : "Leo";
                case 8:
                    return _birthdayDate.Day <= 22 ? "Leo" : "Virgo";
                case 9:
                    return _birthdayDate.Day <= 22 ? "Virgo" : "Libra";
                case 10:
                    return _birthdayDate.Day <= 22 ? "Libra" : "Scorpio";
                case 11:
                    return _birthdayDate.Day <= 21 ? "Scorpio" : "Sagittarius";
                case 12:
                    return _birthdayDate.Day <= 21 ? "Sagittarius" : "Capricorn";
                default:
                    throw new ArgumentException("We haven't invented western Zodiac sign for you yet!");
            }
        }
        private string ChineseZodiacSign()
        {
            switch (_birthdayDate.Year % 12)
            {
                case 0:
                    return "Monkey";
                case 1:
                    return "Rooster";
                case 2:
                    return "Dog";
                case 3:
                    return "Pig";
                case 4:
                    return "Rat";
                case 5:
                    return "Ox";
                case 6:
                    return "Tiger";
                case 7:
                    return "Rabbit";
                case 8:
                    return "Dragon";
                case 9:
                    return "Snake";
                case 10:
                    return "Horse";
                case 11:
                    return "Sheep";
                default:
                    throw new ArgumentException("Your chinese zodiac wasn't found");
            }
        }

        private string SunZodiacSign()
        {
            switch (_birthdayDate.Month)
            {
                case 1:
                    return _birthdayDate.Day <= 19 ? "Saturn" : "Uranus";
                case 2:
                    return _birthdayDate.Day <= 17 ? "Uranus" : "Neptune";
                case 3:
                    return _birthdayDate.Day <= 19 ? "Neptune" : "Mars";
                case 4:
                    return _birthdayDate.Day <= 19 ? "Mars" : "Venus";
                case 5:
                    return _birthdayDate.Day <= 20 ? "Venus" : "Mercury";
                case 6:
                    return _birthdayDate.Day <= 20 ? "Mercury" : "Luna";
                case 7:
                    return _birthdayDate.Day <= 22 ? "Luna" : "Sun";
                case 8:
                    return _birthdayDate.Day <= 22 ? "Sun" : "Mercury";
                case 9:
                    return _birthdayDate.Day <= 22 ? "Mercury" : "Venus";
                case 10:
                    return _birthdayDate.Day <= 22 ? "Venus" : "Pluto";
                case 11:
                    return _birthdayDate.Day <= 21 ? "Pluto" : "Jupiter";
                case 12:
                    return _birthdayDate.Day <= 21 ? "Jupiter" : "Saturn";
                default:
                    throw new ArgumentException("Your planet wasn't found");
            }
        }

    }
}
