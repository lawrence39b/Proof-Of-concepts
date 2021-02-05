//using Microsoft.AspNetCore.Mvc;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Net.Http;
//using System.Threading.Tasks;
//using twitterAnalysis.BAL;
//using twitterAnalysis.requests;
//using LinqToTwitter;
//using LinqToTwitter.OAuth;

//// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

////https://www.code-sample.com/2020/07/consume-rest-api-in-net-using-httpclient.html
////https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/async/task-asynchronous-programming-model



//namespace twitterAnalysis.Controllers2
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class twitterController : ControllerBase
//    {
//        // GET: api/<twitterController>
//        [HttpGet]
//        public IEnumerable<string> Get()
//        {
//            analizeData();
//            return new string[] { "value1", "value2" };
//        }

//        public void analizeData() 
//        {
//            //Create instance of classes that aggregate data 
//            averageTweets avgt = new averageTweets();
//            numberofTweets noftws = new numberofTweets();
//            percentTweetsWithEmojis ptwemo = new percentTweetsWithEmojis();
//            percentTweetsWithPhotoURL withphotourl = new percentTweetsWithPhotoURL();
//            percentTweetsWithURL withurl = new percentTweetsWithURL();

//            // Dependancy injection via Constructor
//            readTwitterSampleData rawAverageTweets = new readTwitterSampleData(avgt);
//            readTwitterSampleData rawNumberOfTweets = new readTwitterSampleData(noftws);
//            readTwitterSampleData rawTweetsWithEmojis = new readTwitterSampleData(ptwemo);
//            readTwitterSampleData rawTweetsWithPhotoURLs = new readTwitterSampleData(withphotourl);
//            readTwitterSampleData rawTweetsWithURLSs = new readTwitterSampleData(withurl);

//            // Execute getResult() method via dependancy 
//            int agvtweets = rawAverageTweets.getResult();
//            int numberOfTweets = rawNumberOfTweets.getResult();
//            int tweetsWithEmojies = rawTweetsWithEmojis.getResult();
//            int percenttweetsWithEmojis = rawTweetsWithEmojis.getResult();
//            int percenttweetsWithPhotoURLS = rawTweetsWithPhotoURLs.getResult();
//            int percenttweetsWithURLs = rawTweetsWithURLSs.getResult();

//            //Write data to console
//            Console.WriteLine("Average Tweets: " + agvtweets.ToString() + Environment.NewLine);
//            Console.WriteLine("Number of Tweets: " + numberOfTweets.ToString() + Environment.NewLine);
//            Console.WriteLine("Number of Tweets with Emojis: " + tweetsWithEmojies.ToString() + Environment.NewLine);

//            Console.WriteLine("Percent of Tweets with Emojis: " + percenttweetsWithEmojis.ToString() + Environment.NewLine);
//            Console.WriteLine("Percent of Tweets with Photo URLs: " + percenttweetsWithPhotoURLS.ToString() + Environment.NewLine);
//            Console.WriteLine("Percent of Tweets with URLs: " + percenttweetsWithURLs.ToString() + Environment.NewLine);
//        }

//        [HttpGet("{id}")]
//        public string Get(int id)
//        {
//            getTweets();
//            //https://docs.microsoft.com/en-us/dotnet/csharp/tutorials/console-webapiclient
//            /*
//             * 
//             * curl -X GET -H "Authorization: Bearer $BEARER_TOKEN" "https://api.twitter.com/2/tweets/sample/stream"
//             */

//            readTwitterSampleData rtd = new readTwitterSampleData(new averageTweets());

//            //GET CALL
//            ///  https://developer.twitter.com/en/docs/twitter-api/tweets/sampled-stream/api-reference/get-tweets-sample-stream
//            //string apiURL = "https://api.twitter.com/2/tweets/sample/stream/";
//            string apiURL2 = "https://api.twitter.com/2/tweets/sample/stream?access_token=30866005-mvyQ0xgrjOcfIGm0Klj7itwXGaUSGgdPuG0OK5NBO";

//            UriBuilder builder = new UriBuilder(apiURL2);
//            //builder.Query = "Username=" + encriptedUserLogin + "&Password=" + encriptedPwd + "";

//            Request.Headers.Add("Authorization", "Bearer AAAAAAAAAAAAAAAAAAAAADLTMAEAAAAAqRNEg3SU3fBfEEbaM2OG1eIzLW0%3DDAC1JVlpggYtNHdhI6ZJz1lL4dypCX5X5Qg6xmMeGGDdway3OF");
//            //Request.Headers.Add("Bearer", "AAAAAAAAAAAAAAAAAAAAADLTMAEAAAAAqRNEg3SU3fBfEEbaM2OG1eIzLW0%3DDAC1JVlpggYtNHdhI6ZJz1lL4dypCX5X5Qg6xmMeGGDdway3OF");

