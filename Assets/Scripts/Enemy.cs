using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	public int HP = 3;
	protected Transform m_transform;

	void Start()
	{
		m_transform = this.transform;

	}

	void Update(){

		updateMove ();
	}
		
	void OnTriggerEnter(Collider collider)
	{

		if (collider.tag.Equals("Rocket")) {
			print ("hit");
			var rocket = collider.GetComponent<Rocket> ();
			HP = HP - rocket.power;
		}

		if (HP <= 0) {
			GameManager.Instance.AddScore (1);

			Destroy (this.gameObject);
		}


	}

	public float speed = 1;
	public float rotSpeed = 30;
	public float timer = 1.5f;

	protected  void updateMove(){
		timer -= Time.deltaTime;

		if (timer <= 0) {
			timer = 3;
			rotSpeed = -rotSpeed;
		}

		m_transform.Rotate (Vector3.up, rotSpeed * Time.deltaTime, Space.World);
		m_transform.Translate (new Vector3 (0, 0, -speed * Time.deltaTime));
	
	}
		
}
