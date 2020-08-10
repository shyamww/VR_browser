using System.Collections;
using UnityEngine;
using Backend;
using UnityEngine.UI;

public class ImageSearch : MonoBehaviour
{
    

    private GameObject temp1, inputTextTemp;
    public GameObject inputField = null; // COMM
    public GameObject image1 = null;
    public GameObject NextPage = null;
    
    private InputField input;

    public static string NextIndex = "";
    public static string SearchTerm = "ant";
    
    public GoogleSearch g_search = new GoogleSearch("000758091533793376942:vei8xgbnvio", "AIzaSyA4hHhKZxz4DCqs5HUeF08YNZuqU6HtKHs");

    /*void Start()
    {
        SearchImage();
    }*/

   /* public void updateSearchTerm(string name)
    {
        SearchTerm = name;
        SearchImage();
    }*/

    private IEnumerator LoadFromLikeCoroutine(string url, Renderer thisRenderer)
    {
        Debug.Log("Loading ....");
        WWW wwwLoader = new WWW(url);   // create WWW object pointing to the url
        yield return wwwLoader;         // start loading whatever in that url ( delay happens here )

        Debug.Log("Loaded");
        thisRenderer.material.color = Color.white;              // set white
        thisRenderer.material.mainTexture = wwwLoader.texture;  // set loaded image
    }

    public void SearchImage()
    {
        string type = "image";
        //   inputTextTemp = inputField.transform.GetChild(0).gameObject; // COM
        // input = inputTextTemp.GetComponent<InputField>(); // COM
         var search = "cake";  //input.text
        //   SearchTerm = "man";
        //  string search = "mango";// search come from mainscript
        //search += SearchTerm.ToString();
        // var search = SearchTerm.ToString();
        Debug.Log("Imageeeeee" + SearchTerm);
        Debug.Log(search);


        // me try to load iname
        input = inputField.GetComponent<InputField>();
        
        search = input.text;
        Debug.Log(search);












        var results = g_search.Search(search, type);
        //var results = g_search.Search(SearchTerm, type);

        SearchTerm = g_search.search_terms;
        NextIndex = "11";    // g_search.next_index;
        Debug.Log(NextIndex + "search" + SearchTerm);
        
        int ChildIndex = 0;
        
        foreach (var result in results)
        {
            Debug.Log(ChildIndex + "1st" + SearchTerm);
            temp1 = image1.transform.GetChild(ChildIndex).gameObject;
            temp1.SetActive(true);
            StartCoroutine(LoadFromLikeCoroutine(result.link, temp1.GetComponent<Renderer>())); // execute the section independently
            
            ChildIndex += 1;
        }

        NextPage.transform.GetChild(0).gameObject.SetActive(true);
    }
  
    public void nextImageSearch()
    {
        Debug.Log(NextIndex + "and" + SearchTerm);
        string type = "image"; 
        var results = g_search.nextPage(SearchTerm, NextIndex, type);
        SearchTerm = g_search.search_terms;
        NextIndex = g_search.next_index;
        Debug.Log(NextIndex + "and2" + SearchTerm);

        int ChildIndex = 0;

        foreach (var result in results)
        {

            Debug.Log(ChildIndex + "1st");
            temp1 = image1.transform.GetChild(ChildIndex).gameObject;
            temp1.SetActive(true);
            StartCoroutine(LoadFromLikeCoroutine(result.link, temp1.GetComponent<Renderer>())); // execute the section independently

            ChildIndex += 1;
        }

        NextPage.transform.GetChild(0).gameObject.SetActive(true);
    }
}
