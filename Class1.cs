using System.Linq;
//The class DAKSAccountChecks is used to check whether correct details were feeded into the system or not.
namespace DAKSAppsAccount
{
    public class DAKSAccountChecks
    {
        //This is how the system will check whether correct details were feeded or not.
        public string AllowedChecking(string User_Name, string emailaddress, string pass,string cpass,string country,string phone)
        {
            //First it will check whether any data is unfilled or not.
            if (User_Name == "" || emailaddress == "" || pass == "" || cpass == ""  || country == "" || phone == "")
            {
                return "Some Data is Unfilled please recheck again.";
            }
            else
            {
                  //Second it will calculate the total letter that comes in the user name.
                    int c = 0;
                    for(int i = 0;i < User_Name.Length;i++)
                    {
                        if (char.IsWhiteSpace(User_Name,i) == false)
                        {
                            c++;
                        }
                    } 
                    //If the total letter in user name is more than 5 then checking will continue otherwise it will stop checking.
                        if (c >= 5)
                        {
                    //Third it will calculate the total letter in email address, if it is more than 8 then checking will continue otherwise it will stop checking.
                        if(emailaddress.Length >= 8)
                        {
                            //Checking whether email address contains white space or not.
                            bool d = false;
                            for (int i = 0; i < emailaddress.Length; i++)
                            {
                                if (emailaddress[i] == ' ')
                                {
                                    d = true;
                                    break;           
                                }
                            }
                            //Fourth it will check whether email address contain any white space or not.
                            if(d == true)
                            {
                                return "No Space in email address is allowed.";
                            }
                            else
                            {
                            //Fifth it will check whether emailaddress's first and last letter is digit or alphabet.
                            if (char.IsLetterOrDigit(emailaddress[0]) == false || char.IsLetterOrDigit(emailaddress[emailaddress.Length - 1]) == false) 
                            {
                                return "Symbols as first or last character in email address is not allowed.";
                            }
                            else
                            {
                                //Checking total no. of @ in the email address.
                                int e = 0;
                                for (int i = 0; i < emailaddress.Length; i++)
                                {
                                    if (emailaddress[i] == '@')
                                    {
                                        e++;
                                    }
                                }
                                //Sixth it will check whether email address's contain only one @ symbol.
                                if (e == 1)
                                {
                                    //Checking whether the email address's @ symbol is at last or not.
                                    bool g = false;
                                    for (int i = 0; i < emailaddress.Length; i++)
                                    {
                                        if (emailaddress[i] == '@')
                                        {
                                            if (emailaddress.Last() == '@')
                                            {
                                                g = true;
                                                break;
                                            }
                                        }
                                    }
                                    //Seventh it will check whether email address doesn't contain any @ at last, because it means no domain is defined for the given email address.
                                    if (g == false)
                                    {
                                        //Checking whether email address doesn't contain any .(dot) just after @.
                                        bool h = false;
                                        for (int i = 0; i < emailaddress.Length; i++)
                                        {
                                            if (emailaddress[i] == '@')
                                            {
                                                //emailaddress[i + 1] == '.'
                                                if (char.IsLetterOrDigit(emailaddress[i+1]))
                                                {
                                                    h = true;
                                                    break;
                                                }
                                            }
                                        }
                                        //Eight it will check whether provided email address doesn't contain any special character just after @, because domain always starts with either number or with letter.
                                        if (h == false)
                                        {
                                            return "No Domain of email address is defined.";
                                        }
                                        else
                                        {
                                            //Checking whether email address last character is .(dot).
                                            bool j = false;
                                            for (int i = 0; i < emailaddress.Length; i++)
                                            {
                                                if (emailaddress[i] == '@')
                                                {
                                                    if (emailaddress[i + 1] != '.')
                                                    {
                                                        if (emailaddress.Last() == '.')
                                                        {
                                                            j = true;
                                                            break;
                                                        }
                                                    }
                                                }
                                            }
                                            //Ninth it will check whether provided email address doesn't contain .(dot) at last, because domain always contains something after .(dot).
                                            if (j == true)
                                            { return "No Domain after (.) is defined."; }
                                            else
                                            {
                                                //Checking whether two or more dots are not present after domain(@).
                                                int pos = 0;
                                                int v = 0;
                                                for (int i = 0; i < emailaddress.Length; i++)
                                                {
                                                    if (emailaddress[i] == '@')
                                                    {
                                                        pos = i;
                                                        for (int l = i + 2; l < emailaddress.Length; l++)
                                                        {
                                                            if (emailaddress[l] == '.')
                                                            {
                                                                v++;
                                                            }
                                                        }
                                                    }
                                                }
                                                //Tenth it will check whether provided email address doesn't contains more than 1 .(dot) after @.
                                                if (v == 1)
                                                {
                                                    //Eleventh the email address should have letter or digit just before (@) symbol.
                                                    if(char.IsLetterOrDigit(emailaddress[pos - 1]) == true)
                                                    {
                                                        //12th now after checking the email address, it will check for password, and password should be more than 8 digits by including whitespaces also.
                                                    if (pass.Length >= 8)
                                                    {
                                                            //Calculating the total characters by excluding the white spaces.
                                                            int passon = 0;
                                                            for (int i = 0; i < pass.Length ; i++)
                                                            {
                                                                if(char.IsWhiteSpace(pass[i])==false)
                                                                {
                                                                    passon++;
                                                                }
                                                            }
                                                            //13th, the total length of the password by excluding the white spaces must be more than 8.
                                                            if(passon >= 8)
                                                            {
                                                                //Calculating the total no. of special character, capital letters, number and small letters in the given password.
                                                                int specialchar = 0;
                                                                int capitall = 0;
                                                                int nom = 0;
                                                                int small = 0;
                                                                for (int i = 0; i < pass.Length; i++)
                                                                {
                                                                    if (char.IsSymbol(pass[i]) == true || pass[i] == '?' || pass[i] == '#' || pass[i] == '~' || pass[i] == '@' || pass[i] == '$' || pass[i] == '₹' || pass[i] == '&' || pass[i] == '*')
                                                                    {
                                                                        specialchar++;
                                                                    }
                                                                    if (char.IsUpper(pass[i]) == true)
                                                                    {
                                                                        capitall++;
                                                                    }
                                                                    if (char.IsLower(pass[i]) == true)
                                                                    {
                                                                        small++;
                                                                    }
                                                                    if (char.IsNumber(pass[i]) == true)
                                                                    {
                                                                        nom++;
                                                                    }
                                                                }
                                                                //14th, there should be atleast one capital letter in the given password.
                                                                if (capitall > 0)
                                                                {
                                                                    //15th, there should be atleast one small letter in the given password.
                                                                    if (small > 0)
                                                                    {
                                                                        //16th, there should be atleast one number digit in the given password.
                                                                        if (nom > 0)
                                                                        {
                                                                            //17th, there should be atleast one special character in the given password.
                                                                            if (specialchar > 0)
                                                                            {
                                                                                //18th, password will be matched with confirm password.
                                                                                if (pass == cpass && pass != "")
                                                                                {
                                                                                    //19th, after satisfying all the above steps of email and password, phone no. will be checked in which its length must be more than 10.
                                                                                    if (phone.Length >= 10)
                                                                                    {
                                                                                        bool alpha = false;
                                                                                        for (int i = 0; i < phone.Length; i++)
                                                                                        {
                                                                                            if (char.IsDigit(phone[i]) == false)
                                                                                            {
                                                                                                if (phone[i] != '+' || phone[0] != '+')
                                                                                                {
                                                                                                    alpha = true;
                                                                                                    break;
                                                                                                }
                                                                                            }
                                                                                        }
                                                                                        //20th, phone no. should have (+) for just first digit only, like +91, +84 like that.
                                                                                        if (alpha == true)
                                                                                        { return "Phone no. is invalid, please recheck."; }
                                                                                        else
                                                                                        {
                                                                                            int z = 0;
                                                                                            for (int i = 0; i < phone.Length; i++)
                                                                                            {
                                                                                                if (phone[i] == '+')
                                                                                                {
                                                                                                    z++;
                                                                                                }
                                                                                            }
                                                                                            //21st, phone no. should not have more than one (+).
                                                                                            if (z > 1)
                                                                                            { return "Phone no. doesn't contains two or more (+)."; }
                                                                                            //After satisfying all the 20 steps given above, a string "success" will return.
                                                                                            else
                                                                                            { return "success"; }
                                                                                        }
                                                                                    }
                                                                                    else
                                                                                    {
                                                                                        return "Phone no. can't be less than 10 digits, put zero as prefix if phone no. is less than 10 digits.";
                                                                                    }
                                                                                }
                                                                                else
                                                                                {
                                                                                    return "Password doesn't matched with confirm password.";
                                                                                }
                                                                            }
                                                                            else
                                                                            {
                                                                                return "Please put atleast one special character such as @,#,*,&&,₹,?,~,$ in your password.";
                                                                            }
                                                                        }
                                                                        else
                                                                        {
                                                                            return "Please put atleast one digit (0-9) in your password.";
                                                                        }
                                                                    }
                                                                    else
                                                                    {
                                                                        return "Please put atleast one small letter (a-z) in your password.";
                                                                    }
                                                                }
                                                                else
                                                                {
                                                                    return "Please put atleast one capital letter (A-Z) in your password.";
                                                                }
                                                            }
                                                            else
                                                            {
                                                                return "Minimum 8 characters required for strong password.";
                                                            }
                                                    }
                                                    else
                                                    {
                                                        return "Password is too weak.";
                                                    }
                                                    }
                                                    else
                                                        { return "Last Character before @ can't be symbol in email address."; }
                                                }
                                                else if (v > 1)
                                                {
                                                    return "No two or more .(dots) allowed after @ in email address.";
                                                }
                                                else
                                                {
                                                    return "No domain is defined for email address(.(dot) is missing).";
                                                }
                                            }
                                        }
                                    }
                                    else
                                    {
                                        return "No domain is defined after @ in email address.";
                                    }
                                }
                                else if (e == 0)
                                {
                                    return "@ missing in your email address.";
                                }
                                else
                                {
                                    return "No two or more @ allowed in email address.";
                                }
                            }

                            }
                        }
                             else
                             {
                                    return "Email address is too small.";
                             }
                        }
                        else
                        {
                             return "User name is too small." ;
                        }
            }
        }

