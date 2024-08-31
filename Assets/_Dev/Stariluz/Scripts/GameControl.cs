using System;
using UnityEngine;
namespace Stariluz.GameControl
{
    [Serializable]
    public abstract class MultiplatformBehaviour<T>
    {
        public delegate T GetBehaviourFunction();
        public GetBehaviourFunction GetBehaviourValue;
        public abstract T PCBehaviour();
        public abstract T TouchMobileBehaviour();
        public MultiplatformBehaviour()
        {
            SetBehaviourToExecute(ControlsEnum.PC);
        }
        public MultiplatformBehaviour(ControlsEnum controlsEnum)
        {
            SetBehaviourToExecute(controlsEnum);
        }
        public virtual void SetBehaviourToExecute(ControlsEnum controlsEnum)
        {
            switch (controlsEnum)
            {
                case ControlsEnum.PC:
                    {
                        GetBehaviourValue = PCBehaviour;
                        break;
                    }
                case ControlsEnum.Touch:
                    {
                        GetBehaviourValue = TouchMobileBehaviour;
                        break;
                    }
            }
        }
    }
    [Serializable]
    public abstract class MultiplatformBehaviour
    {
        public delegate void ControlBehaviour();
        public ControlBehaviour GetBehaviourValue;
        public abstract void PCBehaviour();
        public abstract void TouchMobileBehaviour();
        public MultiplatformBehaviour()
        {
            SetBehaviourToExecute(ControlsEnum.PC);
        }
        public MultiplatformBehaviour(ControlsEnum controlsEnum)
        {
            SetBehaviourToExecute(controlsEnum);
        }
        public virtual void SetBehaviourToExecute(ControlsEnum controlsEnum)
        {
            switch (controlsEnum)
            {
                case ControlsEnum.PC:
                    {
                        GetBehaviourValue = PCBehaviour;
                        break;
                    }
                case ControlsEnum.Touch:
                    {
                        GetBehaviourValue = TouchMobileBehaviour;
                        break;
                    }
            }
        }
    }
    public enum ControlsEnum
    {
        PC,
        Touch
    }
}