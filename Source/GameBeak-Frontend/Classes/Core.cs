using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameBeak_Frontend.Classes
{
    static class Core
    {
        static Core()
        {
            beakMemory = new Memory();
            beakGPU = new GPU();
            beakWindow = new GameWindow();
            beakCPU = new CPU();
            mainWindow = new MainWindow();
            beakInput = new Input();

            clocks = 4500;

            run = true;
            paused = false;
            step = false;
            enableInterruptsNextCycle = false;
            paletteSetting = 0;
        }


        public static MainWindow mainWindow;
        public static Memory beakMemory;
        public static GPU beakGPU;
        public static GameWindow beakWindow;
        public static CPU beakCPU;
        public static Input beakInput;

        public static int clocks;

        //extern int memoryControllerMode;
        public static bool run;
        public static bool paused;
        public static bool step;
        public static bool enableInterruptsNextCycle;
        public static byte paletteSetting;
        //extern byte filterSetting;

        public static bool breakPointEnabled = true;
        public static ConcurrentDictionary<string, short> breakpoints = new ConcurrentDictionary<string, short>();

        //extern Audio beakAudio;

        //extern KeyInput beakInput;
    }

    public static class GameBeak_Main
    {
        public static void startEmulator()
        {
            Core.beakMemory.initializeGameBoyValues();
            Core.beakMemory.readRomHeader();

            int clocksSinceLastTimerTIMAIncrement = 0;
            int clocksSinceLastTimerDIVIncrement = 0;
            int clocksSinceLastScanLineComplete = 0;
            int clocksSinceLastVBlank = 0;
            int clocksSinceLastScreenRefresh = 0;

            //Core.beakMemory.loadDecompressedNintendoLogoToMemory();

            while(Core.run)
            {
                /*
                if (breakPointEnabled)
		        {
			        if (memoryPointer == breakPointAt)
			        {
				        paused = true;
			        }
		        }
                */

                //short[] localBreakpoints = Core.breakpoints.ToArray();

                if (Core.breakPointEnabled)
                { 
                    if(Core.breakpoints.ContainsKey(Core.beakMemory.memoryPointer.ToString("X4")))
                    {
                        Core.paused = true;
                    }
                    
                }

                if (!Core.paused || Core.step)
                {
                    Core.beakInput.readInput();

                    
                    //if (!cpu.checkForHaltOrInterrupt())
                    if (!Core.beakCPU.checkForHaltOrInterrupt())
                    {
                        Core.beakCPU.selectOpcode(Core.beakMemory.readMemory((ushort)Core.beakMemory.memoryPointer++));
                    }
                    else
                    {
                        Core.beakCPU.selectOpcode(0); //Gets stuck at a halt without this, because no cycles are occuring (no opcode is running) the vblank interrupt never occurs
                    }



                    Core.step = false;
                    Core.clocks += Core.beakCPU.tClock;

                    Core.beakCPU.updateTIMA(Core.clocks, ref clocksSinceLastTimerTIMAIncrement, ref clocksSinceLastTimerDIVIncrement);
                    Core.beakWindow.updateLCD(Core.clocks, ref clocksSinceLastScanLineComplete, ref clocksSinceLastScreenRefresh, ref clocksSinceLastVBlank);

                    Core.beakCPU.mClock = 0;
                    Core.beakCPU.tClock = 0;

                    /*
                    if (soundEnabled)
                    {
                        beakAudio.updateSound();
                    }
                    */

                    /*
                    if (checkForWriteBreakpoint(writeBreakpoint, writeBreakpointValue, breakpointValue, writeBreakpointAddress))
                    {
                        paused = true;
                    }
                    */

                }
            }
        }
    }
}
