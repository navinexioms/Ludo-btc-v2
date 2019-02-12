using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneController : MonoBehaviour
{
	public GameObject SplashScreen;
	public GameObject LoginPanel;
	public GameObject Blackscreen;
	public GameObject AvatarScreen;

	public string Username=null, Password=null;

	private bool netConnectivity;

	private Animator Anim;

	void Start()
	{
		print ("Hello");
		Anim = Blackscreen.GetComponent<Animator> ();
		StartCoroutine (LoadPanel (SplashScreen,LoginPanel,1,"a"));
	}
	void Update()
	{
		if (Application.internetReachability == NetworkReachability.ReachableViaLocalAreaNetwork || Application.internetReachability == NetworkReachability.ReachableViaCarrierDataNetwork) 
		{
			print ("internet connection");
		}
		else if(Application.internetReachability == NetworkReachability.NotReachable)
		{
			print ("no Internet connection is there");
		}
	}

	IEnumerator LoadPanel(GameObject panelToDisable,GameObject PanelToEnable,float time,string message)
	{
		if (time == 1.1f) 
		{
			yield return new WaitForSeconds (0);
			StartCoroutine (WaitForWhile (panelToDisable, PanelToEnable, 1.1f,message));	
		} 
		else 
		{
			yield return new WaitForSeconds (time);
			Anim.SetInteger ("Counter", 1);
			StartCoroutine (WaitForWhile (panelToDisable, PanelToEnable, 1,"a"));
		}
	}
	IEnumerator WaitForWhile(GameObject panelToDisable,GameObject PanelToEnable,float time,string message)
	{
		print ("time:"+time);
		if (time == 1.1f) 
		{
			print ("Waiting");
			GameObject WarningText= GameObject.Find ("NetConnectionWarning") as GameObject;
			WarningText.GetComponent<Text> ().text = ""+message;
			yield return new WaitForSeconds(1f);
			WarningText.GetComponent<Text>().text=null;
		} 
		else 
		{
			print ("Waiting");
			yield return new WaitForSeconds (time);
			panelToDisable.SetActive (false);
			PanelToEnable.SetActive (true);
			Anim.SetInteger ("Counter", 2);
		}
	}
	IEnumerator HoldForoneSec()
	{
		yield return new WaitForSeconds (1);
		SceneManager.LoadScene ("GameMenu");
	}
	public void LoadAvatarPanel()
	{
		print ("hello111");
		if (Username.Length == 0) 
		{
			StartCoroutine (LoadPanel (LoginPanel, AvatarScreen, 1.1f, "please enter username"));
		} 
		else if (Password.Length == 0) 
		{
			StartCoroutine (LoadPanel (LoginPanel, AvatarScreen, 1.1f, "please enter password"));
		}
		else if (Application.internetReachability == NetworkReachability.NotReachable) 
		{
			StartCoroutine (LoadPanel (LoginPanel, AvatarScreen, 1.1f, "please connect to internet"));	
		}
		else if (Username.Length > 0 && Password.Length > 0 && (Application.internetReachability == NetworkReachability.ReachableViaLocalAreaNetwork || Application.internetReachability == NetworkReachability.ReachableViaCarrierDataNetwork)) 
		{
			StartCoroutine (LoadPanel (LoginPanel, AvatarScreen, 0,"a"));
		}

	}

	public void TakeuserName(string uname) 
	{
		Username = uname.ToString ();
		print ("Username:"+Username+" username:"+uname);
	}
	public void TakePassword(string pname)
	{
		Password = pname.ToString ();
		print ("Password:"+Password+" password:"+pname);
	} 
	public void LoadGameOptionMenu()
	{

		Anim.SetInteger ("Counter",1);
		StartCoroutine (HoldForoneSec ());
	}
	public void LoadPlayerVSAIScene()
	{
		
		SceneManager.LoadScene ("PlayerVSAI");
	}
}