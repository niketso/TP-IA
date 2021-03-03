using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathfindingManager : MonoBehaviour
{
    static PathfindingManager instance;

    void SetUpSingleton()
    {
        if (Instance == this)
            DontDestroyOnLoad(gameObject);
        else
            Destroy(gameObject);
    }

    public static PathfindingManager Instance
    {
        get
        {
            if (!instance)
                instance = FindObjectOfType<PathfindingManager>();
            if (!instance)
            {
                GameObject pathFindingManager = new GameObject("Pathfinding Manager");
                instance = pathFindingManager.AddComponent<PathfindingManager>();
            }

            return instance;
        }
    }

    [SerializeField] Terrain terrain = null;
    [SerializeField] PathNodeGenerator PathNodeGenerator = new PathNodeGenerator();
    private PathNode[,] pathNodes;
    private PathNode[,] OpenNodes;
    public LayerMask pathlayer;
    public Vector2 size;
    

    private void Awake()
    {
        SetUpSingleton();
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


}
