using Common.Logging;
using Puppy.Monitoring.Events;

namespace Puppy.Monitoring.Adapters.Default
{
    public class NullPipelineAdapter : IPipelineAdapter
    {
        private static readonly ILog log = LogManager.GetLogger<NullPipelineAdapter>();

        public void Push(IEvent @event)
        {
            log.WarnFormat("The event {0} will disappear down the rabbit hole that is the null pipeline adapter");    
        }
    }
}