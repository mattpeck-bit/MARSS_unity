using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PopulateScore : MonoBehaviour
{
    public TextMeshPro Rank, Name, UserScore, UserOffset, UserTime;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Populate(ScoreInstance useThisScore, int theRank)
    {
        Rank.text = theRank.ToString() + ")";
        Name.text = useThisScore.name;
        UserScore.text = useThisScore.totalScore.ToString("F2");
        float tempNum = useThisScore.lvl1TE + useThisScore.lvl2TE + useThisScore.lvl3TE;
        UserOffset.text = tempNum.ToString("F2");
        UserTime.text = useThisScore.time.ToString("F2");
    }
}
