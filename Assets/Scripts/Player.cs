using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	private Transform m_transform;

	public AudioClip shotClip;

	public int HP = 10;

	protected AudioSource m_audio;
	// Use this for initialization
	void Start () {
		m_transform = this.transform;
		m_audio = this.GetComponent<AudioSource>();
	}
		
	public float m_speed = 10;

	public Transform m_rocket;

	private float m_rocketRate = 0;

	// Update is called once per frame
	void Update () {
		float movev = 0;

		float moveh = 0;

		if (Input.GetKey(KeyCode.UpArrow))
		{
			movev += m_speed * Time.deltaTime;
		}
		if (Input.GetKey(KeyCode.DownArrow))
		{
			movev -= m_speed * Time.deltaTime;
		}
		if (Input.GetKey(KeyCode.LeftArrow))
		{
			moveh -= m_speed * Time.deltaTime;
		}
		if (Input.GetKey(KeyCode.RightArrow))
		{
			moveh += m_speed * Time.deltaTime;
		}

		m_rocketRate -= Time.deltaTime;
		if (m_rocketRate <= 0) {

			m_rocketRate = 0.1f;

			if (Input.GetKey (KeyCode.Space)) {
				if (m_rocket != null) {
					Instantiate (m_rocket, m_transform.position, m_transform.rotation);
					m_audio.PlayOneShot (shotClip);
				}
			}
		
		}



		m_transform.Translate(new Vector3(moveh, 0, movev));
	}

	public Transform m_explosionFX;
	void OnTriggerEnter(Collider collider)
	{
		if (collider.tag.Equals ("Enemy") || collider.tag.Equals ("EnemyRocket")) {

			Instantiate (m_explosionFX, m_transform.position, Quaternion.identity);
			Destroy (this.gameObject);
		
		}
			
	}
}
