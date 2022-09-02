using UnityEngine.UIElements;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace Section_SpecialControls
{
    public class ListController
    {
        VisualElement root;
        ListView list;

        List<ListItem> listItems;

        ListItem chosenItem;

        public ListController(VisualElement root, List<ListItem> items)
        {
            this.root = root;
            this.listItems = items;

            createList();
        }

        private void createList()
        {
            list = root.Q<ListView>("List");
            VisualTreeAsset listItemAsset = Resources.Load<VisualTreeAsset>("ListItem");

            list.makeItem = () => listItemAsset.Instantiate();
            list.bindItem = (ve, i) =>
            {
                VisualElement fractionIcon = ve.Q<VisualElement>("FractionIcon");
                Label someName = ve.Q<Label>("ListItemName");
                Label score = ve.Q<Label>("Score");
                VisualElement uselessIcon = ve.Q<VisualElement>("OtherIcon");
                Label reward = ve.Q<Label>("Reward");

                ListItem currentItem = listItems[i];

                Sprite iconImg = Resources.Load<Sprite>("img/" + currentItem.itemIconPath);
                fractionIcon.style.backgroundImage = new StyleBackground(iconImg);

                someName.text = currentItem.itemName;
                score.text = currentItem.score;

                Sprite iconImg2 = Resources.Load<Sprite>("img/" + currentItem.itemIconPath2);
                uselessIcon.style.backgroundImage = new StyleBackground(iconImg2);

                reward.text = "Reward: " + currentItem.reward;
            };

            list.itemsSource = listItems;
            list.fixedItemHeight = 40;

            list.onSelectionChange += (elem) => OnSelectionChanged(elem);
        }

        private void OnSelectionChanged(IEnumerable<object> elem)
        {
            chosenItem = elem.First() as ListItem;
            UpdateDetails();
        }

        void UpdateDetails()
        {
            VisualElement detail_img = root.Q<VisualElement>("DetailImg");
            Sprite iconImg = Resources.Load<Sprite>("img/" + chosenItem.itemIconPath);
            detail_img.style.backgroundImage = new StyleBackground(iconImg);

            Label fraction_label = root.Q<Label>("DetailName");
            fraction_label.text = chosenItem.itemName;

            Label fraction_score = root.Q<Label>("DetailsScore");
            fraction_score.text = "Score: " + chosenItem.score;

            VisualElement score_img = root.Q<VisualElement>("DetailsScoreImg");
            Sprite score_sprite = Resources.Load<Sprite>("img/" + chosenItem.itemIconPath2);
            score_img.style.backgroundImage = new StyleBackground(score_sprite);

            Label reward_label = root.Q<Label>("DetailsReward");
            reward_label.text = "Reward: " + chosenItem.reward;
        }
    }
}

