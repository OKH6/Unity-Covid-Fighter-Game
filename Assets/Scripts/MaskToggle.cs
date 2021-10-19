using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaskToggle : MonoBehaviour
{
    public GameObject Silo;
    public AudioSource HitSFX;
    public int points = 10;
    public GameObject GG;
    [SerializeField]
    public GameObject Mask;
    // Start is called before the first frame update

    public void OnEnable()
    {
        HitSFX = GameObject.FindGameObjectWithTag("HitSFX").GetComponent<AudioSource>();
        GG = GameObject.FindGameObjectWithTag("SSS");
        Mask.SetActive(false);

    }

    public void TakeDamage()
    {
        if (!Mask.activeSelf)
        {
            HitSFX.Play();
            var S = GG.GetComponent<Score>();
            S.AddToScore(points);
            Invoke("EnableMask", 0.5f);

        }


    }

    private void EnableMask()
    {
        Silo.SetActive(false);
        
        Mask.SetActive(true);
    }

    // Update is called once per frame

}
