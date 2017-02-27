﻿//#if !WINDOWS_APP && !WINDOWS_PHONE_APP && !WINDOWS_UWP
//using DBTek.BugGuardian.Config;
//#endif
using System;

namespace DBTek.BugGuardian.Factories
{
    public class ConfigurationFactory
    {
        private const string DefaultCollectionName = "DefaultCollection";

        /// <summary>
        /// Allows to set the condifuration from code. If used, overrides the configuration present in the config file
        /// </summary>
        /// <param name="url">The url of VSTS or the TFS Server to target</param>
        /// <param name="username">The username of the account used to connect to the service</param>
        /// <param name="password">The password of the account used to connect to the service</param>        
        /// <param name="projectName">The name of the Team Project where the bugs will be open</param>
        /// <param name="avoidMultipleReport">If true, if the application throws the same exception more the once it will be reported only once. If false, every time will be created a new Bug to VSTS/TFS.</param>
        public static void SetConfiguration(string url, string username, string password, string projectName, bool avoidMultipleReport = true)
            => SetConfiguration(url, username, password, null, projectName, avoidMultipleReport);

        /// <summary>
        /// Allows to set the condifuration from code. If used, overrides the configuration present in the config file
        /// </summary>
        /// <param name="url">The url of VSTS or the TFS Server to target</param>
        /// <param name="username">The username of the account used to connect to the service</param>
        /// <param name="password">The password of the account used to connect to the service</param>
        /// <param name="collectionName">The name of the Team Collection that contains the Team Project</param>
        /// <param name="projectName">The name of the Team Project where the bugs will be open</param>
        /// <param name="avoidMultipleReport">If true, if the application throws the same exception more the once it will be reported only once. If false, every time will be created a new Bug to VSTS/TFS.</param>
        public static void SetConfiguration(string url, string username, string password, string collectionName, string projectName, bool avoidMultipleReport = true)
        {
            if (string.IsNullOrWhiteSpace(url))
                throw new ArgumentNullException(nameof(url));

            if (string.IsNullOrWhiteSpace(username))
                throw new ArgumentNullException(nameof(username));

            if (string.IsNullOrWhiteSpace(password))
                throw new ArgumentNullException(nameof(password));

            if (string.IsNullOrWhiteSpace(projectName))
                throw new ArgumentNullException(nameof(projectName));

            _url = url;
            Username = username;
            Password = password;
            CollectionName = collectionName ?? DefaultCollectionName;
            ProjectName = projectName;
            _avoidMultipleReport = avoidMultipleReport;
        }

        private static string _url;
        internal static string Url
            => CleanUrl(_url);

        internal static string Username { private set; get; }

        internal static string Password { private set; get; }

        internal static string CollectionName { private set; get; }

        internal static string ProjectName { private set; get; }

        private static bool? _avoidMultipleReport;
        internal static bool AvoidMultipleReport
            => _avoidMultipleReport ?? true;

        private static string CleanUrl(string url)
        {
            if (!string.IsNullOrWhiteSpace(url))
            {
                url = url.Replace(@"\", "/").ToLower();

                if (!url.StartsWith("http://") && !url.StartsWith("https://"))
                    url = $"http://{url}";

                if (url.Contains("visualstudio.com") && !url.Contains("https://"))
                    url = url.Replace("http://", "https://");

                if (url.EndsWith("/"))
                    url = url.TrimEnd('/');
            }
            return url;
        }
    }
}