using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections;

public class GameManager : MonoBehaviour {

	public AudioClip bounceAudio;
	public AudioClip splashAudio;
	public int giftsTotal = 10;
	public int giftsCount = 0;
	public Text StartGameText;
	public Text EndGameText;
	public Button StartGameButton;

	private GameObject selectedGift;
	private int giftsSaved = 0;
	private StuffGenerator giftCreator;
	private ElfController elfControl;

	// Use this for initialization
	void Start () {
		elfControl = GameObject.FindGameObjectWithTag("Elf").GetComponent<ElfController>() as ElfController;
		giftCreator = FindObjectOfType<StuffGenerator>(); 
			//GameObject.FindGameObjectWithTag("GiftCreator").GetComponent as StuffGenerator;
	}

	public void OnClickButton(){
		ResetGame();
		StartGame();
	}

	private void StartGame(){
		StartGameButton.gameObject.SetActive(false);
		StartGameText.gameObject.SetActive(false);
		giftCreator.gameObject.SetActive(true);
		giftCreator.GetComponent<StuffGenerator>().StartGenerating();
	}

	private void ResetGame(){
		giftsSaved = 0;
		giftsCount = 0;
		EndGameText.gameObject.SetActive(false);
		foreach(GameObject item in GameObject.FindGameObjectsWithTag("Gift")){
			Destroy(item);
		} 
	}

	public void EndGame(){
		EndGameText.gameObject.SetActive(true);
		EndGameText.text = "Game Over \nGifts Saved:" + giftsSaved + "\nHappy Holidays!";
		StartGameButton.gameObject.SetActive(true);
	}

	// Update is called once per frame
	void Update () {
		if(Input.GetKey(KeyCode.Escape)){
			//Debug.Log ("Exit");
			Application.Quit();
		}
	}

	public void IsNotInWater(GameObject gift){
		giftsSaved = giftsSaved + 1;
		//Debug.Log("giftsSaved " + giftsSaved);

		selectedGift = gift;
		elfControl.PickUpGift(selectedGift);
	}

	public void PlayBounceAudio(){
		GetComponent<AudioSource>().clip = bounceAudio;
		GetComponent<AudioSource>().Play();
	}

	public void PlaySplashAudio(){
		GetComponent<AudioSource>().clip = splashAudio;
		GetComponent<AudioSource>().Play();
	}
}
