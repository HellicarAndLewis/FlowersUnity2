using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SliderController : MonoBehaviour {

    public Slider slider;
    public int cc;
    public bool audioConnected;

    public fftAnalyzer fft;

    public bool midiControlled;

    public int bin;

	// Use this for initialization
	void Start () {
        if (!slider)
            slider = GetComponentInChildren<Slider>();
        if (!fft)
            fft = FindObjectOfType<fftAnalyzer>();
        midiControlled = false;
	}
	
	// Update is called once per frame
	void Update () {
        if(audioConnected)
        {
            slider.value = fft.spectrumBinned[Mathf.Min(bin, fft.bins-1)];
        }
        //else if(!slider.interactable)
        else if(midiControlled)
        {
            float test = MidiJack.MidiMaster.GetKnob(cc, 0);
            slider.value = test;
        }
	}

    public void OnConnectedChanged(bool _val)
    {
        audioConnected = _val;
    }
}
