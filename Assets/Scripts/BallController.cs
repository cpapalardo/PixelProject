using UnityEngine;
using System.Collections;
using UnityEngine.UI;

//http://noobtuts.com/unity/2d-pong-game

public class BallController : MonoBehaviour {

	public float speed;
    public Text playerScore;
	public Vector3 initialPosition = new Vector3(0,1,0);
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
		if (col.gameObject.name == "RacketRight") {
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
			this.gameObject.SetActive (false);
            UpdateScore();
            transform.position = initialPosition;
			this.gameObject.SetActive (true);
            GetComponent<Rigidbody2D>().velocity = Vector2.right * speed;
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
        int aux = int.Parse(playerScore.text);
        aux++;
        playerScore.text = aux.ToString();
    }

}
