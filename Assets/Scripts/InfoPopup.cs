using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace FactorySimulator
{
    public class InfoPopup : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI header;
        [SerializeField] private TextMeshProUGUI data;
        [SerializeField] private Transform contentHolder;
        [SerializeField] private ContentEntry contentEntryPrefab;

        public void SetHeader(string txt)
        {
            header.text = txt;
        }

        public void SetData(string txt)
        {
            data.text = txt;
        }

        public void AddContent(Sprite icon, int count)
        {
            ContentEntry entryGO = Instantiate(contentEntryPrefab, contentHolder);
            entryGO.SetCount(count);
            entryGO.SetIcon(icon);
        }

        public void ClearContent()
        {
            foreach (Transform item in contentHolder)
            {
                Destroy(item.gameObject);
            }
        }
    }
}
