using System.Collections;
using UnityEngine;
using Backend;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;

public class MainScript : MonoBehaviour
{

 

    public GameObject firstPage = null;
    public GameObject inputField = null;
    public GameObject NextPage = null;
    public string NextIndex = "";
    public string SearchTerm = "google";

    private GameObject temp1, temp2, temp3, inputTextTemp, l_temp1, l_temp2, l_temp3, l_temp4, l_temp5, l_temp6;

    private Transform _transform;
    private TextMeshProUGUI text1, text2, text3;
    private TextMeshProUGUI l_text1, l_text2, l_text3, l_text4, l_text5, l_text6;
    private InputField input;

    
    

    public GoogleSearch g_search = new GoogleSearch("000758091533793376942:vei8xgbnvio", "AIzaSyA4hHhKZxz4DCqs5HUeF08YNZuqU6HtKHs");

    public void SearchUrl()
    {
      //  inputTextTemp = inputField.transform.GetChild(0).gameObject;
        input = inputField.GetComponent<InputField>();
        var search = input.text;
        Debug.Log("I m searching:::::::::::::::::::::::::: "+search);

        var results = g_search.Search(search);

        SearchTerm = g_search.search_terms;
        NextIndex = g_search.next_index;
        Debug.Log(NextIndex + "search" + SearchTerm);
        int i = 0;
        int FirstChildIndex = 0;
        int panelLength = 6;
        

        foreach (var result in results)
        {
           
            if(FirstChildIndex < panelLength)
            {
                Debug.Log(FirstChildIndex + "1st");
                temp1 = firstPage.transform.GetChild(FirstChildIndex).gameObject;
                temp1.SetActive(true);
                temp1 = temp1.transform.GetChild(0).gameObject;
                text1 = temp1.GetComponent<TextMeshProUGUI>();
                text1.text = result.title +  "\n" + result.snippet;

                l_temp1 = firstPage.transform.GetChild(FirstChildIndex + panelLength).gameObject;
                l_temp1.SetActive(true);
                l_temp1 = l_temp1.transform.GetChild(0).gameObject;
                //l_text1 = l_temp1.GetComponent<Text>();
                l_text1 = l_temp1.GetComponent<TextMeshProUGUI>();
                l_text1.text = result.link;
                Debug.Log("the link is@@@@@@@@@@@@@@ " + l_text1.text);

                FirstChildIndex += 1;

            }
            else
            {
                break;
            }
            
        }

        NextPage.transform.GetChild(0).gameObject.SetActive(true);
    }


    public void SearchNextPage()
    {

        Debug.Log(NextIndex + "and" + SearchTerm);

        var results = g_search.nextPage(SearchTerm, NextIndex);
        SearchTerm = g_search.search_terms;
        NextIndex = g_search.next_index;
        Debug.Log(NextIndex + "and2" + SearchTerm);

        int i = 0;
        int FirstChildIndex = 0;
        int panelLength = 6;
        foreach (var result in results)
        {

            if (FirstChildIndex < panelLength)
            {
                Debug.Log(FirstChildIndex + "1st");
                temp1 = firstPage.transform.GetChild(FirstChildIndex).gameObject;
                temp1.SetActive(true);
                temp1 = temp1.transform.GetChild(0).gameObject;
                text1 = temp1.GetComponent<TextMeshProUGUI>();
                text1.text = result.title + "\n" + result.snippet;

                l_temp1 = firstPage.transform.GetChild(FirstChildIndex + panelLength).gameObject;
                l_temp1.SetActive(true);
                l_temp1 = l_temp1.transform.GetChild(0).gameObject;
                //l_text1 = l_temp1.GetComponent<Text>();
                l_text1 = l_temp1.GetComponent<TextMeshProUGUI>();
                l_text1.text = result.link;

                FirstChildIndex += 1;
            }
            else
            {
                break;
            }
        }
    }
}




