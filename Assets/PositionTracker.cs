using UnityEngine;
using System.Collections;

public class PositionTracker : MonoBehaviour {

    public GameObject RobotPos;
	
	// Update is called once per frame
	void Update () {
        transform.localPosition = RobotPos.transform.localPosition;

    }
}
