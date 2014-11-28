using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using TFSBuildDownloader.Objects;

namespace TFSBuildDownloader.Functions
{
    internal class TFS
    {
        private string _userName { get; set; }
        private string _password { get; set; }
        private string _collectionURL { get; set; }
        private string _projectName { get; set; }
        private string _buildNumber { get; set; }
        private string _output { get; set; }
        internal TFS(string UserName
                    , string Password
                    , string CollectionURL
                    , string ProjectName = ""
                    , string BuildNumber = "")
        {
            _userName = UserName;
            _password = Password;
            if (CollectionURL.Substring(CollectionURL.Length - 1, 1) != "/")
            {
                _collectionURL = CollectionURL + "/";
            }
            else
            {
                _collectionURL = CollectionURL;
            }

            Console.WriteLine(_collectionURL);

            if (!string.IsNullOrWhiteSpace(ProjectName))
            {
                _projectName = ProjectName;
                if (string.IsNullOrWhiteSpace(_buildNumber))
                {
                    BuildCollectionURL(BuildType.Project);
                }
                else
                {
                    BuildCollectionURL(BuildType.BuildNumber);
                }
            }
            else
            {
                BuildCollectionURL(BuildType.All);
            }
        }

        internal string BuildCollectionURL(BuildType buildType)
        {
            ConsoleWriter.Write("Building Collection URL list...", MessageType.Information);
            string collectionURL = string.Empty;
            //Get all the builds
            if (buildType == BuildType.All)
            {
                collectionURL = _collectionURL + Constants.buildURL;
            }
            //Will get the build for the build ID provided. Project name required
            if (buildType == BuildType.Project)
            {
                collectionURL = _collectionURL + _projectName + "/" + Constants.buildURL;
            }
            if (buildType == BuildType.BuildNumber)
            {
                collectionURL = _collectionURL + _projectName + "/" + Constants.buildURL + "/" + _buildNumber;
            }
            return _collectionURL = collectionURL;
        }
        internal async Task<TFSBuild.RootObject> GetBuilds()
        {
            using (HttpClient client = new HttpClient())
            {
                ConsoleWriter.Write("Connecting...", MessageType.Information);
                client.DefaultRequestHeaders.Accept.Add(
                    new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic",
                    Convert.ToBase64String(
                        System.Text.ASCIIEncoding.ASCII.GetBytes(
                            string.Format("{0}:{1}", _userName, _password))));
                using (HttpResponseMessage response = client.GetAsync(
                            _collectionURL).Result)
                {
                    ConsoleWriter.Write("Authentication Successfull!!", MessageType.Information);
                    response.EnsureSuccessStatusCode();
                    string responseBody = await response.Content.ReadAsStringAsync();
                    ConsoleWriter.Write("Getting Build(s)...", MessageType.Information);
                    TFSBuild.RootObject rootObject = Utils.DeserializeJSON<TFSBuild.RootObject>(responseBody);
                    return rootObject;
                }
            }
        }
    }
}