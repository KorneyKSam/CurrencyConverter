using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyConverter.CustomExceptions
{
    class FileJsonNotFound : Exception
    {
        public override string Message => "Файл JSON не существует";
    }
}
