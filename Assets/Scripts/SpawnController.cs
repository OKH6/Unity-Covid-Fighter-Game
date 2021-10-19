using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    public GameObject[] Spawns;
    private bool Left;
    private bool Right;
    private float timer;
    private int spawned;
    private AgentSpawn Spawn1;
    private AgentSpawn Spawn2;
    private AgentSpawn Spawn3;
    private AgentSpawn Spawn4;



    // Start is called before the first frame update
    void Start()
    {
        Left = false;
        Right = true;
        Spawn1 = Spawns[0].GetComponent<AgentSpawn>();
        Spawn2 = Spawns[1].GetComponent<AgentSpawn>();
        Spawn3 = Spawns[2].GetComponent<AgentSpawn>();
        Spawn4 = Spawns[3].GetComponent<AgentSpawn>();
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(Right==true && spawned==4)
        {
            spawned = 0;
            Right = false;
            Left = true;
            timer = -6;
        }
        if (Left == true && spawned == 4)
        {
            spawned = 0;
            Left = false;
            Right = true;
            timer = -6;
        }
        if (Right && timer>6)
        {
            timer = 0;

            Spawn3.StartCoroutine("spawn");
            Spawn4.StartCoroutine("spawn");
            spawned++;
        }
        if (Left && timer > 6)
        {
            timer = 0;
            Spawn1.StartCoroutine("spawn");
            Spawn2.StartCoroutine("spawn");

            spawned++;
        }
        
    }
}
