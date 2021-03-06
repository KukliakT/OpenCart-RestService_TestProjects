﻿using System;

namespace Rest414Test.Data
{
    public class CoolDownTime
    {
        public string Time { get; set; }

        public CoolDownTime()
        {
            Time = String.Empty;
        }

        public CoolDownTime(string time)
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
                || (!(obj is CoolDownTime)))
            {
                result = false;
            }
            else
            {
                result = Time.Equals((obj as CoolDownTime).Time);
            }
            return result;
        }
    }
}

