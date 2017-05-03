using UnityEngine;

//-----------------------------------------------------------------------------
// Copyright 2015-2016 RenderHeads Ltd.  All rights reserverd.
//-----------------------------------------------------------------------------

namespace RenderHeads.Media.AVProVideo
{
	/// <summary>
	/// This is an experimental feature and only works in Windows currently
	/// To use, add this component to a gameObject, then add a Unity AudioSource component below that
	/// Currently doesn't handle seeking properly
	/// </summary>
	[AddComponentMenu("AVPro Video/Audio Output", 400)]
	public class AudioOutput : MonoBehaviour
	{
		public MediaPlayer _mediaPlayer;

#if UNITY_STANDALONE_WIN || UNITY_EDITOR_WIN || UNITY_WSA_10_0 || UNITY_WINRT_8_1
		void OnAudioFilterRead(float[] data, int channels)
		{
			//Debug.Log("generate " + channels + " " + data.Length);
			_mediaPlayer.Control.GrabAudio(data, data.Length, channels);
		}
#endif
	}
}