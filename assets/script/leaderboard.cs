using UnityEngine;
using System.Linq;
using Photon.Pun;
using TMPro;
using Photon.Realtime;
using Photon.Pun.UtilityScripts;

public class leaderboard : MonoBehaviour
{

    public GameObject playerholder;
    [Header("option")]
    public float refreshrate = 1F;
    [Header("ui")]
    public GameObject[] slots;
    [Space]
    public TMP_Text[] scoretext;
    public TMP_Text[] nameplayer;
    private void Start()
    {
        InvokeRepeating(nameof(refresh), 1f, refreshrate);
    }
    public void refresh()
    {
        foreach (var slot in slots)
        {
            slot.SetActive(false);
        }
        var sortedplayerlist =
        (from Player in PhotonNetwork.PlayerList orderby Player.GetScore() descending select Player).ToList();
        int i = 0;
        foreach (var Player in sortedplayerlist)
        {

            nameplayer[i].text = Player.NickName;
            scoretext[i].text = Player.GetScore().ToString();
            slots[i].SetActive(true);
            if (Player.NickName == "")
            {
                Player.NickName = "unnamed";

            }
            i++;
        }
    }
    private void Update()
    {
        playerholder.SetActive(Input.GetKey(KeyCode.Tab));
    }

}
