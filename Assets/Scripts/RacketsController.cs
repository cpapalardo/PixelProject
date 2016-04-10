using UnityEngine;
using System.Collections;

public class RacketsController : MonoBehaviour {

	public GameObject pixel;
	public float speed;
	public string axis = "Vertical";
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void FixedUpdate(){
		if (transform.gameObject.name == "RacketRight") {
			float v = Input.GetAxisRaw (axis);
			GetComponent<Rigidbody2D>().velocity = new Vector2(0, v) * speed;
		}
		else if (transform.gameObject.name == "RacketLeft") {
			if (pixel.transform.position.y > transform.localPosition.y) {
				GetComponent <Rigidbody2D> ().velocity = new Vector2 (0, 1) * speed;
			}
			else if (pixel.transform.position.y < transform.localPosition.y) {
				GetComponent<Rigidbody2D> ().velocity = new Vector2 (0, -1) * speed;
			}
			else if (pixel.transform.position.y == transform.localPosition.y) {
				GetComponent<Rigidbody2D> ().velocity = new Vector2 (0, 0);
			}
		}
	}
}
