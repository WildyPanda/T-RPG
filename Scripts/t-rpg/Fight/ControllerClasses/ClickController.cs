using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

namespace TRPG.Fight.ControllerClasses
{
    internal class ClickController : MonoBehaviour, IPointerClickHandler
    {
        private FightController fightController;

        public void init(FightController fightController)
        {
            this.fightController = fightController;
        }


        public void OnPointerClick(PointerEventData eventData)
        {
            if(fightController != null)
            {
                fightController.click(eventData.pointerCurrentRaycast.gameObject, eventData.pointerCurrentRaycast.worldPosition);
            }
        }
    }
}
