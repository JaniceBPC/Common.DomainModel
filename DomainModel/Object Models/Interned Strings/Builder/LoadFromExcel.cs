using System.Data;
using Jbpc.Common.Excel;

namespace Jbpc.Common.DomainModel.InternedStrings
{
    public class LoadFromExcel
    {
        private readonly DataModel dataModel;
        public LoadFromExcel(DataModel dataModel)
        {
            this.dataModel = dataModel;
        }
        public void Build()
        { 
            dataModel.Reset();

            new LoadFromDatabase(dataModel).Build();

            new ImportObjectsFromDataTable(dataModel).ImportObjects(ImportFile());

            dataModel.PostBuild();
        }
        private DataTable ImportFile() => new WorksheetDataTable().CopyUsedRangeIntoDataTable(dataModel.ImportFilename, dataModel.ImportWorksheetName);
    }
}
