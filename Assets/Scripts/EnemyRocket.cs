using UnityEngine;
using System.Collections;

public class EnemyRocket : MonoBehaviour {

	private Transform m_transform;

	// Use this for initialization
	void Start () {
		m_transform = this.transform;
	}


	public float liveTime=1;
	public float speed = 10;
	public int power = 10;

	// Update is called once per frame
	void Update () {
		liveTime -= Time.deltaTime;

		if (liveTime <= 0)
			Destroy (this.gameObject);

		m_transform.Translate(new Vector3(0,0,-speed*Time.deltaTime));
	}

	void OnTriggerEnter(Collider collider)
	{
		if (collider.tag.Equals("Player"))
			Destroy (this.gameObject);
	}
}

