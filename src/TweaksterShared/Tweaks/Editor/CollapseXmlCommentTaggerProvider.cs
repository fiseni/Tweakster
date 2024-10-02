using System.ComponentModel.Composition;
using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Text.Tagging;
using Microsoft.VisualStudio.Utilities;
using Community.VisualStudio.Toolkit;

namespace Tweakster
{
    [Export(typeof(ITaggerProvider))]
    [TagType(typeof(IStructureTag))]
    [Name(nameof(CollapseXmlCommentTaggerProvider))]
    [ContentType(ContentTypes.CSharp)]
    internal sealed class CollapseXmlCommentTaggerProvider : ITaggerProvider
    {
        public ITagger<T> CreateTagger<T>(ITextBuffer buffer) where T : ITag
        {
            if (!Options.Instance.CollapseXmlComments)
            {
                return null;
            }

            return buffer.Properties.GetOrCreateSingletonProperty(() => new CollapseXmlCommentTagger(buffer, Options.Instance.CollapseXmlCommentsShortForm)) as ITagger<T>;
        }
    }
}
