using UnityEngine;
using System.Collections;

public class GiftBox : MonoBehaviour {

	private int rightDirectionForce = -160;
	private GameManager gM;

	// Use this for initialization
	void Start () {
		rightDirectionForce = Random.Range(-160, -60);
		gM = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>() as GameManager; 
		this.gameObject.GetComponent<Rigidbody>().AddForce(rightDirectionForce, 0, 0);
	}

	void OnCollisionEnter(Collision collision) {
		//Debug.Log("GiftBox Collision: " + collision.gameObject.tag);

		if(collision.gameObject.tag == "Water"){
			gM.PlaySplashAudio();
			return;
		}else if(collision.gameObject.tag == "Ground"){
			gM.IsNotInWater(this.gameObject);
		}
	}
}
