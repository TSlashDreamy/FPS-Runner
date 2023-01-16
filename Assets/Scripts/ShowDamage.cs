using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowDamage : MonoBehaviour
{
    [SerializeField] Canvas damageCanvas;
    [SerializeField] float showTime = 3f;
    [SerializeField] float showLerpTime = 1f;
    [SerializeField] float hideLerpTime = 1.5f;
    Vector3 borderShow = new Vector3(1, 1, 1);
    Vector3 borderHide = new Vector3(1.1f, 1.1f, 1.1f);

    // Start is called before the first frame update
    void Start()
    {
        damageCanvas.enabled = false;
    }

    public void ShowDamageImpact()
    {
        StartCoroutine(ShowSplatter());
    }

    IEnumerator ShowSplatter()
    {
        damageCanvas.enabled = true;
        yield return new WaitForSeconds(showTime);
        damageCanvas.enabled = false;
    }
}
