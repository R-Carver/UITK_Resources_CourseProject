using UnityEngine.UIElements;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;

namespace Section_CustomControls
{
    public class StarControl : VisualElement
    {
        public new class UxmlFactory : UxmlFactory<StarControl, UxmlTraits> { }

        public new class UxmlTraits : VisualElement.UxmlTraits
        {
            UxmlIntAttributeDescription starAttribute = new UxmlIntAttributeDescription()
            {
                name = "stars"
            };

            public override void Init(VisualElement ve, IUxmlAttributes bag, CreationContext cc)
            {
                base.Init(ve, bag, cc);

                (ve as StarControl).Stars = starAttribute.GetValueFromBag(bag, cc);
            }
        }

        private const string styleResource = "Stylesheet_StarControl";
        private const string ussContainer = "container";
        private const string ussOuterStar = "outerStar";
        private const string ussInnerStar = "innerStar";

        List<VisualElement> outerStars = new List<VisualElement>();
        List<VisualElement> innerStars = new List<VisualElement>();

        int stars;
        public int Stars
        {
            get => stars;
            set
            {
                stars = value;
                SetStars();
            }
        }

        public StarControl()
        {
            styleSheets.Add(Resources.Load<StyleSheet>(styleResource));

            VisualElement container = new VisualElement();
            hierarchy.Add(container);
            container.AddToClassList(ussContainer);

            for (int i=0; i<7; i++)
            {
                VisualElement outerStarTemp = new VisualElement();
                outerStarTemp.name = "outerStar";
                container.Add(outerStarTemp);
                outerStarTemp.AddToClassList(ussOuterStar);

                outerStars.Add(outerStarTemp);

                VisualElement innerStarTemp = new VisualElement();
                innerStarTemp.name = "innerStar";
                outerStarTemp.Add(innerStarTemp);
                innerStarTemp.AddToClassList(ussInnerStar);

                innerStars.Add(innerStarTemp);


            }

            Stars = 0;
        }

        void SetStars()
        {
            HideAllStars();
            innerStars
                .Take(stars)
                .ToList()
                .ForEach((elem) => elem.style.visibility = Visibility.Visible);
        }

        void HideAllStars()
        {
            innerStars.ForEach((elem) => elem.style.visibility = Visibility.Hidden);
        }
    }
}


