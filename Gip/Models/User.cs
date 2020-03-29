﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using Gip.Models.Exceptions;

namespace Gip.Models
{
    public partial class User
    {
        public User()
        {
            CourseMoment = new HashSet<CourseMoment>();
            CourseUser = new HashSet<CourseUser>();
        }
        public User(string naam, string voorNaam, string mail, string userid)
        {
            this.Naam = naam;
            this.VoorNaam = voorNaam;
            this.Mail = mail;
            this.Userid = userid;
        }

        private string userid;
        private string naam;
        private string voorNaam;
        private string mail;

        public virtual ICollection<CourseUser> CourseUser { get; set; }
        public virtual ICollection<CourseMoment> CourseMoment { get; set; }

        public string Naam
        {
            get { return naam; }
            set
            {
                if (value == "")
                {
                    throw new DatabaseException("The chosen name is empty!" + Environment.NewLine + "Please try again.");

                }
                else
                {
                    string pattern = @"^[a-zA-Z&àáâäãåąčćęèéêëėįìíîïłńòóôöõøùúûüųūÿýżźñçčšžÀÁÂÄÃÅĄĆČĖĘÈÉÊËÌÍÎÏĮŁŃÒÓÔÖÕØÙÚÛÜŲŪŸÝŻŹÑßÇŒÆČŠŽ∂ð ]+$";
                    if (Regex.IsMatch(value, pattern))
                    {
                        naam = value;
                    }
                    else
                    {
                        throw new DatabaseException("U heeft verboden characters ingegeven voor de naam, gelieve dit niet te doen.");

                    }
                }
            }
        }

        public string VoorNaam
        {
            get { return voorNaam; }
            set
            {
                if (value == "")
                {
                    throw new DatabaseException("The chosen name is empty!" + Environment.NewLine + "Please try again.");

                }
                else
                {
                    string pattern = @"^[a-zA-Z&àáâäãåąčćęèéêëėįìíîïłńòóôöõøùúûüųūÿýżźñçčšžÀÁÂÄÃÅĄĆČĖĘÈÉÊËÌÍÎÏĮŁŃÒÓÔÖÕØÙÚÛÜŲŪŸÝŻŹÑßÇŒÆČŠŽ∂ð ]+$";
                    if (Regex.IsMatch(value, pattern))
                    {
                        voorNaam = value;
                    }
                    else
                    {
                        throw new DatabaseException("U heeft verboden characters ingegeven voor de naam, gelieve dit niet te doen.");

                    }
                }
            }
        }

        public string Mail
        {
            get { return mail; }
            set
            {
                if (value.Trim() == "")
                {
                    throw new DatabaseException("Het email-adres is leeg.");
                }
                else
                {
                    mail = value;

                    //Deze setter hieronder staat in comment omdat de email reeds gecontroleerd wordt door IdentityUser met een officiële check of het een correcte mail is.

                    ////@"^([a-zA-Z0-9_-.]+)@(([[0-9]{1,3}.[0-9]{1,3}.[0-9]{1,3}.)|(([a-zA-Z0-9-]+.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(]?)$"
                    ////@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$"
                    //string pattern = @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$";
                    //if (Regex.IsMatch(value, pattern))
                    //{
                    //    mail = value;
                    //}
                    //else
                    //{
                    //    throw new DatabaseException("Het email-adres heeft een verkeerd formaat of een verkeerd character. Gelieve een deftig email-adres in te geven.");

                    //}

                }
            }
        }

        [Key]
        public string Userid
        {
            get { return userid; }
            set
            {
                if (value == "")
                {
                    throw new DatabaseException("Deze user id is leeg.");

                }
                else
                {
                    string pattern = @"^[crusmx]\d{7}$";

                    if (Regex.IsMatch(value, pattern))
                    {
                        userid = value;
                    }
                    else
                    {
                        throw new DatabaseException("Deze user id heeft verbode characters, of is te lang! Probeer opnieuw.");

                    }
                }
            }
        }
    }
}
