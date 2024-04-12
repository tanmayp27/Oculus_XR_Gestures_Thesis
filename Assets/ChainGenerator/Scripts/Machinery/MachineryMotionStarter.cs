using UnityEngine;
using UnityEngine.Events;

namespace Chain
{
    public class MachineryMotionStarter : MonoBehaviour
    {
        public UnityEvent motionEvent;
        void Start()
        {
            motionEvent.Invoke();
        }
    }

}
