using Jbpc.Repository;

namespace Jbpc.Common.DomainModel.InternedStrings
{
    public class Builder
    {
        private DataModel dataModel;
        public IDatabaseContext DatabaseContext { get; set; }

        public Builder(IDatabaseContext databaseContext)
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
