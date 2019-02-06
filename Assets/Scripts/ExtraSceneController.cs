using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class ExtraSceneController : MonoBehaviour 
{
	public static int HowManyPlayers;
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
	public void LoadBettingAmountScene()
	{
		SceneManager.LoadScene ("BettingAmountScene");
	}
	public void LoadColorPickingScene()
	{
		SceneManager.LoadScene ("ColorPicking");
	}
	public void LoadExtraScene()
	{
		SceneManager.LoadScene ("ExtraScenes");
	}
	public void LoadProfileScene()
	{
		SceneManager.LoadScene ("ProfileScene");
	}
	public void WalletScene()
	{
		SceneManager.LoadScene ("WalletScene");
	}
	public void  LoadTransactionScene()
	{
		SceneManager.LoadScene ("TransactionScene");
	}
	public void SettingScene()
	{
		SceneManager.LoadScene ("SettingScene");
	}
	public void Logout()
	{
		SceneManager.LoadScene ("GameMenu");
	}
	public void SaveuserDataAndLoadExtraScene()
	{
		SceneManager.LoadScene ("ExtraScenes");
	}	
	public void LoadExtraSceneFromSetting()
	{
		SceneManager.LoadScene ("ExtraScenes");
	}
	public void LoadExtraScenefromTransaction()
	{
		SceneManager.LoadScene ("ExtraScenes");
	}
	public void LoadExtraSceneFromWalletScene()
	{
		SceneManager.LoadScene ("ExtraScenes");
	}
	public void LoadMainGameSceneFromExtraScene()
	{
		SceneManager.LoadScene ("GameMenu");
	}
	public void LoadPlayerVSAIScene()
	{
		HowManyPlayers = 2;
		SceneManager.LoadScene ("PlayerVSAI");
	}
	public void LoadTwoPlayWithFriend()
	{
		SceneManager.LoadScene ("PlayWithFriend");
	}
	public void LoadOneOnOneScene()
	{
		SceneManager.LoadScene ("OneOnOneGameBoard");
	}
}
