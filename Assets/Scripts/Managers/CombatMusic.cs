using UnityEngine;
using System.Collections;
using UnityEngine.Audio;

public class CombatMusic : MonoBehaviour {

	public AudioMixerSnapshot outOfCombat;
	public AudioMixerSnapshot inCombat;
	public AudioClip[] stings;
	public AudioSource stingSource;
	public float bpm = 128;


	private float m_TransitionIn;
	private float m_TransitionOut;
	private float m_QuarterNote;


	void Start () 
	{
		m_QuarterNote = 60 / bpm;
		m_TransitionIn = m_QuarterNote;
		m_TransitionOut = m_QuarterNote * 32;


	}
	

	void OnTriggerEnter (Collider other)
	{
		if(other.CompareTag("Enemy"))
			{
				inCombat.TransitionTo(m_TransitionIn);
			}
	}

	void OnTriggerExit(Collider other)
	{
				if(other.CompareTag("Enemy"))
					{
						outOfCombat.TransitionTo(m_TransitionOut);
					}
	}
}
