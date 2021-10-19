using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
    

{
    [SerializeField]
    public float fireRate = -10;
    private GameObject Prev;

    [SerializeField]
    public GameObject prefab;
    [SerializeField]
    public GameObject Spawnpoint;

    public float Range = 5f;
    private Animator animator;
    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponentInChildren<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ViewportPointToRay(Vector3.one * 0.5f);
        //Debug.DrawRay(ray.origin, ray.direction * Range, Color.red, 0.2f);
        RaycastHit hitInfo;
        if (Physics.Linecast(ray.origin, ray.origin + ray.direction * Range, out hitInfo))
        {
            if (hitInfo.distance < Range)
            {


                //Debug.Log(hitInfo.distance);

                if (Prev)
                {

                    if (hitInfo.collider.gameObject != Prev)
                    {
                        Prev.GetComponent<Renderer>().enabled = false;

                    }
                }
                //Debug.Log(hitInfo.collider.gameObject.tag);
                if (hitInfo.collider.gameObject.tag == "Silo")
                {

                    hitInfo.collider.gameObject.GetComponent<Renderer>().enabled = true;
                    Prev = hitInfo.collider.gameObject;


                }
            }
        }
        //Prev.GetComponent<Renderer>().enabled = false;

        //Debug.DrawRay(Spawnpoint.transform.position, Spawnpoint.transform.forward * 10, Color.red, 2f);

        timer += Time.deltaTime*3;
        //Debug.Log(timer);
        if (timer >= fireRate)
        {
            if (Input.GetButton("Fire1"))
            {


                timer = 0;
                Invoke("Spawn", 0.4f);
                FireGun();

                GetComponent<AudioSource>().Play();
                //Invoke("Spawn", 0.4f);
            }
        }
        
    }

    private void Spawn()
    {
        Vector3 start = Spawnpoint.transform.position;
        start += Spawnpoint.transform.forward.normalized;
        GameObject obj = (GameObject)Instantiate(prefab, start, Spawnpoint.transform.rotation);
        obj.GetComponent<Rigidbody>().velocity = Spawnpoint.transform.forward*50;

    }

    private void FireGun()
    {
        animator.SetTrigger("Hit");
        //

        Ray ray =Camera.main.ViewportPointToRay(Vector3.one * 0.5f);
        Debug.DrawRay(ray.origin, ray.direction * 20, Color.red, 2f);
        RaycastHit hitInfo;
        if(Physics.Raycast(ray,out hitInfo, Range))
        {
            var health =hitInfo.collider.GetComponent<LinkSiloTOBody>();
            if (health != null)
            {
                health.TakeDamage();
            }


        }
  
    }

}