//            Request.Headers.Add("Access_Token", "AAAAAAAAAAAAAAAAAAAAADLTMAEAAAAAqRNEg3SU3fBfEEbaM2OG1eIzLW0%3DDAC1JVlpggYtNHdhI6ZJz1lL4dypCX5X5Qg6xmMeGGDdway3OF");

//            var response1 = "ABC";
//            //var response1 = GetInfo("AAAAAAAAAAAAAAAAAAAAADLTMAEAAAAAqRNEg3SU3fBfEEbaM2OG1eIzLW0%3DDAC1JVlpggYtNHdhI6ZJz1lL4dypCX5X5Qg6xmMeGGDdway3OF");


//          //  var response2 =  GetTwitterData("AAAAAAAAAAAAAAAAAAAAADLTMAEAAAAAqRNEg3SU3fBfEEbaM2OG1eIzLW0%3DDAC1JVlpggYtNHdhI6ZJz1lL4dypCX5X5Qg6xmMeGGDdway3OF");

//            using (var client = new HttpClient())
//            {
//                //HttpResponseMessage response = client.GetAsync(builder.Uri).Result;
//                var response = client.GetStringAsync(builder.Uri);

//                //if (response.IsSuccessStatusCode)
//                //{
//                //    //var response2 = GetTwitterData("AAAAAAAAAAAAAAAAAAAAADLTMAEAAAAAqRNEg3SU3fBfEEbaM2OG1eIzLW0%3DDAC1JVlpggYtNHdhI6ZJz1lL4dypCX5X5Qg6xmMeGGDdway3OF");
//                //    //curl https://api.twitter.com/2/tweets/sample/stream -H "Authorization: Bearer $BEARER_TOKEN"
//                //    var x1 = response.Content.ReadAsStringAsync().Result;

//                //    //UserModel userResult = response.Content.ReadAsAsync<UserModel>().Result;
//                //}
//            }

//            return response1.ToString();
//            //return "Testing...";
        
//        }
//        private static SingleUserAuthorizer authorizer = new SingleUserAuthorizer
//        {
//            CredentialStore = new SingleUserInMemoryCredentialStore
//            {
//                ConsumerKey = "IpP3rk9RyEgYtVUyCHmHLA5NT",
//                ConsumerSecret = "Ss40pkG2CxMLu2WlYiDKS78pQHv7wjYN8ipvQggaOC5k21InxL",
//                AccessToken = "30866005-qMWa5UUZQH1b3VEXEspAMgT0zbe2PlqQTNEEK1aZN",
//                AccessTokenSecret = "Y5bAallEdBhhSpktpQ94lJriKCzcbZR8rLcLkaiKizBE9"
//            }
//        };
    

//        public List<Status> getTweets ()
//        {
//            string tweetURL = "https://api.twitter.com/2/tweets/sample/stream/";
//            var twitterContext = new TwitterContext(authorizer);
//           List<Status> results = new List<Status>();
//            var tweets = from tweet in twitterContext.Status where tweet.Type == StatusType.Home  select tweet;
//            results = tweets.Select(t => t).ToList();

//            //from tweet in twitterContext.Status where tweet.Type == StatusType.Home  select twee



//            //tweets.ToList().ForEach(t =>  results.Add(text));

//            return results;
//        }


//        public static async Task<string>  GetTwitterData(string authorization)
//        {
//            string status = "Okay";

//            using (var client = new HttpClient())
//            {
//                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", authorization);

//                string req1 = "https://api.twitter.com/2/tweets/sample/stream?tweet.fields=created_at&expansions=author_id&user.fields=created_at";

//                try
//                {
//                    client.BaseAddress = new Uri("https://api.twitter.com/");
//                    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                 

//                    HttpResponseMessage response = new HttpResponseMessage();

//                    response = await client.GetAsync(req1).ConfigureAwait(false);

//                    if (response.IsSuccessStatusCode)
//                    {
//                        //Read response
//                        var stat = response.Content.ReadAsStringAsync();
//                    }
//                }
//                catch (Exception ex)
//                {
//                    status = ex.Message + "; " + ex.InnerException;
//                }
//            }

//            return status;
//        }

//        public static async Task<string> GetInfo(string authorizationToken)
//        {
//            string responseObj = string.Empty;

//            using(var client = new HttpClient())
//            {
//                try
//                { 
//                    string authorization = authorizationToken;
//                    client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", authorization);

//                    client.BaseAddress = new Uri("https://api.twitter.com/2/tweets/sample/stream/");
//                    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

//                    HttpResponseMessage response = new HttpResponseMessage();

//                    response = await client.GetAsync("https://api.twitter.com/2/tweets/sample/stream/");//.ConfigureAwait(false);

//                    if (response.IsSuccessStatusCode)
//                    {
//                        //Read response
//                        var res = response.Content.ReadAsStringAsync();
//                    }
//                }
//                catch (Exception ex)
//                {
//                    responseObj = "Error: " +ex.Message;
//                }
//            }

//            return responseObj;
//        }

//    }
//}
