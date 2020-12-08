using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ComboCounter : MonoBehaviour
{
    public static float currentTime = 3f;
    float stopTime = 0f;

    private TextMeshProUGUI textMeshPro;

    public static int hitCount = 0;

    public static int HighestCount;

    private void Awake()
    {
        textMeshPro = GetComponent<TextMeshProUGUI>();

        SetHitCounter(hitCount);
    }

    private void SetHitCounter(int hitCount)
    {
        textMeshPro.SetText(hitCount.ToString());
    }

    private void Update()
    {
        SetHitCounter(hitCount);

        currentTime -= 1 * Time.deltaTime;

        if (currentTime < 0f)
        {
            hitCount = 0;
            currentTime = 3f;
        }

        if (hitCount > HighestCount)
        {
            HighestCount = hitCount;

        }

    }
}
