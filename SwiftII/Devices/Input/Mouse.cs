using System;
using Cosmos.HAL;
using Cosmos.HAL.Drivers.PCI.Video;
using Cosmos.System;

namespace SwiftII.Devices.Input
{
    public class Mouse
    {
        // The mouse position and the mouse cursor
        private int mouseX, mouseY;

        // Mouse cursor represented by a 2x2 white box (You can replace it with your own design)
        private uint[] mouseCursor = new uint[4] {
            0xFFFFFFFF, 0xFFFFFFFF,  // White pixel for the cursor
            0xFFFFFFFF, 0xFFFFFFFF
        };

        // Constructor
        public Mouse()
        {
            // Initialize the mouse manager
            //MouseManager.Initialize();
            mouseX = 0;
            mouseY = 0;
        }

        // Method to update the mouse position
        public void UpdateMousePosition()
        {
            mouseX = (int)MouseManager.X;  // Get the X position from MouseManager
            mouseY = (int)MouseManager.Y;  // Get the Y position from MouseManager
        }

        // Method to draw the mouse cursor on the screen
        public void Draw(VMWareSVGAII vgaDriver)
        {
            // Update the mouse position
            UpdateMousePosition();

            // Draw the cursor at the current position
            for (int x = 0; x < 2; x++)
            {
                for (int y = 0; y < 2; y++)
                {
                    // Draw the cursor pixels at the position (mouseX + x, mouseY + y)
                    vgaDriver.SetPixel((ushort)(mouseX + x), (ushort)(mouseY + y), mouseCursor[y * 2 + x]);
                }
            }
        }
    }
}
