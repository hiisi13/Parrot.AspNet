using Parrot.Infrastructure;

namespace Parrot.Mvc.Renderers
{
    using System;
    using Nodes;

    public class ContentRenderer : IRenderer
    {
        private readonly IHost _host;

        public ContentRenderer(IHost host)
        {
            _host = host;
        }

        public string Render(AbstractNode node, object model)
        {
            dynamic localModel = model;

            Document document = new Document
            {
                Children = localModel.Children
            };

            return _host.DependencyResolver.Get<DocumentRenderer>().Render(document, localModel.Model);
        }

        [Obsolete]
        public string Render(AbstractNode node)
        {
            throw new InvalidOperationException();
        }
    }
}