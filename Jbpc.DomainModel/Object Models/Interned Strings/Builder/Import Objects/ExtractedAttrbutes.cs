using System.Data;

namespace Jbpc.Common.DomainModel.InternedStrings
{
    public class ExtractedAttributes  : Common.Import.ExtractedAttributes
    {
        public ExtractedAttributes(DataRow dataRow, int nthRow) : base(dataRow, nthRow) { }

        public string Text { get; set; }
    }
}
