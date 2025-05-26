using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandyDestroyer : MonoBehaviour
{
    public CandyManager CandyManager;
    public int reward;
    public GameObject effectPrefab;//������������G�t�F�N�g
    public Vector3 effectRotation;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //�����Ȃ��ǂɓ��������爹������
    private void OnTriggerEnter(Collider other)
    {
        //�d�Ȃ�������̃^�O���L�����f�B�Ȃ�A���̑��������
        if (other.gameObject.tag == "Candy")
        {
            Destroy(other.gameObject);
            //�L�����f�B��ǉ�����
            CandyManager.AddCandy(reward);
            CandyManager.DisplayCandyAmount();
            if(effectPrefab!= null)
            {
                Instantiate(effectPrefab, other.transform.position, Quaternion.Euler(effectRotation));
            }

        }
    }
}
