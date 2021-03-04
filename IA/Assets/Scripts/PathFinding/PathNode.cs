using System.Collections.Generic;
using UnityEngine;

public enum NodeState
{
    Unreviewed,
    open,
    closed
}
public class PathNode 
{
    public List<Vector2Int> AdjacentNodeIndex { get; set; }
    public PathNode Parent { get; set; }
    public PathNode Child  { get; set; }
    public NodeState State { get; set; }
    public Vector3 Position { get; private set; }
    public bool CanBeBlocked { get; private set; }
    public float Cost { get; private set; }
    public float AccumulatedCost { get; set; }

    public PathNode(Vector3 position, bool canBeBlocked = false, float cost = 1.0f)
    {
        AdjacentNodeIndex = new List<Vector2Int>();
        Parent = null;
        Child = null;
        State = NodeState.Unreviewed;
        Position = position;
        CanBeBlocked = canBeBlocked;
        Cost = cost;
        AccumulatedCost = Cost;
    }

}
