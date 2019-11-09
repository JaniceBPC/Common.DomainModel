using System.Linq;
using Jbpc.Common.DomainModel.ImportModel;
using Jbpc.Common.DomainModel.InternedStrings.Import;
using Jbpc.Repository;

namespace Jbpc.Common.DomainModel.InternedStrings
{
    public class DataModel : ImportDataModel<Import.ModelRow>
    {
        public DatabaseContext DatabaseContext { get; }

        public DataModel(DatabaseContext databaseContext)
        {
            this.DatabaseContext = databaseContext;
        }
        public int NumberOfObjectsSavedInDatabase => DatabaseContext.InternedStringRepository.Queries.Objects().Count();
        public bool IsAnyAlreadySavedInDB => NumberOfObjectsSavedInDatabase > 0;
        public void DeleteAll()
        {
            DatabaseContext.InternedStringRepository.DeleteAllObjects();

            Reset();
        }
        public Import.ModelRow Match(InternedString obj) => ModelRows.FirstOrDefault(x => x.ImportedObject.Equals(obj));
        public ModelRow LookUpModelRow(string name) => ModelRows.FirstOrDefault(x => x.ImportedObject.String == name);
        public InternedString TemplateObject(string name)
        {
            var modelRow = LookUpModelRow(name);

            if (modelRow != null) return modelRow.ImportedObject;

            return new InternedStringTemplate(DatabaseContext.InternedStringRepository).TemplateObject(DatabaseContext, name);
        }
    }
}
