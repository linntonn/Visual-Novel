using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        if(player.transform.position.x < 1489)
        {
            transform.position = new Vector3(1489, player.transform.position.y + 120, -10);
        }
        else if(player.transform.position.x > 2712)
        {
            transform.position = new Vector3(2712, player.transform.position.y + 120, -10);
        }
        else
        {
            transform.position = new Vector3(player.transform.position.x, player.transform.position.y + 120, -10);
        }
    }
}
