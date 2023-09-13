using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DevBoard : MonoBehaviour
{
    public GameObject calculatorObject;
    CalculateScore scoreCalculator;
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

    }
}
