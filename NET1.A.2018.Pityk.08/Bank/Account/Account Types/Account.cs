using System;
using Bank.AccountHolder;

namespace Bank.Account
{
    /// <summary>
    /// Abstract class describing bank Account
    /// </summary>
    public abstract class Account
    {
        #region Private fields
        private string _accountNumber;
        
        private AccountHolder.AccountHolder _holder;

        private decimal _defaultBonus;
        #endregion

        #region Properties
        /// <summary>
        /// Describing default bonus of this account type
        /// </summary>
        /// <exception cref="ArgumentException">
        /// Throws if value can`t be equal to null or empty
        /// </exception>
        public decimal DefaultBonus
        {
            get => _defaultBonus;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(nameof(value), "can't be equal to null or empty!");
                }

                _defaultBonus = value;
            }
        }

        /// <summary>
        /// Describing balance of this account
        /// </summary>
        public decimal Balance { get; set; }

        /// <summary>
        /// Describing bonus point if this account
        /// </summary>
        public int BonusPoints { get; set; }

        /// <summary>
        /// Describing number of current account
        /// </summary>
        /// <exception cref="ArgumentException">
        /// Throw if value can`t be equal to null or empty
        /// </exception>
        public string AccountNumber
        {
            get => _accountNumber;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(nameof(value), "can't be equal to null or empty!");
                }

                _accountNumber = value;
            }
        }

        /// <summary>
        /// Describing of holder of this account
        /// </summary>
        /// <exception cref="ArgumentException">
        /// Throw if value can`t be equal to null or empty
        /// </exception>
        public AccountHolder.AccountHolder Holder
        {
            get => _holder;
            set => _holder = value ?? throw new ArgumentException(nameof(value), "can't be equal to null or empty!");
        }

        /// <summary>
        /// Describing Status of this account
        /// </summary>
        public BankService.AccountStatus Status { get; set; }
        #endregion

        #region Constructors
        /// <summary>
        /// Constructor for class
        /// </summary>
        /// <param name="holder">Holder of account</param>
        /// <param name="generatorId">Account ID</param>
        /// <param name="defaultBonus">Bonus of this account at deposit</param>
        public Account(AccountHolder.AccountHolder holder, string generatorId, decimal defaultBonus)
        {
            Holder = holder;
            _accountNumber = generatorId;
            DefaultBonus = defaultBonus;
            Status = BankService.AccountStatus.Open;
        }

        /// <summary>
        /// Constructor for class
        /// </summary>
        /// <param name="holder">Holder of account</param>
        /// <param name="generatorId">Account ID</param>
        /// <param name="defaultBonus">Bonus of this account at deposit</param>
        /// <param name="balance">Balance of this account</param>
        public Account(AccountHolder.AccountHolder holder, string generatorId, decimal defaultBonus, decimal balance)
        {
            Holder = holder;
            _accountNumber = generatorId;
            DefaultBonus = defaultBonus;
            Status = BankService.AccountStatus.Open;
            Balance = balance;
        }

        /// <summary>
        /// Constructor for class
        /// </summary>
        /// <param name="holder">Holder of account</param>
        /// <param name="generatorId">Account ID</param>
        /// <param name="defaultBonus">Bonus of this account at deposit</param>
        /// <param name="balance">Balance of this account</param>
        /// <param name="bonusPoints">Bonus point of this account which depends of type account</param>
        public Account(AccountHolder.AccountHolder holder, string generatorId, decimal defaultBonus, decimal balance, int bonusPoints)
        {
            Holder = holder;
            _accountNumber = generatorId;
            DefaultBonus = defaultBonus;
            Status = BankService.AccountStatus.Open;
            Balance = balance;
            BonusPoints = bonusPoints;
        }
        #endregion

        #region Public Methods

        /// <summary>
        /// Overrided method that return string representation of this instance
        /// </summary>
        /// <returns>String representation of this instance</returns>
        public override string ToString()
        {
            return $" Type: {GetType().Name}\n" + $" ID: {_accountNumber}\n" + $" Status: {Status}\n" +
                $" Holder: {_holder}\n" + $" Balance: {Balance}\n" + $" BonusPoints: {BonusPoints}";
        }

        /// <summary>
        /// Represent  deposit of this account
        /// </summary>
        /// <param name="sum">Deposit sum</param>
        /// <exception cref="ArgumentException">
        /// Throw if you cannot add an amount to a frozen or closed account
        /// or deposit amount can not be less or equal to zero
        /// </exception>
        public void Deposit(decimal sum)
        {
            if (Status != BankService.AccountStatus.Open)
            {
                throw new ArgumentException(nameof(Status), "you cannot add an amount to a frozen or closed account");
            }

            if (sum <= 0)
            {
                throw new ArgumentException(nameof(sum), "Deposit amount can not be less or equal to zero");
            }

            Balance += sum;
            BonusPoints += CalculateBonusPoint(sum);
        }

        public void Withdraw(decimal sum)
        {
            if (Status != BankService.AccountStatus.Open)
            {
                throw new ArgumentException(nameof(Status), "you cannot add an amount to a frozen or closed account");
            }

            if (!IsValidBalance(Balance))
            {
                throw new ArgumentException(nameof(Balance), "incorrect balance");
            }

            if (sum <= 0)
            {
                throw new ArgumentException(nameof(sum), "Sum amount can't be less or equal to zero.");
            }

            if (sum > Balance)
            {
                throw new ArgumentException(nameof(sum), "Sum amount can't be bigger than balance!");
            }

            Balance -= sum;
            BonusPoints -= CalculateBonusPoint(sum) / 4;
        }
        #endregion

        #region Private methods
        public int CalculateBonusPoint(decimal sum) => (int)Math.Round(_defaultBonus + (Balance + sum));

        public bool IsValidBalance(decimal balance) => Balance >= 0;
        #endregion
    }
}
