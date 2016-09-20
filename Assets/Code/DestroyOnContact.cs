using UnityEngine;
using System.Collections;

/// <summary>
/// Purpose of this component is to destroy whatever gameobject triggers
/// the special unity method "OnTriggerEnter" which fires out when
/// a trigger collider detects collision. Keep in mind this is for 
/// trigger colliders which are different because they don't simulate physics.
/// Trigger colliders are more like sensors. 
/// </summary>
public class DestroyOnContact : MonoBehaviour {

    private void OnTriggerEnter(Collider otherGuy) {
        Destroy(otherGuy.gameObject);
    }

}
