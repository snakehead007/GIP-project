﻿using System;
using System.Collections.Generic;
using Gip.Models.Exceptions;
using System.Text.RegularExpressions;

namespace Gip.Models
{
    public partial class Course
    {
        public Course()
        {
            CourseMoment = new HashSet<CourseMoment>();
            CourseUser = new HashSet<CourseUser>();
        }
        public Course(string vakcode, string titel, int studiepunten)
        {
            this.Vakcode = vakcode;
            this.Titel = titel;
            this.Studiepunten = studiepunten;
        }

        public virtual ICollection<CourseMoment> CourseMoment { get; set; }
        public virtual ICollection<CourseUser> CourseUser { get; set; }

        private string vakcode;
        public string Vakcode
        {
            get { return vakcode; }
            set
            {
                if (value.Trim() == "")
                {
                    throw new DatabaseException("U heeft een lege vakcode meegegeven.");
                }
                else
                {
                    string pattern = @"^[a-zA-Z]{0,3}\d\d[a-zA-Z]$";
                    if (Regex.IsMatch(value, pattern))
                    {
                        vakcode = value;
                    }
                    else
                    {
                        throw new DatabaseException("je hebt een foutief formaat van vakcode of een ongeldig character ingegeven. Gelieve een vakcode van het formaat AAA11A in te geven");
                    }
                }
            }
        }

        private string titel;
        public string Titel
        {
            get { return titel; }
            set
            {
                if (value.Trim() == "")
                {
                    throw new DatabaseException("De titel mag niet leeg zijn.");

                }
                else
                {
                    string pattern = @"[\\\/\<\>\;]";
                    if (Regex.IsMatch(value, pattern))
                    {
                        throw new DatabaseException("U heeft een verboden character ingegeven, gelieve dit niet te doen.");
                    }
                    else
                    {
                        titel = value;
                    }
                }
            }
        }

        private int studiepunten;

        public int Studiepunten
        {
            get { return studiepunten; }
            set
            {
                if (value <= 0)
                {
                    throw new DatabaseException("Het aantal studiepunten mag niet negatief zijn.");

                }
                else if (value > 60)
                {
                    throw new DatabaseException("Het aantal studiepunten mag niet hoger zijn dan 60.");
                }
                else
                {
                    string pattern = @"^\d$";
                    if (Regex.IsMatch(value.ToString(), pattern))
                    {
                        studiepunten = value;
                    }
                    else
                    {
                        throw new DatabaseException("U heeft een verboden character ingegeven, gelieve dit niet te doen.");
                    }
                }
            }
        }
    }
}
