using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleRotator : MonoBehaviour {
    
	private void Start () {
        StartCoroutine(RotateVehicle());
	}

    IEnumerator RotateVehicle()
    {
        while(true)
        {
            gameObject.transform.Rotate(0, Time.deltaTime * 50, 0, Space.World);
            yield return null;
        }
    }
	
}
