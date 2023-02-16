using LX.TestPad.Business.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LX.TestPad.Business.Services
{
    public class Encoder : IEncoder
    {
        public string Decode(string input)
        {
            byte[] inputBytes = Convert.FromBase64String(input);
            return Encoding.UTF8.GetString(inputBytes);
        }
        public string Encode(string input)
        {
            byte[] inputBytes = Encoding.UTF8.GetBytes(input);
            return Convert.ToBase64String(inputBytes);
        }
    }
}
