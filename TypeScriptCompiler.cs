using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CoffeeEditor
{
    public class TypeScriptCompiler : ICompiler
    {
        public string Complie(string coffeText)
        {
            string javaScriptText;
            string tempFile = Path.Combine(Directory.GetCurrentDirectory(), Guid.NewGuid() + "temp");
            string tempTsFile = tempFile + ".ts";
            string tempJsFile = tempFile + ".js";
            try
            {
                File.WriteAllText(tempTsFile, coffeText);
                var output = ExeRunner.Execute(Helper.GetCoffeePath(), tempTsFile);

                if(!string.IsNullOrEmpty( output ))
                {
                    throw new CompileException(output);
                }

                javaScriptText = File.ReadAllText(tempJsFile);
                File.Delete(tempTsFile);
                File.Delete(tempJsFile);
            }
            catch (ExeExecutionException ex)
            {
                throw new CompileException(ex.ExeErrorMessage);
            }

            return javaScriptText;
        }

    }
}
