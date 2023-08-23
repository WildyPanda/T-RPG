using UnityEngine;
using TRPG.Global.PlayerClasses;

namespace TRPG.FightConstructor
{
    public class PlayerEditorController : MonoBehaviour
    {
        private Transform input;
        private Transform inputElement;
        private Transform inputElementContent;

        private void Start()
        {
            input = transform.GetChild(1);
            inputElement = transform.GetChild(2);
            inputElementContent = inputElement.GetChild(0).GetChild(0).GetChild(0);

            initElements();
        }

        private void initElements()
        {

        }
    }
}
