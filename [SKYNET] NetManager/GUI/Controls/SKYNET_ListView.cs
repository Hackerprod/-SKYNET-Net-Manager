using SKYNET.GUI;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace SKYNET.Controls
{
	public class SKYNET_ListView : ListView
	{
	
		public event SKYNET_ListView.ScrollPositionChangedDelegate ScrollPositionChanged;

	
		public event Action<SKYNET_ListView> ItemAdded;

	
		public event Action<SKYNET_ListView> ItemsRemoved;

        private Color _SelectedColor;


        public SKYNET_ListView()
		{
			this.Font = new Font("Segoe UI", 9f);
			base.HideSelection = true;
			base.OwnerDraw = true;
			base.DrawColumnHeader += this.ListView_DrawColumnHeader;
			base.DrawItem += this.ListView_DrawItem;
			base.DrawSubItem += this.ListView_DrawSubItem;
			base.Resize += this.ListView_Resize;
			base.SelectedIndexChanged += this.ListView_SelectedIndexChanged;
			base.FullRowSelect = true;
			this._vScrollbar = new MetroScrollBar();
			this._vScrollbar.Visible = false;
			this._vScrollbar.Width = 15;
			this._vScrollbar.Dock = DockStyle.Right;
			this._vScrollbar.ValueChanged += this._vScrollbar_ValueChanged;
			base.Controls.Add(this._vScrollbar);
            this.SelectedColor = Color.FromArgb(29, 39, 51);

        }

		[Category("SKYNET")]
		public bool Selectable
		{
			get
			{
				return base.GetStyle(ControlStyles.Selectable);
			}
			set
			{
				base.SetStyle(ControlStyles.Selectable, value);
			}
		}

        [Category("SKYNET")]
        public Color SelectedColor
        {
            get
            {
                return _SelectedColor;
            }
            set
            {
                _SelectedColor = value;
            }
        }

        public int SelectedIndex { get; set; }

		private void BeginDisableChangeEvents()
		{
			this._disableChangeEvents++;
		}

		private void EndDisableChangeEvents()
		{
			bool flag = this._disableChangeEvents > 0;
			if (flag)
			{
				this._disableChangeEvents--;
			}
		}

		private void _vScrollbar_ValueChanged(object sender, int newValue)
		{
			bool flag = this._disableChangeEvents <= 0;
			if (flag)
			{
				this.SetScrollPosition(this._vScrollbar.Value);
			}
		}

		public void GetScrollPosition(out int min, out int max, out int pos, out int smallchange, out int largechange)
		{
			SKYNET_ListView.SCROLLINFO scrollinfo = default(SKYNET_ListView.SCROLLINFO);
			scrollinfo.cbSize = (uint)Marshal.SizeOf(typeof(SKYNET_ListView.SCROLLINFO));
			scrollinfo.fMask = 23U;
			bool scrollInfo = SKYNET_ListView.GetScrollInfo(base.Handle, 1, ref scrollinfo);
			if (scrollInfo)
			{
				min = scrollinfo.nMin;
				max = scrollinfo.nMax;
				pos = scrollinfo.nPos + 1;
				smallchange = 1;
				largechange = (int)scrollinfo.nPage;
			}
			else
			{
				min = 0;
				max = 0;
				pos = 0;
				smallchange = 0;
				largechange = 0;
			}
		}

		public void UpdateScrollbar()
		{
			bool flag = this._vScrollbar != null;
			if (flag)
			{
				int minimum;
				int num;
				int value;
				int smallChange;
				int num2;
				this.GetScrollPosition(out minimum, out num, out value, out smallChange, out num2);
				this.BeginDisableChangeEvents();
				this._vScrollbar.Value = value;
				this._vScrollbar.Maximum = num - num2 + 1;
				this._vScrollbar.Minimum = minimum;
				this._vScrollbar.SmallChange = smallChange;
				this._vScrollbar.LargeChange = num2;
				this._vScrollbar.Visible = (this._vScrollbar.Maximum != 101);
				this.EndDisableChangeEvents();
			}
		}

		public void SetScrollPosition(int pos)
		{
			pos = Math.Min(base.Items.Count - 1, pos);
			bool flag = pos >= 0 && pos < base.Items.Count;
			if (flag)
			{
				base.SuspendLayout();
				base.EnsureVisible(pos);
				for (int i = 0; i < 10; i++)
				{
					bool flag2 = base.TopItem != null && base.TopItem.Index != pos;
					if (flag2)
					{
						base.TopItem = base.Items[pos];
					}
				}
				base.ResumeLayout();
			}
		}

		protected void OnItemAdded()
		{
			bool flag = this._disableChangeEvents <= 0;
			if (flag)
			{
				this.UpdateScrollbar();
				bool flag2 = this.ItemAdded != null;
				if (flag2)
				{
					this.ItemAdded(this);
				}
			}
		}

		protected void OnItemsRemoved()
		{
			bool flag = this._disableChangeEvents <= 0;
			if (flag)
			{
				this.UpdateScrollbar();
				bool flag2 = this.ItemsRemoved != null;
				if (flag2)
				{
					this.ItemsRemoved(this);
				}
			}
		}

		protected override void OnMouseWheel(MouseEventArgs e)
		{
			base.OnMouseWheel(e);
			bool flag = this._vScrollbar != null;
			if (flag)
			{
				this._vScrollbar.Value -= 3 * Math.Sign(e.Delta);
			}
		}

		protected override void WndProc(ref Message m)
		{
			bool flag = (long)m.Msg == 277L;
			if (flag)
			{
				int num;
				int num2;
				int num3;
				int num4;
				int num5;
				this.GetScrollPosition(out num, out num2, out num3, out num4, out num5);
				bool flag2 = this.ScrollPositionChanged != null;
				if (flag2)
				{
					this.ScrollPositionChanged(this, num3);
				}
				bool flag3 = this._vScrollbar != null;
				if (flag3)
				{
					this._vScrollbar.Value = num3;
				}
			}
			else
			{
				bool flag4 = (long)m.Msg == 131L;
				if (flag4)
				{
					int windowLong = SKYNET_ListView.GetWindowLong(base.Handle, -16);
					bool flag5 = (windowLong & 2097152) == 2097152;
					if (flag5)
					{
						SKYNET_ListView.SetWindowLong(base.Handle, -16, windowLong & -2097153);
					}
				}
				else
				{
					bool flag6 = (long)m.Msg == 4103L || (long)m.Msg == 4173L;
					if (flag6)
					{
						this.OnItemAdded();
					}
					else
					{
						bool flag7 = (long)m.Msg == 4104L || (long)m.Msg == 4105L;
						if (flag7)
						{
							this.OnItemsRemoved();
						}
					}
				}
			}
			base.WndProc(ref m);
		}

		public static int GetWindowLong(IntPtr hWnd, int nIndex)
		{
			bool flag = IntPtr.Size == 4;
			int result;
			if (flag)
			{
				result = (int)SKYNET_ListView.GetWindowLong32(hWnd, nIndex);
			}
			else
			{
				result = (int)((long)SKYNET_ListView.GetWindowLongPtr64(hWnd, nIndex));
			}
			return result;
		}

		public static int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong)
		{
			bool flag = IntPtr.Size == 4;
			int result;
			if (flag)
			{
				result = (int)SKYNET_ListView.SetWindowLongPtr32(hWnd, nIndex, dwNewLong);
			}
			else
			{
				result = (int)((long)SKYNET_ListView.SetWindowLongPtr64(hWnd, nIndex, dwNewLong));
			}
			return result;
		}

		private void ListView_SelectedIndexChanged(object sender, EventArgs e)
		{
			this.UpdateScrollbar();
		}

		private void ListView_Resize(object sender, EventArgs e)
		{
			int count = base.Columns.Count;
		}

		private void ListView_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
		{
			Color color = Color.FromArgb(147, 157, 160);
			bool flag = base.View == View.Details;
			if (flag)
			{
				bool selected = e.Item.Selected;
				if (selected)
				{
					e.Graphics.FillRectangle(new SolidBrush(SelectedColor), e.Bounds);
					color = Color.White;
				}
				TextFormatFlags textFormatFlags = TextFormatFlags.Default;
				int num = 0;
				int num2 = 0;
				bool flag2 = base.CheckBoxes && e.ColumnIndex == 0;
				if (flag2)
				{
					num = 12;
					num2 = 14;
					int num3 = e.Bounds.Height / 2 - 6;
					using (Pen pen = new Pen(color))
					{
						Rectangle rect = new Rectangle(e.Bounds.X + 2, e.Bounds.Y + num3, 12, 12);
						e.Graphics.DrawRectangle(pen, rect);
					}
					bool @checked = e.Item.Checked;
					if (@checked)
					{
						Color color2 = Color.Blue;
						bool selected2 = e.Item.Selected;
						if (selected2)
						{
							color2 = Color.White;
						}
						using (SolidBrush solidBrush = new SolidBrush(color2))
						{
							num3 = e.Bounds.Height / 2 - 4;
							Rectangle rect2 = new Rectangle(e.Bounds.X + 4, e.Bounds.Y + num3, 9, 9);
							e.Graphics.FillRectangle(solidBrush, rect2);
						}
					}
				}
				bool flag3 = base.SmallImageList != null;
				if (flag3)
				{
					Image image = null;
					bool flag4 = e.Item.ImageIndex > -1;
					if (flag4)
					{
						image = base.SmallImageList.Images[e.Item.ImageIndex];
					}
					bool flag5 = e.Item.ImageKey != "";
					if (flag5)
					{
						image = base.SmallImageList.Images[e.Item.ImageKey];
					}
					bool flag6 = image != null;
					if (flag6)
					{
						num2 += ((num2 > 0) ? 4 : 2);
						int num4 = (e.Item.Bounds.Height - image.Height) / 2;
						e.Graphics.DrawImage(image, new Rectangle(e.Item.Bounds.Left + num2, e.Item.Bounds.Top + num4, image.Width, image.Height));
						num2 += base.SmallImageList.ImageSize.Width;
						num += base.SmallImageList.ImageSize.Width;
					}
				}
				int width = e.Item.Bounds.Width;
				bool flag7 = base.View == View.Details;
				if (flag7)
				{
					width = base.Columns[0].Width;
				}
				using (StringFormat stringFormat = new StringFormat())
				{
					HorizontalAlignment textAlign = e.Header.TextAlign;
					HorizontalAlignment horizontalAlignment = textAlign;
					if (horizontalAlignment != HorizontalAlignment.Right)
					{
						if (horizontalAlignment == HorizontalAlignment.Center)
						{
							stringFormat.Alignment = StringAlignment.Center;
						}
					}
					else
					{
						stringFormat.Alignment = StringAlignment.Far;
					}
					double num5;
					bool flag8 = e.ColumnIndex > 0 && double.TryParse(e.SubItem.Text, NumberStyles.Currency, NumberFormatInfo.CurrentInfo, out num5);
					if (flag8)
					{
						stringFormat.Alignment = StringAlignment.Far;
					}
					Rectangle bounds = new Rectangle(e.Bounds.X + num2, e.Bounds.Y, 300, e.Item.Bounds.Height);
					TextRenderer.DrawText(e.Graphics, e.SubItem.Text, this.Font, bounds, color, textFormatFlags | TextFormatFlags.SingleLine | TextFormatFlags.VerticalCenter | TextFormatFlags.WordEllipsis);
				}
			}
			else
			{
				e.DrawDefault = true;
			}
		}

		private void ListView_DrawItem(object sender, DrawListViewItemEventArgs e)
		{
			Color color = Color.Red;
			bool flag = base.View == View.Details | base.View == View.List | base.View == View.SmallIcon;
			if (flag)
			{
				Color color2 = Color.Gray;
				bool selected = e.Item.Selected;
				if (selected)
				{
					e.Graphics.FillRectangle(new SolidBrush(Color.Green), e.Bounds);
					color = Color.White;
					color2 = Color.White;
				}
				TextFormatFlags textFormatFlags = TextFormatFlags.Default;
				int num = 0;
				int num2 = 0;
				bool checkBoxes = base.CheckBoxes;
				if (checkBoxes)
				{
					num = 12;
					num2 = 14;
					int num3 = e.Bounds.Height / 2 - 6;
					using (Pen pen = new Pen(color))
					{
						Rectangle rect = new Rectangle(e.Bounds.X + 2, e.Bounds.Y + num3, 12, 12);
						e.Graphics.DrawRectangle(pen, rect);
					}
					bool @checked = e.Item.Checked;
					if (@checked)
					{
						using (SolidBrush solidBrush = new SolidBrush(color2))
						{
							num3 = e.Bounds.Height / 2 - 4;
							Rectangle rect2 = new Rectangle(e.Bounds.X + 4, e.Bounds.Y + num3, 9, 9);
							e.Graphics.FillRectangle(solidBrush, rect2);
						}
					}
				}
				bool flag2 = base.SmallImageList != null;
				if (flag2)
				{
					Image image = null;
					bool flag3 = e.Item.ImageIndex > -1;
					if (flag3)
					{
						image = base.SmallImageList.Images[e.Item.ImageIndex];
					}
					bool flag4 = e.Item.ImageKey != "";
					if (flag4)
					{
						image = base.SmallImageList.Images[e.Item.ImageKey];
					}
					bool flag5 = image != null;
					if (flag5)
					{
						num2 += ((num2 > 0) ? 4 : 2);
						int num4 = (e.Item.Bounds.Height - image.Height) / 2;
						e.Graphics.DrawImage(image, new Rectangle(e.Item.Bounds.Left + num2, e.Item.Bounds.Top + num4, image.Width, image.Height));
						num2 += base.SmallImageList.ImageSize.Width;
						num += base.SmallImageList.ImageSize.Width;
					}
				}
				bool flag6 = base.View != View.Details;
				if (flag6)
				{
					Rectangle bounds = e.Item.Bounds;
					int width = bounds.Width;
					bool flag7 = base.View == View.Details;
					if (flag7)
					{
						width = base.Columns[0].Width;
					}
					bounds = new Rectangle(e.Bounds.X + num2, e.Bounds.Y, width - num, e.Item.Bounds.Height);
					TextRenderer.DrawText(e.Graphics, e.Item.Text, this.Font, bounds, color, textFormatFlags | TextFormatFlags.SingleLine | TextFormatFlags.VerticalCenter | TextFormatFlags.WordEllipsis);
				}
			}
			else
			{
				bool flag8 = base.View == View.Tile;
				if (flag8)
				{
					int num5 = 0;
					bool flag9 = base.LargeImageList != null;
					if (flag9)
					{
						num5 = base.LargeImageList.ImageSize.Width + 2;
						Image image2 = null;
						bool flag10 = e.Item.ImageIndex > -1;
						if (flag10)
						{
							image2 = base.LargeImageList.Images[e.Item.ImageIndex];
						}
						bool flag11 = e.Item.ImageKey != "";
						if (flag11)
						{
							image2 = base.LargeImageList.Images[e.Item.ImageKey];
						}
						bool flag12 = image2 != null;
						if (flag12)
						{
							int num6 = (e.Item.Bounds.Height - image2.Height) / 2;
							e.Graphics.DrawImage(image2, new Rectangle(e.Item.Bounds.Left + num5, e.Item.Bounds.Top + num6, image2.Width, image2.Height));
						}
					}
					bool selected2 = e.Item.Selected;
					if (selected2)
					{
						Rectangle rect3 = new Rectangle(e.Item.Bounds.X + num5, e.Item.Bounds.Y, e.Item.Bounds.Width, e.Item.Bounds.Height);
						e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(250, 194, 87)), rect3);
					}
					int num7 = 0;
					foreach (object obj in e.Item.SubItems)
					{
						ListViewItem.ListViewSubItem listViewSubItem = (ListViewItem.ListViewSubItem)obj;
						bool flag13 = num7 > 0 && !e.Item.Selected;
						if (flag13)
						{
							color = Color.Silver;
						}
						int y = e.Item.Bounds.Y;
						int num8 = (e.Item.Bounds.Height - e.Item.SubItems.Count * 15) / 2;
						Rectangle bounds2 = new Rectangle(e.Item.Bounds.X + num5, e.Item.Bounds.Y + num7, e.Item.Bounds.Width, e.Item.Bounds.Height);
						TextFormatFlags textFormatFlags2 = TextFormatFlags.Default;
						TextRenderer.DrawText(e.Graphics, listViewSubItem.Text, new Font("Segoe UI", 9f), bounds2, color, textFormatFlags2 | TextFormatFlags.SingleLine | TextFormatFlags.WordEllipsis);
						num7 += 15;
					}
				}
				else
				{
					bool checkBoxes2 = base.CheckBoxes;
					if (checkBoxes2)
					{
						int num9 = e.Bounds.Height / 2 - 6;
						using (Pen pen2 = new Pen(Color.Black))
						{
							Rectangle rect4 = new Rectangle(e.Bounds.X + 6, e.Bounds.Y + num9, 12, 12);
							e.Graphics.DrawRectangle(pen2, rect4);
						}
						bool checked2 = e.Item.Checked;
						if (checked2)
						{
							Color color3 = Color.Gold;
							bool selected3 = e.Item.Selected;
							if (selected3)
							{
								color3 = Color.White;
							}
							using (SolidBrush solidBrush2 = new SolidBrush(color3))
							{
								num9 = e.Bounds.Height / 2 - 4;
								Rectangle rect5 = new Rectangle(e.Bounds.X + 8, e.Bounds.Y + num9, 9, 9);
								e.Graphics.FillRectangle(solidBrush2, rect5);
							}
						}
						Rectangle r = new Rectangle(e.Bounds.X + 23, e.Bounds.Y + 1, e.Bounds.Width, e.Bounds.Height);
						e.Graphics.DrawString(e.Item.Text, this.Font, new SolidBrush(color), r);
					}
					e.DrawDefault = true;
				}
			}
		}

		private void ListView_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
		{
			Color color = Color.Red;
			e.Graphics.FillRectangle(new SolidBrush(_SelectedColor), e.Bounds);
			using (StringFormat stringFormat = new StringFormat())
			{
				stringFormat.Alignment = StringAlignment.Near;
				e.Graphics.DrawString(e.Header.Text, this.Font, new SolidBrush(color), e.Bounds, stringFormat);
			}
		}

		[DllImport("user32.dll", CharSet = CharSet.Auto, EntryPoint = "GetWindowLong")]
		public static extern IntPtr GetWindowLong32(IntPtr hWnd, int nIndex);

		[DllImport("user32.dll", CharSet = CharSet.Auto, EntryPoint = "GetWindowLongPtr")]
		public static extern IntPtr GetWindowLongPtr64(IntPtr hWnd, int nIndex);

		[DllImport("user32.dll", CharSet = CharSet.Auto, EntryPoint = "SetWindowLong")]
		public static extern IntPtr SetWindowLongPtr32(IntPtr hWnd, int nIndex, int dwNewLong);

		[DllImport("user32.dll", CharSet = CharSet.Auto, EntryPoint = "SetWindowLongPtr")]
		public static extern IntPtr SetWindowLongPtr64(IntPtr hWnd, int nIndex, int dwNewLong);

		[DllImport("user32.dll")]
		private static extern bool GetScrollInfo(IntPtr hwnd, int fnBar, ref SKYNET_ListView.SCROLLINFO lpsi);

		private int _disableChangeEvents;

		private MetroScrollBar _vScrollbar;

		public delegate void ScrollPositionChangedDelegate(SKYNET_ListView listview, int pos);

		private struct SCROLLINFO
		{
			public uint cbSize;

			public uint fMask;

			public int nMin;

			public int nMax;

			public uint nPage;

			public int nPos;

			public int nTrackPos;
		}
	}
}
