using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestSharp;
using RestSharp.Authenticators;
using RestSharp.Authenticators.OAuth2;
using System.Text.Json.Serialization;

namespace GithubConfigurator
{
    class Execute
    {
        private static CancellationToken cancellationToken;

        static async Task Main(string[] args)
        {
            var bearerToken = "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";
            //----------Start authentication
            var url = "https://api.github.com/user/repos";
            var client = new RestClient(url)
            {
                Authenticator = new OAuth2AuthorizationRequestHeaderAuthenticator(
                bearerToken,
                "Bearer"
            )
            };

            // Create a new repository
            var request = new RestRequest(url, Method.Post);
            request.AddHeader("Content-Type", "application/json");
            var body = new
            {
                Accept = "application/vnd.github+json",
                name = "newTestRepo",
                description = "This is a test-repo, it can be deleted when not needed anymore"
            };
            var bodyy = JsonConvert.SerializeObject(body);
            request.AddBody(bodyy, "application/json");
            RestResponse response = await client.ExecuteAsync(request);
            var output = response.Content;

            // Add a file to the newly created repository HIER WEITER MACHEN
            _ = new RestRequest(url, Method.Put);
            _ = new
            {
                message = "message",
                content = "VGhpcyBmaWxlIHdhcyBjcmVhdGVkIHRvIGVuYWJsZSByZXBvc2l0b3J5IHNldHRpbmdzIGNvbnRyb2wgYWZ0ZXIgY3JlYXRpb24="
            };
            var bodyyy = JsonConvert.SerializeObject(body);
            request.AddBody(bodyyy, "application/json");
            RestResponse response1 = await client.ExecuteAsync(request);         
        }













































        //public async Task<IActionResult> IndexAsync()
        //{
        //    var url = "https://api.github.com/user/repos";
        //    var client = new RestClient(url);
        //    var request = new RestRequest(url, Method.Post);
        //    request.AddHeader("Content-Type", "application/json");
        //    var body = new
        //    {
        //        Accept = "application/vnd.github+json",
        //        name = "newTestRepo",
        //        description = "This is a test-repo, it can be deleted when not needed anymore"
        //    };
        //    var bodyy = JsonConvert.SerializeObject(body);
        //    request.AddBody(bodyy, "application/json");
        //    RestResponse response = await client.ExecuteAsync(request);
        //    var output = response.Content;
        //    return View();
        //}

        //        private IActionResult View()
        //        {
        //            throw new NotImplementedException();
        //        }
    }
}









//namespace GithubConfigurator
//{


//    // ---------- Main class
//    class GithubConfigurator
//    {
//        private static CancellationToken cancellationToken;

//        static async Task Main(string[] args)
//        {
//            // ---------- Start authentication
//            var client = new RestClient("https://api.github.com/");
//            //client.Authenticator = new HttpBasicAuthenticator("aaron-olivieri-loepfe", "HalloPasswort1");// mit bearer token

//            client.Authenticator = new OAuth2AuthorizationRequestHeaderAuthenticator(
//                token, "Bearer"
//            );

//            var request = new RestRequest("githubConfigJSON.json", (Method)DataFormat.Json);

//            var timeline = await client.GetAsync<HomeTimeline>(request, cancellationToken);
//        }

//        internal class HomeTimeline
//        {
//        }

//        // ---------- Get token
//        record TokenResponse
//        {
//            [JsonPropertyName("token_type")]
//            public string TokenType { get; init; }
//            [JsonPropertyName("access_token")]
//            public string AccessToken { get; init; }
//        }

//    }
//}




//            var client = new RestClient("https://raw.githubusercontent.com/");
//            var response = await client.GetJsonAsync<Response>("OurWorldMetaverse/OurOSBasic/main/O_OS-Kernel/ACK/Resources/ACKCommands.json");
//            Console.WriteLine(response!.Commands["ping"]);
//        }

//class Commands : Dictionary<string, string> { }

//        class Response
//        {
//            public Commands? Commands { get; set; }
//        }
//    }









