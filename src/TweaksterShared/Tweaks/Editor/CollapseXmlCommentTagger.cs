using Microsoft.VisualStudio.Text;

namespace Tweakster
{
    public class CollapseXmlCommentTagger : CollapseTagger
    {
        private const string _shortCollapsedForm = "///";

        public CollapseXmlCommentTagger(ITextBuffer buffer, bool isShortCollapsedForm)
            : base(buffer, isShortCollapsedForm, _shortCollapsedForm)
        {
        }

        protected override bool ShouldCollapse(ITextSnapshotLine line, out Span span)
        {
            var text = line.GetText();
            var clean = text.TrimStart();

            span = Span.FromBounds(line.Start + (text.Length - clean.Length), line.End);

            clean = clean.TrimEnd();

            return !string.IsNullOrEmpty(clean) && clean.StartsWith("///");
        }
    }
}
