using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceInformation : MonoBehaviour {
	public GameObject SizeForTwoPices;
	public GameObject SizeForThreePices;
	public GameObject SizeForFourPices;
	public GameObject SizeForFivePices;
	public GameObject SizeForSixPices;
	public GameObject ActualSize;
	public List<GameObject> PicesContains;
	public int Number=0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerEnter2D(Collider2D col)
	{
		PicesContains.Add (col.gameObject);
		if (PicesContains.Count >1) {
			StartCoroutine (ChangePosition ());
		}
	}
	IEnumerator ChangePosition()
	{
		yield return new WaitForSeconds (.5f);
		if (PicesContains.Count == 2) {
			PicesContains [0].transform.position = new Vector3 (PicesContains [0].transform.position.x + 5, PicesContains [0].transform.position.y, PicesContains [0].transform.position.z);
			PicesContains [1].transform.position = new Vector3 (PicesContains [1].transform.position.x - 5, PicesContains [1].transform.position.y, PicesContains [1].transform.position.z);
		}
	}
	void OnTriggerExit2D(Collider2D col)
	{
		PicesContains.Remove (col.gameObject);
		col.gameObject.transform.localScale = ActualSize.transform.localScale;
		if (PicesContains.Count == 1) {
			PicesContains [0].transform.position = this.transform.position;
		}
	}
}
