using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TRPG.Other
{
    public class DestroyButton : MonoBehaviour
    {
        public void DestroyGameObject(GameObject go)
        {
            Destroy(go);
        }
    }
}

