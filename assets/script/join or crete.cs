using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using TMPro;
using Photon.Realtime;

public class joinorcrete : MonoBehaviourPunCallbacks
{
    public TMP_InputField inputcreate;
    public TMP_InputField inputjoin;

    public void CreateRoom(){
        PhotonNetwork.JoinRandomOrCreateRoom(null,4);
    }
    public void JoinRoom(){
        PhotonNetwork.JoinRoom(inputjoin.text);
    }
    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel("SampleScene");
        print(PhotonNetwork.CountOfPlayersInRooms);

        }
}
