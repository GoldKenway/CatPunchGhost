using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitFeel : MonoBehaviour
{

    bool stopping;
    float SlowTime = 1f;

    public void TimeStop(float Duration)
    {
        if (stopping)
            return;
        Time.timeScale = 0;

        StartCoroutine(Stop(Duration));

    }

    IEnumerator Stop(float Duration)
    {
        stopping = true;
        yield return new WaitForSecondsRealtime(Duration);
        Time.timeScale = 0.01f;

        yield return new WaitForSecondsRealtime(SlowTime);


        Time.timeScale = 1;
        stopping = false;

    }

}
