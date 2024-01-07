using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TMPro;

public class roommanager : MonoBehaviourPunCallbacks


{
    public static roommanager instance;

    public GameObject player;
    public Transform spawnpoint;
    public GameObject roomcam;
    public GameObject nameui;
    public GameObject coonectedui;
    public string nickname;
   
   public void ChangeNickname(string _name) {
        nickname = _name;
    }
    public void JoinRoomButtonPressed()
    {

        nameui.SetActive(false);
        coonectedui.SetActive(true);
        Debug.Log("Connecting...");
        PhotonNetwork.ConnectUsingSettings();
    }

      void Awake() {
        instance = this;
    }


    public override void OnConnectedToMaster()
    {
        base.OnConnectedToMaster();

        Debug.Log("Connected To Server!");

        PhotonNetwork.JoinLobby();

    }

    public override void OnJoinedLobby()
    {
        base.OnJoinedLobby();

        PhotonNetwork.JoinOrCreateRoom("test", null, null);

        Debug.Log("We're Connected");
                Invoke("PhotonInit", 3);


    }
    
    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();
        Debug.Log("we are in a room");
        roomcam.SetActive(false);
        Respawn();


    }
    public void Respawn()
    {
        PhotonNetwork.LocalPlayer.NickName=nickname;
        GameObject _player = PhotonNetwork.Instantiate (player.name, spawnpoint.position,Quaternion.identity);

        _player.GetComponent<PlayerSetup>().IsLocalPlayer();
        _player.GetComponent<playerstate>().isloacal=true;
        _player.GetComponent<PhotonView>().RPC("SetNickName",RpcTarget.All,nickname);
    }

}