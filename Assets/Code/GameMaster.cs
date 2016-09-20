using UnityEngine;
using System.Collections;

public class GameMaster : MonoBehaviour {

    public int maxTime = 30;
    public int startingDebt = 50000;

    public Basket basket;
    public GUIText debtText;
    public GUIText timeLeft;

    private GameState currentState = GameState.INITIAL;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
