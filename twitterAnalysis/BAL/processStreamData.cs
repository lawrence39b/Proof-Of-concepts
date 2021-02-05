using LinqToTwitter;
using LinqToTwitter.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using twitterAnalysis.requests;

namespace twitterAnalysis.BAL
{
    //Singletom patterned class to collect totals
    /// <summary>
    /// Singleton patterened class used to hold counts and dynamic data that will be accessed by other 
    /// Module: processStreamData.cs
    /// class object.
    /// Author : Lawrence Butler
    /// Date 01/31/2021
    /// 
    /// </summary>
    public sealed class processStreamData
    {
        processStreamData()
        {
            //counttimer = new CountTimer();
        }
        private static readonly object mylock = new object();
        private static processStreamData instance = null;
        public static int numberofTweets;
        public static int numberofTweetsWitlURL;
        public static int percentofTweetsWithURL;
        public static double percentofTweetsWithEmojis;
        public static double percentofTweetsWithPhotoURL;
        public static int percentofTweetsWitlPhotoURL;
        public static string topDomainURL;
        public static string topEmoji;
        public static List<string> toptopHashTags;
        //
        public static int tweetsPerSecond;
        public static int tweetsPerMinute;
        public static int tweetsPerHour;

        //Date Time 
        DateTime startDateTime = DateTime.Now;

        public static processStreamData Instance
        {
            get
            {
                lock (mylock)
                {
                    if (instance == null)
                    {
                        instance = new processStreamData();
                    }
                    return instance;
                }
            }
        }

        private static SingleUserAuthorizer authorizer = new SingleUserAuthorizer
        {
            CredentialStore = new SingleUserInMemoryCredentialStore
            {
                ConsumerKey = "IpP3rk9RyEgYtVUyCHmHLA5NT",
                ConsumerSecret = "Ss40pkG2CxMLu2WlYiDKS78pQHv7wjYN8ipvQggaOC5k21InxL",
                AccessToken = "30866005-qMWa5UUZQH1b3VEXEspAMgT0zbe2PlqQTNEEK1aZN",
                AccessTokenSecret = "Y5bAallEdBhhSpktpQ94lJriKCzcbZR8rLcLkaiKizBE9"
                //, UserID = 19977010
            }
        };

        public void readTweetData(int displayResults=0)
        {
            List<Status> results = new List<Status>();

            try
            {
                //string tweetURL = "https://api.twitter.com/2/tweets/sample/stream/";
                //string tweetURL2 = "https://api.twitter.com/2/tweets/sample/stream?tweet.fields=attachments";

                
                var twitterContext = new TwitterContext(authorizer);

                //List<Status> results = new List<Status>();
                var tweets = from tweet in twitterContext.Status where tweet.Type == StatusType.Home select tweet;
                results = tweets.Select(t => t).ToList();

                //Number of Tweets
                tallyNumberOfTweets(results.Count);

                //Tweets With URLs
                List<Status> tweetsWithURL = results.Where(t => t.Text.Contains("http")).ToList();
                tallyTweetsWithURL(tweetsWithURL.Count);

                //percent tweets with URL
                calculatePercenttewwtswithURL(tweetsWithURL.Count, results.Count);


                //List<TweetQuery> tttttt = twitterContext.Tweets.ToList<TweetQuery>();


                //List<Status> t2 = (List<Status>)tweets.Where(t => t.Text.Contains("http"));

                //from tweet in twitterContext.Status where tweet.Type == StatusType.Home  select twee
                List<Status> results2 = new List<Status>();
                var tweets2 = from tweet in twitterContext.Status where tweet.Type == StatusType.Mentions select tweet;
                results2 = tweets2.Select(t => t).ToList();


                List<Status> results3 = new List<Status>();
                var tweets3 = from tweet in twitterContext.Status where tweet.Type == StatusType.User select tweet;
                results3 = tweets3.Select(t => t).ToList();


                //Time Deltas
                DateTime curent = DateTime.Now;
                TimeSpan timespan = curent.Subtract(startDateTime);

                //Calculate Counts
                tweetsPerSecond = numberofTweets / timespan.Seconds;
                tweetsPerMinute = (timespan.Minutes <= 0) ? numberofTweets : (numberofTweets / timespan.Minutes);
                tweetsPerHour = (timespan.Hours <= 0) ? numberofTweets : numberofTweets / timespan.Hours;


                if (displayResults==2)
                {
                    // Output stored in memory object
                    var output_data = analizeData();
                }
                mylogger.LogAllData();
            }
            catch(Exception ex)
            {
                var error = ex.Message + " " + ex.InnerException;
                //RESET();
                return;
            }

            //tweets.ToList().ForEach(t =>  results.Add(text));

            processStreamData processor = processStreamData.Instance;
            processor.tallyNumberOfTweets(results.Count);


            processStreamData processor2 = processStreamData.Instance;
            processor2.tallyNumberOfTweets(10);
        }

