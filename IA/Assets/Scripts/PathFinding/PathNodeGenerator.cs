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
    Vector2 size = Vector2.zero;


    float pathNodeDistance = 1f;
    PathNode[,] pathNodes;



    public PathNode[,] GereneratePathNodes(Vector2 sizeOfTerrain,LayerMask lymsk)
    {
        size.x = sizeOfTerrain.x;
        size.y = sizeOfTerrain.y;
        width = Mathf.FloorToInt(size.x / pathNodeDistance);
        height = Mathf.FloorToInt(size.y / pathNodeDistance);
        maxPosX = size.x;
        maxPosZ = size.y;
        minPosX = 0;
        minPosZ = 0;
        pathNodes = new PathNode[width, height];
        

        for (float z = minPosZ; z < maxPosZ; z ++)
        {
            for (float x = minPosX; x < maxPosX; x ++)
            {
                RaycastHit hit;
                Vector3 rayOrigin = new Vector3(x, 1000f, z);
               // Debug.DrawRay(rayOrigin, Vector3.down * 100f, Color.red);
                if (Physics.Raycast(rayOrigin, Vector3.down, out hit, 1000f, lymsk))
                {
                    PathNode pathNode = null;

                    //layer 9 terrain
                    if (hit.transform.gameObject.layer == 9)
                    {
                        pathNode = new PathNode(hit.point);

                    }//layer 10 obstacle
                    else if (hit.transform.gameObject.layer == 10)
                    {
                        pathNode = new PathNode(hit.point, true);
                    }


                    Debug.Log(hit.transform.gameObject.layer);

                    if (pathNode != null)
                    {
                        pathNodes[(int)x, (int)z] = pathNode;

                    }
                }
               
            }
        }
        SetAdjacentNodes(pathNodes);
        return pathNodes;
    }

    public void SetAdjacentNodes(PathNode[,] pathNodeM)
    {

        for (int z = (int)minPosZ; z < maxPosZ; z++)
        {
            for (int x = (int)minPosX; x < maxPosX; x++)
            {
                if (pathNodeM[x,z] != null && !pathNodeM[x, z].CanBeBlocked)
                {
                    //-1,-1
                    if (x - 1 > 0 && z - 1 > 0)
                    {
                        if (pathNodeM[x - 1, z - 1] != null && !pathNodeM[x - 1, z - 1].CanBeBlocked)
                        {
                            pathNodeM[x, z].AdjacentNodeIndex.Add(new Vector2Int(x - 1, z - 1));
                        }
                    }
                    //-1 1            
                    if (x - 1 > 0)
                    {
                        if (pathNodeM[x - 1, z] != null && !pathNodeM[x - 1, z].CanBeBlocked)
                        {
                            pathNodeM[x, z].AdjacentNodeIndex.Add(new Vector2Int(x - 1, z));
                        }
                    }
                    //-1 +1
                    if (x - 1 > 0 && z + 1 < height)
                    {
                        if (pathNodeM[x - 1, z + 1] != null && !pathNodeM[x - 1, z + 1].CanBeBlocked)
                        {
                            pathNodeM[x, z].AdjacentNodeIndex.Add(new Vector2Int(x - 1, z + 1));
                        }

                    }
                    //1 -1
                    if (z - 1 > 0)
                    {
                        if (pathNodeM[x, z - 1] != null && !pathNodeM[x, z - 1].CanBeBlocked)
                        {
                            pathNodeM[x, z].AdjacentNodeIndex.Add(new Vector2Int(x, z - 1));
                        }
                    }
                    //1 +1
                    if (z + 1 < height)
                    {
                        if (pathNodeM[x, z + 1] != null && !pathNodeM[x, z + 1].CanBeBlocked)
                        {
                            pathNodeM[x, z].AdjacentNodeIndex.Add(new Vector2Int(x, z + 1));
                        }
                    }
                    //+1 -1
                    if (x + 1 < width && z - 1 > 0)
                    {
                        if (pathNodeM[x + 1, z - 1] != null && !pathNodeM[x + 1, z - 1].CanBeBlocked)
                        {
                            pathNodeM[x, z].AdjacentNodeIndex.Add(new Vector2Int(x + 1, z - 1));
                        }
                    }
                    //+1 1
                    if (x + 1 < width)
                    {
                        if (pathNodeM[x + 1, z] != null && !pathNodeM[x + 1, z].CanBeBlocked)
                        {
                            pathNodeM[x, z].AdjacentNodeIndex.Add(new Vector2Int(x + 1, z));
                        }
                    }
                    //+1 +1
                    if (x + 1 < width && z + 1 < height)
                    {
                        if (pathNodeM[x + 1, z + 1] != null && !pathNodeM[x + 1, z + 1].CanBeBlocked)
                        {
                            pathNodeM[x, z].AdjacentNodeIndex.Add(new Vector2Int(x + 1, z + 1));
                        }
                    }
                }
            }
        }
    }
}