﻿namespace PipelineHosting
{
    public class DefaultHttpContext : HttpContext
    {
        public IFeatureCollection HttpContextFeatures { get; }

        public DefaultHttpContext(IFeatureCollection httpContextFeatures)
        {
            this.HttpContextFeatures = httpContextFeatures;
            this.Request=new DefaultHttpRequest(this);
            this.Response=new DefaultHttpResonse(this);
        }

        public override HttpRequest Request { get; }

        public override HttpResponse Response { get; }
    }
}
