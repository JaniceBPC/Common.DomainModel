using Jbpc.Common.Import;
using Jbpc.Common.DomainModel.InternedStrings.Import;

namespace Jbpc.Common.DomainModel.InternedStrings
{
    public class InstantiateObject : InstantiateObject<ExtractedAttributes>
    {
        private readonly DataModel dataModel;
        public InstantiateObject(DataModel dataModel)
        {
            this.dataModel = dataModel;
        }
        public override void Instantiate(ExtractedAttributes extractedAttributes)
        {
            var attributes = extractedAttributes;

            var modelRow = dataModel.LookUpModelRow(attributes.Text);

            if (modelRow == null)
            {
                var obj = dataModel.TemplateObject(attributes.Text);

                dataModel.Add(new ModelRow { ImportedObject = obj});

                ApplyMarkDirtyWhereChanges.Apply(obj, x => x.String != attributes.Text, x => x.String = attributes.Text);
            }


        }
    }
}