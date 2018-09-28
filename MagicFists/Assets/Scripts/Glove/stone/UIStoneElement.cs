using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIStoneElement : MonoBehaviour
{
    [SerializeField]
    private Image Icon;
    [SerializeField]
    private GameObject addBar;
    [SerializeField]
    private string name;
    public void UpdateElements(Sprite icon, Color c)
    {
        this.Icon.sprite = icon;
        this.Icon.color = c;
    }
    
    public void ActiveAddStonePanel(bool flag)
    {
        addBar.SetActive(flag);
    }
}
