using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level3 : MonoBehaviour
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
    //int convo2 = 0;
    //int convo3 = 0;

    int visit1 = 0;
    int visit2 = 0;

    //X pos var
    int start = 3550;
    int end1 = 6450;
    //int end2 = 5710;
    //int end3 = 4900;

    //Y pos var
    int area1 = -305;
    int area2 = -1305;
    int area3 = -2305;

    //Story Dialogue
    string[] s1 = new string[]
    {
        "We’re getting closer now. We’ll check the hospital first in case and then figure out anywhere else he could’ve gone.:Jules",
        "Sound plan. Hospital highest priority.:Rom",
        "Should be just down this- why is there a fence in the middle of the street?:Jules",
        "Quarantine zone. High concentration of virus at hospital. Separate rest of city.:Rom",
        "Great. Nothing is ever easy with humans, is it?:Jules",
        "You’re right about that.:???",
        "!?:Jules",
        "Another acquaintance of yours?:Rom",
        "Just because I’m not stuck in a fish tank all day doesn’t mean I know every animal in town.:Jules",
        "Pleasure to make your acquaintance. My name is Lulu. You two are quite the pair, aren’t you? Don’t cats eat fish?:Lulu",
        "Not like that isn’t still an option.:Jules",
        "Not recommended. Very low nutritional value.:Rom",
        "I was kidding.:Jules",
        "Both looking for owner. Any information helpful.:Rom",
        "If you mean that guy on the bike who willingly turned himself in for quarantine yesterday, then he’s most likely at the hospital.:Lulu",
        "...:Jules",
        "Not good. Break quarantine now. See owner.:Rom",
        "You’re going to try and get inside? It’s going to be dangerous.:Lulu",
        "No choice. Far from home. Have to keep going.:Rom",
        "...:Jules"
    };

    string[] s2 = new string[]
    {
        "Your friend doesn't seem to be taking the news very well.:Lulu",
        "She is worried. Has happened before.:Rom",
        "You say that like she's gone searching for your owner in the past.:Lulu",
        "She has. Owner always came back soon after. Leaves again to search for Jules.:Rom",
        "...She always did come back.:Jules",
        "Was...amusing. Owner was gone longer searching for her.:Rom",
        "...Don't remind me.:Jules",
        "But this time? You went searching along with her.:Lulu",
        "Something was wrong. Needed to find owner.:Rom",
        "And if she returns while you're gone?:Lulu",
        "Then we learn to take a hint.:Rom"
    };

    string[] s3 = new string[]
    {
        "Don’t see your owner. Inside?:Rom",
        "She was taken to the hospital after the men in suits visited us. I don’t know what happened to her after that.:Lulu",
        "...:Jules",
        "I am sorry. Same situation then.:Rom",
        "All I can do is hope and wait for her to come back. Until then, I’m stuck in here. At least you two are able to do something about it.:Lulu",
        "...:Jules",
        "Better to remain inside. Safe. Familiar.:Rom",
        "Well, you’re also out here too aren’t you? I find it hard to believe your friend just scooped you out of your fish tank against your will.:Lulu",
        "…Made our decision. Must see it through.:Rom",
        "Then you understand why I want to find my owner.:Lulu",
        "…We do.:Rom"
    };

    string[] s4 = new string[]
    {
        "Not much farther now.:Rom",
        "...:Jules",
        "Nothing has changed. Still must find him.:Rom",
        "...:Jules",
        "You are worried.:Rom",
        "Of course I am! What’ll happen to us if he’s gone!? I don’t need you to point this out to me!:Jules",
        "You know the real reason. We both do.:Rom",
        "...:Jules",
        "We will see him again. You are not alone.:Rom",
        "...:Jules",
        "Thanks."
    };

    //Characters
    string[] c1 = new string[]
    {
        "Lulu2",
        "Rom2",
        "Lulu2",
        "Rom2",
        "Lulu2",
        "Bird1",
        "Lulu1",
        "Rom2",
        "Lulu2",
        "Bird2",
        "Lulu2",
        "Rom2",
        "Lulu2",
        "Rom2",
        "Bird1",
        "Lulu2",
        "Rom2",
        "Bird1",
        "Rom2",
        "Lulu2"
    };

    string[] c2 = new string[]
    {
        "Bird1",
        "Rom2",
        "Bird1",
        "Rom2",
        "Lulu2",
        "Rom2",
        "Lulu2",
        "Bird1",
        "Rom2",
        "Bird1",
        "Rom2"
    };

    string[] c3 = new string[]
    {
        "Rom2",
        "Bird1",
        "Lulu2",
        "Rom2",
        "Bird2",
        "Lulu2",
        "Rom2",
        "Bird2",
        "Rom2",
        "Bird1",
        "Rom2"
    };

    string[] c4 = new string[]
    {
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
        "Lulu2"
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
                if (controller.playerPos() > 3906 && controller.playerPos() < 4275 && Input.GetKeyDown(KeyCode.Space))
                {
                    area = 2;
                    visit1 = 1;
                    controller.MovePlayer(start, area2);
                }
                else if (controller.playerPos() > 5777 && controller.playerPos() < 5822 && Input.GetKeyDown(KeyCode.Space))
                {
                    area = 3;
                    visit2 = 1;
                    controller.MovePlayer(start, area3);
                }
                else if (controller.playerPos() >= end1 && visit1 == 1 && visit2 == 1 && Input.GetKeyDown(KeyCode.Space))
                {
                    index = 0;
                    speechArray = s4;
                    charactersArray = c4;
                    visit1 = 2;
                    visit2 = 2;
                    controller.Transition();
                    dialogue.Open();
                }
                else if(controller.playerPos() > 4570 && controller.playerPos() < 4680 && Input.GetKeyDown(KeyCode.Space))
                {
                    if(convo1 == 0)
                    {
                        index = 0;
                        speechArray = s2;
                        charactersArray = c2;
                        convo1 += 1;
                        controller.Transition();
                        dialogue.Open();
                    }
                    else if (convo1 == 1)
                    {
                        index = 0;
                        speechArray = s3;
                        charactersArray = c3;
                        convo1 += 1;
                        controller.Transition();
                        dialogue.Open();
                    }
                }
                else if (controller.playerPos() < start && Input.GetKeyDown(KeyCode.Space))
                {
                    playerInstance.toggleMove();
                    controller.DisplayText("A trash can. Nothing worthwhile seems to be in here.");
                }
                else if (controller.playerPos() > 6100 && controller.playerPos() < 6200 && Input.GetKeyDown(KeyCode.Space))
                {
                    playerInstance.toggleMove();
                    controller.DisplayText("A trash can. Nothing useful is inside. Is this what you thought you would be doing when you went outside?");
                }
            }
            else if (area == 2)
            {
                if (controller.playerPos() <= start && Input.GetKeyDown(KeyCode.Space))
                {
                    area = 1;
                    controller.MovePlayer(4096, area1);
                }
                else if (controller.playerPos() > 3650 && controller.playerPos() < 3750 && Input.GetKeyDown(KeyCode.Space))
                {
                    playerInstance.toggleMove();
                    controller.DisplayText("A trash can. Inside is one half of what appears to be a human cutting tool.");
                }
                else if (controller.playerPos() > 5200 && controller.playerPos() < 5300 && Input.GetKeyDown(KeyCode.Space))
                {
                    playerInstance.toggleMove();
                    controller.DisplayText("A trash can. Empty again. What else is new.");
                }
            }
            else if (area == 3)
            {
                if (controller.playerPos() <= start && Input.GetKeyDown(KeyCode.Space))
                {
                    area = 1;
                    controller.MovePlayer(5800, area1);
                }
                else if (controller.playerPos() > 3550 && controller.playerPos() < 3650 && Input.GetKeyDown(KeyCode.Space))
                {
                    playerInstance.toggleMove();
                    controller.DisplayText("A trash can. Nothing useful. This is getting old.");
                }
                else if (controller.playerPos() > 4650 && controller.playerPos() < 4750 && Input.GetKeyDown(KeyCode.Space))
                {
                    playerInstance.toggleMove();
                    controller.DisplayText("A trash can. The other half of the tool is here. Finally.");
                }
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Space) && !controller.isTransitioning() && !dialogue.isMoving())
            {
                if (index >= speechArray.Length)
                {
                    if(visit1 == 2 && visit2 == 2)
                    {
                        controller.LoadNextLevel();
                    }
                    else
                    {
                        controller.Transition();
                    }
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
