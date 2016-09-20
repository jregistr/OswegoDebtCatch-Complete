using UnityEngine;
using System.Collections;

/// <summary>
/// Destroys the object that collided with the object this component is attached to.
/// </summary>
public class DestroyOnTrigger : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D otherGuy) {
        Destroy(otherGuy.gameObject);
    }
}
