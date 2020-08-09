using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UpdateSearchToImage : MonoBehaviour
{

    private ImageSearch imageSearch;
    public GameObject inputField = null;
    private InputField input;
    void Awake()
    {
        imageSearch = GameObject.FindObjectOfType< ImageSearch >();
    }

    public void updateSearch()
    {
        input = inputField.GetComponent<InputField>();
        var search = input.text;
        Debug.Log("types inpue is::::: "+search);
        //imageSearch.updateSearchTerm(search);
        
    }
}
