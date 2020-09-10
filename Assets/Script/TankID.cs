using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankID : MonoBehaviour
{
    public TextMesh nameText;
    public PhotonView pview;
    public int life=100;
    // Start is called before the first frame update
    void Start()
    {
        nameText.text = pview.Owner.NickName;
    }

    // Update is called once per frame
    void Update()
    {
        //name.transform.LookAt(Camera.main.transform);
        nameText.transform.forward = transform.position - Camera.main.transform.position;


        if (pview.IsMine)
        {      
            if (life <= 0)
            {
                PhotonNetwork.Destroy(gameObject);
            }
        }
    }

    void DamageTaken(Vector3 pos)
    {
        if (pview.IsMine)
        {
            float distance = Vector3.Distance(pos, transform.position);
            //life -= (int)(50 / (distance + 1));
            life -= 10;

            pview.RPC("DamageCall", RpcTarget.All, pos, life);
            GetComponent<Rigidbody>().AddExplosionForce(50000, transform.position, 20);
        }
            
    }

    [PunRPC]
    public void DamageCall(Vector3 pos, int livesremain)
    {
        life = livesremain;
        
        
        nameText.text = pview.Owner.NickName+" "+life.ToString();

    }
}
