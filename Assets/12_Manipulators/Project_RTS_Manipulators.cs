using UnityEngine.UIElements;
using System.Collections.Generic;
using UnityEngine;
using Section_SpecialControls;

namespace Section_Manipulators
{
    public class Project_RTS_Manipulators : MonoBehaviour
    {
        public List<Fraction> fractions;
        public List<ListItem> listItems;

        VisualElement root;

        private void OnEnable()
        {
            root = GetComponent<UIDocument>().rootVisualElement;

            InitializeBadges();

            new DropdownController(root, fractions);
            new ListController(root, listItems);
            new TooltipController(root);
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

