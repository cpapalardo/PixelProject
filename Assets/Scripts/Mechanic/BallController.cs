using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//http://noobtuts.com/unity/2d-pong-game

public class BallController : MonoBehaviour {

	public float speed;
    public Text aIScore;
	public bool gotHeart;
	public Vector3 initialPosition = new Vector3(0,1,0);
	public string axis = "Vertical";
	public GameObject heart;
	// Use this for initialization
	void Start () {
		GetComponent<Rigidbody2D> ().velocity = Vector2.right * speed;
	}

	void OnCollisionEnter2D(Collision2D col){
		/*col possui informações de colisão. Se a bola colidir com uma raquete
		col.gameObject é a raquete
		col.transform.position é a posição da raquete 
		col.collider é o colisor da raquete*/
		if (col.gameObject.name == "RacketLeft") {
			float y = HitFactor (transform.position, col.transform.position, col.collider.bounds.size.y);

			//Calcula direção
			Vector2 direction = new Vector2 (1, y).normalized;

			//Define velocidade como direction * velocidade
			GetComponent<Rigidbody2D> ().velocity = direction * speed;
		}
		if (col.gameObject.name == "RacketRight" && !gotHeart) {
			// Calculate hit Factor
			float y = HitFactor(transform.position,
				col.transform.position,
				col.collider.bounds.size.y);

			// Calculate direction, make length=1 via .normalized
			Vector2 direction = new Vector2(-1, y).normalized;

			// Set Velocity with dir * speed
			GetComponent<Rigidbody2D>().velocity = direction * speed;
		}
		if (col.gameObject.name == "DestroyerLeft" || col.gameObject.name == "DestroyerRight") {
			if (gotHeart)
				SceneManager.LoadScene ("Tela02");
			else {
				SoundController.PlaySound (SoundDatabase.miss);
				this.gameObject.SetActive (false);
				UpdateScore ();
				transform.position = initialPosition;
				this.gameObject.SetActive (true);
				GetComponent<Rigidbody2D> ().velocity = Vector2.right * speed;
			}
        }
		if (col.gameObject.name == "Heart") {
			gotHeart = true;
			col.gameObject.SetActive (false);
			SoundController.StopSound ();
			GetComponent<Rigidbody2D> ().velocity = new Vector2(0f,0f);
		}

	}

	public float HitFactor (Vector2 ballPosition, Vector2 racketPosition, float racketHeight){

		// ||  1 <- topo da raquete
		// ||
		// ||  0 <- meio da raquete
		// ||
		// || -1 <- baixo da raquete

		return (ballPosition.y - racketPosition.y) / racketHeight;
	}

    public void UpdateScore()
    {
		int aux = int.Parse(aIScore.text);
        aux++;
		aIScore.text = aux.ToString();
    }

	void FixedUpdate(){
		if (Time.time < 15f)
			speed +=0.005f;
		if(gotHeart){
			float v = Input.GetAxisRaw (axis);
			float h = Input.GetAxisRaw ("Horizontal");
			GetComponent<Rigidbody2D>().velocity = new Vector2(h, v) * speed;
		}
	}

}
