using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinkSiloTOBody : MonoBehaviour
{
    [SerializeField]
    private GameObject Main;
    // Start is called before the first frame update

    public void TakeDamage()
    {
        Main.GetComponent<MaskToggle>().TakeDamage();
    }
}
