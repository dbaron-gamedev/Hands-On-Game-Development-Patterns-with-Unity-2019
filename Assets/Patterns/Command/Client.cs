using UnityEngine;

namespace Pattern.Command_
{
    public class Client : MonoBehaviour
    {
        private RemoteControlDevice m_RadioReceiver;
        private RemoteControlDevice m_TelevisionReceiver;
        private RemoteControlDevice[] m_Devices = new RemoteControlDevice[2];

        void Start()
        {
            m_RadioReceiver = new RadioReceiver();
            m_TelevisionReceiver = new TelevisionReceiver();

            m_Devices[0] = m_RadioReceiver;
            m_Devices[1] = m_TelevisionReceiver;
        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.O))
            {
                Command commandTV = new TurnOnCommand(m_Devices[0]);
                Command commandRadio = new TurnOnCommand(m_Devices[1]);

                Invoker invoker = new Invoker();

                invoker.SetCommand(commandTV);
                invoker.ExecuteCommand();

                invoker.SetCommand(commandRadio);
                invoker.ExecuteCommand();
            }

            if (Input.GetKeyDown(KeyCode.K))
            {
                Command commandKill = new KillSwitchCommand(m_Devices);
                Invoker invoker = new Invoker();
                invoker.SetCommand(commandKill);
                invoker.ExecuteCommand();
            }
        }

        void OnGUI()
        {
            GUI.color = Color.black;
            GUI.Label(new Rect(10, 10, 500, 20), "Press F1 to start/stop recording.");
            GUI.Label(new Rect(10, 30, 500, 20), "Press F2 to start/stop playback.");
        }
    }
}
