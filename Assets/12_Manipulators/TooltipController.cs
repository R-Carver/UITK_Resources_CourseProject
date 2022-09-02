using UnityEngine;
using UnityEngine.UIElements;

namespace Section_Manipulators
{
    public class TooltipController
    {
        public TooltipController(VisualElement root)
        {
            VisualElement tooltipElem1 = root.Q("Tooltip_1");
            VisualElement tooltipElem2 = root.Q("Tooltip_2");
            VisualElement tooltipElem3 = root.Q("Tooltip_3");
            VisualElement tooltipElem4 = root.Q("Tooltip_4");

            Tooltip reusableTooltip = new Tooltip();
            root.Add(reusableTooltip);

            tooltipElem1.AddManipulator(new TooltipManipulator(reusableTooltip));
            tooltipElem2.AddManipulator(new TooltipManipulator(reusableTooltip));
            tooltipElem3.AddManipulator(new TooltipManipulator(reusableTooltip));
            tooltipElem4.AddManipulator(new TooltipManipulator(reusableTooltip));
        }
    }
}