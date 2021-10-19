using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class CountDownTimer : MonoBehaviour
{
    public Text countDowntxt;
    float currentTime;
    public Text GameOver;
    float startingTime=300f;

    void Start()
    {
        currentTime = startingTime;
        
    }

    // Update is called once per frame
    void Update()
    {
        currentTime -= 1 * Time.deltaTime;
        countDowntxt.text = currentTime.ToString("0");
        if (currentTime == 0)
        {
            GameOver.text = "GameOver You Lost";

            Invoke("Endgame", 3f);
        }
        {

        }

    }
    void Endgame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
