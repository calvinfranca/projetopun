using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Gameroom : MonoBehaviour
{
    public GameObject roompanel;
    public ServerList[] players;
    // Start is called before the first frame update
    void Start()
    {

        roompanel.SetActive(true);
        players = FindObjectsOfType<ServerList>();
        foreach (ServerList player in players)
        {
            player.Reset();
        }       
        InvokeRepeating("CheckAllReady", 1, 1);
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    void CheckAllReady()
    {
        
        bool allready = true;
        if (players.Length > 1)
        {
            allready = players.All(x => x.ready);
            //for (int i = 0; i < playersNames.Length; i++)
            //{
            //    if (!playersNames[i].ready)
            //    {
            //
            //        allready = false;
            //    }
            //}
            if (allready)
            {
                PhotonNetwork.CurrentRoom.IsOpen = false;
                PhotonNetwork.LoadLevel("Game");
            }
        }

    }
}
