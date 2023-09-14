using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Microsoft.MixedReality.Toolkit.Utilities;

public class PollforScores : MonoBehaviour
{
    List<ScoreInstance> toBeDisplayed;
    public GameObject ScoresGrid;
    //public GameObject scorePrefab;
    //GridObjectCollection theGrid;
    // Start is called before the first frame update
    void Start()
    {
        //theGrid = ScoresGrid.GetComponent<GridObjectCollection>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnEnable()
    {
        //theGrid = ScoresGrid.GetComponent<GridObjectCollection>();
        toBeDisplayed = XMLManager.instance.LoadScores();
        for (int i = 0; i < 5; i++)
        {
            GameObject temp = ScoresGrid.gameObject.transform.GetChild(i).gameObject;
            //Change the text fields
            PopulateScore theScript = temp.GetComponent<PopulateScore>();
            theScript.Populate(toBeDisplayed[i], i+1);
            //Attach as child
            temp.transform.parent = ScoresGrid.transform;
        }
        //theGrid.UpdateCollection();
    }
}
