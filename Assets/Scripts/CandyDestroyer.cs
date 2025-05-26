using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandyDestroyer : MonoBehaviour
{
    public CandyManager manager;
    public int reward;
    public GameObject effectPrefab;//さっき作ったエフェクト
    public Vector3 effectRotation;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //見えない壁に当たったら飴を消す
    private void OnTriggerEnter(Collider other)
    {
        //重なった相手のタグがキャンディなら、その相手を消す
        if (other.gameObject.tag == "Candy")
        {
            Destroy(other.gameObject);
            //キャンディを追加する
            manager.AddCandy(reward);
            manager.DisplayCandyAmount();
            if(effectPrefab!= null)
            {
                Instantiate(effectPrefab, other.transform.position, Quaternion.Euler(effectRotation));
            }

        }
    }
}
