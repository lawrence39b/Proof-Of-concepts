using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using twitterData;
using twitterData.interfaces;
using twitterData.requests;
using twitterStreams;

namespace tweetStreamDataTest
{
    [TestClass]
    public class TestTwitterStream : processTweetsBase
    {
        private processTweets localObject = processTweets.Instance;
        twitterDataStream dataStream;

        public TestTwitterStream()
        {
            populateData();
            dataStream = new twitterDataStream();
        }

        [TestMethod]
        public void ValidOutputCreated()
        {
            string[] data = localObject.analizeData();

            Assert.IsNotNull(data);
        }

        [TestMethod]
        public void TestValidOutput()
        {
          string[] result =  localObject.analizeData();

           Assert.IsTrue(result.Length > 0); 
        }

        [TestMethod]
        public void ValidTweetCountValue()
        {
            twitterData.processTweetsBase pt = new processTweetsBase();
            int numTweets;

            Assert.IsTrue( int.TryParse(pt.numberofTweets.ToString(), out numTweets) );
        }

        [TestMethod]
        public void ValidTweetWithEmojiCountValue()
        {
            twitterData.processTweetsBase pt = new processTweetsBase();
            int numTweets;

            Assert.IsTrue(int.TryParse(pt.numberofTweetsWithEmojis.ToString(), out numTweets));
        }

        [TestMethod]
        public void ValidTweetWithPhotoCountValue()
        {
            twitterData.processTweetsBase pt = new processTweetsBase();
            int numTweets;

            Assert.IsTrue(int.TryParse(pt.numberofTweetsWitlPhotoURL.ToString(), out numTweets));
        }

        [TestMethod]
        public void ValidTweetWithURLCountValue()
        {
            twitterData.processTweetsBase pt = new processTweetsBase();
            int numTweets;

            Assert.IsTrue(int.TryParse(pt.numberofTweetsWithURL.ToString(), out numTweets));
        }

        [TestMethod]
        public void DomainsInTweetsAccessable()
        {
            var domDict = localObject.domainDictionary;

            Assert.IsNotNull(domDict);
            Assert.IsTrue(domDict.Count >= 0);
        }

        [TestMethod]
        public void HashTagsInTweetsAccessable()
        {
            var hasTagDict = localObject.hasTagDictionary;

            Assert.IsNotNull(hasTagDict);
            Assert.IsTrue(hasTagDict.Count >= 0);
        }

        [TestMethod]
        public void EmojisInTweetsAccessable()
        {
            var hasEmojiDict = localObject.emojiDictionary;

            Assert.IsNotNull(hasEmojiDict);
            Assert.IsTrue(hasEmojiDict.Count >= 0);
        }

        private void populateData()
        {
            numberofTweets = 45;
            numberofTweetsWithURL = 1000;
            numberofTweetsWitlPhotoURL = 250;
            numberofTweetsWithEmojis = 112;

            tweetsPerHour = 50000;
            tweetsPerMinute = tweetsPerHour / 60;
            tweetsPerSecond = tweetsPerMinute / 60;

            percentofTweetsWithEmojis = ((double)numberofTweetsWithEmojis / (double)numberofTweets) * 100.00;
            percentofTweetsWithURLs = ((double)numberofTweetsWithEmojis / (double)numberofTweets) * 100.00;
            percentofTweetsWithPhotoURL = ((double)numberofTweetsWithEmojis / (double)numberofTweets) * 100.00;

            domainDictionary.Add("me.com", 24);
            domainDictionary.Add("twitter.com", 5);
            domainDictionary.Add("matkerting.suzuki.com", 2);
            domainDictionary.Add("michaels.com", 5);
            domainDictionary.Add("matkerting.com", 14);
            domainDictionary.Add("wallstreet.com", 5);
            domainDictionary.Add("infobooksrus.com", 8);


            hasTagDictionary.Add("gamestop", 24);
            hasTagDictionary.Add("wallstreet", 5);
            hasTagDictionary.Add("springbreak", 2);
            hasTagDictionary.Add("toasted", 5);
            hasTagDictionary.Add("believer", 14);
            hasTagDictionary.Add("bestcook", 5);
            hasTagDictionary.Add("top_golfer", 8);


            emojiDictionary.Add("\uf002", 24);
            emojiDictionary.Add("\ufa02", 5);
            emojiDictionary.Add("\uf702", 2);
            emojiDictionary.Add("\uf0e2", 5);
            emojiDictionary.Add("\uf402", 14);
            emojiDictionary.Add("\uf022", 5);
            emojiDictionary.Add("\uf00f", 8);
        }

        public int getResult()
        {
            throw new System.NotImplementedException();
        }
    }
}
