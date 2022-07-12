using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsPanelControl : MonoBehaviour
{
    [SerializeField]
    private GameObject menuPanel;

    [SerializeField]
    private Animator menuPanelAnim;

    [SerializeField]
    private Button backBtn;

    public void OpenMenuPanel()
    {
        menuPanel.SetActive(true);
        menuPanelAnim.Play("SlideRight");
        StartCoroutine(EnableButtons());

    }
    public void CloseMenuPanel()
    {
        StartCoroutine(CloseSettings());
        backBtn.interactable = false;
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
        backBtn.interactable = true;
    }
}
