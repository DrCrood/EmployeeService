using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextParser
{
    public class Parser
    {
        public char Delimiter { get; set; }
        public bool SetDelimiter(string line)
        {
            try
            {
                if (line.Contains('|'))
                {
                    this.Delimiter = '|';
                }
                else if (line.Contains(','))
                {
                    this.Delimiter = ',';
                }
                else
                {
                    this.Delimiter = ' ';
                }
                return true;
            }
            catch(Exception)
            {
                return false;
            }
        }
    }
}
