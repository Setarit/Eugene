﻿using System;

namespace Eugene.Network
{
    class RemoteDownloadLocation
    {
        private readonly RemoteFileReader _remoteFileReader;

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="_remoteLocation">The URL where the remote Eugene file is located</param>
        public RemoteDownloadLocation(string _remoteLocation)
        {
            _remoteFileReader = RemoteFileReader.GetInstance();
            _remoteFileReader.RemoteLocation = _remoteLocation;
            _remoteFileReader.ReadRemoteFile();
        }

        /// <summary>
        /// Reads the remote Eugene file for the location where the new software version can be downloaded
        /// </summary>
        /// <returns>The location where the new software version can be downloaded</returns>
        public string GetDownloadLocation()
        {
            return _remoteFileReader.GetValue("download");
        }
    }
}
