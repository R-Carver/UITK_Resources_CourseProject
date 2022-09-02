using UnityEngine;
using UnityEngine.UIElements;

namespace Section_Query
{
    public class Project_RTS_Query : MonoBehaviour
    {
        VisualElement root;

        private void OnEnable()
        {
            root = GetComponent<UIDocument>().rootVisualElement;

            InitializeBadges();
        }

        void InitializeBadges()
        {
            string[] romanNum = { "I", "II", "III", "IV", "V", "VI" };

            int index = 0;

            root.Query("PanelBadges")
                .Descendents<VisualElement>()
                .Name("LabelLevel")
                .ForEach(elem => (elem as Label).text = romanNum[index++]);
        }
    }
}


