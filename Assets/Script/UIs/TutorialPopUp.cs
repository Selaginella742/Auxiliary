using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;

[RequireComponent(typeof(BoxCollider))]
public class TutorialPopUp : MonoBehaviour
{
    public GameObject tutorialPop;
    [Tooltip("put the text that this tutorial shows")]
    [TextArea]public string text;

    PlayableDirector pd;
    Text popText;

    private void Start()
    {
        pd = tutorialPop.GetComponent<PlayableDirector>();
        popText = tutorialPop.GetComponentInChildren<Text>();
    }

    /**
     * if the player enter, show the infomation pop up
     */
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player") 
        {
            pd.Stop();
            popText.text = text;
            pd.Play();
        }
    }

    /**
     * if the player finishs watching information, destroy the collider object
     * so that the player won't repeatly trigger tutorial
     */
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            Destroy(this.gameObject);
        }
    }
}
