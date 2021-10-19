using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpawn : MonoBehaviour
{
    public GameObject[] CARS;
    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        spawn();
        
    }
    public void spawn()
    {
        Vector3 start = transform.position;
        start += transform.forward.normalized;
        var carNUM = Random.Range(0, CARS.Length);
        Instantiate(CARS[carNUM], start, transform.rotation);

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > 4)
        {
            spawn();
            timer = 0;
        }

    }
}
