﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class ServerList : MonoBehaviour
{
    public Text nametext;
    public PhotonView pview;
    public Toggle readyToggle;
    public bool ready = false;

    // Start is called before the first frame update
    void Start()
    {
        
        nametext.text = pview.Owner.NickName;

        GameObject content = GameObject.FindGameObjectWithTag("PlayerList");
        if (content)
            transform.parent = content.transform;

        if (pview.IsMine)
        {
            readyToggle.interactable = true;
        }
        else
        {
            readyToggle.interactable = false;
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Reset()
    {
        nametext.text = pview.Owner.NickName;
        GameObject content = GameObject.FindGameObjectWithTag("PlayerList");
        transform.parent = content.transform;
        readyToggle.isOn = false;

        if (pview.IsMine)
        {
            readyToggle.interactable = true;
        }
        else
        {
            readyToggle.interactable = false;
        }

    }

    public void ReadyIsChange()
    {
        if(ready != readyToggle.isOn)
        {
            ready = readyToggle.isOn;
            pview.RPC("StatusChange", RpcTarget.OthersBuffered, ready);
        }
       

    }

    [PunRPC]
    void StatusChange(bool myready)
    {
       
        readyToggle.isOn = myready;
        ready = myready;
    }
}
