using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private float speed = 0.001f;
    public bool keepMoving = true;
    private bool arrived = false;
    Stack<PathNode> path;
    PathNode currentTarget;

    public void SetDestination(Vector3 destination)
    {

        path = PathfindingManager.Instance.GeneratePath(transform.position, destination);
        keepMoving = true;
        arrived = false;
        if (path != null)
        {
            while (path.Count > 0 && keepMoving)
            {
                currentTarget = path.Pop();
                MoveToTarget(currentTarget.Position);

            }
            if (!keepMoving)
            {
                arrived = true;
                currentTarget = path.Pop();
                MoveToTarget(currentTarget.Position);
                keepMoving = true;
                
            }

            if (path.Count == 0)
            {
                arrived = true;
                keepMoving = false;
            }


        }
        
            
    }

    public void MoveToTarget(Vector3 destination)
    {
        destination.y = 1.0f;
        float maxDistanceDelta = speed * Time.deltaTime;
        Vector3 currentPos = transform.position;       
        transform.position = Vector3.MoveTowards(currentPos, destination, maxDistanceDelta);
        //dist = Vector3.Distance(transform.position, destination);
        //maxDistanceDelta = speed * Time.deltaTime;        
        //transform.position = destination;
        
    }

    public void StopMoving()
    {
        keepMoving = false;
    }

    public bool HasArrived()
    {
        return arrived;
    }

    public void SetState(bool state)
    {
        arrived = state;
    }

}
