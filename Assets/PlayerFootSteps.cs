using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFootSteps : MonoBehaviour
{
    public void PlayFootsteps()
    {
        AudioManager.Instance.PlayAudio(AudioType.PLAYERFOOTSTEP);
    }
}
