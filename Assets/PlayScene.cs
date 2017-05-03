using UnityEngine;
using System.Collections;

public class PlayScene : MonoBehaviour
{
    public GameObject airVr;
    public float duration;

    public GameObject[] particles;
    public bool particleOn = false;
    private float nowTime = 0.0f;
    private Scene scene;

    private void Awake()
    {
        scene = Scene.Instance;
        Cursor.visible = false;
        Screen.SetResolution(1920 , 1200 , true);

        for(int i=0; i<particles.Length; i++)
        {
            particles[i].SetActive(false);
        }
    }

    private void Update()
    {
        scene.ManualUpdate();

        if (nowTime < duration)
        {
            if(nowTime > 3f && particleOn == false)
            {
                particleOn = true;
                for (int i = 0; i < particles.Length; i++)
                {
                    particles[i].SetActive(true);
                }
            }

            nowTime += Time.deltaTime;
            return;
        }

        Destroy(airVr);
        Scene.Instance.GoToEndScene();
    }
}
