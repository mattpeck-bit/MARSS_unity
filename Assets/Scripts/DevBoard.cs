using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DevBoard : MonoBehaviour
{
    public GameObject calculatorObject;
    CalculateScore scoreCalculator;
    string[] names = { "Jeff", "Daniel", "Matt", "Filippo", "Reese", "Maya", "Andrew", "James", "Karen", "aspodifjqpw" };
    // Start is called before the first frame update
    void Start()
    {
        scoreCalculator = calculatorObject.GetComponent<CalculateScore>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GenDummyData()
    {
        for (int i = 0; i < 5; i++)
        {
            ScoreInstance scoreStorage = new ScoreInstance { name = names[Random.Range(0,names.Length)], totalScore = Random.Range(0.0f,100.0f), lvl1TE = Random.Range(0.0f, 100.0f), lvl2TE = Random.Range(0.0f, 100.0f), lvl3TE = Random.Range(0.0f, 100.0f), time = Random.Range(0.0f, 100.0f) };
            XMLManager.instance.leaderboard.list.Add(scoreStorage);
            XMLManager.instance.leaderboard.list.Sort((ScoreInstance x, ScoreInstance y) => y.totalScore.CompareTo(x.totalScore));
        }
        //Debug.LogError("Here's the LIST!!!!    " + XMLManager.instance.leaderboard.list);
    }

    public void SaveDummyData()
    {
        XMLManager.instance.SaveScores(XMLManager.instance.leaderboard.list);
        //Debug.LogError("IF NOTHING ELSE WENT WRONG, THE LIST SHOULD BE SAVED!");
    }

    public void LoadDummyData()
    {
        List<ScoreInstance> tempList = XMLManager.instance.LoadScores();
        //Debug.LogError("IS IT NULL?!?!?: " + tempList);
    }
}
