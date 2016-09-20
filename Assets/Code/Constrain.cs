using UnityEngine;
using System.Collections;

/// <summary>
/// The purpose of this component is to define position constraints
/// for the gameobject that has this component. It simply clamps the
/// x position between the lower value and upper value.
/// </summary>
public class Constrain : MonoBehaviour {

    // The lowest the x position is allowed to be.
    public float minX;

    // The highest the x position is allowed to be.
    public float maxX;

    private Transform trans;

    private void Start() {
        // Get a reference to the transform component and save it,
        // that way we're not calling transform all the time.
        // here transform is bad because it looks innocent but really is
        // this.gameObject.getComponent<Transform>()
        // which is kinda an expensive method call.
        trans = transform;
    }
	
    /// <summary>
    /// Update function is one of the method names reserved by Unity for classes
    /// that inherit MonoBehaviour. This gets called every frame. Refer to the
    /// documentation to find other reserved method names.
    /// </summary>
	private void Update () {
	    if(trans.position.x < minX) {
            trans.position = new Vector3(minX, trans.position.y, trans.position.z);
        }
        else if(trans.position.x > maxX) {
            trans.position = new Vector3(maxX, trans.position.y, trans.position.z);
        }
	}
}
