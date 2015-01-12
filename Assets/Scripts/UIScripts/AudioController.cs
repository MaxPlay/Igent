using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AudioController : MonoBehaviour {

    public Slider Master;
    public Slider SFX;
    public Slider Music;

	void Start () {
        Master.value = AudioSettings.Master;
        SFX.value = AudioSettings.SFX;
        Music.value = AudioSettings.SFX;
	}

    public void Refresh() {
        AudioSettings.Master = Master.value;
        AudioSettings.SFX = SFX.value;
        AudioSettings.Music = Music.value;
    }
}
