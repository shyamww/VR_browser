using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class menuStart : MonoBehaviour
{
    public void changemenuscene(string scenename)
    {
        Application.LoadLevel (scenename);
        //SceneManager.LoadScene(scenename, LoadSceneMode.Single);
    }
}
