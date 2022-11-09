using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ContentEntry : MonoBehaviour
{
    [SerializeField] private Image icon;
    [SerializeField] private TextMeshProUGUI count;

    public void SetIcon(Sprite icon)
    {
        this.icon.sprite = icon;
    }

    public void SetCount(int count)
    {
        this.count.text = count.ToString();
    }
}