        private void calculatePercenttewwtswithURL(int count1, int count2)
        {
            if (count2 <= 0)
                return;
            percentofTweetsWithURL = (count1 / count2);
        }

        public void  tallyNumberOfTweets(int num)
        {
            numberofTweets += num;
        }

        public void tallyTweetsWithURL(int num)
        {
            numberofTweetsWitlURL += num;
        }


        public static string[] analizeData()
        {
            //Create instance of classes that aggregate data 
            averageTweets avgt = new averageTweets();
            numberofTweets noftws = new numberofTweets();
            percentTweetsWithEmojis ptwemo = new percentTweetsWithEmojis();
            percentTweetsWithPhotoURL withphotourl = new percentTweetsWithPhotoURL();
            percentTweetsWithURL withurl = new percentTweetsWithURL();

            // Dependancy injection via Constructor
            readTwitterSampleData rawAverageTweets = new readTwitterSampleData(avgt);
            readTwitterSampleData rawNumberOfTweets = new readTwitterSampleData(noftws);
            readTwitterSampleData rawTweetsWithEmojis = new readTwitterSampleData(ptwemo);
            readTwitterSampleData rawTweetsWithPhotoURLs = new readTwitterSampleData(withphotourl);
            readTwitterSampleData rawTweetsWithURLSs = new readTwitterSampleData(withurl);

            // Execute getResult() method via dependancy 
            int numberOfTweets = rawNumberOfTweets.getResult();
            int tweetsWithEmojies = rawTweetsWithEmojis.getResult();
            int percenttweetsWithEmojis = rawTweetsWithEmojis.getResult();
            int percenttweetsWithPhotoURLS = rawTweetsWithPhotoURLs.getResult();
            int percenttweetsWithURLs = rawTweetsWithURLSs.getResult();

            //Write data to console
            Console.WriteLine("Number of Tweets: " + numberOfTweets.ToString() + Environment.NewLine);
            Console.WriteLine("Number of Tweets with Emojis: " + tweetsWithEmojies.ToString() + Environment.NewLine);

            Console.WriteLine("Percent of Tweets with Emojis: " + percenttweetsWithEmojis.ToString() + Environment.NewLine);
            Console.WriteLine("Percent of Tweets with Photo URLs: " + percenttweetsWithPhotoURLS.ToString() + Environment.NewLine);
            Console.WriteLine("Percent of Tweets with URLs: " + percenttweetsWithURLs.ToString() + Environment.NewLine);

            //Calculations 
            double percentwithEmojis = (numberOfTweets > 0) ? ((double)tweetsWithEmojies / (double)numberOfTweets) : 0.0;
            double percentwithphotos = (numberOfTweets > 0) ? ((double)percenttweetsWithPhotoURLS / (double)numberOfTweets) : 0.0;

            string[] st1 = new string[] {
                "Number of Tweets: " + numberOfTweets.ToString(),
                "Number of Tweets with Emojis: " + tweetsWithEmojies.ToString(),
                "Percent of Tweets with Emojis: " + percentwithEmojis.ToString(),
                "Percent of Tweets with Photo URLs: " + percentwithphotos.ToString(),
                "Percent of Tweets with URLs: " + percenttweetsWithURLs.ToString(),
                "Tweets per Second: " + tweetsPerSecond,
                "Tweets per Minute: " + tweetsPerMinute,
                "Tweets per Hour: " + tweetsPerHour
                };

            return st1;
        }

        public void RESET()
        {
            numberofTweets = 0;
            numberofTweetsWitlURL = 0;
            percentofTweetsWithEmojis = 0.0;
            percentofTweetsWitlPhotoURL =0;
            topDomainURL ="";
            topEmoji = "";
            toptopHashTags = null;
            tweetsPerSecond = 0;
            tweetsPerMinute = 0;
            tweetsPerHour = 0;
    }
    }

}