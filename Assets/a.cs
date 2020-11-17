using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class a : MonoBehaviour
{
    public static float currentTime = 3f;
    float stopTime = 0f;

    private TextMeshPro textMeshPro;

    public static int hitCount = 0;

    private void Awake()
    {
        textMeshPro = GetComponent<TextMeshPro>();

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

        print(currentTime);

        if (currentTime < 0f)
        {
            hitCount = 0;
            currentTime = 3f;
        }

    }
}
