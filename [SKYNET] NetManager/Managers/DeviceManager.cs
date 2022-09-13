using SKYNET.Helpers;
using SKYNET.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Net;
using System.Windows.Forms;

namespace SKYNET
{
    public class DeviceManager
    {
        public static Device GetDevice(DeviceBox deviceBox)
        {
            return deviceBox.Device;
        }

        public static Device GetDeviceFromIP(IPAddress address)
        {
            Device device = null;
            foreach (Control item in frmMain.frm.DeviceContainer.Controls)
            {
                if (item is DeviceBox)
                {
                    DeviceBox box = (DeviceBox)item;
                    if (box.Device.IPAddress == address.ToString())
                    {
                        return box.Device;
                    }
                }
            }
            return device;
        }

        public static DeviceBox GetBoxFromIP(IPAddress address)
        {
            DeviceBox device = null;
            foreach (Control item in frmMain.frm.DeviceContainer.Controls)
            {
                if (item is DeviceBox)
                {
                    DeviceBox box = (DeviceBox)item;
                    if (box.Device.IPAddress == address.ToString())
                    {
                        return box;
                    }
                }
            }
            return device;
        }

        public static DeviceBox GetBoxFromIP(List<IPAddress> addresses)
        {
            DeviceBox device = null;
            foreach (Control item in frmMain.frm.DeviceContainer.Controls)
            {
                if (item is DeviceBox)
                {
                    DeviceBox box = (DeviceBox)item;
                    foreach (var address in addresses)
                    {
                        if (box.Device.IPAddress == address.ToString())
                        {
                            return box;
                        }
                    }
                }
            }
            return device;
        }

        public static int GetDeviceCount()
        {
            int Count = 0;

            for (int i = 0; i < frmMain.frm.DeviceContainer.Controls.Count; i++)
            {
                if (frmMain.frm.DeviceContainer.Controls[i] is DeviceBox)
                {
                    Count++;
                }
            }
            return Count; 
        }

        public static ImageType GetImageType(string imageFile)
        {
            string ext = Path.GetExtension(imageFile);

            if (ext.ToUpper() == ".JPG")
                return ImageType.JPG;
            else if (ext.ToUpper() == ".PNG")
                return ImageType.PNG;
            else if (ext.ToUpper() == ".ICO")
                return ImageType.ICO;
            else if (ext.ToUpper() == ".GIF")
                return ImageType.GIF;
            else
                return ImageType.PNG;
        }

        public static Image GetDeviceImage(DeviceBox device)
        {
            return GetDeviceImage(device.Device);
        }

        public static Image GetDeviceImage(Device device)
        {
            string filePath = Path.Combine(Common.GetPath(), "Data", "Images", device.Guid + ".jpg");

            if (File.Exists(filePath))
            {
                return Common.ImageFromFile(filePath);
            }
            return Resources.OfflinePC;
        }

        public static bool GetDeviceImage(Device device, out Image image)
        {
            var filePath = Path.Combine(Common.GetPath(), "Data", "Images", device.Guid + ".jpg");
            image = Resources.OfflinePC; 

            if (File.Exists(filePath))
            {
                image = Common.ImageFromFile(filePath);
                return true;
            }

            return false;
        }

        public static string GetAvatarPath(Device device)
        {
            var filePath = Path.Combine(Common.GetPath(), "Data", "Images", device.Guid + ".jpg");

            if (File.Exists(filePath))
            {
                return filePath;
            }
            return Path.Combine(Common.GetPath(), "Data", "Images", "Default.jpg");
        }
    }
    public enum ImageType
    {
        JPG,
        PNG,
        ICO,
        GIF
    }
}