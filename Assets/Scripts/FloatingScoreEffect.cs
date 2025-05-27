using UnityEngine;
using TMPro;
using System.Collections;

public class FloatingScoreEffect : MonoBehaviour
{
    public float floatSpeed = 50f;
    public float duration = 1.5f;

    private CanvasGroup canvasGroup;
    private TextMeshProUGUI tmp;

    void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        tmp = GetComponent<TextMeshProUGUI>();
        StartCoroutine(FadeAndRise());
    }

    IEnumerator FadeAndRise()
    {
        float timer = 0f;
        Vector3 startPos = transform.position;

        while (timer < duration)
        {
            float t = timer / duration;
            transform.position = startPos + Vector3.up * floatSpeed * t;
            canvasGroup.alpha = 1 - t;
            timer += Time.deltaTime;
            yield return null;
        }

        Destroy(gameObject);
    }
}
