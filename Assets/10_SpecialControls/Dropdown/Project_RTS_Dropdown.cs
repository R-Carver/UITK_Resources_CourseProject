using UnityEngine;
using UnityEngine.UIElements;
using System.Collections.Generic;

namespace Section_SpecialControls
{
    public class Project_RTS_Dropdown : MonoBehaviour
    {
        public List<Fraction> fractions;

        VisualElement root;

        private void OnEnable()
        {
            root = GetComponent<UIDocument>().rootVisualElement;

            InitializeBadges();

            new DropdownController(root, fractions);
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

