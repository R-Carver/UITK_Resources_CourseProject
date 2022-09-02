using UnityEngine.UIElements;
using UnityEngine;

namespace Section_Manipulators
{
    public class TooltipManipulator : PointerManipulator
    {
        private Tooltip tooltip;

        public TooltipManipulator(Tooltip tooltip)
        {
            this.tooltip = tooltip;
        }

        protected override void RegisterCallbacksOnTarget()
        {
            target.RegisterCallback<PointerEnterEvent>(OnPointerEnter);
            target.RegisterCallback<PointerLeaveEvent>(OnPointerLeave);
        }

        protected override void UnregisterCallbacksFromTarget()
        {
            target.UnregisterCallback<PointerEnterEvent>(OnPointerEnter);
            target.UnregisterCallback<PointerLeaveEvent>(OnPointerLeave);
        }

        void OnPointerEnter(PointerEnterEvent e)
        {
            tooltip.Show(target, e.localPosition);
        }

        void OnPointerLeave(PointerLeaveEvent e)
        {
            tooltip.Hide();
        }
    }
}