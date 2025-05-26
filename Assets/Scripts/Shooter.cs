using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Shooter : MonoBehaviour
{
    public GameObject[] candyPrefabs;
    public Transform candyParentTransform;
    public float shotTorque;
    public float shotForce;
    public float basewidth;
    public CandyManager cm;
    AudioSource shotSound;

    private void Start()
    {
        shotSound = GetComponent<AudioSource>();//音を鳴らす準備
    }
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))Shot();
    }
    void Shot()
    {
        //  キャンディの数が０になったら出なくする
        if(cm.GetCandyAmount() <= 0)
        {
            return;
        }
        GameObject candy=Instantiate(SelectCandy(), GetInstantiatePotision(), Quaternion.identity);
        //Instantiate=プレハブのコピー
        Rigidbody rb=candy.GetComponent<Rigidbody>();//rigidbodyを持ってくる
        rb.AddForce(transform.forward * shotForce);//力を加えさせる処理
        rb.AddTorque(new Vector3(0, shotTorque, 0));//ねじれを起こす
        //キャンディを減らす処理を持ってくる
        cm.ConsumeCandy();
        cm.DisplayCandyAmount();
        shotSound.Play();
    }
    //ランダムにキャンディを選んで渡す
    GameObject SelectCandy()
    {
        int select = Random.Range(0, candyPrefabs. Length);
        return candyPrefabs[select];
    }
    Vector3 GetInstantiatePotision()
    {
        float x=basewidth*(Input.mousePosition.x/Screen.width)-(basewidth/2);
        return transform.position+new Vector3(x,0,0);
    }
}
