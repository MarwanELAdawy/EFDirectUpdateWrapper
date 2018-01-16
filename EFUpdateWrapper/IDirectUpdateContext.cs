using System;

namespace CodeLab.Assets.EFUpdateWrapper
{
    public interface IDirectUpdateContext
    {
        DirectUpdateMode? CurrentSaveOperationMode { get; set; } 
    }

}
