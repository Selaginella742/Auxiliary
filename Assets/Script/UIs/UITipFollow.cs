using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UITipFollow : MonoBehaviour
{
    public GameObject UITemplate;
    public Sprite displayImage;

    GameObject canvas;
    GameObject UITipIns;
    RectTransform uiPos;
    Image InsImage;

    void Start()
    {
        //instantiate UI on the canvas
        canvas = GameObject.Find("ItemDropCanvas");
        UITipIns = Instantiate(UITemplate, canvas.transform);
        uiPos = UITipIns.GetComponent<RectTransform>();
        UITipIns.SetActive(false);

        //initalize the position of the ui panel
        var displayPos = Camera.main.WorldToScreenPoint(transform.position);
        displayPos.y += 200;
        uiPos.position = displayPos;

        InsImage = UITipIns.GetComponent<Image>();

        this.gameObject.GetComponent<TreasureBox>().UITip = UITipIns;

        if (displayImage != null)
        {
            InsImage.sprite = displayImage;
        }
    }

    void Update()
    {
        //update UI's position to follow the item
        var displayPos = Camera.main.WorldToScreenPoint(transform.position);
        displayPos.y += 200;
        uiPos.position = displayPos;
    }

    /**
     * display when the player enter the trigger
     */
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            UITipIns.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            UITipIns.SetActive(false);
        }
    }
}
