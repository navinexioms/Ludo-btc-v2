using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using SimpleJSON;
using UnityEngine.Networking;


public class SceneController : MonoBehaviour
{
	public GameObject SplashScreen;
	public GameObject LoginPanel;
	public GameObject Blackscreen;
	public GameObject AvatarScreen;
	public Text Username1;
	public Text Password1;
	JSONNode rootnode = new JSONClass ();
	JSONNode rootnode1 = new JSONClass ();
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
			PlayerPrefs.SetString ("userid", null);
		} 
		else if (Password.Length == 0) 
		{
			StartCoroutine (LoadPanel (LoginPanel, AvatarScreen, 1.1f, "please enter password"));
			PlayerPrefs.SetString ("userid", Username);
		}
		else if (Application.internetReachability == NetworkReachability.NotReachable) 
		{
			StartCoroutine (LoadPanel (LoginPanel, AvatarScreen, 1.1f, "please connect to internet"));	
		}
		else if (Username.Length > 0 && Password.Length > 0 && (Application.internetReachability == NetworkReachability.ReachableViaLocalAreaNetwork || Application.internetReachability == NetworkReachability.ReachableViaCarrierDataNetwork)) 
		{
			StartCoroutine (HitUrl());
		}

	}
	IEnumerator HitUrl()
	{
		UnityWebRequest request =new UnityWebRequest("http://apienjoybtc.exioms.me/api/Home/login?my_sponsar_id="+Username+"&password="+Password);

		request.chunkedTransfer = false;

		request.downloadHandler = new DownloadHandlerBuffer ();

		yield return request.SendWebRequest ();
		print(request.downloadHandler.text);
		if (request.error != null) {
			print ("something went wrong");
			print (request.error);
		} else {
			string msg = request.downloadHandler.text.ToString();
			string start = "";
			if (msg.Contains ("{")) {
				print ("Contains");
				msg=msg.Substring(1,msg.Length-2);
				print (msg);
				rootnode = SimpleJSON.JSONData.Parse (msg);
//				print (rootnode);
				print (rootnode [0]);
				string KeyValues = rootnode [0];
				print (KeyValues);
				if (!KeyValues.Contains ("Invalidlogincredentials")) {
					print ("valid");
					PlayerPrefs.SetString ("userid", Username);
					string name = PlayerPrefs.GetString ("userid");
					print (name);
					StartCoroutine (LoadPanel (LoginPanel, AvatarScreen, 1f, "a"));
				}
				else {
					print ("Invalid");
					StartCoroutine (LoadPanel (LoginPanel, AvatarScreen, 1.1f, "invalid login credentials"));
				}
			} 
		}
	}
	/*public void MyMethod()
	{
		StartCoroutine(HitUrl1());	
	}
	IEnumerator HitUrl1()
	{
		UnityWebRequest request =new UnityWebRequest("http://shehnaiya.com/pharomyd/index.php/webservice/countryList");

		request.chunkedTransfer = false;

		request.downloadHandler = new DownloadHandlerBuffer ();

		yield return request.SendWebRequest ();
		if (request.error != null) {
			print ("something went wrong");
			print (request.error);
		} else {
			string msg = request.downloadHandler.text.ToString();
			rootnode = SimpleJSON.JSONData.Parse (msg);
			print (rootnode [1][0]);
			int i = 0;
			foreach (JSONNode j in rootnode[1].Childs) {
				print (j [0]);
			}
		}

	}*/
	public void TakeuserName(string uname) 
	{
		Username = uname.ToString ();
		print ("Username:"+Username+" username:"+uname);

		print (name);

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