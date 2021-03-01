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
    public List<PathNode> AdjacentNodes { get; set; }
    public PathNode Parent { get; set; }
    public PathNode Child  { get; set; }
    public NodeState State { get; set; }
    public Vector3 Position { get; private set; }
    public bool CanBeBlocked { get; private set; }
    public float Cost { get; private set; }
    public float AccumulatedCost { get; private set; }

    public PathNode(Vector3 position, bool canBeBlocked = false, float cost = 1.0f)
    {
        AdjacentNodes = new List<PathNode>();
        Parent = null;
        Child = null;
        State = NodeState.Unreviewed;
        Position = position;
        CanBeBlocked = canBeBlocked;
        Cost = cost;
        AccumulatedCost = Cost;
    }

}
