using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityTemplateProjects;

public class NetCamera : MonoBehaviour
{
    public GameObject player;
    public Vector3 ajuste;
    public SimpleCameraController simpleCameraController;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player)
        {
            simpleCameraController.enabled = false;
            transform.LookAt(player.transform);
            transform.position = Vector3.Lerp(transform.position, player.transform.position-player.transform.forward*ajuste.z+Vector3.up*ajuste.y,Time.deltaTime);

        }
        else
        {
            simpleCameraController.enabled = true;

        }
    }
    public void SetPlayer(GameObject myplayer)
    {
        player = myplayer;
    }
}
