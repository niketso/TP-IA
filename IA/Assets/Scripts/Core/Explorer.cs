using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Explorer : MonoBehaviour
{
    [SerializeField] private LayerMask layerMask = 0;
    [SerializeField] GameObject SpotDetectorGO;
    private float speed = 1f;
    private float fov = 45f;
    private float viewDistance = 10f;
    private bool hasSpot = false;
    private SpotDetector SpotDetector;

    private void Start()
    {
        SpotDetector = GetComponentInChildren<SpotDetector>();
        SpotDetector.checkCollisionExplorer += OnCollisionDetect;
    }
     
    public bool HasSpot()
    {       
        return hasSpot;
    }

    public void OnCollisionDetect(GameObject GO)
    {
        Vector3 direction =  GO.transform.position - this.transform.position;
        float angle = Vector2.Angle(direction, this.transform.forward);

        if (angle < fov * 0.5f)
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, direction.normalized, out hit, viewDistance, layerMask))
            {
                if (hit.transform.gameObject.layer == 11)
                {
                    hasSpot = true;
                    SpotDetection(false);
                } 
            }
        }
    }

    public void SpotDetection(bool active)
    {
        SpotDetectorGO.SetActive(active);
    }

    public void SetDestination(Vector3 destination)
    {
        float maxDistanceDelta = 0;
        transform.position = Vector3.MoveTowards(transform.position, destination, maxDistanceDelta);
    }
}
