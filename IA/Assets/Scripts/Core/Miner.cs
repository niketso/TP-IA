using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Miner : StateMachine
{
    [SerializeField] private LayerMask layerMask = 0;
    //How much it can carry.
    [SerializeField] private int capacity = 0;
    //How many per action it can mine.
    [SerializeField] private int efficiency = 0;
    [SerializeField] GameObject MineDetectorGO = null;
    public int currentGold = 0;
    private float speed = 1f;
    private float fov = 45f;
    private float viewDistance = 10f;
    private MineDetector mineDetector;
    private bool hasMine;


    private void Start()
    {
        mineDetector = GetComponentInChildren<MineDetector>();
        mineDetector.checkCollisionMiner += OnCollisionDetect;
    }

    public bool CanMine(Mine currentMine)
    {

        if (currentMine)
        {
            //Debug.Log("Miner::CanMine(); true");
            return true;
        }

        // Debug.Log("Miner::CanMine(); false");
        return false;

    }

    public void Mine(Mine currentMine)
    {
        if (HasCapacity() || currentMine.IsActive())
        {
            if (currentMine.ExtractGold(efficiency))
            {
                currentGold += efficiency;
            }
        }
    }

    public bool HasCapacity()
    {
        if (capacity > currentGold)
        {
            //Debug.Log("Miner::HasCapacity().Can carry.");
            return true;
        }
        else
        {
            //Debug.Log("Miner::HasCapacity().Already full.");
            return false;
        }
    }
    public bool DepositGold(HQ hq)
    {
        if (hq)
        {
            if (hq.DepositGold(this))
            {
                //Debug.Log("Miner::Deposit. Depositing");
                return true;
            }
            else
            {
                //Debug.Log("Miner::Deposit. Couldn't deposit.");
                return false;
            }

        }
        else
        {
            return false;
        }

    }

    public void SetDestination(Vector3 destination)
    {
        float maxDistanceDelta = 0;
        transform.position = Vector3.MoveTowards(transform.position, destination, maxDistanceDelta);
    }

    public void OnCollisionDetect(GameObject GO)
    {
        Vector3 direction = GO.transform.position - this.transform.position;
        float angle = Vector2.Angle(direction, this.transform.forward);

        if (angle < fov * 0.5f)
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, direction.normalized, out hit, viewDistance, layerMask))
            {
                if (hit.transform.gameObject.layer == 11)
                {
                    hasMine = true;
                    MineDetection(false);
                }
            }
        }
    }

    public bool HasMine()
    {
        return hasMine;
    }
    public void MineDetection(bool active)
    {
        MineDetectorGO.SetActive(active);
    }
}
