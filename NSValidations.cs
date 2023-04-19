using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;
using static System.Net.Mime.MediaTypeNames;



namespace NSClassLibrary
{
    //Add a public static class called XXValidations, with the following public static (class-level) methods
    public static class NSValidations
    {
       
        //Add a method called XXCapitalize that accepts a string and returns a string
        public static String NSCapitalize(String input)
        {
            //If the input string is null, return it as an empty string
            string result = string.Empty;

            if (input != null)
            {
                //Change the input string to lower case and remove leading & trailing spaces
                var lowerString = input.ToString().Trim().ToLower();
                //Shift the first letter of every word in the string to upper case
                result = char.ToUpper(lowerString[0]) + lowerString.Substring(1);
                //Return the newly-capitalised string
                return result;
            }
            else
                return result;
        }

        //Add a method called XXExtractDigits that accepts a string and returns a string
        public static String NSExtractDigits(String input)
        {
            //Return a string containing all digits found in the input string.
            Regex pattern = new Regex(@"^\d$", RegexOptions.IgnoreCase);
            if (pattern.IsMatch(input.ToString()))
                return input;
            return input = string.Empty;
        }
        //Add a method called XXPostalCodeValidation that accepts a string and returns a Boolean
        public static bool NSPostalCodeValidation(String input)
        {
            /*
             The regular expression pattern, @"^[ABCEGHJ-NPRSTVXY]\d[ABCEGHJ-NPRSTV-Z][ -]?\d[ABCEGHJ-NPRSTV-Z]\d$" 
            matches a Canadian postal code format.
            If the input string is null, empty or matches the pattern,
            the function returns true. Otherwise, it returns false.
             
             */
            Regex pattern = new Regex(@"^[ABCEGHJ-NPRSTVXY]\d[ABCEGHJ-NPRSTV-Z][ -]?\d[ABCEGHJ-NPRSTV-Z]\d$", RegexOptions.IgnoreCase);
            if (input == null || input.ToString() == "" || pattern.IsMatch(input.ToString()))
                return true;
            return false;
        }
        public static String NSPostalCodeFormat(String input)


        /*
         inserts a space character at the 4th position of the input string and converts the resulting string 
        to uppercase if it is not null or empty and has a character at the 4th position,
        otherwise it returns the input string unchanged.*/

        {
            if (input == null || input == "")
                return input;
            else
            {
                if (input[3] == null)
                {
                    return input;
                }
                else
                {
                    input = input.Insert(3, " ").ToUpper();
                    return input;
                }

            }

        }
        public static bool NSZipCodeValidation(ref string zipcode)
        {
            /*
             this method to verify & format a US zip code, when the address is in the states.
            this checks if a given zipcode object is null or empty, and if it is not, it extracts the numeric characters from it 
            and formats it as a US ZIP code (either 5-digit or 9-digit with hyphen) if possible, and returns true. Otherwise, it returns false.
             
             */
            if (zipcode == null || zipcode.ToString() == "")
            {
                zipcode = "";
                return true;
            }

            else
            {
                string numericZipCode = new String(zipcode.Where(Char.IsDigit).ToArray());
                if (numericZipCode.Length == 5)
                {
                    zipcode = numericZipCode;
                    return true;
                }
                if (numericZipCode.Length == 9)
                {
                    zipcode = numericZipCode.Insert(5, "-");
                    return true;
                }
            }
            return false;
        }
    }
}
