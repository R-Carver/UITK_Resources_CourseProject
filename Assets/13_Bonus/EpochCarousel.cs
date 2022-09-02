using UnityEngine.UIElements;
using UnityEngine;
using System.Collections.Generic;

namespace Section_Bonus
{
    public class EpochCarousel : VisualElement
    {
        public new class UxmlFactory : UxmlFactory<EpochCarousel> { }

        public string[] textEntries = {
            "Neolithic",
            "Ancient",
            "Classical",
            "Medieval",
            "Early Modern",
            "Industrial",
            "Contemporary"
        };

        private const string styleResource = "StyleSheet_EpochCarousel";
        private const string ussCarouselContainer = "carouselContainer";
        private const string ussMainContainer = "mainContainer";
        private const string ussScrollView = "scrollView";
        private const string ussScrollContainer = "scrollContainer";
        private const string ussScrollText = "scrollText";
        private const string ussEpochLabel = "epochLabel";
        private const string ussButton = "button";
        private const string ussButtonRight = "buttonRight";
        private const string ussBulletContainer = "bulletContainer";
        private const string ussOuterBullet = "outerBullet";
        private const string ussActiveBullet = "activeBullet";

        private ScrollView scrollView;

        private int currentContentIndex;

        private int CurrentContentIndex
        {
            get => currentContentIndex;
            set
            {
                if (value >= 0 && value < currentContent.Count)
                {
                    currentContentIndex = value;
                }
            }
        }

        private Label priorEpochLabel;
        private Label nextEpochLabel;

        private VisualElement bulletContainer;

        private List<VisualElement> currentContent = new List<VisualElement>();
        private List<VisualElement> activeBullets = new List<VisualElement>();

        public EpochCarousel()
        {
            styleSheets.Add(Resources.Load<StyleSheet>(styleResource));
            AddToClassList(ussMainContainer);

            VisualElement carouselContainer = new VisualElement();
            carouselContainer.AddToClassList(ussCarouselContainer);
            hierarchy.Add(carouselContainer);

            bulletContainer = new VisualElement();
            bulletContainer.AddToClassList(ussBulletContainer);
            hierarchy.Add(bulletContainer);

            scrollView = new ScrollView(ScrollViewMode.Horizontal);
            scrollView.AddToClassList(ussScrollView);
            scrollView.contentContainer.parent.AddToClassList(ussScrollContainer);
            scrollView.horizontalScrollerVisibility = ScrollerVisibility.Hidden;

            Button leftButton = new Button();
            Button rightButton = new Button();
            leftButton.AddToClassList(ussButton);
            rightButton.AddToClassList(ussButton);
            rightButton.AddToClassList(ussButtonRight);

            leftButton.clicked += () => OnLeftClicked();
            rightButton.clicked += () => OnRightClicked();

            priorEpochLabel = new Label();
            nextEpochLabel = new Label();
            priorEpochLabel.AddToClassList(ussEpochLabel);
            nextEpochLabel.AddToClassList(ussEpochLabel);

            carouselContainer.Add(priorEpochLabel);
            carouselContainer.Add(leftButton);
            carouselContainer.Add(scrollView);
            carouselContainer.Add(rightButton);
            carouselContainer.Add(nextEpochLabel);

            InitializeContent();
            UpdateTextLabels();
            UpdateBullets();
            currentContent = (List<VisualElement>)scrollView.Children();

            currentContentIndex = 0;
        }

        private void InitializeContent()
        {
            foreach (string entry in textEntries)
            {
                Label newLabel = new Label(entry);
                newLabel.AddToClassList(ussScrollText);
                scrollView.Add(newLabel);

                // bullets
                VisualElement newBullet = new VisualElement();
                newBullet.AddToClassList(ussOuterBullet);
                bulletContainer.Add(newBullet);

                VisualElement newInnerBullet = new VisualElement();
                newInnerBullet.AddToClassList(ussActiveBullet);
                newBullet.Add(newInnerBullet);

                activeBullets.Add(newInnerBullet);
            }
        }

        private void UpdateBullets()
        {
            activeBullets.ForEach((elem) => elem.style.visibility = Visibility.Hidden);
            activeBullets[currentContentIndex].style.visibility = Visibility.Visible;
        }

        void OnLeftClicked()
        {
            CurrentContentIndex--;
            scrollView.ScrollTo(currentContent[CurrentContentIndex]);
            UpdateTextLabels();
            UpdateBullets();
        }

        void OnRightClicked()
        {
            CurrentContentIndex++;
            scrollView.ScrollTo(currentContent[CurrentContentIndex]);
            UpdateTextLabels();
            UpdateBullets();
        }

        private void UpdateTextLabels()
        {
            if (currentContentIndex > 0)
            {
                priorEpochLabel.text = textEntries[currentContentIndex - 1];
            }
            else
            {
                priorEpochLabel.text = "";
            }

            if (currentContentIndex < textEntries.Length - 1)
            {
                nextEpochLabel.text = textEntries[currentContentIndex + 1];
            }
            else
            {
                nextEpochLabel.text = "";
            }
        }
    }
}


