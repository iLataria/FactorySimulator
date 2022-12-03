using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class MainUI : MonoBehaviour
{
    [SerializeField] private Color[] unitColors;
    [SerializeField] private Button btnPrefab;
    [SerializeField] private RectTransform colorsPanel;

    private List<Button> colorBtns;
    private Action<Color> colorChanged;

    private void Awake()
    {
        colorBtns = new List<Button>();
    }

    private void Init()
    {
        foreach (var color in unitColors)
        {
            Button btn = Instantiate(btnPrefab, colorsPanel);
            btn.GetComponent<Image>().color = color;
            btn.onClick.AddListener(()=> {
                foreach (var item in colorBtns)
                {
                    item.interactable = true;
                }

                btn.interactable = false;
                colorChanged?.Invoke(color);
            });

            colorBtns.Add(btn);
        }
    }

    private void Start()
    {
        Init();
        SetColor(unitColors[2]);
    }

    public void SetColor(Color color)
    {
        for(int i = 0; i < unitColors.Length; i++)
        {
            if (unitColors[i] == color)
            {
                colorBtns[i].onClick.Invoke();
            }
        }
    }
}
