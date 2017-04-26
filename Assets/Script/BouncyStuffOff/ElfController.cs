using UnityEngine;
using System.Collections;

public class ElfController : MonoBehaviour {

	private ArrayList giftPickUpArray;
	private int giftIndex = 0;
	private GameObject currentGift;
	private Animator anim;
	private bool ReadyForNext = true;
	private float timeToWalk = 0f;

	// Use this for initialization
	void Start () {
		giftPickUpArray = new ArrayList();
		anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		if(giftPickUpArray.Count > 0){
			if(giftIndex < giftPickUpArray.Count){
				currentGift = (GameObject) giftPickUpArray[giftIndex];
				timeToWalk = timeToWalk + 0.1f;
				this.gameObject.transform.LookAt(currentGift.transform.position);
				this.gameObject.transform.position = Vector3.Lerp(this.gameObject.transform.position, currentGift.transform.position, timeToWalk );
				anim.SetBool("Walking", true);
				ReadyForNext = true;
			}

		}

		if(currentGift && 
		   this.gameObject.transform.position == currentGift.transform.position 
		   && ReadyForNext == true){
			anim.SetBool("Walking", false);
			ReadyForNext = false;
			giftIndex = giftIndex + 1;
			timeToWalk = 0f;
			Destroy(currentGift);
		}
	}

	public void PickUpGift(GameObject gift){
		//currentGift.y = this.gameObject.transform.position.y;
		giftPickUpArray.Add(gift);
	}
}
