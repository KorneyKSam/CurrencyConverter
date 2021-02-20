using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyConverter.CustomExceptions
{
    class CurrencyNotFound : Exception
    {
        public override string Message => "В списке нет такой валюты";
    }
}
