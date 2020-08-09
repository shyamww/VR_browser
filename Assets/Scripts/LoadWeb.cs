using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using TMPro;

public class LoadWeb : MonoBehaviour
{
    const string IP_ADDRESS = "https://peaceful-crag-49779.herokuapp.com/";
    string uri_image;
    public Renderer meshRender;
  
    public void loadWebsite(TextMeshProUGUI searchurl)
    {
        Debug.Log("jo dhunhd rhe h mil gya  "+searchurl.text);
        uri_image = IP_ADDRESS + "webshot?url=" + searchurl.text;
        //meshRender.material.color = Color.red;
        StartCoroutine(GetWebShotFromUrl(uri_image, true, IP_ADDRESS + "webshot"));
    }

    IEnumerator GetWebShotFromUrl(string url, bool isMain, string query)
    {
        Debug.Log(url);
        UnityWebRequest www = UnityWebRequest.Get(url);
        yield return www.SendWebRequest();
        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log(www.error);
            Debug.Log("praksh");
        }
        else
        {
            byte[] imageBytes = www.downloadHandler.data;
            Debug.Log("satya");
            Debug.Log(www.downloadHandler.text);
            LoadTexture(imageBytes);
        }
    }

    private void LoadTexture(byte[] imageBytes)
    {
        StartCoroutine(LoadTextureCoroutine(imageBytes));
    }

    IEnumerator LoadTextureCoroutine(byte[] imageBytes)
    {
        Texture2D tempTex = new Texture2D(1024, 768);
        tempTex.LoadImage(imageBytes);
        Debug.Log("WIDTH: " + tempTex.width + " HEIGHT: " + tempTex.height);
        meshRender.material.mainTexture = tempTex;
        // meshRender.material = screenMat;
        yield return new WaitForSeconds(1f);
    }

}