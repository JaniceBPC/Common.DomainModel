using System;
using System.Collections.Generic;
using Jbpc.Repository;

namespace Jbpc.Common.DomainModel
{
    public interface IAbstractEditSession
    {
        event EventHandler<EditChangesEventArgs> ModelChanged;
        event EventHandler<EditChangesEventArgs> ModelRowChanged;
        event EventHandler<PendingChangesEventArgs> PendingChanges;
        event EventHandler<ChangesSaveEventArgs> ChangesSaved;
        int Count { get; }
        bool IsPendingChanges { get; }
        bool IsAnyMarkedForDeletion { get; }
        int NumberOfPendingChanges { get; }
        void RaiseModelChangedEvent();
        void RaiseSaveEvent(bool changesSaved);
        void Reset();
        List<IRepositoryObject> RepositoryObjectsToUpdate();
    }
}