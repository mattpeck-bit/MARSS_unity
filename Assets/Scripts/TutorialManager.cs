using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TutorialManager : MonoBehaviour
{

    public TextMeshPro tutText;
    int stage;
    string[] tutScript = { "Hi, I’m Blocky, and welcome to my ultrasound training application! Thank you for taking the time to try my service.",
        "Let’s start with something simple. If you’re using my application, you should have an ultrasound probe somewhere around you. Try picking it up now, and make sure to keep it in view.",
        "Take a second and try using the probe on your arm if you’d like. You may need to apply some pressure, but you should be able to see a view of the inside of your arm. Let me know when you’re ready to move on.," +
        "Ultrasound is pretty fascinating, but it can be difficult to understand what exactly you’re seeing right away. Thankfully, my anatomy is a little more straightforward than the human body. If you haven’t already found me, make sure I’m in view now and we can formally meet each other.",
        "Alright, now that we’ve met, let’s get to work. Try using the probe on my semi-cylinder organ. Se if you can find any injuries it might have sustained recently.",
        "Thank you! I’ll have to make sure to go get that checked out. While I have you here, would you mind taking a look at my triangle organ? It should be close by. I’m feeling some pain there and I’m worried whatever hurt my semi-cylinder may have also hurt that too.",
        "It looks like my next trip to the doctor is going to be very eventful. Makes me think of the time I had to go in for surgery. They had to biopsy my nexus. It’s like my brain, but it can take a lot more physical damage than a human brain. It’s also shaped like a triangle. See if you can find the place where the tissue is missing from the biopsy, it should still be there.",
        "Look at you go! You’ve managed to use the probe well enough to get a tour of my anatomy. If you’d like to go through this tutorial again, you can always access it from the main menu. On the other hand, if you’d like to test yourself, you can try out the time trials, which will give you a score based on your time and accuracy at using the probe. One last time, thanks for talking with me. Have a great day!"};
    string[] titleTexts = { "Welcome!", "Let’s Get Started…", "Awesome!", "Some Introductions:", "Let’s do some training!", "Well done!", "Good job!", "Looks like you’re ready for work" };
    // Start is called before the first frame update
    void Start()
    {
        stage = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CheckStatus()
    {
        switch (stage)
        {
            case 0:
                //Check if the start button has been pressed
                break;
            case 1:
                //Check to see if the ultrasound probe has been found
                break;
            case 2:
                //Check to see if the button has been pressed
                break;
            case 3:
                //Check to see if the phantom has been found
                break;
            case 4:
                //Check distance and found status of semi-cylinder (stage 1)
                break;
            case 5:
                //Check distance and found status of traingle organ (stage 2)
                break;
            case 6:
                //Check distance and found status of brain (stage 3)
                break;
            default:
                break;
        }
    }

    public void MoveOn()
    {
        if (stage < 8) { 
            stage++;
            UpdateMenu(stage);
        }
    }

    void UpdateMenu(int whatStage)
    {
        tutText.text = tutScript[whatStage];
    }
}
