using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConfirmPlayer : MonoBehaviour
{
    [SerializeField] private GameObject gameScreen;
    [SerializeField] private Text confirmText;
    private GameObject curPlayer;

    public void OnClick(){
        curPlayer = gameScreen.GetComponent<GameScreen>().getCurPlayer();
        curPlayer.GetComponent<Player>().BlockCards(true);
        this.gameObject.SetActive(false);
    }
}
