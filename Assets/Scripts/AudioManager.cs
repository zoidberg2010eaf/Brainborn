using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

	public static AudioManager _Instance;

	public AudioClip[] _clipList;

	public AudioClip[] _musicList;

	private Dictionary<string, AudioClip> _audioDic = new Dictionary<string, AudioClip>();

	private Dictionary<string, AudioClip> _musicDic = new Dictionary<string, AudioClip>();

	public AudioSource _musicSource, _audioSource;



	private void Awake()
	{
		_Instance = this;
		LoadData();
		PlayMusic("main_music_noel");
	}

	private void LoadData()
    {
		for(int i =0; i < _clipList.Length; i++)
        {
			_audioDic.Add(_clipList[i].name, _clipList[i]);
        }

		for (int i = 0; i < _musicList.Length; i++)
		{
			_musicDic.Add(_musicList[i].name, _musicList[i]);
		}

		if(!PlayerPrefs.HasKey("Sound") ||! PlayerPrefs.HasKey("Music"))
        {
			PlayerPrefs.SetInt("Sound", 1);
			PlayerPrefs.SetInt("Music", 1);
		}

		if (PlayerPrefs.GetInt("Sound") == 0)
			_audioSource.volume = 0.0f;
		else
			_audioSource.volume = 1.0f;

		if (PlayerPrefs.GetInt("Music") == 0)
			_musicSource.volume = 0.0f;
		else
			_musicSource.volume = 1.0f;

	}

	public void PlaySound(string _soundFile)
    {
		_audioSource.PlayOneShot(_audioDic[_soundFile]);
    }

	public void PlayMusic(string _musicFile)
	{
		_musicSource.clip = _musicDic[_musicFile];
		_musicSource.Play();
	}
}
