using UnityEngine;
using System.Collections;

public class TitleScene : MonoBehaviour
{
    private Scene scene;
    
    private void Awake()
    {
        scene = Scene.Instance;
    }

    private void Update()
    {
        scene.ManualUpdate();
    }
}
