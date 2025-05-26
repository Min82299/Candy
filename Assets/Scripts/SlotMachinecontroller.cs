using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotMachinecontroller : MonoBehaviour
{
    public Slotreal[] reels;
    public CandyManager candyManager;
    public AudioSource winSound; // スロットが揃ったときの効果音
    private List<Sprite> results = new List<Sprite>();

    public Sprite fruit_cherry_illsut_137;
    public Sprite iconstar;
    public Sprite candy;

    private Dictionary<Sprite, int> candyRewards;

    private void Start()
    {
        // Spriteに応じたキャンディ数のマップ
        candyRewards = new Dictionary<Sprite, int>()
        {
            { fruit_cherry_illsut_137, 3 },
            { iconstar, 10 },
            { candy, 5 },
        };

        // AudioSource の設定確認
        if (winSound == null)
        {
            winSound = GetComponent<AudioSource>();
            if (winSound == null)
            {
                Debug.LogError("AudioSource が設定されていません！");
            }
        }
        
    }

    public void Spinslot()
    {
        results.Clear();
        foreach (var reel in reels)
        {
            reel.StartSpinning();
        }
        StartCoroutine(StopReel());
    }

    private IEnumerator StopReel()
    {
        for (int i = 0; i < reels.Length; i++)
        {
            yield return StartCoroutine(reels[i].StopSpinning(0.5f, result => results.Add(result)));
        }
        CheckResult();
    }

    private void CheckResult()
    {
        if (results.Count >= 3)
        {
            // 全部同じ絵柄か？
            if (results[0] == results[1] && results[1] == results[2])
            {
                Sprite matched = results[0];

                if (candyRewards.ContainsKey(matched))
                {
                    int reward = candyRewards[matched];
                    if (candyManager != null)
                    {
                        candyManager.AddCandy(reward);
                        candyManager.DisplayCandyAmount();
                        // 効果音を再生
                        if (winSound != null)
                        {
                            winSound.Play();
                        }
                        Debug.Log("当たり！" + matched.name + "でキャンディ " + reward + "個ゲット！");
                    }
                    else
                    {
                        Debug.LogError("CandyManager が設定されていません！");
                    }
                }
                else
                {
                    Debug.Log("はずれ...");
                }
            }
        }
    }
}