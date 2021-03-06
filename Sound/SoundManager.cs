﻿using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]


public class SoundManager : CacheBehaviour
{
	public AudioClip collectPrize;

	void Start()
	{
		base.CacheComponents();
	}

	// EVENT LISTENERS
	void OnEnable()
	{
		Messenger.AddListener<int>( "prize collected", OnPrizeCollected );
	}

	void OnDestroy()
	{
		Messenger.RemoveListener<int>( "prize collected", OnPrizeCollected );
	}

	// EVENT RESPONDERS
	void OnPrizeCollected(int worth)
	{
		audio.PlayOneShot(collectPrize, 0.1F);
	}

}
