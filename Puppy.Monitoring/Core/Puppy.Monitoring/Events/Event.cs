using System;
using Puppy.Monitoring.Publishing;

namespace Puppy.Monitoring.Events
{
    [Serializable]
    public abstract class Event : IEvent
    {
        protected Event(Categorisation categorisation, Guid correlationId)
            : this(SystemTime.Now(), categorisation, null, correlationId)
        {
        }

        protected Event(Categorisation categorisation, Timings timings, Guid correlationId)
            : this(SystemTime.Now(), categorisation, timings, correlationId)
        {
        }

        protected Event(DateTime publishedOn, Categorisation categorisation, Timings timings) : this(publishedOn, categorisation, timings, Guid.Empty)
        {
        }

        protected Event(DateTime publishedOn, Categorisation categorisation, Timings timings, Guid correlationId)
        {
            Categorisation = categorisation;
            Timings = timings;
            CorrelationId = correlationId;
            EventAudit = new EventTiming(publishedOn);
            Id = Guid.NewGuid();
        }

        public PublishingContext Context { get; protected set; }
        public EventTiming EventAudit { get; private set; }
        public Categorisation Categorisation { get; private set; }
        public Guid CorrelationId { get; private set; }
        public Timings Timings { get; private set; }
        public Guid Id { get; private set; }

        public void AttachContext(PublishingContext context)
        {
            this.Context = context;
        }

        public override string ToString()
        {
            return string.Format("{0}{3}{1}{3}{2}",
                                 Categorisation,
                                 EventAudit,
                                 Timings,
                                 Environment.NewLine);
        }
    }
}