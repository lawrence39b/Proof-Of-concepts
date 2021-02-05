using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using twitterAnalysis.BAL;
using twitterAnalysis.requests;
using LinqToTwitter;
using LinqToTwitter.OAuth;
using System.Threading;
using Newtonsoft.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

//https://www.code-sample.com/2020/07/consume-rest-api-in-net-using-httpclient.html
//https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/async/task-asynchronous-programming-model


namespace twitterAnalysis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class twitterController : ControllerBase
    {
        System.Threading.Timer Timer;
        bool CloseTimer = false;
        private static int displayResults = 0;
        // GET: api/<twitterController>
        [Route("totals")]
        [HttpGet]
        public IEnumerable<string> Get()
        {
            try
            {
                //The following three lines will stop to processing of the twitter Stream
                // This would be moved to another request however for this purpose we stop
                // the processing here
                if (Timer != null)
                    Timer.Dispose();
                CloseTimer = true;
            }
            catch
            {
                //
            }

            var response = processStreamData.analizeData().ToList<string>();

            return response;

        }


        [Route("stop")]
        [HttpGet]
        public string Stop()
        {
            if (Timer != null)
                Timer.Dispose();
            CloseTimer = true;
            return "Processing of Twitter Stream has been stopped by client.";
        }

        [Route("start")]
        [HttpGet]
        public string start()
        {
            //Start a timer to run every half second
            Timer = new Timer(tally, null, 1000, 500);

            //processStreamData.Instance.readTweetData();

            return "Processing Twitter Stream...";
        }


       

        // method to tally twitter data
        private void tally(object state)
        {
            //getTweets();
            processStreamData.Instance.readTweetData(displayResults);

            if (CloseTimer)
            {
                processStreamData.Instance.RESET();
                Timer.Dispose();
            }
        }

        //public static async Task<string>  GetTwitterData(string authorization)
        //{
        //    string status = "Okay";

        //    using (var client = new HttpClient())
        //    {
        //        client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", authorization);

        //        string req1 = "https://api.twitter.com/2/tweets/sample/stream?tweet.fields=created_at&expansions=author_id&user.fields=created_at";

        //        try
        //        {
        //            client.BaseAddress = new Uri("https://api.twitter.com/");
        //            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                 

        //            HttpResponseMessage response = new HttpResponseMessage();

        //            response = await client.GetAsync(req1).ConfigureAwait(false);

        //            if (response.IsSuccessStatusCode)
        //            {
        //                //Read response
        //                var stat = response.Content.ReadAsStringAsync();
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            status = ex.Message + "; " + ex.InnerException;
        //        }
        //    }

        //    return status;
        //}

        //public static async Task<string> GetInfo(string authorizationToken)
        //{
        //    string responseObj = string.Empty;

        //    using(var client = new HttpClient())
        //    {
        //        try
        //        { 
        //            string authorization = authorizationToken;
        //            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", authorization);

        //            client.BaseAddress = new Uri("https://api.twitter.com/2/tweets/sample/stream/");
        //            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

        //            HttpResponseMessage response = new HttpResponseMessage();

        //            response = await client.GetAsync("https://api.twitter.com/2/tweets/sample/stream/");//.ConfigureAwait(false);

        //            if (response.IsSuccessStatusCode)
        //            {
        //                //Read response
        //                var res = response.Content.ReadAsStringAsync();
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            responseObj = "Error: " +ex.Message;
        //        }
        //    }

        //    return responseObj;
        //}

    }
}
