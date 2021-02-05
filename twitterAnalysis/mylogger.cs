using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using System.Text;
using twitterAnalysis.BAL;

namespace twitterAnalysis
{
    public class mylogger
    {
        private static string logFile;


        /// <summary>
        /// zdefult constructor creates a activity folder and file in the Current working directory
        /// </summary>
        mylogger()
        {
            logFile = Directory.GetCurrentDirectory() + "\\activity\\.log";
        }

        /// <summary>
        /// Constructor with logfile parameter created a logfile in the targeted directory
        /// </summary>
        /// <param name="logfile"></param>
        mylogger(string logfile) { logFile = logfile; }


        public static async Task logMessage(string message)
        {
            
            if(string.IsNullOrEmpty(message))
            {
                //Do not attempt to log empty message
                return;
            }
            try
            {
                using (var fileStream = File.Open(logFile, FileMode.OpenOrCreate, FileAccess.Write, FileShare.ReadWrite))
                {
                    using (var streamWriter = new StreamWriter(fileStream, Encoding.UTF8))
                    {
                        await logTofile(streamWriter, message);
                    }
                }
                    
            }
            catch
            {
                // Error writing to file
                Console.WriteLine("Error writing to Log");
            }

        }

        private static Task<int> logTofile(StreamWriter streamWriter, string message)
        {
            int returnstatus =  0;
            streamWriter.WriteLine(message);
            return Task.FromResult(returnstatus);
        }


        /// <summary>
        /// Method: LogAllData
        /// Parameters: None
        /// Function: Returns a string array of results ( Note the requirement does not require output to data store
        /// Author: Lawrence Butler
        /// </summary>
        /// <returns></returns>
        public static Task<List<string>> LogAllData()
        {
            List<string> datas = new List<string>();

            datas.Add(new string("Number of Tweets : " + processStreamData.numberofTweets));
            datas.Add(new string("Number of Tweets with URL  : " + processStreamData.numberofTweetsWitlURL));
            datas.Add(new string("Percent Tweets with Emojis : " + processStreamData.percentofTweetsWithEmojis));
            datas.Add(new string("Percent Tweets with Photo URL  : " + processStreamData.percentofTweetsWithPhotoURL));
            datas.Add(new string("Top Domains in Tweets : " + processStreamData.topDomainURL));
            datas.Add(new string("Top Emoji in Tweets  : " + processStreamData.topEmoji));
            datas.Add(new string("Top Hash Tags : " + processStreamData.toptopHashTags));


            return Task.FromResult(datas);
        }
    }
}
