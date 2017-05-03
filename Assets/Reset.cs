using UnityEngine;
using System.Collections;

public class Reset : MonoBehaviour {

    public GameObject sphere;
    public GameObject floor;
    public GameObject hip;

    private void Start()
    {
        ResetStart();
    }

    private void ResetStart()
    {
        StartCoroutine(ResetRoutine());
    }

    private IEnumerator ResetRoutine()
    {
        float waitTime = 1.0f;
        float nowTime = 0.0f;

        while(nowTime < waitTime)
        {
            nowTime += Time.deltaTime;
            yield return null;
        }

        print("Go");
        floor.transform.localPosition = hip.transform.localPosition + new Vector3(0.0f, -6.0f, 0.0f);
        sphere.transform.localPosition = hip.transform.localPosition + new Vector3(0.0f, -6.0f, 0.0f);
    }
}
