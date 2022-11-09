using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FactorySimulator
{
    public class UIController : MonoBehaviour
    {
        public static UIController Instance;
        public ResourceDB resourceDB;
        private IUIContent currentUIContent;
        [SerializeField] private InfoPopup popup;

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
                Sprite icon = null;
                icon = resourceDB?.GetItem(item.Id)?.Icon;

                //set item icon to popup
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

