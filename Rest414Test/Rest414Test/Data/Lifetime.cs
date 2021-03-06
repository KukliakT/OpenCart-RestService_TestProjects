﻿using System;

namespace Rest414Test.Data
{
    public class Lifetime
    {
        public string Time { get; set; }

        public Lifetime()
        {
            Time = String.Empty;
        }

        public Lifetime(string time)
        {
            Time = time;
        }

        public override bool Equals(object obj)
        {
            bool result = false;
            if (this == obj)
            {
                result = true;
            }
            else if ((obj == null)
                || (!(obj is Lifetime)))
            {
                result = false;
            }
            else 
            {
                result = Time.Equals((obj as Lifetime).Time);
            }
            return result;
        }

        public override string ToString()
        {
            return "Lifetime: [ Time = " + Time + " ];";
        }
    }
}
