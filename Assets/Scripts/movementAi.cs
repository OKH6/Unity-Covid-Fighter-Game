using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class movementAi : MonoBehaviour
{
    public int prevSc;
    public GameObject ScoreOb;
    public Vector3 Invalid;
    public GameObject point;
    private NavMeshAgent agent;
    public Animator animator;
    public GameObject IncLever;
    public int lvl;

    public GameObject AimSlo;

    public int scoreCheck;

    void Start()
    {
        lvl = 1;
        prevSc = 0;
        ScoreOb = GameObject.FindGameObjectWithTag("SSS");
        ScoreOb = GameObject.FindGameObjectWithTag("SSS");
        IncLever=GameObject.FindGameObjectWithTag("LevelInc");
        agent = GetComponent<NavMeshAgent>();
        agent.speed = Random.Range(1f, 1.75f);

        if (AimSlo)
        {
            Debug.Log(AimSlo);
            //AimSlo.SetActive(false);
            AimSlo.GetComponent<Renderer>().enabled = false;

        }


        // Disabling auto-braking allows for continuous movement
        // between points (ie, the agent doesn't slow down as it
        // approaches a destination point).
        agent.autoBraking = false;

        GotoNextPoint();
    }

    public void SetPoint(GameObject Point)
    {

        point = Point;
        GotoNextPoint();
    }
    public void setSpeed(float min,float max)
    {
        if (agent)
        {


            agent.speed = Random.Range(min, max);
            if (Random.Range(0, 1) > 0.9)
            {
                agent.speed = 2;

            }
        }

    }



    void GotoNextPoint()
    {
        
        if (point && agent!=null)
        {
            if (!point.Equals(new GameObject()))
            {
                //Debug.Log(agent);
                agent.destination = point.transform.position;
            }
            //Debug.Log("SSSS");
            
        }
            

 

        //destPoint = (destPoint + 1) % points.Length;
    }



    void Update()
    {

        var S = ScoreOb.GetComponent<Score>();

        int curScore = S.score;
        if (curScore % 200 == 0 && curScore != prevSc && curScore!=0)
        {
            lvl++;
            var x = IncLever.GetComponent<IncLevel>();
            x.IncreaseLevel(lvl);
            //Levl.text = "Level " + lvl.ToString();
            

            agent.speed = agent.speed + 0.5f;
            Debug.Log(agent.speed);
            prevSc = S.score;
        }
        if (curScore == scoreCheck)
        {
            scoreCheck += 10;

        }






        //Debug.Log(agent.path.corners);
        // Choose the next destination point when the agent gets
        // close to the current one.
        if (point != null && !point.Equals(null))
        {


            if ((point.transform.position.x - 5 <= transform.position.x) & (transform.position.x <= point.transform.position.x + 5) & (point.transform.position.z - 5 <= transform.position.z) & (transform.position.z <= point.transform.position.z + 5))
            {
                Destroy(gameObject);
            }
        }

        animator.SetFloat("speed", agent.velocity.magnitude / 2);
    }


}
