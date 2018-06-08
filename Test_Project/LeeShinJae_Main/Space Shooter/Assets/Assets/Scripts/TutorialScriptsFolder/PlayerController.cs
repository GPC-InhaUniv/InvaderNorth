using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Unity는 위에서부터 한줄씩 함수를 실행한다.

[System.Serializable]
public class Boundary
{
    public float xMin, xMax, zMin, zMax;
}

public class PlayerController : MonoBehaviour {

    public float speed; // 이 변수가 없는상태로 실행하면 moveHorizontal, moveVertical의 값이
                        // 0~1 까지로만 변하게 되므로 speed값을 곱해줌으로서 한번에 움직이는 거리를 길게한다.
    public Boundary boundary;
    //Boundary클래스를 선언함
    public float tilt;
    //비행기가 양옆으로 움직일 때 기울기를 조정하는  public 값
    public GameObject shot;
    public Transform[] shotSpawns; //shotSpawn.transform.position..
    public float FireRate;
    private float nextFire;
    new AudioSource audio;

    private void Start()
    {
        audio = GetComponent<AudioSource>();
    }
    private void Update()
    {
        if(Input.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time +FireRate;
            //GameObject clone = 
            foreach(var shotSpawn in shotSpawns)
            {
                Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
            }
            //as GameObject;
            //추가만 해준다고 audio재생이 되는것이 아니라 script에서 play명령을 내려줘야 한다.
            audio.Play();// Unity5 부터는 Getcomponent<>로 직접 가져와줘야 한다.
           
        }
        //Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
    }
    private void FixedUpdate()
    {
        //플레이어에게서 입력값을 받는다.
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Rigidbody rigidbody = GetComponent<Rigidbody>();
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rigidbody.velocity = movement * speed;
        //Mathf: 유용한 수학함수 모음
        //pie, Pingpong, Tangent, Sin, Cos etc....
        rigidbody.position = new Vector3
            (
                Mathf.Clamp(rigidbody.position.x, boundary.xMin, boundary.xMax),
                0.0f,
                Mathf.Clamp(rigidbody.position.z, boundary.zMin, boundary.zMax)
            );
        //Quaternion.Euler 한번 더 찾아보기 => 비행기가 양쪽으로 움직일 때 기울이기를 적용한다.
        rigidbody.rotation = Quaternion.Euler(0.0f, 0.0f, rigidbody.velocity.x * -tilt);
    }
}

