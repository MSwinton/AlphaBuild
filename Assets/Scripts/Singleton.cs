/*
 * Source:
 * http://answers.unity3d.com/questions/11314/audio-or-music-to-continue-playing-between-scene-c.html?page=2&pageSize=5&sort=oldest
 * */

using UnityEngine;
using System.Collections;

public class Singleton : MonoBehaviour {
	
	private static Singleton instance = null;
	
	public static Singleton Instance {
		get { return instance; }
	}
	
	void Awake() 
	{
		if (instance != null && instance != this) 
		{
			audio.Stop();
			if(instance.audio.clip != audio.clip)
			{
				instance.audio.clip = audio.clip;
				instance.audio.volume = audio.volume;
				instance.audio.Play();
			}
			
			Destroy(this.gameObject);
			return;
		} 
		instance = this;
		audio.Play ();
		DontDestroyOnLoad(this.gameObject);
	}
}