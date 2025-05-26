using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slotreal : MonoBehaviour
{
    public SpriteRenderer reelSpriteRenderer; // SpriteRenderer コンポーネント
    public Sprite[] symbols; // 絵柄のスプライト配列

    private int currentIndex = 0;
    private bool spinning = false;

    private void Start()
    {
        // SpriteRenderer が設定されているか確認
        if (reelSpriteRenderer == null)
        {
            reelSpriteRenderer = GetComponent<SpriteRenderer>();
            if (reelSpriteRenderer == null)
            {
                Debug.LogError("SpriteRenderer が設定されていません！", gameObject);
            }
        }
        // 初期スプライトを設定
        if (symbols.Length > 0)
        {
            reelSpriteRenderer.sprite = symbols[0];
        }
    }

    public void StartSpinning()
    {
        if (symbols.Length == 0)
        {
            Debug.LogWarning("Symbols 配列が空です！", gameObject);
            return;
        }
        spinning = true;
        StartCoroutine(SpinRoutine());
    }

    public IEnumerator StopSpinning(float delay, System.Action<Sprite> onStopped)
    {
        yield return new WaitForSeconds(delay);
        spinning = false;

        // ランダムに絵柄を選択
        currentIndex = Random.Range(0, symbols.Length);
        reelSpriteRenderer.sprite = symbols[currentIndex];
        // 外部に通知
        onStopped?.Invoke(symbols[currentIndex]);
    }

    private IEnumerator SpinRoutine()
    {
        while (spinning)
        {
            currentIndex = (currentIndex + 1) % symbols.Length;
            reelSpriteRenderer.sprite = symbols[currentIndex];
            yield return new WaitForSeconds(0.05f);
        }
    }
}