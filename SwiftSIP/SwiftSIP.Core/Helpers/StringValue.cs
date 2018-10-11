using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SoftPhone.Core.Helpers
{
    public class StringValue : System.Attribute
    {
        private readonly string _value;

        public StringValue(string value)
        {
            _value = value;
        }

        public string Value
        {
            get { return _value; }
        }

    }
}