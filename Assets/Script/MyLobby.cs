using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System.Linq;
using Photon.Realtime;
using UnityEngine.UI;

public class MyLobby : MonoBehaviourPunCallbacks
{

    public string PlayerName;
    public GameObject roomPanel;
    public InputField uiNick;
    public GameObject req;
    public GameObject nameContent;

    public ServerList[] playersNames;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayGame()
    {
        if (uiNick.text.Length > 0)
        {
            PlayerName = uiNick.text;
            PhotonNetwork.LocalPlayer.NickName = PlayerName;
            PhotonNetwork.ConnectUsingSettings();
        }
        else
        {
            req.SetActive(true);
        }
        


    }

    public void JoinRoom()
    {
        PhotonNetwork.JoinRandomRoom();

    }

    public override void OnConnectedToMaster()
    {
        roomPanel.SetActive(true);
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        Debug.Log("Não encontrou sala, criando uma...");
        string roomName = "Sala00";
        RoomOptions rOp = new RoomOptions();
        rOp.MaxPlayers = 20;
        PhotonNetwork.CreateRoom(roomName, rOp);

    }
    
    public override void OnJoinedRoom()
    {
        PhotonNetwork.Instantiate("PlayerName", Vector3.zero, Quaternion.identity);
        InvokeRepeating("CheckAllReady", 1, 1);

        //obj.transform.parent = nameContent.transform;
        //PhotonNetwork.LoadLevel("Game");

    }
    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        Debug.Log("newPlayer.NickName" + "Entrou");
        //InvokeRepeating("CheckAllReady", 1, 1);

    }
    void CheckAllReady()
    {
        playersNames = FindObjectsOfType<ServerList>();
        bool allready = true;
        if (playersNames.Length > 1)
        {
            allready = playersNames.All(x => x.ready);
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
