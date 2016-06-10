using UnityEngine;
using System.Collections;

public class SuperEnemy : MonoBehaviour {

	public int HP = 30;
	protected Transform m_transform;

	void Start()
	{
		m_transform = this.transform;
		HP = 30;

	}

	void Update(){

		updateMove ();
	}
		

	void OnTriggerEnter(Collider collider)
	{

		print (HP);
		if (collider.tag.Equals("Rocket")) {
			print (HP);
			var rocket = collider.GetComponent<Rocket> ();
			HP = HP - rocket.power;
		}

		if (HP <= 0) {
			GameManager.Instance.AddScore (10);

			Instantiate (m_explosionFX, m_transform.position, Quaternion.identity);
			Destroy (this.gameObject);
		}


	}
		

	public float speed = 1;

	public Transform m_rocket;

	public float rocketdelaytime = 5;

	public Transform m_explosionFX;

	protected  void updateMove(){
		m_transform.Translate (new Vector3 (0, 0, -speed * Time.deltaTime));

		rocketdelaytime -= Time.deltaTime;

		if (rocketdelaytime <= 0) {
			rocketdelaytime = 5;

			print (m_transform.rotation);



			Instantiate (m_rocket,m_transform.position,m_transform.rotation);
		
		}


	}


}

