using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Photon.Pun.Demo.Cockpit
{
	public class OneOnOneConnectionManager : MonoBehaviourPunCallbacks
	{
		public static bool isMaster,isRemote;
		void Awake()
		{
			DontDestroyOnLoad (this);
		}
		void Start()
		{
			print ("hello");

		}
	// Use this for initialization
		public void CreateRoomMethod()
		{
			PhotonNetwork.ConnectUsingSettings ();
		}
		public override void OnConnectedToMaster()
		{
			print ("Conneced to master server:");
			PhotonNetwork.JoinLobby ();
		}
		public override void OnJoinedLobby()
		{
			print ("Joined lobby");
			PhotonNetwork.CreateRoom ("nsd", new Photon.Realtime.RoomOptions{ MaxPlayers = 2, PlayerTtl = 20000 }, null);
		}
		public override void OnCreatedRoom()
		{
			print ("Room Created Successfully");
			isMaster = true;
		}
		public override void OnCreateRoomFailed(short msg,string msg1)
		{
			print(msg1);

			PhotonNetwork.JoinRoom ("nsd");
		}
		public override void OnJoinedRoom()
		{
			print ("Room Joined successfully");
			if (PhotonNetwork.PlayerList.Length == 2) 
			{
				isRemote = true;
			}
			SceneManager.LoadScene ("OneOnOneGameBoard");
		}
		// Update is called once per frame
	}
}
