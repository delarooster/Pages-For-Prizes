﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography;
using System.Web;

namespace Capstone.Web
{
    public class User
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [Display(Name = "First Name:")]
        public string FirstName { get; set; }

        
        
        public string LastName { get; set; }

        public string FamilyName { get; set; }

        public int FamilyID { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [Display(Name = "Username:")]
        public string Username { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [Display(Name = "Password:")]
        public string Password { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [Compare("Password", ErrorMessage = "Passwords do not match")]
        [Display(Name = "Confirm Password:")]
        public string ConfirmPassword { get; set; }

        public string Salt { get; set; }

        //[Required(ErrorMessage = "This field is required")]
        public int RoleID { get; set; }
    }

    public class PasswordHash
    {
        private string password;
        private static int _workFactor = 20;
        private static int _saltSize = 16;

        public string Salt { get; private set; }
        public string Hash { get; private set; }


        public PasswordHash(string password)
        {
            this.password = password;
            GenerateSalt();
            GenerateHash();
        }

        public PasswordHash(string password, string salt)
        {
            this.password = password;
            this.Salt = salt;
            GenerateHash();
        }

        public bool Verify(string hash)
        {
            return Hash == hash;
        }



        #region Private methods

        private void GenerateSalt()
        {
            Rfc2898DeriveBytes rfc = new Rfc2898DeriveBytes(password, _saltSize, _workFactor);
            Salt = GetSalt(rfc);
        }

        private void GenerateHash()
        {
            Rfc2898DeriveBytes rfc = HashPasswordWithPBKDF2(password, Salt);
            Hash = GetHash(rfc);
        }

        private static Rfc2898DeriveBytes HashPasswordWithPBKDF2(string password, string salt)
        {
            // Creates the crypto service provider and provides the salt - usually used to check for a password match
            Rfc2898DeriveBytes rfc2898DeriveBytes = new Rfc2898DeriveBytes(password, Convert.FromBase64String(salt), _workFactor);

            return rfc2898DeriveBytes;
        }

        private static string GetHash(Rfc2898DeriveBytes rfc)
        {
            return Convert.ToBase64String(rfc.GetBytes(20));
        }

        private static string GetSalt(Rfc2898DeriveBytes rfc)
        {
            return Convert.ToBase64String(rfc.Salt);
        }

        #endregion

    }
}