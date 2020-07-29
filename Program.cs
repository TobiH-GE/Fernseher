using System;

namespace Fernseher
{
    class TV
    {
        int Volume = 0;
        int Channel = 0;
        bool Power = false;

        public void Status()
        {
            Console.WriteLine("### TV STATUS on: {0} - channel {1} - volume {2} ###\n", Power, Channel, Volume);
        }
        public void SwitchChannel(int newChannel)
        {
            Console.Write("switch channel to " + newChannel);
            if (!Power)
            {
                Console.WriteLine(" ==> can't switch to channel, TV not powered on!");
                return;
            }
            if (newChannel < 0 || newChannel > 100)
            {
                Console.WriteLine(" ==> can't switch to channel, wrong channel!");
                return;
            }
            else
            {
                Channel = newChannel;
                Console.WriteLine(" ==> TV switched to channel: " + Channel);
            }

        }
        public void ChannelUp()
        {
            if (Channel < 100)
            {
                SwitchChannel(Channel + 1);
            }
            else
            {
                SwitchChannel(0);
            }
        }
        public void ChannelDown()
        {
            if (Channel > 0)
            {
                SwitchChannel(Channel - 1);
            }
            else
            {
                SwitchChannel(100);
            }
        }
        public void VolumeUp()
        {
            if (Volume < 100)
            {
                SetVolume(Volume + 1);
            }
        }
        public void VolumeDown()
        {
            if (Volume > 0)
            {
                SetVolume(Volume - 1);
            }
        }
        public void SetVolume(int newVolume)
        {
            Console.Write("set volume to " + newVolume);
            if (Power)
            {
                Volume = newVolume;
                Console.WriteLine(" ==> TV new volume: " + Volume);
            }
            else
            {
                Console.WriteLine(" ==> can't set volume, TV not powered on!");
            }
        }
        public void PowerOn(bool OnOff)
        {
            Console.Write("turn TV to " + OnOff);
            if (Power && OnOff)
            {
                Console.WriteLine(" ==> TV already on!");
            }
            else if (!Power && !OnOff)
            {
                Console.WriteLine(" ==> TV already off!");
            }
            else if (Power && !OnOff)
            {
                Power = OnOff;
                Console.WriteLine(" ==> TV is off!");
            }
            else
            {
                Power = OnOff;
                Console.WriteLine(" ==> TV is on!");
            }
        }
        public void PowerSwitch()
        {
            Console.Write("switch TV power ");

            if (Power)
            {
                Power = false;
                Console.WriteLine(" ==> TV is off!");
            }
            else
            {
                Power = true;
                Console.WriteLine(" ==> TV is on!");
            }
        }
    }
    class Program                               // *** TV by TobiH ***
    {
        static void Main(string[] args)
        {
            ConsoleKeyInfo UserInput = new ConsoleKeyInfo();
            string ChannelNumber = "";

            TV Sony = new TV();

            do
            {
                Console.Clear();
                Sony.Status();
                Console.WriteLine("[v ^] channel down/up\n[number + enter] switch to channel\n[< >] volume down/up\n[p] power on/off\n[x] exit program");
                Console.WriteLine("\nUserInput Key: " + UserInput.Key);
                Console.WriteLine("UserInput ChannelNumber: " + ChannelNumber);
                UserInput = Console.ReadKey();

                switch (UserInput.Key)
                {
                    case ConsoleKey.UpArrow:
                        Sony.ChannelUp();
                        break;
                    case ConsoleKey.DownArrow:
                        Sony.ChannelDown();
                        break;
                    case ConsoleKey.LeftArrow:
                        Sony.VolumeDown();
                        break;
                    case ConsoleKey.RightArrow:
                        Sony.VolumeUp();
                        break;
                    case ConsoleKey.P:
                        Sony.PowerSwitch();
                        break;
                    case ConsoleKey.Enter:
                        Sony.SwitchChannel(Convert.ToInt32(ChannelNumber));
                        ChannelNumber = "";
                        break;
                    default:
                        if (Char.IsNumber(UserInput.KeyChar))
                        {
                            ChannelNumber = ChannelNumber + UserInput.KeyChar;
                        }
                        else
                        {
                            Console.WriteLine("\nunknown key");
                        }
                        break;
                }
            } while (UserInput.Key != ConsoleKey.X);
        }
    }
}