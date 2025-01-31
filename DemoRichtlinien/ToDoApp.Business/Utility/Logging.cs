using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace ToDoApp.Business.Utility
{
    public static class Logging
    {
        public static void WriteLog(string myMessage)
        {
            string myPath = @"ToDoLogging.txt";
            string myText = DateTime.Now.ToString("dd.MM.yyyy-HH:mm:ss") + " - " + myMessage + "\r\n";

            if (File.Exists(myPath))
                File.AppendAllText(myPath, myText);
            else
                File.WriteAllText(myPath, myText);

        }

    }
}
