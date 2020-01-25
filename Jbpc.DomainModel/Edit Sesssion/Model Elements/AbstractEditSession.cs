
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Jbpc.Common.Import;
using Jbpc.Repository;

namespace Jbpc.Common.DomainModel
{
    public abstract class AbstractEditSession<T> : IAbstractEditSession, IImportLogger 
        where T : AbstractModelRow, IAbstractModelRow
    {
        public event EventHandler<EditChangesEventArgs> ModelChanged;
        public event EventHandler<EditChangesEventArgs> ModelRowChanged;
        public event EventHandler<PendingChangesEventArgs> PendingChanges;
        public event EventHandler<ChangesSaveEventArgs> ChangesSaved;
        
        public List<T> ModelRows { get; set; } = new List<T>();
        public virtual void Add(T modelRow)
        {
            ModelRows.Add(modelRow);

            modelRow.NthRow = ModelRows.Count;

            modelRow.ModelRowChanged += ModelRowChanged;
        }
        public void RaiseModelChangedEvent()
        {
            ModelChanged?.Invoke(this, new EditChangesEventArgs { });

            RaisePendingChangesEvent();
        }
        public virtual void RaiseModelRowChangedEvent(IAbstractModelRow modelRow)
        {
            ModelRowChanged?.Invoke(this, new EditChangesEventArgs { ModelRow = modelRow});
        }
        public void RaisePendingChangesEvent()
        {
            PendingChanges?.Invoke(this, new PendingChangesEventArgs() { Changes = NumberOfPendingChanges });
        }
        public void RaiseSaveEvent(bool changesSaved)
        {
            PostSave(changesSaved);

            ChangesSaved?.Invoke(this, new ChangesSaveEventArgs() { ChangesSaved = changesSaved});
        }
        public virtual void Build()
        {
            LogMessage = new StringBuilder();
        }
        public virtual void PostSave(bool changesSaved)
        {

        }
        public int Count => ModelRows.Count;
        public virtual void Reset()
        {
            LogMessage = new StringBuilder();

            ModelRows.Clear();
        }
        public virtual void PostBuild()
        {
            RaiseModelChangedEvent();
        }
        public virtual List<IRepositoryObject> RepositoryObjectsToUpdate()
        {
            if (!IsPopulated) return new List<IRepositoryObject>();

            return ModelRows.SelectMany(x => x.RepositoryObjectsToUpdate()).Where(x=> x.IsChangesPending).Distinct().ToList();
        }
        public StringBuilder LogMessage { get; set;  } = new StringBuilder();
        public bool IsPendingChanges => RepositoryObjectsToUpdate().Any();
        public bool IsAnyMarkedForDeletion => RepositoryObjectsToUpdate().Exists(x => x.IsMarkedForDeletion);
        public int NumberOfPendingChanges => RepositoryObjectsToUpdate().Count;
        public bool IsPopulated => ModelRows.Any();
        public int NumberModelRows => ModelRows.Count;
        public string ImportFilename { get; set; } = "";
        public string ImportWorksheetName { get; set; } = "";
    }

    public class PendingChangesEventArgs
    {
        public int Changes { get; set; }
    }
    public class ChangesSaveEventArgs : EventArgs
    {
        public bool ChangesSaved { get; set; }
    }
    public class EditChangesEventArgs : EventArgs
    {
        public IAbstractModelRow ModelRow { get; set; }
    }
}
