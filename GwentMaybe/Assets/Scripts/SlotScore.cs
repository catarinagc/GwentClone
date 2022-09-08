using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlotScore : MonoBehaviour
{
    public int score =0;
    public Text scoreText;
    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = score.ToString() + " POINTS";
    }

    // Update is called once per frame
    void Update()
    {
        DropZone d = gameObject.GetComponent<DropZone>();
        score= d.pointsTotal;
        scoreText.text = d.pointsTotal.ToString() + " POINTS";
    }
}
