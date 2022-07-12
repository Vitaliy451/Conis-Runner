using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamePanelConrol : MonoBehaviour
{
    [SerializeField]
    private GameObject menuPanel;

    [SerializeField]
    private Animator menuPanelAnim;

    [SerializeField]
    private Button palyBtn;

    [SerializeField]
    private Button stngsBtn;


    public void OpenMenuPanel()
    {
        menuPanel.SetActive(true);
        menuPanelAnim.Play("SlideRight");
        StartCoroutine(EnableButtons());

    }
    public void CloseMenuPanel()
    {
        StartCoroutine(CloseSettings());
        palyBtn.interactable = false;
        stngsBtn.interactable = false;
    }
    IEnumerator CloseSettings()
    {
        menuPanelAnim.Play("SlideLeft");
        yield return new WaitForSeconds(1f);
        menuPanel.SetActive(false);
    }
    IEnumerator EnableButtons()
    {
        yield return new WaitForSeconds(1f);
        palyBtn.interactable = true;
        stngsBtn.interactable = true;
    }
}
