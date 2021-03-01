using System.Collections;
using UnityEngine;

public abstract class State
{
    protected MinerManager MinerManager;
    protected ExplorerManager ExplorerManager;

    public State(MinerManager minerManager )
    {
        MinerManager = minerManager;
    }

    public State(ExplorerManager explorerManager)
    {
        ExplorerManager = explorerManager;
    }

    public virtual IEnumerator Start()
    {
        yield break;
    }
    public virtual IEnumerator Update()
    {
        yield break;
    }
}
