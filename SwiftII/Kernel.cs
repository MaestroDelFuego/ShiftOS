using System;
using System.Collections.Generic;
using System.Text;
using Sys = Cosmos.System;
using Cosmos.Core;
using Cosmos.HAL.Drivers.PCI.Video;
using SwiftII.Devices.Input;
using Cosmos.Debug.Kernel;
using Cosmos.Core.IOGroup;
using Cosmos.HAL.Drivers.PCI.Video;
//using Cosmos.System.Threading;  // Make sure to include this for threading
using Mouse = SwiftII.Devices.Input.Mouse;


namespace SwiftII
{
    public class Kernel : Cosmos.System.Kernel
    {
        private Mouse mouse;
        private VMWareSVGAII vgaDriver;

        public Kernel()
        {
            mouse = new Mouse();
            vgaDriver = new VMWareSVGAII();  // Initialize the VGA driver (assuming VMWareSVGAII or your custom driver)
        }

        protected override void Run()
        {
            while (true)
            {
                // Update and draw the mouse on the screen
                mouse.Draw(vgaDriver);

                // Add other rendering/logic code here

                // Allow the system to continue updating
                //Cosmos.System.Threading.Thread.Sleep(10);  
            }
        }
    }

}
