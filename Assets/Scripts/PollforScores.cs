using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PollforScores : MonoBehaviour
{
    List<ScoreInstance> toBeDisplayed;
    public GameObject ScoresGrid;
    public GameObject scorePrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnEnable()
    {
        toBeDisplayed = XMLManager.instance.LoadScores();
        for (int i = 0; i < toBeDisplayed.Count; i++)
        {
            GameObject temp = Instantiate(scorePrefab);
            //Change the text fields
            //Attach as child
        }
    }
}
