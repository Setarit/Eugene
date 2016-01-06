using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using Eugene.Exception;

namespace Eugene.Network
{
    /// <summary>
    /// Checks on the given url the latest version number of the software
    /// </summary>
    class RemoteVersionChecker
    {
        private string _remoteLocation;

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="remoteLocation">The url of the location where the latest software version number is stored</param>
        public RemoteVersionChecker(string remoteLocation)
        {
            _remoteLocation = remoteLocation;            
        }

        /// <summary>
        /// Connects to the remote location and checks the remote version number
        /// </summary>
        /// <exception cref="InvalidRemoteVersion">If the file on the given location is in an invalid format</exception>
        /// <returns>The remote version number</returns>
        public double GetRemoteVersionNumber()
        {
            var task = _remoteVersionRetreiveTask();
            task.RunSynchronously();
            return task.Result;
        }

        private async Task<double> _remoteVersionRetreiveTask()
        {
            System.Net.Http.HttpClient client = new System.Net.Http.HttpClient();
            string version = await client.GetStringAsync(_remoteLocation);
            double versionAsDouble = -1;
            try {
                versionAsDouble = double.Parse(version);
            }catch(System.Exception e)
            {
                throw new InvalidRemoteVersion(e.Message, e);
            }
            return versionAsDouble;
        }
    }
}
