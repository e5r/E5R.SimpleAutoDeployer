using System;

namespace E5R.SimpleAutoDeployer.Tasks
{
    public class Log
    {
        public DateTime Started { get; set; }
        public DateTime Finished { get; set; }
        public String OutputText { get; set; }
        public String OutputFilePath { get; set; }
        public String OutputFileName { get; set; }
    }
}
