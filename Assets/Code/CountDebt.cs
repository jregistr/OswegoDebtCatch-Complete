using UnityEngine;
using UnityEngine.UI;
using System.Collections;

/// <summary>
/// This component changes the debt of the player when collision is detected.
/// It also renders that score on the given textbox.
/// </summary>
public class CountDebt : MonoBehaviour {

    public Text debtScore;
    public int debtPerABook = -5000;
    public int debtPerFBook = 15000;

    private int currentDebt = 50000;

    private void Start() {
        debtScore.text = string.Format("Debt:{0}", currentDebt);
    }

    private void OnTriggerEnter2D(Collider2D otherGuy) {
        Debug.Log("Collision");
        if(otherGuy.tag == "A") {
            currentDebt += debtPerABook;
        }
        else {
            currentDebt += debtPerFBook;
        }

        debtScore.text = string.Format("Debt:{0}", currentDebt);
    } 

}
