using UnityEngine;

namespace Events
{
    public class EventTester : MonoBehaviour
    {
        public void MouseEventTest()
        {
            Debug.Log("Clicked left button");
        }
        
        public void TestIntEvent(int value)
        {
            Debug.Log(value);
        }
    }
}