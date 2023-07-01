using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLevel1 : MonoBehaviour
{
    private List<string> animationList = new List<string>
                                            {   "Attack",
                                                "Bounce",
                                                "Clicked",
                                                "Death",
                                                "Eat",
                                                "Fear",
                                                "Fly",
                                                "Hit",
                                                "Idle_A", "Idle_B", "Idle_C",
                                                "Jump",
                                                "Roll",
                                                "Run",
                                                "Sit",
                                                "Spin/Splash",
                                                "Swim",
                                                "Walk"
                                            };

    private List<string> shapekeyList = new List<string>
                                            {   "Eyes_Annoyed",
                                                "Eyes_Blink",
                                                "Eyes_Cry",
                                                "Eyes_Dead",
                                                "Eyes_Excited",
                                                "Eyes_Happy",
                                                "Eyes_LookDown",
                                                "Eyes_LookIn",
                                                "Eyes_LookOut",
                                                "Eyes_LookUp",
                                                "Eyes_Rabid",
                                                "Eyes_Sad",
                                                "Eyes_Shrink",
                                                "Eyes_Sleep",
                                                "Eyes_Spin",
                                                "Eyes_Squint",
                                                "Eyes_Trauma",
                                                "Sweat_L",
                                                "Sweat_R",
                                                "Teardrop_L",
                                                "Teardrop_R"
                                            };
    // Start is called before the first frame update
    void Start()
    {
        //stablish animations
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown("up")) { 
            //accelerate
        }
        else if (Input.GetKeyDown("down")) { 
            //slowDown
        }
        if (Input.GetKeyDown("right")) {

        }
        else if (Input.GetKeyDown("left")) {

        }


    }

    void Eat()
    {

    }
}