//// ---------- Login
//public class TwitterAuthenticator : AuthenticatorBase
//{
//    readonly string _baseUrl;
//    readonly string _clientId;
//    readonly string _clientSecret;

//    public TwitterAuthenticator(string baseUrl, string clientId, string clientSecret) : base("")
//    {
//        _baseUrl = baseUrl;
//        _clientId = clientId;
//        _clientSecret = clientSecret;
//    }

//    protected override async ValueTask<Parameter> GetAuthenticationParameter(string accessToken)
//    {
//        var token = string.IsNullOrEmpty(Token) ? await GetToken() : Token;
//        return new HeaderParameter(KnownHeaders.Authorization, token);
//    }
//}


//// ----------- Initiate Github connection
//public class GitHubClient
//{
//    readonly RestClient _client;

//    public GitHubClient()
//    {
//        _client = new RestClient("https://api.github.com/")
//            .AddDefaultHeader(KnownHeaders.Accept, "application/vnd.github.v3+json");
//    }

//    public Task<GitHubRepo[]> GetRepos()
//        => _client.GetJsonAsync<GitHubRepo[]>("users/aspnet/repos");
//}


//public class ExecuteJson
//{
//    // ----------- Execute JSON file
//    var request = new RestRequest("address/update").AddJsonBody(updatedAddress);
//    var response = await client.PostAsync<AddressUpdateResponse>(request);
//}































//using System;
//using Octokit;



//var client = new GitHubClient(new ProductHeaderValue("my-cool-app"));

//var tokenAuth = new Credentials("Set a new Bearer Token");
//client.Credentials = tokenAuth;

//var listOfRepos = await client.Repository.GetAllForUser("aaron-olivieri-loepfe");

//await client.Repository.Delete("aaron-olivieri-loepfe", "newRepo");

//await client.Repository.Create(new NewRepository("newRepo"));

//var branchProtectionRequiredReviews = new BranchProtectionRequiredReviews[1];

//await client.Repository.e





//public class NewRepository
//{
////Features
//    public string Name { get; set; }
//    public string Description { get; set; }
//    public bool HasWiki = false;
//    public bool HasIssues = false;
//    //forking
//    //sponsorships
//    public bool HasProjects = false;
//    //discussions

////Pull Requests
//    public bool AllowMergeCommit = false;



//    //For Testing:
//    public bool

//}














//using Octokit.Internal;
//using System.Diagnostics;
//using System.Diagnostics.CodeAnalysis;
//using System.Globalization;

//namespace Octokit
//{
//    /// <summary>
//    /// Describes a new repository to create via the <see cref="IRepositoriesClient.Create(NewRepository)"/> method.
//    /// </summary>
//    [DebuggerDisplay("{DebuggerDisplay,nq}")]
//    public class NewRepository
//    {
//        /// <summary>
//        /// Creates an object that describes the repository to create on GitHub.
//        /// </summary>
//        /// <param name="name">The name of the repository. This is the only required parameter.</param>
//        public NewRepository(string name)
//        {
//            Ensure.ArgumentNotNullOrEmptyString(name, nameof(name));

//            Name = name;
//        }

//        /// <summary>
//        /// Optional. Gets or sets whether to create an initial commit with empty README. The default is false.
//        /// </summary>
//        public bool? AutoInit { get; set; }

//        /// <summary>
//        /// Required. Gets or sets the new repository's description
//        /// </summary>
//        public string Description { get; set; }

//        /// <summary>
//        /// Optional. Gets or sets whether to enable downloads for the new repository. The default is true.
//        /// </summary>
//        public bool? HasDownloads { get; set; }

//        /// <summary>
//        /// Optional. Gets or sets whether to enable issues for the new repository. The default is true.
//        /// </summary>
//        public bool? HasIssues { get; set; }

//        /// <summary>
//        /// Optional. Gets or sets whether to enable projects for the new repository. The default is true.
//        /// </summary>
//        public bool? HasProjects { get; set; }

