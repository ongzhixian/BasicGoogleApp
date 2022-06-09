using BasicGoogleApp.ConsoleApp;
using BasicGoogleApp.ConsoleApp.Helpers;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System;

AppState.Initialize();

// Generates state and PKCE values.
string state = RandomHelper.GenerateRandomDataBase64url(32);

string codeVerifier = RandomHelper.GenerateRandomDataBase64url(32);

string codeChallenge = RandomHelper.Base64UrlEncodeNoPadding(RandomHelper.Sha256Ascii(codeVerifier));

const string codeChallengeMethod = "S256";

CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
var cancelToken = cancellationTokenSource.Token;



// Thread vs Task
var x = Task.Run(async () =>
{
    // Creates a redirect URI using an available port on the loopback address.
    string redirectUri = $"http://{IPAddress.Loopback}:4315/";
    
    Log("redirect URI: " + redirectUri);

    // Creates an HttpListener to listen for requests on that redirect URI.
    var http = new HttpListener();
    
    http.Prefixes.Add(redirectUri);
    
    Log("Listening..");
    
    http.Start();

    while (!cancelToken.IsCancellationRequested)
    {
        // Waits for the OAuth authorization response.
        var context = await http.GetContextAsync();

        var response = context.Response;
        string responseString = "<html><head><meta http-equiv='refresh' content='10;url=https://google.com'></head><body>Please return to the app.</body></html>";
        byte[] buffer = Encoding.UTF8.GetBytes(responseString);
        
        response.ContentLength64 = buffer.Length;

        using (var responseOutput = response.OutputStream)
        {
            await responseOutput.WriteAsync(buffer);
        }
    }


    //// Sends an HTTP response to the browser.
    //var response = context.Response;
    //string responseString = "<html><head><meta http-equiv='refresh' content='10;url=https://google.com'></head><body>Please return to the app.</body></html>";
    //byte[] buffer = Encoding.UTF8.GetBytes(responseString);
    //response.ContentLength64 = buffer.Length;
    //var responseOutput = response.OutputStream;
    //await responseOutput.WriteAsync(buffer, 0, buffer.Length);
    //responseOutput.Close();
    //http.Stop();
    //Log("HTTP server stopped.");

    //// Checks for errors.
    //string error = context.Request.QueryString.Get("error");
    //if (error is object)
    //{
    //    Log($"OAuth authorization error: {error}.");
    //    return;
    //}
    //if (context.Request.QueryString.Get("code") is null
    //    || context.Request.QueryString.Get("state") is null)
    //{
    //    Log($"Malformed authorization response. {context.Request.QueryString}");
    //    return;
    //}

    //// extracts the code
    //var code = context.Request.QueryString.Get("code");
    //var incomingState = context.Request.QueryString.Get("state");

}, cancellationTokenSource.Token);


Console.WriteLine("Press <ENTER> to terminate.");
Console.ReadLine();

void Log(string output) => Console.WriteLine(output);

