using UnityEngine;
using System.Collections;

[System.Serializable]
public struct Boundary
{
    public float xMin, xMax, zMin, zMax;
}

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float tilt;
    public Boundary boundary;

    public GameObject shot;
    public Transform shotSpawn;
    public float fireRate;
    float nextFire;
    AudioSource shotAudio;
    GameObject bullet;
    Rigidbody rigidbody;
    Collider collider;



    void OnEnable()                  //활성화 시 호출되는 함수.
    {
        if (rigidbody != null)           //처음에는 실행 안되게
        {
            StartCoroutine(FirstMove());
            StartCoroutine(GetShotInput());
            StartCoroutine(GetTransferInput());
        }
    }

    void Start()
    {
        collider = GetComponent<MeshCollider>();
        rigidbody = GetComponent<Rigidbody>();
        shotAudio = GetComponent<AudioSource>();
        StartCoroutine(FirstMove());
        StartCoroutine(GetShotInput());
        StartCoroutine(GetTransferInput());
    }



    IEnumerator GetShotInput()
    {
        yield return new WaitForSeconds(2);
        while (true)
        {
            if (Input.GetButton("Fire1") && Time.time > nextFire)
            {
                nextFire = Time.time + fireRate;
                bullet = ObjectPoolManager.PoolManager.PlayerBulletPool.PopFromPool();
                bullet.transform.position = shotSpawn.position;
                bullet.SetActive(true);
                shotAudio.Play();

            }
            yield return null;
        }
    }

    IEnumerator GetTransferInput()
    {
        yield return new WaitForSeconds(2);
        while (true)
        {
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");
            Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
            rigidbody.velocity = movement * speed;

            rigidbody.position = new Vector3
            (
                Mathf.Clamp(rigidbody.position.x, boundary.xMin, boundary.xMax),
                0.0f,
                Mathf.Clamp(rigidbody.position.z, boundary.zMin, boundary.zMax)
            );
            rigidbody.rotation = Quaternion.Euler(0.0f, 0.0f, rigidbody.velocity.x * -tilt);
            yield return null;
        }
    }

    IEnumerator FirstMove()
    {
        collider.enabled = false;
        while (true)
        { 
            gameObject.transform.Translate(Vector3.forward * 3f * Time.deltaTime);
            if (gameObject.transform.position.z >= -2)
                break;
            yield return null;

        }
        yield return new WaitForSeconds(2);
        collider.enabled = true;
        StopCoroutine(FirstMove());
    }

   






}