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
    [SerializeField] Movement movement = null;
    public int currentGold = 0;
    public bool isFull = false;
    private float fov = 45f;
    private float viewDistance = 10f;
    private MineDetector mineDetector;
    private bool hasMine = false;
    public Mine lastMine = null;


    private void Start()
    {
        mineDetector = GetComponentInChildren<MineDetector>();        
        mineDetector.checkCollisionMiner += OnCollisionDetect;
        

    }

    public bool CanMine(Mine currentMine)
    {

        if (currentMine)
        {
            Debug.Log("Miner::CanMine(); true");
            return true;
        }

         Debug.Log("Miner::CanMine(); false");
        return false;

    }

    public void Mine(Mine currentMine)
    {
        if ( currentMine.IsActive() && HasCapacity())
        {
            if (currentMine.ExtractGold(efficiency))
            {
                currentGold += efficiency;
            }
            if (currentMine.IsEmpty() || !currentMine.IsActive())
            {
                Debug.Log("Miner::Mine().Empty Mine");
                //this.lastMine = null;
            }
            Debug.Log("Miner::Mine()");
        }
    }

    public bool HasCapacity()
    {
        if (capacity > currentGold)
        {
            Debug.Log("Miner::HasCapacity().Can carry.");
            return true;
        }
        else
        {
            isFull = true;
            Debug.Log("Miner::HasCapacity().Already full.");
            return false;
        }
    }
    public bool DepositGold(HQ hq)
    {
        if (hq)
        {
            if (hq.DepositGold(this))
            {
                Debug.Log("Miner::Deposit. Depositing");
                return true;
            }
            else
            {
                Debug.Log("Miner::Deposit. Couldn't deposit.");
                return false;
            }

        }
        else
        {
            return false;
        }

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
                if (hit.transform.gameObject.layer == 12)
                {
                    MineDetection(false);
                    StopMoving();
                    lastMine = hit.transform.gameObject.GetComponent<Mine>();
                    hasMine = true;
                }
            }
            else
            {
                Debug.Log("OnCollisionDetect(),NO ES POR AHI");
            }
        }
        else
        {
            Debug.Log("OnCollisionDetect(),Wrong Angle");
        }
    }

    public bool HasMine()
    {
        return hasMine;
    }
    public void SetHasMine(bool _Hasmine)
    {
        hasMine = _Hasmine;
    }

    public void MineDetection(bool active)
    {
        MineDetectorGO.SetActive(active);
    }
    public void SetDestination(Vector3 destination)
    {
        movement.SetDestination(destination);
    }

    public void StopMoving()
    {
        movement.StopMoving();
    }

    public bool HasArrived()
    {
        return movement.HasArrived();
    }

    public void SetState(bool state)
    {
        movement.SetState(state);
    }
}
