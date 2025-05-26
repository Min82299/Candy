using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CandyManager : MonoBehaviour
{
    public int defaultCandyAmount = 30;//�ŏ��̃L�����f�B�̏�����
    public int candy;
    public TextMeshProUGUI candyamount;
    public TextMeshProUGUI countdown;
    const int Recoverytime = 10;//�񕜂���܂ł̎���
    int counter;//�J�E���g�_�E�������邽�߂̏���
    void Start()
    {
        candy = defaultCandyAmount;
        DisplayCandyAmount();
    }
    private void Update()
    {
        if(counter <= 0&&candy<defaultCandyAmount)
        {
            StartCoroutine(Recoverycandy());//�J�E���^�[���O�ȉ��̎��ɃJ�E���^�[���쓮������
        }
    }
    IEnumerator Recoverycandy()//�J�E���g���J�n������
    {
        counter = Recoverytime;
        while (counter > 0)
        {
            yield return new WaitForSeconds(1.0f);//�P�b�҂�
            counter--;
            //Debug.Log("counter" + counter);
            countdown.SetText("("+counter+"s)");
        }
        candy++;
        DisplayCandyAmount();
    }

    //�L�����f�B�̐������炷���\�b�h
    public void ConsumeCandy()
    {
        if (candy > 0)
        {

            candy--;//�L�����f�B��1���炷
            DisplayCandyAmount(); 
        }
    }

    //�L�����f�B�̐��𑝂₷���\�b�h
    public void AddCandy(int amount)
    {
        candy=candy+amount;//candy+=amount�Ɠ����Ӗ�
    }

    //�L�����f�B�̐�����ʂɕ\������
    public void DisplayCandyAmount()
    {
        candyamount.SetText("Candy:" + candy);
    }

    public int GetCandyAmount()
    {
        return candy;
    }
    
}
