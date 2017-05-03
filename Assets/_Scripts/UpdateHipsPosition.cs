using UnityEngine;
using System.Collections;

public class UpdateHipsPosition : MonoBehaviour {

	public GameObject origin;

	void Update () {
        this.transform.localPosition = origin.transform.localPosition;

    }   
}
