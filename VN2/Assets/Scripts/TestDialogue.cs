using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestDialogue : MonoBehaviour
{
    DialogueScript dialogue;
    GameController controller;
    string[] speechArray;
    string[] charactersArray;
    int index;
    int area;

    //Conversation var
    int convo1 = 0;
    int convo2 = 0;
    int convo3 = 0;

    /*X pos var
    int normalStart = 1189;
    int normalEnd = 3012;
    */

    /*Y pos var
    int area1 = -468;
    int area2 = -1105;
    int area3 = -1742;
    */

    // Start is called before the first frame update
    void Start()
    {
        dialogue = DialogueScript.instance;
        controller = GameController.instance;

        area = 1;
        index = 0;
        speechArray = s1;
        charactersArray = c1;
        dialogue.Open();
    }

    string[] s1 = new string[]
    {
        "Hello there!:Lintton",
        "This is the beginning of my first game.",
        "I hope it doesn't suck.",
        "It won't suck, Lintton. Not if you put in all of your effort.:Game Fairy",
        "I'll just have to take your word for it.:Lintton"
    };

    string[] c1 = new string[]
    {
        "WhiteSquare",
        "WhiteSquare",
        "WhiteSquare",
        "BlackSquare",
        "WhiteSquare",
    };

    // Update is called once per frame
    void Update()
    {
        if (!controller.camEnabled())
        {
            //AREA 1-----------------------------------------------------------------------------------------------------
            if (area == 1)
            {
                if (controller.playerPos() >= 2712 && convo1 == 0)
                {
                    index = 0;
                    speechArray = s1;
                    charactersArray = c1;
                    convo1 += 1;
                    controller.Transition();
                    dialogue.Open();
                }
                else if (controller.playerPos() >= 3053 && Input.GetMouseButtonDown(0))
                {
                    area = 2;
                    controller.playerMove(1189, -1105);
                }
            }

            //AREA 2-----------------------------------------------------------------------------------------------------
            else if (area == 2)
            {
                if (controller.playerPos() >= 2712 && convo2 == 0)
                {
                    index = 0;
                    speechArray = s1;
                    charactersArray = c1;
                    convo2 += 1;
                    controller.Transition();
                    dialogue.Open();
                }
                else if (controller.playerPos() >= 3053)
                {
                    area = 3;
                    controller.playerMove(1189, -1742);
                }
                else if (controller.playerPos() <= 1143)
                {
                    area = 1;
                    controller.playerMove(3023, -468);
                }
            }
            //AREA 3-----------------------------------------------------------------------------------------------------
            else if (area == 3)
            {
                if (controller.playerPos() >= 2712 && convo3 == 0)
                {
                    index = 0;
                    speechArray = s1;
                    charactersArray = c1;
                    convo3 += 1;
                    controller.Transition();
                    dialogue.Open();
                }
                else if (controller.playerPos() <= 1143)
                {
                    area = 2;
                    controller.playerMove(3023, -1105);
                }
            }
        }

        else
        {
            if (Input.GetKeyDown(KeyCode.Space) && !controller.isTransitioning())
            {
                if (index >= speechArray.Length)
                {
                    controller.Transition();
                }

                else
                {
                    string[] parts = speechArray[index].Split(':');
                    string speech = parts[0];
                    string speaker = (parts.Length >= 2) ? parts[1] : "";

                    dialogue.Say(speech, charactersArray[index], speaker);
                    index += 1;
                }
            }
        }
    }
}
