using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class IncLevel : MonoBehaviour
{
    public Text lvl;
    // Start is called before the first frame update

    public void IncreaseLevel(int lvla)
    {
        lvl.text ="Level"+ lvla.ToString();
        Invoke("ClearText",2f);

    }
    void ClearText()
    {
        lvl.text = "";
    }

}
