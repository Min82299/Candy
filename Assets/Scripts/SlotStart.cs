using System.Collections;
using UnityEngine;

public class SlotStartTrigger : MonoBehaviour
{
    public SlotMachinecontroller slotMachinne; // 呼び出したいスロットマネージャー
    public float cooltime = 3f;

    private bool alreadyTriggered = false;

    private void OnTriggerEnter(Collider other)
    {
        // すでに呼び出していたら無視（連続発火防止）
        if (alreadyTriggered) return;

        // 通過したオブジェクトのタグが "Candy" などか確認（必要に応じて）
        if (other.CompareTag("Candy") && slotMachinne.candyManager.GetCandyAmount() > 0)
            {
                alreadyTriggered = true;
                slotMachinne.candyManager.ConsumeCandy(); // trừ kẹo khi chơi slot
                slotMachinne.Spinslot();
                StartCoroutine(ResetTrigger());
            }

    }
    private IEnumerator ResetTrigger()
    {
        yield return new WaitForSeconds(cooltime);
        alreadyTriggered = false;
    }
}
