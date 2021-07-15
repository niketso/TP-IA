using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    static Spawner instance;

    public static Spawner Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<Spawner>();
            }
            return instance;
        }
    }


    [SerializeField] private int maxSpots = 0;
    [SerializeField] GameObject spotPrefab = null;
    [SerializeField] GameObject minePrefab = null;
    [SerializeField] GameObject spots = null;  
    [SerializeField] GameObject mines = null;
    private Vector3 spawnPosition = Vector3.zero;

    private void Awake()
    {
        instance = this;

        DontDestroyOnLoad(gameObject);
    }
    private void Start()
    {
        for (int i = 0; i < maxSpots; i++)
        {
            CreateSpot();
        }
    }

    private void Update()
    {
      
    }

    public GameObject CreateSpot()
    {
        GameObject spot = null;       
        spawnPosition = PathfindingManager.Instance.GetRandomPathNodePos();
        spawnPosition.y = 1.0f;
        spot = Instantiate(spotPrefab, spawnPosition, Quaternion.identity, spots.transform);                          
        return spot;
    }

    public void ResetSpot(GameObject Spot)
    {
        Vector3 newPos = PathfindingManager.Instance.GetRandomPathNodePos();
        newPos.y = 1.0f;
        Spot.transform.position = newPos;

    }

    public void CreateMine(Vector3 position)
    {        
        Instantiate(minePrefab,position, Quaternion.identity, mines.transform);
        Debug.Log("creo");
    }
   
}
