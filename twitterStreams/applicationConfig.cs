using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.IO;

namespace twitterData
{
    class applicationConfig
    {
        private Dictionary<string,string> appSettings = new Dictionary<string,string>();
        private string applicationDirectory;

        public applicationConfig(string currentdirectory)
        {
            applicationDirectory = currentdirectory;
            readConfiguration();
        }

        private void readConfiguration()
        {
            string line;
            string workingDirectory = applicationDirectory + @"\settings.txt";

            bool fileexists = File.Exists(workingDirectory);
            try
            {
                using (StreamReader file = new StreamReader(workingDirectory))
                {
                    while ((line = file.ReadLine()) != null)
                    {
                        if (string.IsNullOrEmpty(line))
                            continue;
                        string[] data = line.Split('=');
                        appSettings.Add(data[0], data[1]);
                    }
                }
            }
            catch
            {
                Console.WriteLine("Error accessing file [{0}]", workingDirectory);
            }

        }
        public Dictionary<string,string> getAppSettings()
        {
            return appSettings;
        }
    }
}
