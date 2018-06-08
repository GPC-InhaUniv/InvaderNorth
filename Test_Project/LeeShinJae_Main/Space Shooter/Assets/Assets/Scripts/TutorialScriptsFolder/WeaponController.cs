using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour {

    public GameObject shot;
    public Transform shotSpawn;
    public float fireRate;
    public float delay;
    private AudioSource audioSource;
    


	void Start ()
    {
        audioSource = GetComponent<AudioSource>();
        InvokeRepeating("Fire", delay, fireRate); //InvokeRepeating() 잘 알아둘것...
	}

    void Fire()
    {
        //shotSpawn의 위치, 회전값을 가져와서 shot을 생성함
        Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
        audioSource.Play();
    }
}
