using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LX.TestPad.Business.Interfaces
{
    public interface IEncoder
    {
        public string Encode(string input);
        public string Decode(string input);
    }
}