        //This method analyzes username only.
        public string  AllowedChecking(string username)
        { 
            int totalchar = 0;
            for(int i = 0;i < username.Length; i++)
            {
                if(username[i] != ' ')
                { totalchar++; }
            }    
            if (totalchar >= 5)
            {
                return "No Issue";
            }else
            { return "Too Short"; } 
        }
        //This method analyzes confirm password only.
        public string ConfirmAllowedPassword(string cpass, string pass)
        {
            if (pass == cpass && pass != "")
            {
                return "No Issue";
            }
            else
            {
                return "Password not matched";
            }
        }
        //This method analyzes country only.
        public string Country(string coun)
        {
            if(coun.Length > 0)
            {
                return "No Issue";
            }
            else
            {
                return "Please select country";
            }
        }
        //This method analyzes phone no. only.
        public string Phones(string phone)
        {
            if (phone.Length >= 10)
            {
                bool alpha = false;
                for (int i = 0; i < phone.Length; i++)
                {
                    if (char.IsDigit(phone[i]) == false)
                    {
                        if (phone[i] != '+' || phone[0] != '+')
                        {
                            alpha = true;
                            break;
                        }
                    }
                }
                if (alpha == true)
                { return "Invalid No."; }
                else
                {
                    int z = 0;
                    for (int i = 0; i < phone.Length; i++)
                    {
                        if (phone[i] == '+')
                        {
                            z++;
                        }
                    }
                    if (z > 1)
                    { return "Invalid No."; }
                    else
                    { return "No Issue"; }
                }
            }
            else
            {
                return "Invalid No.";
            }
        }
        //This method analyzes Password only.
        public string AllowedPassword(string pass)
        {
            if (pass.Length >= 8)
            {
                int passon = 0;
                for (int i = 0; i < pass.Length; i++)
                {
                    if(char.IsWhiteSpace(pass[i])==false)
                    {
                        passon++;
                    }
                }
                if (passon >= 8)
                {
                    int specialchar = 0;
                    int capitall = 0;
                    int nom = 0;
                    int small = 0;
                    for (int i = 0; i < pass.Length; i++)
                    {
                        if (char.IsSymbol(pass[i]) == true || pass[i] == '?' || pass[i] == '#' || pass[i] == '~' || pass[i] == '@' || pass[i] == '$' || pass[i] == '₹' || pass[i] == '&' || pass[i] == '*')
                        {
                            specialchar++;
                        }
                        if (char.IsUpper(pass[i]) == true)
                        {
                            capitall++;
                        }
                        if (char.IsLower(pass[i]) == true)
                        {
                            small++;
                        }
                        if (char.IsNumber(pass[i]) == true)
                        {
                            nom++;
                        }
                    }
                    if (capitall > 0)
                    {
                        if (small > 0)
                        {
                            if (nom > 0)
                            {
                                if (specialchar > 0)
                                {
                                    return "No Issue";
                                }
                                else
                                {
                                    return "Put one special character.";
                                }
                            }
                            else
                            {
                                return "Put one digit(0-9)";
                            }
                        }
                        else
                        {
                            return "Put one small letter (a-z)";
                        }
                    }
                    else
                    {
                        return "Put one capital letter (A-Z)";
                    }
                }
                else
                {
                    return "Min. 8 characters required.";
                }
            }
            else
            {
                return "Password is too weak.";
            }
        }
        //This method analyzes email address only.
        public string AllowedEmail(string emailaddress)
        {
             if(emailaddress.Length >= 8)
                        {
                            bool d = false;
                            for (int i = 0; i < emailaddress.Length; i++)
                            {
                                if (emailaddress[i] == ' ')
                                {
                                    d = true;
                                    break;           
                                }
                            }
                            if(d == true)
                            {
                                return "Space not allowed";
                            }
                            else
                            {
                    if (char.IsLetterOrDigit(emailaddress[0]) == false || char.IsLetterOrDigit(emailaddress[emailaddress.Length - 1]) == false)
                    {
                        return "Invalid Email-Id";
                    }
                    else
                    {
                        int e = 0;
                        for (int i = 0; i < emailaddress.Length; i++)
                        {
                            if (emailaddress[i] == '@')
                            {
                                e++;

                            }
                        }
                        if (e == 1)
                        {
                            bool g = false;
                            for (int i = 0; i < emailaddress.Length; i++)
                            {
                                if (emailaddress[i] == '@')
                                {
                                    if (emailaddress.Last() == '@')
                                    {
                                        g = true;
                                        break;
                                    }
                                }
                            }
                            if (g == false)
                            {
                                bool h = false;
                                for (int i = 0; i < emailaddress.Length; i++)
                                {
                                    if (emailaddress[i] == '@')
                                    {
                                        if (char.IsLetterOrDigit(emailaddress[i + 1]))
                                        {
                                            h = true;
                                            break;
                                        }
                                    }
                                }
                                if (h == false)
                                {
                                    return "Domain not defined";
                                }
                                else
                                {
                                    bool j = false;
                                    for (int i = 0; i < emailaddress.Length; i++)
                                    {
                                        if (emailaddress[i] == '@')
                                        {
                                            if (emailaddress[i + 1] != '.')
                                            {
                                                if (emailaddress.Last() == '.')
                                                {
                                                    j = true;
                                                    break;
                                                }
                                            }
                                        }
                                    }
                                    if (j == true)
                                    { return "Domain not defined"; }
                                    else
                                    {
                                        int posy = 0;
                                        int vy = 0;
                                        for (int i = 0; i < emailaddress.Length; i++)
                                        {
                                            if (emailaddress[i] == '@')
                                            {
                                                posy = i;
                                                for (int l = i + 2; l < emailaddress.Length; l++)
                                                {
                                                    if (emailaddress[l] == '.')
                                                    {
                                                        vy++;
                                                    }
                                                }
                                            }
                                        }
                                        if (vy == 1)
                                        {
                                            if (char.IsLetterOrDigit(emailaddress[posy - 1]) == true)
                                            { return "No Issue"; }
                                            else
                                            { return "Invalid Email-Id"; }
                                        }
                                        else if (vy > 1)
                                        {
                                            return "Domain not defined";
                                        }
                                        else
                                        {
                                            return "Domain not defined";
                                        }
                                    }
                                }
                            }
                            else
                            {
                                return "Domain not defined";
                            }
                        }
                        else if (e == 0)
                        {
                            return "@ missing";
                        }
                        else
                        {
                            return "Domain not defined";
                        }
                    }
                            }
                        }
                             else
                             {
                                    return "Too Small";
                             }
        }

    }

}