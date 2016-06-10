using UnityEngine;
using System.Collections;

public class EnemySpawn : MonoBehaviour {


	private Transform m_transform;

	public Transform m_enemy;
	// Use this for initialization
	void Start () {
		m_transform = this.transform;
	}


	public float spawnTime = 5;
	// Update is called once per frame
	void Update () {
	
		spawnTime -= Time.deltaTime;

		if (spawnTime <= 0) {
			spawnTime = 5;
			if(m_enemy!=null)
				Instantiate (m_enemy, m_transform.position, Quaternion.identity);
		}

	}

	void OnDrawGizmos()
	{
		Gizmos.DrawIcon (this.transform.position, "item.png", true);

	}
}
