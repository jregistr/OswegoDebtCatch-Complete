using UnityEngine;
using System.Collections;

/// <summary>
/// The purpose of this component is to move the x position of the object its attached to
/// to where the mouse is. It also keeps the object constraint between the min x and max x.
/// </summary>
///
[RequireComponent(typeof(Rigidbody2D))]
public class Basket : MonoBehaviour {

    public Camera cam;

    public float minX;
    public float maxX;

    private Transform trans;
    private Rigidbody2D body;
    private bool allowedControl = false;

    /// <summary>
    /// This is a very simple of a C# feature called a property. It's sort of like
    /// getters and setters in java except this allows us to access the property like
    /// it's a field but fires up these methods. For example, calling this.AllowedControl calls
    /// the get method and calling this.AllowedControl = 5 would call the set method.
    /// </summary>
    public bool AllowedControl {
        get { return allowedControl; }
        set {
            allowedControl = value;
        }
    }

    private void Start() {
        // grab reference to the components we'll be using from this object.
        trans = transform;
        body = GetComponent<Rigidbody2D>();
    }
	
	// Update is called every physics step.
	private void FixedUpdate () {
	    if(AllowedControl) {
            Vector3 mouseScreenPosition = Input.mousePosition;
            Vector3 mousePositionInWorld = cam.ScreenToWorldPoint(mouseScreenPosition);

            Vector3 targetPosition = new Vector3(Mathf.Clamp(mousePositionInWorld.x, minX, maxX), trans.position.y, trans.position.z);
            body.MovePosition(targetPosition);
        }
	}

}
