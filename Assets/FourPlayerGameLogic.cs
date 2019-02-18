using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Realtime;
using SimpleJSON;
using UnityEngine.EventSystems;
using ExitGames.Client.Photon;
using Photon.Realtime;

namespace Photon.Pun.UtilityScripts
{
	public class FourPlayerGameLogic : MonoBehaviourPunCallbacks,IPunTurnManagerCallbacks 
	{


		private PunTurnManager turnManager;

		public int TriggeredTime;
		public int TriggerCounter;
		public int timer;
		public int playerCounter;

		public int TriggeredTime2;
		public int TriggerCounter2;
		public int timer2;

		public int ImageFillingCounter;

		public GameObject DisconnectPanel;
		public GameObject WinPanel, LosePanel;

		public Text DisconnectText;
		public Text DisconnectText1;
		public GameObject ReconnectButton;


		JSONNode rootNode=new JSONClass();
		JSONNode childNode = new JSONClass ();
		JSONNode BlankTurn1 = new JSONClass ();
		JSONNode BlankTurn2=new JSONClass();

		public Image TimerImage;

		public Image ImageOne;
		public Image ImageTwo;

		public Vector3 TimerOnePosition;
		public Vector3 TimerTwoPosition;

		public GameObject GameOver;
		public Text GameOverText;
		private int totalBlueInHouse, totalGreenInHouse;

		public GameObject BlueFrame, GreenFrame;

		public GameObject BluePlayerI_Border,BluePlayerII_Border,BluePlayerIII_Border,BluePlayerIV_Border;
		public GameObject GreenPlayerI_Border,GreenPlayerII_Border,GreenPlayerIII_Border,GreenPlayerIV_Border;
		public GameObject RedPlayerI_Border,RedPlayerII_Border,RedPlayerIII_Border,RedPlayerIV_Border;
		public GameObject YellowPlayerI_Border, YellowPlayerII_Border, YellowPlayerIII_Border, YellowPlayerIV_Border;

		public Sprite[] DiceSprite=new Sprite[7];

		public Vector3[] BluePlayers_Pos;
		public Vector3[] GreenPlayers_Pos;
		public Vector3[] RedPlayers_Pos;
		public Vector3[] YellowPlayers_Pos;


		public Button BluePlayerI_Button, BluePlayerII_Button, BluePlayerIII_Button, BluePlayerIV_Button;
		public Button GreenPlayerI_Button,GreenPlayerII_Button,GreenPlayerIII_Button,GreenPlayerIV_Button;
		public Button RedPlayerI_Button,RedPlayerII_Button,RedPlayerIII_Button,RedPlayerIV_Button;
		public Button YellowPlayerI_Button,YellowPlayerII_Button,YellowPlayerIII_Button,YellowPlayerIV_Button;


		public Text BlueRankText, GreenRankText;

		public string playerTurn="BLUE";

		public Transform diceRoll;

		public Button DiceRollButton;

		public Transform BlueDiceRollPosition, GreenDiceRollPosition,RedDiceRollPosition,YellowDicePosition;

		private string currentPlayer="none";
		private string currentPlayerName = "none";

		public GameObject BluePlayerI, BluePlayerII, BluePlayerIII, BluePlayerIV;
		public GameObject GreenPlayerI, GreenPlayerII, GreenPlayerIII, GreenPlayerIV;
		public GameObject RedPlayerI, RedPlayerII, RedPlayerIII, RedPlayerIV;
		public GameObject YellowPlayerI,YellowPlayerII,YellowPlayerIII,YellowPlayerIV;


		public List<int> BluePlayer_Steps=new List<int>();
		public List<int> GreenPlayer_Steps=new List<int>();
		public List<int> RedPlayer_Steps=new List<int>();
		public List<int> YellowPlayer_Steps=new List<int>();

		private int bluePlayerI_Steps,bluePlayerII_Steps,bluePlayerIII_Steps,bluePlayerIV_Steps;
		private int GreenPlayerI_Steps,GreenPlayer_StepsII,GreenPlayerIII_Steps,GreenPlayerIV_Steps;
		private int RedPlayerI_Steps, RedPlayerII_Steps, RedPlayerIII_steps, RedPlayerIV_Steps;
		private int YellowPlayerI_Steps, YellowPlayerIISteps, YellowPlayerIII_Steps, YellowPlayerIV_Steps;

		//----------------Selection of dice number Animation------------------
		private int selectDiceNumAnimation;

		//Players movement corresponding to blocks
		public List<GameObject> blueMovemenBlock=new List<GameObject>();
		public List<GameObject> greenMovementBlock=new List<GameObject>();
		public List<GameObject> redMovementBlock = new List<GameObject> ();
		public List<GameObject> yellowMovementBlock = new List<GameObject> ();


		public List<GameObject> BluePlayers=new List<GameObject>();
		public List<GameObject> GreenPlayers=new List<GameObject>();
		public List<GameObject> RedPlayers = new List<GameObject> ();
		public List<GameObject> YellowPlayers = new List<GameObject> ();


		private System.Random randomNo;
		public GameObject confirmScreen;
		public GameObject gameCompletedScreen;

		public bool isMyTurn;
		public bool PlayerCanPlayAgain;
		public bool ActualPlayerCanPlayAgain;


		public void OnTurnBegins(int turn)
		{
		}
		public void OnTurnCompleted(int turn)
		{}
		public void OnPlayerMove(Player player, int turn, object move)
		{}
		public void OnPlayerFinished(Player player, int turn, object move)
		{
		}
		public void OnTurnTimeEnds(int turn)
		{

		}
	}
}
