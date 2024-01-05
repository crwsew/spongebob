using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class roommanager : MonoBehaviourPunCallbacks
{
    public static roommanager instance;
    public GameObject player;
    public Transform spawnpoint;
    public GameObject roomcam;

    public GameObject nameui;
    public GameObject coonectedui;
    private string nickname="unnamed";
    void Avake(){
        instance=this;
    }
    public void ChangeNickName(string _name){
        nickname= _name;
    }
    public void JoinRoomButtonPressed(){
        
        nameui.SetActive(false);
        coonectedui.SetActive(true);
    }
    void Start()
    {
        Debug.Log("Connecting...");
        PhotonNetwork.ConnectUsingSettings();

    }
    

    public override void OnConnectedToMaster() {
        base.OnConnectedToMaster();

        Debug.Log("Connected To Server!");

        PhotonNetwork.JoinLobby();

    }

    public override void OnJoinedLobby()
    {
        base.OnJoinedLobby();

        PhotonNetwork.JoinOrCreateRoom("test", null , null);

        Debug.Log("We're Connected and in a room now!");

    }
    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();
        Debug.Log("we are in a room");
        roomcam.SetActive(false);
        Respawn();


    }
    public void Respawn(){
        GameObject _player =PhotonNetwork.Instantiate(player.name,spawnpoint.position,Quaternion.identity);
        _player.GetComponent<playersetup>().IsLocalplayer();
            _player.GetComponent<playerstate>().isloacal=true;

    }

}