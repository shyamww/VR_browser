using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class openPanel : MonoBehaviour
{
    public GameObject gameObject;
    public GameObject gameObject1;
    public GameObject gameObject2;
    //public MenuCanvas gameObject1;
    bool active;
    public void openAndClose()
    {
        if(gameObject.active == false)
        {
            gameObject.transform.gameObject.SetActive(true);
            gameObject.active = true;
        }
        else
        {
            gameObject.transform.gameObject.SetActive(false);
            gameObject.active = false;
        }

        if (gameObject1.active == false)
        {
            gameObject1.SetActive(true);
            gameObject1.active = true;
        }
        else
        {
            gameObject1.SetActive(false);
            gameObject1.active = false;
        }

        if (gameObject2.active == false)
        {
            gameObject2.transform.gameObject.SetActive(true);
            gameObject2.active = true;
        }
        else
        {
            gameObject2.transform.gameObject.SetActive(false);
            gameObject2.active = false;
        }
    }
}
