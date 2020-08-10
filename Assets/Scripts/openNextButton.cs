using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class openNextButton : MonoBehaviour
{
    public GameObject gameObject;
    bool active;
    public void OpenNextButton()
    {
        if (gameObject.active == false)
        {
            gameObject.transform.gameObject.SetActive(true);
            gameObject.active = true;
        }
    }
}
