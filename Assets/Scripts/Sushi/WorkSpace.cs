using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WorkSpace
{
    public List<int> _workSpace;
    int unlockedWorkPlace = 1;
    public bool canAdd;
    int count;

    public WorkSpace(List<int> workSpace)
    {
        this._workSpace = new List<int>(workSpace);
    }

    public void ResetWorkSpace()
    {
        this._workSpace.Clear();
    }

    public int CheckList()
    {
        if (_workSpace.Count < unlockedWorkPlace) 
        {
            canAdd = true;
        }
        return _workSpace.Count;
    }

    public void AddServing()
    {
        _workSpace.Add(count);
        count++;
    }
}
