using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mine : MonoBehaviour
{
    [SerializeField] private int capacity = 0;
    public bool isEmpty = false;
    

    private void Update()
    {
        if (!IsActive())
        {
            DeactivateMine();
        }
    }

    public bool IsActive()
    {
        if (capacity > 0 && gameObject.activeInHierarchy == true)
        {
            return true;
        }
        else
        {
            isEmpty = true;
            return false;
        }
    }

    public bool IsEmpty()
    {
        return isEmpty;
    }
    public void DeactivateMine()
    {
        Spawner.Instance.currentFlags--;
        gameObject.SetActive(false);
        Destroy(gameObject);
    }

    public bool ExtractGold(int quantity)
    {
        if (capacity > 0)
        {
            capacity -= quantity;
            return true;
        }
        else
        {
            return false;
        }
    }

    /*private void OnTriggerEnter(Collider other)
    {
        if (other.tag == ("Player"))
        {
            //Debug.Log("Mine::OTE. Arrived to Mine");
            minerManager.SetState(new MiningState(minerManager));
        }
    }
    */
     
}
