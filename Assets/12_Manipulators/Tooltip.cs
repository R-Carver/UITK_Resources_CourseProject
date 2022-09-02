using UnityEngine.UIElements;
using UnityEngine;

namespace Section_Manipulators
{
    public class Tooltip : VisualElement
    {
        Label label;

        public new class UxmlFactory : UxmlFactory<Tooltip> { }

        private const string styleResource = "StyleSheet_Tooltip";
        private const string ussElem = "tooltip";
        private const string ussLabel = "tooltip_text";

        public Tooltip()
        {
            styleSheets.Add(Resources.Load<StyleSheet>(styleResource));
            AddToClassList(ussElem);

            label = new Label();
            label.text = "Nice Tooltip!";
            label.AddToClassList(ussLabel);
            hierarchy.Add(label);

            style.position = Position.Absolute;
            pickingMode = PickingMode.Ignore;

            style.visibility = Visibility.Hidden;
        }

        public void Show(VisualElement target, Vector2 localMousePos)
        {
            style.visibility = Visibility.Visible;

            label.text = target.tooltip;

            style.left = target.worldBound.xMin + localMousePos.x;
            style.top = target.worldBound.yMin + localMousePos.y - 50;
        }

        public void Hide()
        {
            style.visibility = Visibility.Hidden;
        }




    }
}


