using Jbpc.Common.Import;

namespace Jbpc.Common.DomainModel.InternedStrings
{
    public class ImportObjectsFromDataTable : ImportObjectsFromDataTable<ExtractedAttributes>
    {
        private readonly DataModel dataModel;
        public static string NameFieldName => "Name";
        public override string[] ColumnLabels()
        {
            return new[]
            {
                NameFieldName
            };
        }
        public ImportObjectsFromDataTable(DataModel dataModel) : base(dataModel)
        {
            this.dataModel = dataModel;
        }
        public override ImportStepsConfiguration<ExtractedAttributes> ImportStepsConfiguration => 
            new ImportStepsConfiguration<ExtractedAttributes>(
                new ExtractAttributes(), 
                new Validate(), 
                new InstantiateObject(dataModel));

    }
}
