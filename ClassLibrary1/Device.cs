using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    // Тип устройства, состояние, 2 метода
    public class Device : ISwitchContract
    {
        public string Name { get; set; }
        public bool State{ get; set; }
        public void SwitchOn()
        {
                State = true;
        }
        public void SwitchOff() 
        {
                State = false;
        }
    
    }
}
