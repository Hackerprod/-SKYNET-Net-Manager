﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace SKYNET.GUI
{
    public partial class DeviceHistory : UserControl
    {
        private Dictionary<int, int> Values;
        private int count = 0;

        public DeviceHistory()
        {
            InitializeComponent();
            Values = new Dictionary<int, int>();
            InitializeValues();
        }

        private void InitializeValues()
        {
            for (int i = 1; i < 31; i++)
            {
                Values.Add(i, 0);
            }
        }

        internal void Add(int RoundTrip)
        {
            count++;

            Panel newPanel = new Panel();
            newPanel.Width = 5;
            newPanel.Name = "BackPanel_" + count.ToString();
            newPanel.Padding = new Padding(1, 0, 0, 0);

            Panel PanelValue = new Panel();
            PanelValue.Dock = DockStyle.Bottom;
            PanelValue.Height = RoundTrip;
            PanelValue.Name = "PanelValue_" + count.ToString();
            PanelValue.BackColor = GetColor(RoundTrip);

            InvokeAddControl(newPanel, PanelValue);

            InvokeAddControl(BarContainer, newPanel);

            newPanel.Dock = DockStyle.Right;

            if (BarContainer.Controls.Count > 31)
            {
                Common.InvokeAction(BarContainer, delegate { BarContainer.Controls.RemoveAt(0); });
            }
        }

        private void InvokeAddControl(Control control, Control newPanel)
        {
            if (control.InvokeRequired)
            {
                control.Invoke(new Action(() =>
                {
                    control.Controls.Add(newPanel);
                }));
            }
            else
            {
                control.Controls.Add(newPanel);
            }
        }

        private Color GetColor(int roundTrip)
        {
            Color returnColor = Color.FromArgb(4, 252, 86);

            if (roundTrip >= 0 && roundTrip <= 5)
            {
                returnColor = Color.FromArgb(4, 252, 86);
            }
            else if (roundTrip >= 6 && roundTrip <= 25)
            {
                returnColor = Color.FromArgb(208, 252, 5);
            }
            else if (roundTrip >= 26 && roundTrip <= 55)
            {
                returnColor = Color.FromArgb(252, 162, 5);
            }
            else if (roundTrip >= 56 && roundTrip <= 105)
            {
                returnColor = Color.FromArgb(252, 98, 5);
            }
            else
                returnColor = Color.Red;


            return returnColor;
        }

        private void UpdatePanels()
        {
        }
    }
}
