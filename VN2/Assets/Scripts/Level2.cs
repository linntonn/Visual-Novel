using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2 : MonoBehaviour
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

    //X pos var
    int start = 3550;
    int end1 = 6450;
    //int end2 = 5710;

    //Y pos var
    int area1 = -305;
    int area2 = -1305;

    //Story Dialogue
    string[] s1 = new string[]
    {
        "Sure is quiet around here. Looks like that disease you mentioned is the real deal.:Jules",
        "Lockdown orders enforced. All residents inside homes. Minimize outside activity.:Rom",
        "Looks like not everyone is following the rules. Look, there’s a few humans over there.:Jules",
        "Hide.:Rom",
        "What? What’s the big-:Jules",
        "Unclear if animals can transmit virus. Will be detained if spotted. Hide NOW.:Rom",
        "Alright, alright.:Jules",
        "And you haven’t been experiencing any of the symptoms? Alright, well thank you for your time sir.:Official",
        "What do you think they’re-:Jules",
        "Whatcha two doin’? Can I join?:???",
        "!?:Jules",
        "Friend of yours?:Rom",
        "No, just an…acquaintance. This is Rex.:Jules",
        "Aaaw, how could you say that? Weren't our games of tag fun?:Rex",
        "Not the word I would use to describe it. Have you seen our owner? He left a couple days ago and hasn’t come back.:Jules",
        "Him? Oh yes, I did see him. He took off on his bike down this street and took a left. Something seemed off with him though, he was sweating buckets as he took off past us.:Rex",
        "Sweating? It hasn’t been that hot out recently, has it?:Jules",
        "Maybe a sign of the virus. Could be going to hospital.:Rom",
        "Never talk like that. We don’t know for sure.:Jules",
        "Not relevant now. Get past humans, find owner.:Rom",
        "I can work with that.:Jules"
    };

    string[] s2 = new string[]
    {
        "So where’s your owner right now?:Jules",
        "He’s inside right now. He’s always so busy these days with no time to play or take me for walks! It’s been months since we went to the park when we used to go every week.:Rex",
        "Self-isolation. Stay inside. Minimize risk.:Rom",
        "It’s always good to get fresh air once in a while! You two are outside right now, aren’t you?:Rex",
        "We’re not here to play, we’re here to find our owner. Hard to look for someone if you can’t go outside.:Jules",
        "Agreed.:Rom",
        "Awww, c’mon! If you don’t relax or play, you’re not really enjoying life! Let’s play some tag again!:Rex",
        "I think I’ll pass this time.:Jules"
    };

    string[] s3 = new string[]
    {
        "Acquaintances? How did you meet?:Rom",
        "When we first moved here, I walked around these streets to get a better idea of this place. As it happens, I ran into Rex and his owner going for a walk.:Jules",
        "I’m sorry, I just love meeting new animals! The more you meet, the more you can play with!:Rex",
        "Except Rex started to chase me around the block. As we both ran, he was just asking all sorts of questions. “What’s your name”? “Where do you live”? “What kind of dog are you”? His owner was running up and down the streets trying to catch us. I felt like I was going to die.:Jules",
        "Interesting. Have never seen cat before?:Rom",
        "Oh nah. First time I’ve ever seen a pet like her before. That just made me want to know more about her!:Rex",
        "Ever since, if Rex sees me, he tries to chase me down. This is one of the few calm conversations we have ever had.:Jules",
        "Willing to go outside despite fear of Rex. How brave of you.:Rom",
        "Don’t forget that I’m the one carrying you.:Jules"
    };

    string[] s4 = new string[]
    {
        "Situation grimmer than realized. Owner could be sick.:Rom",
        "I thought I told you not to say things like that. No use worrying when we don’t know for sure.:Jules",
        "Sick, not sick. At hospital or just supermarket. Do not know. Prepared for all outcomes. Are you?:Rom",
        "...:Jules",
        "You are worried.:Rom",
        "…He’ll be fine. Let’s just find him.:Jules",
        "We will.:Rom"
    };

    //Characters
    string[] c1 = new string[]
    {
        "Lulu2",
        "Rom2",
        "Lulu2",
        "Rom2",
        "Lulu1",
        "Rom2",
        "Lulu2",
        "nothing",
        "Lulu2",
        "Rex1",
        "Lulu1",
        "Rom2",
        "Lulu2",
        "Rex1",
        "Lulu2",
        "Rex2",
        "Lulu2",
        "Rom2",
        "Lulu1",
        "Rom2",
        "Lulu1",
    };

    string[] c2 = new string[]
    {
        "Lulu2",
        "Rex2",
        "Rom2",
        "Rex2",
        "Lulu2",
        "Rom2",
        "Rex1",
        "Lulu2"
    };

    string[] c3 = new string[]
    {
        "Rom2",
        "Lulu2",
        "Rex1",
        "Lulu1",
        "Rom2",
        "Rex2",
        "Lulu2",
        "Rom2",
        "Lulu2"
    };

    string[] c4 = new string[]
    {
        "Rom2",
        "Lulu2",
        "Rom2",
        "Lulu2",
        "Rom2",
        "Lulu2",
        "Rom2"
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
                if (controller.playerPos() > 4580 && controller.playerPos() < 5000 && Input.GetKeyDown(KeyCode.Space))
                {
                    area = 2;
                    visit1 = 1;
                    controller.MovePlayer(start, area2);
                }
                else if(controller.playerPos() >= end1 && visit1 == 1 && Input.GetKeyDown(KeyCode.Space))
                {
                    index = 0;
                    speechArray = s4;
                    charactersArray = c4;
                    visit1 = 2;
                    controller.Transition();
                    dialogue.Open();
                }
                else if(controller.playerPos() > 3980 && controller.playerPos() < 4330 && Input.GetKeyDown(KeyCode.Space))
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
                    else if(convo1 == 1)
                    {
                        index = 0;
                        speechArray = s3;
                        charactersArray = c3;
                        convo1 += 1;
                        controller.Transition();
                        dialogue.Open();
                    }
                }
            }
            else if (area == 2)
            {
                if (controller.playerPos() <= start && Input.GetKeyDown(KeyCode.Space))
                {
                    area = 1;
                    controller.MovePlayer(4790, area1);
                }
                else if (controller.playerPos() > 4600 && controller.playerPos() < 4900 && Input.GetKeyDown(KeyCode.Space))
                {
                    playerInstance.toggleMove();
                    controller.DisplayText("A pile of garbage. The only thing that stands out is a lighter, something humans use to summon fire.");
                }
                else if (controller.playerPos() > 5400 && controller.playerPos() < 5500 && Input.GetKeyDown(KeyCode.Space))
                {
                    playerInstance.toggleMove();
                    controller.DisplayText("A pile of garbage. The bags are full of cardboard and dried leaves. Maybe they can be put to use.");
                }
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Space) && !controller.isTransitioning() && !dialogue.isMoving())
            {
                if (index >= speechArray.Length)
                {
                    if (visit1 == 2)
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
