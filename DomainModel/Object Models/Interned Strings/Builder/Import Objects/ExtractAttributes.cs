using Jbpc.Common.ExtensionMethods;
using Jbpc.Common.Import;
using System.Data;

namespace Jbpc.Common.DomainModel.InternedStrings
{
    public class ExtractAttributes : IExtractAttributes<ExtractedAttributes> 
    {
        public ExtractedAttributes Extract(DataRow dataRow, int nthRow)
        {
            var attributes = new ExtractedAttributes(dataRow, nthRow)
            {
                Text = dataRow.GetString(ImportObjectsFromDataTable.NameFieldName)
            };

            return attributes;
        }
    }
}
