using System;
using System.Collections.Generic;
using Puppy.Monitoring.Tracking;

namespace Puppy.Monitoring
{
    public class TrackWritingInfoCollector<TResponse>
    {
        private readonly Track<TResponse> track;
        private IWriteTracking writer = new NullTrackingWriter();
        private string request = string.Empty;
        private Func<TResponse, string> serialisation = response => response.ToString();
        private Func<string> identifier = () => "unknown";
        private TrackReportInfoCollector<TResponse> trackReportInfoCollector;

        public TrackWritingInfoCollector(Track<TResponse> track)
        {
            this.track = track;
        }

        public TrackWritingInfoCollector<TResponse> Write()
        {
            return this;
        }

        public TrackWritingInfoCollector<TResponse> With(IWriteTracking writer)
        {
            this.writer = writer;
            return this;
        }

        public TrackWritingInfoCollector<TResponse> TheRequest(string request)
        {
            this.request = request;
            return this;
        }

        public TrackReportInfoCollector<TResponse> TheResponse(Func<TResponse, string> serialisation)
        {
            this.serialisation = serialisation;
            trackReportInfoCollector = new TrackReportInfoCollector<TResponse>(this);
            return trackReportInfoCollector;
        }

        public TResponse Go()
        {
            return track.Go();
        }

        internal void Execute(TResponse callResponse)
        {
            writer.Write(identifier(), 
                request,
                serialisation(callResponse));    
        }

        public TrackWritingInfoCollector<TResponse> UsingAsIdentifier(Func<string> identifier)
        {
            this.identifier = identifier;
            return this;
        }

        internal List<Func<ReportInfoCollector>> Successes()
        {
            return trackReportInfoCollector.Successes;
        }

        internal List<Func<ReportInfoCollector>> Failures()
        {
            return trackReportInfoCollector.Failures;
        }
    }
}