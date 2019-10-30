using System.Linq;

namespace Jbpc.Common.DomainModel.InternedStrings
{
    public class LoadFromDatabase
    {
        private readonly DataModel dataModel;
        public LoadFromDatabase(DataModel dataModel)
        {
            this.dataModel = dataModel;
        }
        public void Build()
        {
            dataModel.Reset();

            var objects = dataModel.DatabaseContext.InternedStringRepository.Queries.Objects();

            objects = objects.OrderBy(x => x).ToList();

            foreach (var obj in objects)
            {
                var modelRow = new Import.ModelRow()
                {
                    ImportedObject = obj
                };
                dataModel.Add(modelRow);
            }

            dataModel.PostBuild();
        }
    }
}
