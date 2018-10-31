using System;

namespace Bank.AccountHolder
{
    /// <summary>
    /// Class representing added account from holder
    /// </summary>
    public static class CreateAccountHolder
    {
        private static long _holderId;

        /// <summary>
        /// Create new Holder object
        /// </summary>
        /// <param name="name">Holder name</param>
        /// <param name="surname">Holder surname</param>
        /// <param name="email">Holder email</param>
        /// <param name="contactPhone">Holder contact phone</param>
        /// <returns>New Holder object </returns>
        public static AccountHolder CreateAccount(string name, string surname, string email, string contactPhone)
            => new AccountHolder(name, surname, email, contactPhone, ++_holderId);
    }
}
