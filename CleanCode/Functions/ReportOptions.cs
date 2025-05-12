using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Functions
{
    public class ReportOptions
    {
        /*
         * string title, bool isColor, bool isIcludeGraphs, List<string> Authors, List<object> ExtraData
         */

        public string Title { get; set; }
        public bool IsColor { get; set; }
        public bool IsIncludeGraphs { get; set; }
        public List<string> Authors { get; set; }
        public List<object> ExtraData { get; set; }
    }
}
