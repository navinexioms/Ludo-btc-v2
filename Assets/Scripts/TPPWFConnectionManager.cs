using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using VoxelBusters;
using VoxelBusters.NativePlugins;

namespace Photon.Pun.UtilityScripts
{
	public class TPPWFConnectionManager : MonoBehaviourPunCallbacks {
		public static bool isMaster,isRemote,JoinedRoomFlag;
		public Text RoomName,WarningText;

		void Awake()
		{
			DontDestroyOnLoad (this);
		}
	// Use this for initialization
		void Start () 
		{
			
		}
	
	// Update is called once per frame
		void Update () {
		
		}
		public void CreateOrJoinRoomMethod()
		{
			if (RoomName.text.Length > 0 && (Application.internetReachability == NetworkReachability.ReachableViaLocalAreaNetwork || Application.internetReachability == NetworkReachability.ReachableViaCarrierDataNetwork)) {
				if (PhotonNetwork.AuthValues == null) 
				{
					PhotonNetwork.AuthValues = new Photon.Realtime.AuthenticationValues ();
				}
				PhotonNetwork.AuthValues.UserId = "nsd";
				PhotonNetwork.LocalPlayer.NickName = "nsd";
				PhotonNetwork.ConnectUsingSettings ();
			} else {
				StartCoroutine (RoomNameWarning());
			}
		}

		IEnumerator RoomNameWarning()
		{
			WarningText.text = "PLEASE ENTER THE ROOM NAME";
			yield return new WaitForSeconds (1);
			WarningText.text = null;
		}

		private void FinishSharing(eShareResult _result)
		{
			print (_result);
		}

		public override void OnConnectedToMaster()
		{
			print ("Conneced to master server:");
			PhotonNetwork.JoinLobby ();
		}
		public override void OnJoinedLobby()
		{
			print ("Joined lobby");
			PhotonNetwork.JoinOrCreateRoom (RoomName.text, new Photon.Realtime.RoomOptions {
				MaxPlayers = 2,
				PlayerTtl = 300000,
				EmptyRoomTtl = 10000
			}, null);
		}
		public override void OnCreatedRoom()
		{
			print ("Room Created Successfully");
			ShareSheet shareSheet = new ShareSheet ();
			shareSheet.Text = RoomName.text;
			NPBinding.Sharing.ShowView (shareSheet, FinishSharing);
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
			if (!JoinedRoomFlag) {
				SceneManager.LoadScene ("OneOnOneGameBoard");
			}
			JoinedRoomFlag = true;
		}
	}
}
