using TMPro;
using UnityEngine;
using Unity.VisualScripting;

public class ShoppingState : BaseState
{
    public override void EnterState(GameObject Object)
    {
        Transform shopButtons = GameObject.FindObjectOfType(typeof(Canvas)).GameObject().gameObject.transform.Find("ShopButtonsGroup");
        if (shopButtons.CompareTag("ShopButtonsGroup"))
        {
            shopButtons.GameObject().SetActive(true);
        }
    }
    public override void UpdateState(GameObject Object)
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ExitState(Object);
            Object.GetComponent<RoundManager>().SwitchState(Object.GetComponent<RoundManager>().peacefulState);
        }
    }
    protected override void ExitState(GameObject Object)
    {
        Object.GetComponent<RoundManager>().shop.isAccessedByPlayer = false;
        Transform shopButtons = GameObject.FindObjectOfType(typeof(Canvas)).GameObject().gameObject.transform.Find("ShopButtonsGroup");
        if (shopButtons.CompareTag("ShopButtonsGroup"))
        {
            shopButtons.GameObject().SetActive(false);
        }
    }
}
