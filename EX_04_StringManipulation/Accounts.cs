using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace EX_04_StringManipulation
{
    public class Accounts
    {
        public List<char> _charsToRemoveList = new List<char>(){')',':','!','#','$',
            '%','&','\'','*','+','-',',','/','=','?','^','_','`','{','|','}','~'};

        public string FindUserName(string account)
        {
            if (account.Contains("@"))
            {
                string[] splitEmail = account.Split('@');
                string namePart = splitEmail[0];
                string domainPart = splitEmail[1];
                string[] names = namePart.Split('.');
                account = "Name: ";
                foreach (string name in names)
                {
                    account += char.ToUpper(name[0]) + name.Substring(1) + " ";
                }
                string domain = domainPart.Split('.')[0];
                account += "Domain: " + char.ToUpper(domainPart[0]) + domain.Substring(1);
            }
            else if (account.Contains("/"))
            {
                string[] splitDomain = account.Split('/');
                string namePart = splitDomain[1];
                string domainPart = splitDomain[0];
                string[] names = namePart.Split('.');
                account = "Name: ";
                foreach (string name in names)
                {
                    account += char.ToUpper(name[0]) + name.Substring(1) + " ";
                }
                account += "Domain: " + char.ToUpper(domainPart[0]) + domainPart.Substring(1);
            }
            return account;
        }

        public string CreateUsername(string name)
        {
            string username;
            List<char> dottedChars = new List<char>() { 'õ', 'ä', 'ö', 'ü', 'Õ', 'Ä', 'Ö', 'Ü' };
            List<char> replacementChars = new List<char>() { 'o', 'a', 'o', 'u', 'o', 'a', 'o', 'u' };
            if (name.Length > 1)
            {
                string nameWithoutDots = string.Empty;
                foreach (char c in name)
                {
                    if (!_charsToRemoveList.Contains(c))
                    {
                        int dottedCharIndex = dottedChars.IndexOf(c);
                        if (dottedCharIndex != -1)
                        {
                            nameWithoutDots += replacementChars[dottedCharIndex];
                        }
                        else
                        {
                            nameWithoutDots += c;
                        }
                    }
                }
                int index = nameWithoutDots.LastIndexOf(' ');
                if (index != -1)
                {
                    string forenames = nameWithoutDots.Substring(0, index);
                    string lastname = nameWithoutDots.Substring(index + 1);
                    forenames = forenames.Replace(" ", string.Empty);
                    username = $"{forenames}.{lastname}";
                }
                else
                {
                    username = name;
                }
                username = username.ToLower();
                username = username.Trim();
                name = username;
                return name;
            }
            return name;
        }

        public string CreateEmailAddress(string data)
        {
            string[] parts = data.Split(" ");
            string emailAddress = "";
            if (parts.Length > 2)
            {
                for (int i = 0; i < parts.Length - 2; i++)
                {
                    emailAddress += parts[i] + ".";
                }
            }
            int lastNameIndex = parts.Length - 2;
            emailAddress += parts[lastNameIndex];
            emailAddress += "@";
            int domainIndex = parts.Length - 1;
            emailAddress += parts[domainIndex];
            emailAddress += ".eu";
            foreach (char c in _charsToRemoveList)
            {
                emailAddress = emailAddress.Replace(c.ToString(), String.Empty);
            }
            emailAddress = CreateUsername(emailAddress);
            return emailAddress;
        }

        public string CreateDomainAccount(string data)
        {
            int index = data.LastIndexOf(' ');
            string names = data.Substring(0, index);
            string domain = data.Substring(index + 1);
            string[] parts = data.Split(" ");
            string namesInDomainAccount = "";
            if (parts.Length > 2)
            {
                for (int i = 0; i < parts.Length - 1; i++)
                {
                    if (i > 0)
                    {
                        namesInDomainAccount += ".";
                    }
                    namesInDomainAccount += parts[i];
                }
            }
            string domainAccount = $"{domain}/{namesInDomainAccount}";
            domainAccount = CreateUsername(domainAccount);
            return domainAccount;
        }
    }
}
