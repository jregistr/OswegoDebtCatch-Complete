using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameMaster : MonoBehaviour {

    public int maxTime = 30;
    public float bookDelayMin = 0.5f;
    public float bookDelayMax = 2.1f;
    public int aBookChance = 65;
    public int minSpawnX = -7;
    public int maxSpawnX = 7;
    public GameObject aBookPrefab;
    public GameObject fBookPrefab;

    public Basket basket;

    public Text timeLeftText;
    public GameObject gameOver;
    public GameObject play;
    public GameObject restart;

    private GameState currentState;
    private float currentTimeLeft;
    private float nextBookTime;

	// Use this for initialization
	private void Start () {
        currentState = GameState.INITIAL;
        StateTransition();
	}
	
	// Update is called once per frame
	private void Update () {
	    if(currentState == GameState.PLAYING) {
            if(currentTimeLeft <= 0) {
                currentState = GameState.GAMEOVER;
                StateTransition();
            }
            else {
                currentTimeLeft -= Time.deltaTime;
                if(Time.time >= nextBookTime) {
                    makeNextBookTime();
                    var nextBook = makeNextBook();
                    nextBook.transform.position = new Vector3(Random.Range(minSpawnX, maxSpawnX), 7, -1);
                }
            }

            timeLeftText.text = string.Format("Time:{0}", currentTimeLeft);
        }
	}

    private void StateTransition() {
        if(currentState == GameState.INITIAL) {
            basket.AllowedControl = false;
            currentTimeLeft = maxTime;
            gameOver.SetActive(false);
            play.SetActive(true);
            restart.SetActive(false);
        }
        else if(currentState == GameState.PLAYING) {
            basket.AllowedControl = true;
            gameOver.SetActive(false);
            play.SetActive(false);
            restart.SetActive(false);
        }
        else {
            basket.AllowedControl = false;
            gameOver.SetActive(true);
            play.SetActive(false);
            restart.SetActive(true);
        }
    }

    private void makeNextBookTime() {
        nextBookTime = Time.time + Random.Range(bookDelayMin, bookDelayMax);
    }

    private GameObject makeNextBook() {
        GameObject prefab;
        if(Random.Range(0, 100) <= aBookChance) {
            prefab = aBookPrefab;
        } else {
            prefab = fBookPrefab;
        }

        return GameObject.Instantiate(prefab);
    }

    public void OnPlayClick() {
        currentState = GameState.PLAYING;
        StateTransition();
    }

    public void OnRestartClick() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
