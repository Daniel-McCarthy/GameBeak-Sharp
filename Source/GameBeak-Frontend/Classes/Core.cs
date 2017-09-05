using System;
using System.Collections.Generic;
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

            clocks = 4500;

            run = true;
            paused = false;
            step = false;
            enableInterruptsNextCycle = false;
            paletteSetting = 0;
        }
        

        public static Memory beakMemory;
        public static GPU beakGPU;
        public static GameWindow beakWindow;
        public static CPU beakCPU;

        public static int clocks;

        //extern int memoryControllerMode;
        public static bool run;
        public static bool paused;
        public static bool step;
        public static bool enableInterruptsNextCycle;
        public static byte paletteSetting;
        //extern byte filterSetting;


        //extern Audio beakAudio;

        //extern KeyInput beakInput;
    }

    }
}
