using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueScript : MonoBehaviour
{
    public static DialogueScript instance;
    public ELEMENTS elements;
    public RectTransform characterPanel;
    public Vector2 target;
    public float speed;
    private string prevSpeaker = "";
    private RectTransform root;
    
    public Vector2 anchorPadding { get { return root.anchorMax - root.anchorMin; } }

    void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        speed *= Time.deltaTime;
    }

    public void Open()
    {
        foreach (Transform child in characterPanel.transform)
        {
            GameObject.Destroy(child.gameObject);
        }

        speechPanel.SetActive(true);
        speechText.text = "";
        speakerText.text = "";
    }

    public void Say(string speech, string character, string speaker = "")
    {
        foreach (Transform child in characterPanel.transform)
        {
            GameObject.Destroy(child.gameObject);
        }

        speechPanel.SetActive(true);
        speechText.text = speech;
        if (speaker == "")
        {
            speakerText.text = prevSpeaker;
        }
        else if(speaker == "nothing")
        {
            speakerText.text = "";
        }
        else
        {
            speakerText.text = speaker;
            prevSpeaker = speaker;
        }

        if (character != "nothing")
        {
            GameObject prefab = Resources.Load("Images/Characters/" + character) as GameObject;
            GameObject ob = Instantiate(prefab, characterPanel);
            moving = StartCoroutine(Moving(ob));
        }
    }

    Coroutine moving;
    //bool isMoving { get { return moving != null; } }
    public bool isMoving()
    {
        return moving != null;
    }

    public void stopMoving()
    {
        if(isMoving())
        {
            StopCoroutine(moving);
        }
        moving = null;
    }

    IEnumerator Moving(GameObject ob)
    {
        if (ob != null)
        {
            root = ob.GetComponent<RectTransform>();

            Vector2 padding = anchorPadding;

            float maxX = 1f - padding.x;
            float maxY = 1f - padding.y;

            Vector2 minAnchorTarget = new Vector2(maxX * target.x, maxY * target.y);

            while (root.anchorMin != minAnchorTarget)
            {
                root.anchorMin = Vector2.Lerp(root.anchorMin, minAnchorTarget, speed);
                root.anchorMax = root.anchorMin + padding;
                yield return new WaitForEndOfFrame();
            }
            stopMoving();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    [System.Serializable]
    public class ELEMENTS
    {
        public GameObject speechPanel;
        public Text speakerText;
        public Text speechText;
    }
    public GameObject speechPanel { get { return elements.speechPanel; } }
    public Text speakerText { get { return elements.speakerText; } }
    public Text speechText { get { return elements.speechText; } }
}
