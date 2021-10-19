using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PlayerHealth : MonoBehaviour
{
    public int Health;
    public Text GameOver;
    private float timer;
    public GameObject[] Lives;
    private int curLives;
    [SerializeField]
    private CharacterController CharacterController;
    public AudioSource Damage;

    // Start is called before the first frame update
    void Start()
    {
        GameOver.text="";
        curLives = 3;
        Health = 5;
    }
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        
        if (hit.collider.gameObject.layer == 10 && timer>2)
        {
            Damage.Play();

            StartCoroutine(ThrowPlayer(hit.collider.gameObject));

            if (curLives == 0)
            {
                Cursor.lockState = CursorLockMode.None;
                GameOver.text = "GameOver";
                Invoke("Endgame", 1f);
                //Destroy(gameObject);
                
            }
            Destroy(Lives[curLives-1]);
            curLives--;
            Health -= 1;
            timer = 0;


        }


    }
    IEnumerator ThrowPlayer(GameObject coll)
    {
        var mv = coll.transform.forward * 15 * 2;
        


        float elapsed = 0.0f;
        while (elapsed < 0.1f)
        {
            CharacterController.Move(mv * Time.deltaTime);
            elapsed += Time.deltaTime;
            yield return null;
        }

    }

    // Update is called once per frame
    private void Update()
    {
        timer += Time.deltaTime;

        if (transform.position.z >= 62)
        {
            GameOver.text = "GameWon";
            Destroy(gameObject);
            Invoke("Endgame", 2f);



        }
   
    }

    void Endgame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

}
