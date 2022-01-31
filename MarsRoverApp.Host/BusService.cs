using MassTransit;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MarsRoverApp.Host
{
    /// <summary>
    /// 
    /// </summary>
    public class BusService : IHostedService
    {
        private readonly IBusControl _busControl;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="busControl"></param>
        public BusService(IBusControl busControl)
        {
            _busControl = busControl;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task StartAsync(CancellationToken cancellationToken)
        {
            return _busControl.StartAsync(cancellationToken);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task StopAsync(CancellationToken cancellationToken)
        {
            return _busControl.StopAsync(cancellationToken);
        }
    }
}   
