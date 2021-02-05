using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using twitterAnalysis.interfaces;

namespace twitterAnalysis.BAL
{
    //   https://dotnettutorials.net/lesson/dependency-injection-design-pattern-csharp/


    public class readTwitterSampleData : ITwitterSampleData, ItwitterSampleDataValue
    {

        public ITwitterSampleData twitterSampleData;
        public List<string> datas = new List<string>();

        public readTwitterSampleData(ITwitterSampleData twitterSampleData)
        {
            this.twitterSampleData = twitterSampleData;
        }

        public int getResult()
        {
            ////
            //int hasURLs = 0;
            //int hasEmojis = 0;
            //int hasPhotos = 0;

            //datas.ForEach((item) =>
            //    {
            //        hasPhotos += (item.Contains('$')) ? 1 : 0;
            //        hasEmojis += (item.Contains('@')) ? 1 : 0;
            //        hasURLs += (item.Contains("http")) ? 1 : 0;
            //    }
            //);


            return this.twitterSampleData.getResult();

        }

        public async Task<int> logData(string str)
        {
            //await Console.WriteLine(DateTime.Now.ToLocalTime() + "   " + str);
            List<string> currentResults = await mylogger.LogAllData();

            return 1;

        }

        public string getValue()
        {
            return null;
        }
    }
}