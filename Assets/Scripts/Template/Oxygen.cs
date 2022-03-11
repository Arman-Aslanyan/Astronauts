using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Oxygen : MonoBehaviour
{
    public int _Oxygen = 80;
    public Slider slider;
    private bool playingAud;
    public RandomContainer oxyAudioSource;

    public float time;
    // Start is called before the first frame update
    void Start()
    {
        slider.maxValue = _Oxygen;
        slider.value = _Oxygen;
    }

    // Update is called once per frame
    void Update()
    {
        if (_Oxygen < 0) PlayerDeath();
        else if(time >= 1f)
        {
            _Oxygen--;
            SetOxygen();
            time = 0;
            if (_Oxygen <= Mathf.RoundToInt(slider.maxValue * 0.3f) - 1 && !playingAud)
            {
                playingAud = true;
                oxyAudioSource.PlayLowOxyClips();
                oxyAudioSource.PlaySound(true);
                StartCoroutine(WaitToReEnable());
            }
        }
        else
        {
            time += Time.deltaTime;
        }
    }

    public void SetOxygen()
    {
        if (slider.value > 0 && slider.value <= slider.maxValue)
            slider.value -= 1;
    }

    public void PlayerDeath()
    {
        SceneManager.LoadScene("EndScene");
    }

    public IEnumerator WaitToReEnable()
    {
        yield return new WaitForSeconds(oxyAudioSource.oxyClips[0].length);
        playingAud = false;
    }
}
