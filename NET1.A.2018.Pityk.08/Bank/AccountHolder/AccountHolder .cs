using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Bank.AccountHolder
{
    /// <summary>
    /// Class representing person attached to account
    /// </summary>
    public sealed class AccountHolder : IEquatable<AccountHolder>
    {
        #region Private fields
        private string _name;

        private string _surname;

        private string _email;

        private string _contactPhone;

        private List<Account.Account> _holderAccounts;

        private readonly long _holderId;

        #endregion

        /// <summary>
        /// Constructor for AccountHolder class
        /// </summary>
        /// <param name="name">Holder's name</param>
        /// <param name="surname">Holder's surname</param>
        /// <param name="email">Holder's email</param>
        /// <param name="contactPhone">Holder's contact phone</param>
        /// <param name="holderId">Holder's Id</param>
        public AccountHolder(string name, string surname, string email, string contactPhone, long holderId)
        {
            this.Name = name;
            this.Surname = surname;
            this.Email = email;
            this.ContactPhone = contactPhone;
            this._holderId = holderId;
            _holderAccounts = new List<Account.Account>();
        }

        #region Properties 

        /// <summary>
        /// Represent holder's name
        /// </summary>
        /// <exception cref="ArgumentException">
        /// Throws if value can't be equal to null or empty or the name must consist of letters only
        /// </exception>
        public string Name
        {
            get => _name;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(nameof(value), "can't be equal to null or empty!");
                }
                else if (!value.All(char.IsLetter))
                {
                    throw new ArgumentException(nameof(value), "the name must consist of letters only");
                }

                _name = value;
            }
        }

        /// <summary>
        /// Represent holder's surname
        /// </summary>
        /// <exception cref="ArgumentException">
        /// Throws if value can't be equal to null or empty or the surname must consist of letters only
        /// </exception>
        public string Surname
        {
            get => _surname;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(nameof(value), "can't be equal to null or empty!");
                }
                else if (!value.All(char.IsLetter))
                {
                    throw new ArgumentException(nameof(value), "the surname must consist of letters only");
                }

                _surname = value;
            }
        }

        /// <summary>
        /// Represent holder's email
        /// </summary>
        /// <exception cref="ArgumentException">
        /// Throws if value can't be equal to null or empty or can`t be contains "@"
        /// </exception>
        public string Email
        {
            get => _email;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(nameof(Email), "can't be equal to null or empty!");
                }
                else if (!value.Contains("@"))
                {
                    throw new ArgumentException(nameof(value), "can`t be contains \"@\"");
                }

                _email = Email;
            }
        }

        /// <summary>
        /// Represent holder's contact phone
        /// </summary>
        /// <exception cref="ArgumentException">
        /// Throws if value can't be equal to null or empty or can`t be in form "+X (XXX) XXX-XXXX"
        /// </exception>
        public string ContactPhone
        {
            get => _contactPhone;
            set
            {
                if (value is null)
                {
                    throw new ArgumentException(nameof(value), "can't be equal to null or empty!");
                }

                if (!Regex.IsMatch(value, @"^\+\d \(\d{3}\) \d{3}-\d{4}$"))
                {
                    throw new ArgumentException(nameof(value), "must be in form \"+X (XXX) XXX-XXXX\"");
                }

                _contactPhone = value;
            }
        }
        #endregion

        #region Overrided Methods
        /// <summary>
        /// Overrided method that return string representation of this instance
        /// </summary>
        /// <returns>String representation of this instance</returns>
        public override string ToString()
        {
            return string.Format("Id: {0} | Name: {1} | Surname: {2} | Email: {3} | Contact phone: {4}", _holderId, Name, Surname, Email, ContactPhone);
        }

        /// <summary>
        /// Overrided method that equals two objects
        /// </summary>
        /// <param name="obj">Comperer object</param>
        /// <returns>Bool value</returns>
        public override bool Equals(object obj)
        {
            if (obj is null)
            {
                return false;
            }
            else if (GetType() != obj.GetType())
            {
                return false;
            }
            else if (ReferenceEquals(this, obj))
            {
                return true;
            }

            return this.Equals((AccountHolder)obj);
        }

        /// <summary>
        /// Check if two objects are equal
        /// </summary>
        /// <param name="other">Comperer object</param>
        /// <returns></returns>
        public bool Equals(AccountHolder other)
        {
            if (other is null)
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return _holderId == other._holderId && _name == other._name && _surname == other._surname;
        }

        /// <summary>
        /// Overrided method get HashCode of this object
        /// </summary>
        /// <returns>This object HashCode</returns>
        public override int GetHashCode()
        {
            return _holderId.GetHashCode();
        }
        #endregion

        #region Public methods
        /// <summary>
        /// Add new account of this Holder
        /// </summary>
        /// <param name="account">Account that be add</param>
        /// <exception cref="ArgumentException">
        /// Throw if account can't be equal to null or empty
        /// </exception>
        public void AddAccount(Account.Account account)
        {
            if (account is null)
            {
                throw new ArgumentException(nameof(account), "can't be equal to null or empty!");
            }

            _holderAccounts.Add(account);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>IEnumerable type what contains all holder account</returns>
        public IEnumerable<Account.Account> GetAllAccount() => _holderAccounts.Where(t => t.Holder._holderId == this._holderId);
        #endregion
    }
}
