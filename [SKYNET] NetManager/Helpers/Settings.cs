using System;

namespace SKYNET.Helpers
{
    public class Settings
    {
        public static string Username { get; set; }
        public static bool MinimizeWhenClose { get; set; }
        public static bool LaunchWindowsStart { get; set; }
        public static string CurrentSection { get; set; }
        public static string Key { get; set; }
        public static bool ShowInLeft { get; set; }
        public static double OpacityForm { get; set; }
        public static int Timeout { get; set; }
        public static int BufferSize { get; set; }
        public static int TTL { get; set; }
        public static bool CustomSound { get; set; }
        public static string CustomSoundPath { get; set; }
        public static bool ShowTopPanel { get; set; }
        public static int Handle { get; set; }

        private static RegistrySettings Registry;

        static Settings()
        {
            Registry = new RegistrySettings(@"SOFTWARE\SKYNET\[SKYNET] NetManager\");
        }

        public static void Load()
        {
            Username = Registry.Get<string>("Username", Environment.UserName);
            MinimizeWhenClose = Registry.Get<bool>("MinimizeWhenClose", false);
            LaunchWindowsStart = Registry.Get<bool>("LaunchWindowsStart", false);
            CurrentSection = Registry.Get<string>("CurrentSection", "Device");
            Key = Registry.Get<string>("Key", "F8");
            ShowInLeft = Registry.Get<bool>("ShowInLeft", false);
            OpacityForm = Registry.Get<int>("OpacityForm", 100);
            Timeout = Registry.Get<int>("Timeout", 2000);
            BufferSize = Registry.Get<int>("BufferSize", 32);
            TTL = Registry.Get<int>("TTL", 32);
            CustomSound = Registry.Get<bool>("CustomSound", false);
            CustomSoundPath = Registry.Get<string>("CustomSoundPatch", "");
            ShowTopPanel = Registry.Get<bool>("ShowTopPanel", true);
        }

        public static void Save()
        {
            Registry.Set("Username", Username);
            Registry.Set("MinimizeWhenClose", MinimizeWhenClose);
            Registry.Set("LaunchWindowsStart", LaunchWindowsStart);
            Registry.Set("CurrentSection", CurrentSection);
            Registry.Set("Key", Key);
            Registry.Set("ShowInLeft", ShowInLeft);
            Registry.Set("OpacityForm", OpacityForm);
            Registry.Set("Timeout", Timeout);
            Registry.Set("BufferSize", BufferSize);
            Registry.Set("TTL", TTL);
            Registry.Set("CustomSound", CustomSound);
            Registry.Set("CustomSoundPatch", CustomSoundPath);
            Registry.Set("ShowTopPanel", ShowTopPanel);
        }

        public static void SetHandle(long Handle)
        {
            Registry.Set("Handle", Handle);

        }
    }
}

