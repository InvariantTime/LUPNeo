using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LUP.SceneGraph
{
    public abstract class ActivableComponent : Component
    {
        private bool enable = true;

        public bool Enable
        {
            get => enable;
            
            set
            {
                OnEnableChanged(value);
            }
        }


        protected virtual void OnActivate()
        {
        }


        protected virtual void OnDisable()
        {
        }


        private void OnEnableChanged(bool value)
        {
            if (value == enable)
                return;

            if (value == true)
                OnActivate();
            else
                OnDisable();

            enable = value;
        }
    }
}
