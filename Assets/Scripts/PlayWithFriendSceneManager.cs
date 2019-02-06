using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon;
public class PlayWithFriendSceneManager : Photon.Pun.MonoBehaviourPun
{

	public Toggle TwoPlayerToggle, FourPlayerToggle;
	public GameObject TwoPlayerGameObject, FourPlayerGameObject;
	public void SelectTwoPlayerGamePlay()
	{
		TwoPlayerGameObject.SetActive (TwoPlayerToggle.isOn);
		FourPlayerGameObject.SetActive (false);
	}
	public void SelectFourPlayerGamePlay()
	{
		TwoPlayerGameObject.SetActive (false);
		FourPlayerGameObject.SetActive (FourPlayerToggle.isOn);
	}
	public void TakeRoomNameForTwoPlayers()
	{
		
	}
	public void TakeRoomNameForFourPlayers()
	{
		
	}
	//==============Method to Invite friend and Create Room======================//
	public void InviteFriend()
	{
		
	}

	//=============Method to Join Game=================//
	public void JoinGame()
	{
		
	}
	// Use this for initialization
	void Start () 
	{
		
	}
	

}
