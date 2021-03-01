using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathNodeGenerator
{
    float minPosX = 0f;
    float maxPosX = 0f;
    float minPosZ = 0f;
    float maxPosZ = 0f;

    int height = 0;
    int width = 0;
    Vector3 size = Vector3.zero;

    [SerializeField] Terrain terrain = null;
    [SerializeField] float pathNodeDistance = 1f;
    public LayerMask terrainLayer;
    public LayerMask obstacleLayer;
    PathNode [] pathNodes;

    private void Start()
    {
        size.x = terrain.terrainData.size.x;
        size.z = terrain.terrainData.size.z;
        
    }

    public  void GereneratePathNodes()
    {
        width = Mathf.FloorToInt(size.x / pathNodeDistance);
        height = Mathf.FloorToInt(size.z / pathNodeDistance);
        maxPosX = size.x;        
        maxPosZ = size.y;
      //minPosX = ;
      //minPosZ = ;
        pathNodes = new PathNode[width * height];
        Vector3 currentRayPos = new Vector3 (minPosX,1000,minPosZ);        

        for (float z = minPosZ; z <= maxPosZ; z += pathNodeDistance)
        {
            for (float x = minPosZ; x <= maxPosX; x += pathNodeDistance)
            {

            }
        }
    }

    public void SetAdjacentNodes()
    {
         

    }
}
