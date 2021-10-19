using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class SanitizerLevel : MonoBehaviour
{
    public AudioSource Fill;
    public Text GameOver;
    public Slider slider;
    public GameObject Player;
    public Text score;
    public Text Counter;

    public int CurCounter;
    public int scoreCheck;
    public int prevSc;
    public int maxHealth = 100;
    // Start is called before the first frame update
    void Start()
    {
        scoreCheck = 10;
        CurCounter = 10;
        slider.value = maxHealth;
        
    }

    public void UpdateHealth()
    {
        slider.value = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        int curScore = int.Parse(score.text);
        if (curScore % 100 == 0 && curScore != prevSc)
        {
            Fill.Play();
            prevSc = int.Parse(score.text);
            slider.value = maxHealth;
            Counter.text = "10";
            CurCounter = 11;


        }
        if (curScore == scoreCheck)
        {
            scoreCheck += 10;
            CurCounter--;

            Counter.text = CurCounter.ToString();



        }




        slider.value -= Time.deltaTime*2;
        if (slider.value==0)
        {
            GameOver.text = "GameOver";
            

            Destroy(Player);
            Invoke("Endgame", 3f);

        }
    }

    void Endgame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
