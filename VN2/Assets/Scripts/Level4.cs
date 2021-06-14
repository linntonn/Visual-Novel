using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level4 : MonoBehaviour
{
    DialogueScript dialogue;
    GameController controller;
    PlayerMovement playerInstance;
    string[] speechArray;
    string[] charactersArray;
    int index;
    int area;

    //Conversation var
    int convo1 = 0;
    /*
    int convo2 = 0;
    int convo3 = 0;
    */

    //X pos var
    int start = 3550;
    int end1 = 6450;
    

    //Y pos var
    int area1 = -305;
    int area2 = -1305;
    

    //Story Dialogue
    string[] s1 = new string[]
    {
        "We’re finally here.:Jules",
        "Owner somewhere inside. Front desk has patient information.:Rom",
        "And humans. More sneaking around?:Jules",
        "Need to know. No more time.:Rom",
        "Yeah. We find her now.:Jules"
    };

    string[] s2 = new string[]
    {
        "...:Jules",
        "…Will you not enter?:Rom",
        "I don’t know what I’ll see if I go in. What kind of condition she’ll be in.:Jules",
        "Do not know.:Rom",
        "What do we even do after this? Go home?:Jules",
        "Do not know either.:Rom",
        "What do you know then?:Jules",
        "Know what to do now. Go inside. Stay with her. However long it takes.:Rom",
        "…Yeah. Whatever happens…we won’t be alone.:Jules",
        "Ready?:Rom",
        "I am now.:Jules",
        ":nothing",
        "…!? Jules, Rom? How did you get here?:Owner",
        "...:Rom",
        "Talk to her.:Rom",
        "What do I even say? It’s not like she can understand us.:Jules",
        "Pfffft-:Owner",
        "?:Jules",
        "Hahahahaha-:Owner",
        "What's so funny!?:Jules",
        "Here I was so worried about where you both had gone.:Owner",
        "The person I asked to look after you couldn't find you guys.:Owner",
        "O-oh.:Jules",
        "Should have seen this coming.:Rom",
        "S-shut up! This was your idea too!:Jules",
        "But I'm glad you both're here.:Owner",
        "You both must have been worried.",
        "I-:Jules",
        "We were.",
        "But we're together again. You don't...have to worry anymore.:Owner",
        "Once this is all over...we'll go back home.",
        "...",
        "She's asleep.:Rom",
        "What now?:Jules",
        "...Could use sleep ourselves.:Rom",
        "Can't disagree with that. We had quite the crazy day.:Jules",
        "Indeed. But...it was interesting. To see the outside world.:Rom",
        "Heh.:Jules",
        "Goodnight Rom.",
        "Goodnight Jules.:Rom",
        "THE END:nothing"
    };

    //Characters
    string[] c1 = new string[]
    {
        "Lulu2",
        "Rom2",
        "Lulu2",
        "Rom2",
        "Lulu2"
    };

    string[] c2 = new string[]
    {
        "Lulu2",
        "Rom2",
        "Lulu2",
        "Rom2",
        "Lulu2",
        "Rom2",
        "Lulu2",
        "Rom2",
        "Lulu2",
        "Rom2",
        "Lulu2",
        "nothing",
        "Owner1",
        "Rom2",
        "Rom2",
        "Lulu1",
        "Owner2masked",
        "Lulu1",
        "Owner2masked",
        "Lulu1",
        "Owner3masked",
        "Owner3",
        "Lulu2",
        "Rom2",
        "Lulu1",
        "Owner2",
        "Owner3",
        "Lulu1",
        "Lulu2",
        "Owner3",
        "Owner3",
        "Owner3",
        "Rom2",
        "Lulu2",
        "Rom2",
        "Lulu2",
        "Rom2",
        "Lulu2",
        "Lulu2",
        "Rom2",
        "nothing"
    };

    // Start is called before the first frame update
    void Start()
    {
        dialogue = DialogueScript.instance;
        controller = GameController.instance;
        playerInstance = PlayerMovement.instance;

        area = 1;
        index = 0;
        speechArray = s1;
        charactersArray = c1;
        dialogue.Open();
    }

    // Update is called once per frame
    void Update()
    {
        if (!controller.camEnabled())
        {
            if (!playerInstance.canMove)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    controller.StopText();
                    playerInstance.toggleMove();
                }
            }
            else if (area == 1)
            {
                if(controller.playerPos() > 5900 && controller.playerPos() < 6080 && Input.GetKeyDown(KeyCode.Space))
                {
                    area = 2;
                    controller.MovePlayer(start, area2);
                }
                else if(controller.playerPos() >= end1 && convo1 == 0 && Input.GetKeyDown(KeyCode.Space))
                {
                    index = 0;
                    speechArray = s2;
                    charactersArray = c2;
                    convo1 += 1;
                    controller.Transition();
                    dialogue.Open();
                }
                else if (controller.playerPos() > 3800 && controller.playerPos() < 4100 && Input.GetKeyDown(KeyCode.Space))
                {
                    playerInstance.toggleMove();
                    controller.DisplayText("A coughing man sits upright on the stretcher. When he sees you, he smiles and pets your head before lying down.");
                }
                else if (controller.playerPos() > 4600 && controller.playerPos() < 4900 && Input.GetKeyDown(KeyCode.Space))
                {
                    playerInstance.toggleMove();
                    controller.DisplayText("A woman lying on the stretcher breathes erratically. You go to touch her hand, and her breathing calms down and becomes normal.");
                }
                else if (controller.playerPos() > 5300 && controller.playerPos() < 5600 && Input.GetKeyDown(KeyCode.Space))
                {
                    playerInstance.toggleMove();
                    controller.DisplayText("A child cries alone on a stretcher. You sit with him for a little while and he stops crying.");
                }
            }
            else if(area == 2)
            {
                if (controller.playerPos() <= start && Input.GetKeyDown(KeyCode.Space))
                {
                    area = 1;
                    controller.MovePlayer(5985, area1);
                }
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Space) && !controller.isTransitioning() && !dialogue.isMoving())
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
