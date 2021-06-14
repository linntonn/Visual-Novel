using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1 : MonoBehaviour
{
    DialogueScript dialogue;
    GameController controller;
    PlayerMovement playerInstance;
    string[] speechArray;
    string[] charactersArray;
    int index;
    int area;

    /*Conversation var
    int convo1 = 0;
    int convo2 = 0;
    int convo3 = 0;*/

    int visit1 = 0;
    int visit2 = 0;

    //X pos var
    int start = 3450;
    int end1 = 5550;
    

    //Y pos var
    int area1 = -305;
    int area2 = -1305;
    int area3 = -2305;
    

    //Story Dialogue
    string[] s1 = new string[]
    {
        "Is he back yet?:Jules",
        "Do not know. Still stuck inside fish tank.:Rom",
        "Very funny. How long has he been gone now?:Jules",
        "Two days. You are worried.:Rom",
        "As if. What he does is his own problem, but he still needs to feed us.:Jules",
        "Extra food for both of us. He knew he would be gone. Planned on it.:Rom",
        "That’s all well and good but he still needs to come back one of these days. I can’t exactly reach where our food is. Where do you think he went?:Jules",
        "Do not know. Only know he left.:Rom",
        "Then I’m going to check the house again. You stay here.:Jules",
        "Cannot do anything else.:Rom"
    };

    string[] s2 = new string[]
    {
        "He’s definitely gone. Where the hell did he go?:Jules",
        "Do not know. Will you look for him?:Rom",
        "Of course I will! He still needs to take care of us and you won’t be able to change my mind this-:Jules",
        "Good. Take me with you.:Rom",
        "That’s what I- wait, you want to come along?:Jules",
        "Yes. Very dangerous for humans to be outside.:Rom",
        "What do you mean?:Jules",
        "Watching human news. New disease. Very contagious. Could be sick right now. Must leave soon.:Rom",
        "Well then, we have no choice now do we? We have to go right now. But uh…how am I supposed to bring you along?:Jules",
        "Go to the kitchen. You will need something.:Rom",
        ":nothing",
        "This is a terrible idea.:Jules",
        "I will not disagree.:Rom"
    };

    //Characters
    string[] c1 = new string[]
    {
        "Lulu2",
        "Rom1",
        "Lulu2",
        "Rom1",
        "Lulu2",
        "Rom1",
        "Lulu2",
        "Rom1",
        "Lulu2",
        "Rom1"
    };

    string[] c2 = new string[]
    {
        "Lulu1",
        "Rom1",
        "Lulu2",
        "Rom1",
        "Lulu1",
        "Rom1",
        "Lulu2",
        "Rom1",
        "Lulu2",
        "Rom1",
        "nothing",
        "Lulu2",
        "Rom2",
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
            if(!playerInstance.canMove)
            {
                if(Input.GetKeyDown(KeyCode.Space))
                {
                    controller.StopText();
                    playerInstance.toggleMove();
                }
            }
            else if(area == 1)
            {
                if(controller.playerPos() >= end1 && Input.GetKeyDown(KeyCode.Space))
                {
                    controller.MovePlayer(start, area3);
                    area = 3;
                    visit1 = 1;
                }
                else if(controller.playerPos() > 3751 && controller.playerPos() < 4027 && Input.GetKeyDown(KeyCode.Space))
                {
                    controller.MovePlayer(start, area2);
                    area = 2;
                    visit2 = 1;                   
                }
                else if(controller.playerPos() <= start && visit1 == 1 && visit2 == 1 && Input.GetKeyDown(KeyCode.Space))
                {
                    index = 0;
                    speechArray = s2;
                    charactersArray = c2;
                    visit1 = 2;
                    visit2 = 2;
                    controller.Transition();
                    dialogue.Open();
                }
                else if(controller.playerPos() > 4170 && controller.playerPos() < 4300 && Input.GetKeyDown(KeyCode.Space))
                {
                    playerInstance.toggleMove();
                    controller.DisplayText("A food and water bowl. It has several days worth of food already ready to eat.");
                }
            }
            else if(area == 2)
            {
                if(controller.playerPos() <= start && Input.GetKeyDown(KeyCode.Space))
                {
                    controller.MovePlayer(3900, area1);
                    area = 1;                  
                }
                else if (controller.playerPos() > 4000 && controller.playerPos() < 5000 && Input.GetKeyDown(KeyCode.Space))
                {
                    playerInstance.toggleMove();
                    controller.DisplayText("An old couch. Always a comfortable place to take a nap.");
                }
                else if (controller.playerPos() > 5100 && controller.playerPos() < 5540 && Input.GetKeyDown(KeyCode.Space))
                {
                    playerInstance.toggleMove();
                    controller.DisplayText("Something called a 'television'. Rom always listens to it whenever it's on.");
                }
            }
            else if(area == 3)
            {
                if (controller.playerPos() <= start && Input.GetKeyDown(KeyCode.Space))
                {
                    controller.MovePlayer(end1, area1);
                    area = 1;                   
                }
                else if (controller.playerPos() > 3600 && controller.playerPos() < 4800 && Input.GetKeyDown(KeyCode.Space))
                {
                    playerInstance.toggleMove();
                    controller.DisplayText("My owner's bed. It still smells like she's still here.");
                }
                else if (controller.playerPos() > 5000 && controller.playerPos() < 5540 && Input.GetKeyDown(KeyCode.Space))
                {
                    playerInstance.toggleMove();
                    controller.DisplayText("I'm not sure what this is, but my owner spends a lot of her time here. Must be important.");
                }
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Space) && !controller.isTransitioning() && !dialogue.isMoving())
            {
                if (index >= speechArray.Length)
                {
                    if (visit1 == 2 && visit2 == 2)
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
