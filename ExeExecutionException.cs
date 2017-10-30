using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeEditor
{
    public class ExeExecutionException : Exception
    {
       
        public ExeExecutionException(string exeErrorMessage, string exePath, string exeParameters)
            : base(
                "Error:" + exeErrorMessage + Environment.NewLine + " Exe:" + exePath + Environment.NewLine
                + " Exe Parameters :" + exeParameters)
        {
            ExeErrorMessage = exeErrorMessage;
            ExePath = exePath;
            ExeParameters = exeParameters;
        }

        /// <summary>
        /// Gets the exe error message.
        /// </summary>
        public string ExeErrorMessage { get; private set; }

        /// <summary>
        /// Gets the exe path.
        /// </summary>
        public string ExePath { get; private set; }

        /// <summary>
        /// Gets the exe parameters.
        /// </summary>
        public string ExeParameters { get; private set; }
    }
}
