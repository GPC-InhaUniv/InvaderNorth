using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScroller : MonoBehaviour {

    public float scrollSpeed;
    public float tilesSizeZ;
    private Vector3 startPosition;
	void Start () {
        startPosition = transform.position;
	}

	void Update () {
        float newposition = Mathf.Repeat(Time.time * -scrollSpeed, tilesSizeZ);
        transform.position = startPosition + Vector3.forward * newposition;
	}
}
