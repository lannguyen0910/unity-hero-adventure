using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    public string destination;

    [SerializeField]
    GameObject player;
    [SerializeField]
    GameObject anim;

    bool ready = false;

    void Update()
    {
        if (!ready) return;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Start transition animation
            anim.SetActive(true);
            anim.GetComponent<StageTransitionController>().SetParameter(destination, player);          
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.isTrigger && collision.gameObject == player)
        {
            ready = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!collision.isTrigger && collision.gameObject == player)
        {
            ready = false;
        }
    }

    public void SetPlayer(GameObject player)
    {
        this.player = player;
    }
}
