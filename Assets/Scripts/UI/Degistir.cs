using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Degistir : MonoBehaviour
{
    public GameObject bisiklet;
    public GameObject tank;

  
    public void Degis()
   {
        
        if(bisiklet.active==true)
        {
            tank.SetActive(true);
            bisiklet.SetActive(false);
            //Debug.Log("�al��ma");
        }

        else if (tank.active == true)
        {
            bisiklet.SetActive(true);
            tank.SetActive(false);
            //Debug.Log("�al��t�r");
        }

    }
}
