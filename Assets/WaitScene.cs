using UnityEngine;
using System.Collections;

public class WaitScene : MonoBehaviour {

    private Scene scene;

    private void Awake()
    {
        Cursor.visible = false;
        scene = Scene.Instance;
    }
	// Update is called once per frame
	void Update ()
    {
        scene.ManualUpdate();
	}
}
