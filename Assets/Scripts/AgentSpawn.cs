using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentSpawn : MonoBehaviour
{
    public GameObject[] AGENTS;
    public GameObject TargetPoint;
    public float Rate;


    // Start is called before the first frame update
    public void spawn()
    {
        //Debug.Log(timer);
        Vector3 start = transform.position;
        start += transform.forward.normalized;
        var AgNumn = Random.Range(0, AGENTS.Length);
        var obj= (GameObject)Instantiate(AGENTS[AgNumn], start, transform.rotation);
        var MoveScript=obj.GetComponent<movementAi>();
        MoveScript.SetPoint(TargetPoint);
        MoveScript.setSpeed(1.0f, 1.25f);
        
        


        //obj.AddComponent<CarsMovement>();
    }

    // Update is called once per frame

}
