using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldCandy : MonoBehaviour
{
    public int bonusCandy = 5;
    public CandyManager CandyManager;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            CandyManager.AddCandy(bonusCandy); 
            CandyManager.AddScore(bonusCandy); 
            CandyManager.DisplayCandyAmount();
            Destroy(gameObject);
        }
    }
}
