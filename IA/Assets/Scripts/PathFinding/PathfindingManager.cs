using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathfindingManager : MonoBehaviour
{
    static PathfindingManager instance;
   
    public static PathfindingManager Instance
    {       
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<PathfindingManager>();
            }
            return instance;
        }
    }

    [SerializeField] Terrain terrain = null;
    [SerializeField] PathNodeGenerator PathNodeGenerator = new PathNodeGenerator();
    private PathNode[,] pathNodes = null;
    private List<PathNode> openNodes = new List<PathNode>();
    private List<PathNode> closedNodes = new List<PathNode>();
    public LayerMask pathlayer;
    public Vector2 size;
    

    private void Awake()
    {
        instance = this;

        DontDestroyOnLoad(this.gameObject);
    }

    private void Start()
    {
        size.x = terrain.terrainData.size.x;
        size.y = terrain.terrainData.size.z;
        pathNodes = PathNodeGenerator.GereneratePathNodes(size,pathlayer);
    }

    private void Update()
    {
        foreach (PathNode pathNode in pathNodes)
        {           
            foreach (Vector2Int adjacentIndex in pathNode.AdjacentNodeIndex)
            {
                PathNode adjacentNode = pathNodes[adjacentIndex.x, adjacentIndex.y];
                Debug.DrawLine(pathNode.Position, adjacentNode.Position, Color.red);
            }
        }
    }

    public Vector3 GetRandomPathNodePos()
    {
       int x =  Random.Range(0, 99);
       int y =  Random.Range(0, 99);

        while(pathNodes[x,y].CanBeBlocked)
        {
            x = Random.Range(0, 99);
            y = Random.Range(0, 99);
        }
        return pathNodes[x, y].Position;
    }

    public Stack<PathNode> GeneratePath(Vector3 origin, Vector3 destination)
    {
        Stack<PathNode> path = null;

        PathNode originNode = pathNodes[(int)origin.x, (int)origin.z];
        PathNode destinationNode = pathNodes[(int)destination.x, (int)destination.z];
        bool foundDestination = false;
        OpenNode(originNode);

        while (openNodes.Count > 0 && !foundDestination)
        {
            PathNode pathNode = GetOpenNode(destinationNode);
            if (pathNode == destinationNode)
            {
                foundDestination = true;
                FillPath(pathNode, originNode, out path);
            }
            CloseNode(pathNode);
               if (!foundDestination)
                OpenAdjacentNodes(pathNode);
        }

        ResetNodes();

        return path;

    }

    void FillPath(PathNode destinationNode, PathNode originNode, out Stack<PathNode> path)
    {
        path = new Stack<PathNode>();

    }
    
    PathNode GetOpenNode(PathNode destinationNode)
    {
        PathNode openNode = null;

        if (openNodes.Count > 0)
        {
            openNode = openNodes[0];
            float closestSqrDistToDest = (destinationNode.Position - openNode.Position).sqrMagnitude;
            foreach (PathNode pathNode in openNodes)
            {
                float sqrDistToDest = (destinationNode.Position - pathNode.Position).sqrMagnitude;

                if (pathNode.AccumulatedCost < openNode.AccumulatedCost && sqrDistToDest < closestSqrDistToDest)
                {
                    closestSqrDistToDest = sqrDistToDest;
                    openNode = pathNode;
                }
            }
        }
        return openNode;
    }

    void OpenNode(PathNode node)
    {
        node.State = NodeState.open;
        openNodes.Add(node);
    }

    void CloseNode(PathNode node)
    {
        node.State = NodeState.closed;
        openNodes.Remove(node);
        closedNodes.Add(node);
    }

    void OpenAdjacentNodes(PathNode parentNode)
    {
        foreach (Vector2Int adjacentIndex in parentNode.AdjacentNodeIndex)
        {
            PathNode adjacentNode = pathNodes[adjacentIndex.x, adjacentIndex.y];
            if (adjacentNode.State == NodeState.Unreviewed)
            {
                float sqrDistance = (parentNode.Position - adjacentNode.Position).sqrMagnitude;
                parentNode.Child = adjacentNode;
                adjacentNode.Parent = parentNode;
                adjacentNode.AccumulatedCost += parentNode.AccumulatedCost + sqrDistance;
                OpenNode(adjacentNode);
            }
            
        }
    }

    void ResetNodes()
    {
        foreach (PathNode pathNode in openNodes)
        {
            pathNode.State = NodeState.Unreviewed;
            pathNode.Parent = null;
            pathNode.Child = null;
            pathNode.AccumulatedCost = pathNode.Cost;
        }
        foreach (PathNode pathNode in closedNodes)
        {
            pathNode.State = NodeState.Unreviewed;
            pathNode.Parent = null;
            pathNode.Child = null;
            pathNode.AccumulatedCost = pathNode.Cost;
        }

        openNodes.Clear();
        closedNodes.Clear();
    }


}
