using UnityEngine;
using UnityEngine.UIElements;
using System.Collections.Generic;

namespace Section_SpecialControls
{   
    public class DropdownController
    {
        VisualElement root;

        Fraction currentFraction = null;

        public DropdownController(VisualElement root, List<Fraction> fractions)
        {
            this.root = root;

            VisualElement container = root.Q<VisualElement>("DropdownContainer");

            PopupField<Fraction> dropdown = new PopupField<Fraction>();

            dropdown.choices = fractions;
            dropdown.value = fractions[0];
            currentFraction = fractions[0];

            dropdown.formatListItemCallback = (elem) => elem.fractionName;
            dropdown.formatSelectedValueCallback = (elem) => elem.fractionName;

            dropdown.RegisterCallback<ChangeEvent<Fraction>>(OnFractionSelected);

            container.Add(dropdown);

            UpdateUI();

        }

        void OnFractionSelected(ChangeEvent<Fraction> evt)
        {
            Debug.Log("Fraction Selected");

            currentFraction = evt.newValue;
            UpdateUI();
        }

        void UpdateUI()
        {
            VisualElement characterElem = root.Q<VisualElement>("Character");
            Sprite charImg = Resources.Load<Sprite>(currentFraction.characterImgPath);
            characterElem.style.backgroundImage = new StyleBackground(charImg);

            Label fractionLabel = root.Q<Label>("FractionName");
            fractionLabel.text = currentFraction.fractionName;

            Label mottoLabel = root.Q<Label>("FractionMotto");
            mottoLabel.text = currentFraction.fractionMotto;

            VisualElement fractionImgElem = root.Q<VisualElement>("PanelFraction");
            Sprite fractionImg = Resources.Load<Sprite>(currentFraction.fractionImgPath);
            fractionImgElem.style.backgroundImage = new StyleBackground(fractionImg);
        }
    }
}