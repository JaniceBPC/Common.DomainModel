using Jbpc.Repository;

namespace Jbpc.Common.DomainModel.InternedStrings
{
    public class Builder
    {
        private DataModel dataModel;
        public DatabaseContext DatabaseContext { get; set; }

        public Builder(DatabaseContext databaseContext)
        {
            this.DatabaseContext = databaseContext;
        }
        public  DataModel Build(DataModel dataModel)
        {
            this.dataModel = dataModel;


            return dataModel;
        }
    }
}
