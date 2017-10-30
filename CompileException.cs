using System;

namespace CoffeeEditor
{
    public class CompileException : Exception
    {
        public CompileException(string exeErrorMessage)
            : base(
                "Error:" + exeErrorMessage)
        {
            ExeErrorMessage = exeErrorMessage;
        }

        /// <summary>
        /// Gets the exe error message.
        /// </summary>
        public string ExeErrorMessage { get; private set; }
    }
}

