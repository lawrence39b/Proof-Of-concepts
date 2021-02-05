using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace twitterAnalysis.BAL
{
    public class sample
    {

        //        const qs = require('querystring');
        //        const request = require('request');
        //        const readline = require('readline').createInterface({



        //      input: process.stdin,
        //              output: process.stdout
        //    });
        //const util = require('util');

        //    const get = util.promisify(request.get);
        //    const post = util.promisify(request.post);

        //    const string consumer_key = ""; // Add your API key here
        //    const string consumer_secret = ""; // Add your API secret key here

        //    const string requestTokenURL = new URL('https://api.twitter.com/oauth/request_token');
        //    const string accessTokenURL = new URL('https://api.twitter.com/oauth/access_token');
        //    const string authorizeURL = new URL('https://api.twitter.com/oauth/authorize');
        //    const string endpointURL = new URL('https://api.twitter.com/labs/2/tweets');

        //        const params = {
        //      ids: '1138505981460193280',
        //      'tweet.fields': 'created_at',
        //    };

        //async function input(prompt)
        //{
        //    return new Promise(async (resolve, reject) => {
        //    readline.question(prompt, (out) => {
        //        readline.close();
        //        resolve(out);
        //    });
        //});
        //}

        //async function requestToken()
        //{
        //    const oAuthConfig = {
        //    callback: 'oob',
        //    consumer_key: consumer_key,
        //    consumer_secret: consumer_secret,
        //  };

        //const req = await post({url: requestTokenURL, oauth: oAuthConfig});
        //if (req.body)
        //{
        //    return qs.parse(req.body);
        //}
        //else
        //{
        //    throw new Error('Cannot get an OAuth request token');
        //}
        //}

        //async function accessToken({oauth_token, oauth_token_secret}, verifier) {
        //    const oAuthConfig = {
        //    consumer_key: consumer_key,
        //    consumer_secret: consumer_secret,
        //    token: oauth_token,
        //    token_secret: oauth_token_secret,
        //    verifier: verifier,
        //  };

        //const req = await post({url: accessTokenURL, oauth: oAuthConfig});
        //if (req.body)
        //{
        //    return qs.parse(req.body);
        //}
        //else
        //{
        //    throw new Error('Cannot get an OAuth request token');
        //}
        //}



        //async function getRequest({oauth_token, oauth_token_secret}) {
        //    const oAuthConfig = {
        //    consumer_key: consumer_key,
        //    consumer_secret: consumer_secret,
        //    token: oauth_token,
        //    token_secret: oauth_token_secret,
        //  };

        //const req = await get({url: endpointURL, oauth: oAuthConfig, qs: params, json: true});
        //if (req.body)
        //{
        //    return req.body;
        //}
        //else
        //{
        //    throw new Error('Cannot get an OAuth request token');
        //}
        //}

        //(async () => {
        //    try
        //    {

        //        // Get request token
        //        const oAuthRequestToken = await requestToken();

        //        // Get authorization
        //        authorizeURL.searchParams.append('oauth_token', oAuthRequestToken.oauth_token);
        //        console.log('Please go here and authorize:', authorizeURL.href);
        //        const pin = await input('Paste the PIN here: ');

        //        // Get the access token
        //        const oAuthAccessToken = await accessToken(oAuthRequestToken, pin.trim());

        //        // Make the request
        //        const response = await getRequest(oAuthAccessToken);
        //        console.log(response);
        //    }
        //    catch (e)
        //    {
        //        console.error(e);
        //        process.exit(-1);
        //    }
        //    process.exit();
        //})();
    }
}
