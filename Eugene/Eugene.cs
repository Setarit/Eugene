﻿using Eugene.Configuration;
using Eugene.Network;

namespace Eugene
{
    public class Eugene
    {
        private ConfigurationFileReader _configFileReader;
        private double _currentSoftwareVersion;


        /// <summary>
        /// Default constructor
        /// <param name="configFileLocation">The absolute path of the configuration file</param>
        /// <param name="currentSoftwareVersion">The current version number of the software</param>
        /// </summary>
        public Eugene(string configFileLocation, double currentSoftwareVersion)
        {
            _configFileReader = new ConfigurationFileReader(configFileLocation);
            _currentSoftwareVersion = currentSoftwareVersion;
        }

        /// <summary>
        /// Checks with the configuration file and the current version is outdated
        /// </summary>
        /// <returns>True if a new version is available</returns>
        public bool CurrentVerionIsOutdated()
        {
            RemoteVersionChecker versionChecker = new RemoteVersionChecker(_configFileReader.GetConfigurationValue("location"));
            var remoteVersion = versionChecker.GetRemoteVersionNumber();
            return remoteVersion > _currentSoftwareVersion;
        }
    }
}