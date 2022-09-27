using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneController : MonoBehaviour
{
    public GameObject player, mainCamera, timerCanvas, cutsceneCamera;
    public Animator anim;
    void Start()
    {

    }

    void Update()
    {
        if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1)
        {
            timerCanvas.gameObject.SetActive(true);
            mainCamera.gameObject.SetActive(true);
            player.GetComponent<PlayerController>().enabled = true;
            cutsceneCamera.gameObject.SetActive(false);
        }
    }
}
