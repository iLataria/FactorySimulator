using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FactorySimulator
{
    public class UIController : MonoBehaviour
    {
        public static UIController Instance;

        [SerializeField] private ResourceDB resourceDB;
        [SerializeField] private InfoPopup popup;

        private IUIContent currentUIContent;
        private List<Building.Resource> resourceBuffer;

        private void Awake()
        {
            Instance = this;
            resourceBuffer = new List<Building.Resource>();
            resourceDB.Init();
        }

        private void Update()
        {
            if (currentUIContent == null)
                return;

            resourceBuffer.Clear();
            popup.ClearContent();
            currentUIContent.GetContent(ref resourceBuffer);

            foreach (var item in resourceBuffer)
            {
                Sprite icon = resourceDB?.GetItem(item.Id)?.Icon;
                popup.AddContent(icon, item.Amount);
            }
        }

        public void SetCurrentContent(IUIContent content)
        {
            currentUIContent = content;
            if (content == null)
            {
                popup.gameObject.SetActive(false);
            }
            else
            {
                popup.gameObject.SetActive(true);
                popup.SetData(content.GetData());
                popup.SetHeader(content.GetName());
            }
        }
    }
}

