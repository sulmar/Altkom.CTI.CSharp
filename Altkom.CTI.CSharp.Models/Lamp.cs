using Stateless;
using Stateless.Graph;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Altkom.CTI.CSharp.Models
{
    public class Lamp
    {
        public LampState State { get; set; }

        private StateMachine<LampState, Trigger> machine;

        public Lamp()
        {
            machine = new StateMachine<LampState, Trigger>(LampState.Off);

            machine.Configure(LampState.Off)
                .Permit(Trigger.Start, LampState.On);

            machine.Configure(LampState.On)
                .Permit(Trigger.Stop, LampState.Off)
                .Permit(Trigger.Start, LampState.Blink)
                .OnEntry(() => Trace.WriteLine("Tweet"))
                .OnExit(() => Trace.WriteLine("THX"));

            machine.Configure(LampState.Blink)
               // .Permit(Trigger.Start, LampState.On)
                .Permit(Trigger.Stop, LampState.Off);


            string graph = UmlDotGraph.Format(machine.GetInfo());

            Trace.WriteLine(graph);

        }

        

        public void SwitchOn()
        {
            machine.Fire(Trigger.Start);
        }


        public void SwitchOff()
        {
            machine.Fire(Trigger.Stop);
        }

        public LampState LampState
        {
            get
            {
                return machine.State;
            }
        }

    }

    public enum Trigger
    {
        Start,
        Stop
    }

    public enum LampState
    {
        Off,
        On,
        Blink
    }

}
