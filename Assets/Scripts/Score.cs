using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public int score;
    public int SpeedIncrease;
    public Text ScoreText;
    public GameObject Player;



    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        ScoreText.text = (0).ToString();


    }
    private void updateSpeeed()
    {
        SpeedIncrease++;
    }


    // Update is called once per frame
    public void AddToScore(int num)
    {

        score += num;
   
       
        ScoreText.text = score.ToString();
        if (score % 100 == 0)
        {
            updateSpeeed();

        }
 
        //Debug.Log(score);
    }

}