//        /// <summary>
//        /// Optional. Gets or sets whether to enable the wiki for the new repository. The default is true.
//        /// </summary>
//        public bool? HasWiki { get; set; }

//        /// <summary>
//        /// Either true to make this repo available as a template repository or false to prevent it. Default: false.
//        /// </summary>
//        public bool? IsTemplate { get; set; }

//        /// <summary>
//        /// Optional. Gets or sets the new repository's optional website.
//        /// </summary>
//        public string Homepage { get; set; }

//        /// <summary>
//        /// Optional. Gets or sets the desired language's or platform's .gitignore template to apply. Use the name of the template without the extension; "Haskell", for example. Ignored if <see cref="AutoInit"/> is null or false.
//        /// </summary>
//        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Gitignore", Justification = "It needs to be this way for proper serialization.")]
//        public string GitignoreTemplate { get; set; }

//        /// <summary>
//        /// Optional. Gets or sets the desired LICENSE template to apply. Use the name of the template without
//        /// the extension. For example, “mit” or “mozilla”.
//        /// </summary>
//        /// <remarks>
//        /// The list of license templates are here: https://github.com/github/choosealicense.com/tree/gh-pages/_licenses
//        /// Just omit the ".txt" file extension for the template name.
//        /// </remarks>
//        public string LicenseTemplate { get; set; }

//        /// <summary>
//        /// Required. Gets or sets the new repository's name.
//        /// </summary>
//        public string Name { get; private set; }

//        /// <summary>
//        /// Optional. Gets or sets whether the new repository is private; the default is false.
//        /// </summary>
//        public bool? Private { get; set; }

//        /// <summary>
//        /// Optional. Gets or sets the Id of the team to grant access to this repository. This is only valid when creating a repository for an organization.
//        /// </summary>
//        public int? TeamId { get; set; }

//        public bool? DeleteBranchOnMerge { get; set; }

//        /// <summary>
//        /// Optional. Gets or sets whether the new repository is public, private, or internal. A value provided here overrides any value set in the existing private field.
//        /// </summary>
//        public RepositoryVisibility? Visibility { get; set; }

//        /// <summary>
//        /// Optional. Gets or sets whether the new repository allows rebase merges.
//        /// </summary>
//        public bool? AllowRebaseMerge { get; set; }

//        /// <summary>
//        /// Optional. Gets or sets whether the new repository allows squash merges.
//        /// </summary>
//        public bool? AllowSquashMerge { get; set; }

//        /// <summary>
//        /// Optional. Gets or sets whether the new repository allows merge commits.
//        /// </summary>
//        public bool? AllowMergeCommit { get; set; }

//        /// <summary>
//        /// Optional. Gets or sets whether the new repository allows auto merge.
//        /// </summary>
//        public bool? AllowAutoMerge { get; set; }

//        /// <summary>
//        /// Optional. Gets or sets whether the squash pr title is used as default when using Squash Merge. Default is false. Cannot currently be tested as it isn't returned in the GET method.
//        /// </summary>
//        public bool? UseSquashPrTitleAsDefault { get; set; }

//        internal string DebuggerDisplay
//        {
//            get
//            {
//                return string.Format(CultureInfo.InvariantCulture, "Name: {0} Description: {1}", Name, Description);
//            }
//        }
//    }

//    /// <summary>
//    /// The properties that repositories can be visible by.
//    /// </summary>
//    public enum RepositoryVisibility
//    {
//        /// <summary>
//        /// Sets repository visibility to public
//        /// </summary>
//        [Parameter(Value = "public")]
//        Public,

//        /// <summary>
//        /// Sets repository visibility to private
//        /// </summary>
//        [Parameter(Value = "private")]
//        Private,

//        /// <summary>
//        /// Sets repository visibility to internal
//        /// </summary>
//        [Parameter(Value = "internal")]
//        Internal,
//    }
//}







//BranchProtectionRequiredStatusChecks

//Console.WriteLine(listOfRepos);
//var user = await client.User.Current();



