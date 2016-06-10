using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public static GameManager Instance;

	public int Score = 0;
	public  static int HistoryScore = 0;

	protected Player m_player;

	public AudioClip m_musicClip;

	protected AudioSource m_audio;

	void Awake()
	{
		Instance = this;
	}

	// Use this for initialization
	void Start () {
		m_audio = this.GetComponent<AudioSource>();
		GameObject obj = GameObject.FindGameObjectWithTag ("Player");
		if (obj!=null) {
			m_player = obj.GetComponent<Player> ();
		}
	
	}
	
	// Update is called once per frame
	void Update () {
		if (!m_audio.isPlaying) {
			m_audio.clip = m_musicClip;
			m_audio.Play ();
		}

		if (Time.timeScale > 0 && Input.GetKeyDown (KeyCode.Escape)) {
			Time.timeScale = 0;
		
		}
	}

	void OnGUI()
	{
		if (Time.timeScale == 0) {
		
			if (GUI.Button (new Rect (Screen.width * 0.5f - 50, Screen.height * 0.4f, 100, 30), "繼續遊戲")) {
				Time.timeScale = 1;
			}
			if (GUI.Button (new Rect (Screen.width * 0.5f - 50, Screen.height * 0.6f, 100, 30), "離開遊戲")) {
				Application.Quit ();
			}
		
		}

		int life = 0;
		if (m_player==null || m_player.HP <=0) {
			GUI.skin.label.fontSize = 50;
			GUI.skin.label.alignment = TextAnchor.LowerCenter;
			GUI.Label (new Rect (0, Screen.height * 0.2f, Screen.width, 60), "遊戲失敗");


			GUI.skin.label.fontSize = 20;

			if (GUI.Button (new Rect (Screen.width * 0.5f - 50, Screen.height * 0.5f, 100, 30), "再試一次")) {
				Application.LoadLevel (Application.loadedLevelName);
			
			}

		}


		GUI.skin.label.fontSize = 15;

		GUI.Label (new Rect (5, 5, 100, 30), "HP : " + life);

		GUI.skin.label.alignment = TextAnchor.LowerCenter;
		GUI.Label (new Rect (0, 5, Screen.width, 30), "紀錄 :" + HistoryScore);

		GUI.Label (new Rect (0, 25, Screen.width, 30), "分數 :" + Score);


	}

	public void AddScore(int point)
	{
		Score += point;

		if (HistoryScore <= Score)
			HistoryScore = Score;
	}
}
