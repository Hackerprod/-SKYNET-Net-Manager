using SKYNET.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace SKYNET
{
    public partial class frmProfile : Form
    {
        private bool mouseDown;     //Mover ventana
        private Point lastLocation; //Mover ventana

        public TypeMessage typeMessage;
        public static string NewProfile;

        public frmProfile()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;  //Para permitir acceso a los subprocesos

            if (!Directory.Exists(modCommon.CurrentDirectory + "/Data"))
                Directory.CreateDirectory(modCommon.CurrentDirectory + "/Data");

            string[] files = Directory.GetFiles(modCommon.CurrentDirectory + "/Data", "*.json");

            foreach (var item in files)
            {
                profileBox.Items.Add(Path.GetFileNameWithoutExtension(item));
            }
            SelectIndex(frmMain.CurrentSection);
        }

        private void SelectIndex(string Section)
        {
            for (int i = 0; i < profileBox.Items.Count; i++)
            {
                profileBox.SelectedIndex = i;
                if (profileBox.Text == Section)
                {
                    return;
                }
            }
        }

        private void Event_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                Location = new Point((Location.X - lastLocation.X) + e.X, (Location.Y - lastLocation.Y) + e.Y);
                Update();
                Opacity = 0.93;
            }
        }

        private void Event_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            lastLocation = e.Location;

        }

        private void Event_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
            Opacity = 100;
        }


        private void cancelBtn_Click(object sender, EventArgs e)
        {
            Close();
        }


        public enum TypeMessage
        {
            Alert,
            Normal,
            YesNo
        }


        private void FrmManager_Load(object sender, EventArgs e)
        {


        }

        private void SetProfile_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(profileBox.Text))
            {
                modCommon.Show("Seleccione un perfil para continuar");
                return;
            }
            frmMain.frm.LoadProfile(profileBox.Text);
            frmMain.CurrentSection = profileBox.Text;
        }

        private void AddProfile_Click(object sender, EventArgs e)
        {
            frmAddProfile addProfile = new frmAddProfile();
            DialogResult result = addProfile.ShowDialog();
            if (result == DialogResult.OK)
            {
                if (!File.Exists(modCommon.CurrentDirectory + "/Data/" + NewProfile + ".json"))
                {
                    using (FileStream fileStream = new FileStream(modCommon.CurrentDirectory + "/Data/" + NewProfile + ".json", FileMode.OpenOrCreate)) { }
                }

                profileBox.Items.Add(NewProfile);
                SelectIndex(NewProfile);
            }
        }

        private void Close_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void Close_MouseMove(object sender, MouseEventArgs e)
        {
            panelClose.BackColor = Color.FromArgb(53, 64, 78);
        }

        private void Close_MouseLeave(object sender, EventArgs e)
        {
            panelClose.BackColor = Color.FromArgb(43, 54, 68);
        }

        private void DeleteProfile_Click(object sender, EventArgs e)
        {
            if (profileBox.Text == "Device")
            {
                frmMessage nop = new frmMessage("El perfil que intenta eliminar es el perfil por defecto del programa." + Environment.NewLine + "Operación no válida.", frmMessage.TypeMessage.Normal);
                nop.ShowDialog();
                return;
            }
            frmMessage cuestion = new frmMessage("Esta a punto de eliminar el perfil " + profileBox.Text + ". Esta acción no se podrá deshacer." + Environment.NewLine + "Desea continuar?", frmMessage.TypeMessage.YesNo);
            DialogResult result = cuestion.ShowDialog();
            if (result == DialogResult.OK)
            {
                if (!Directory.Exists(modCommon.CurrentDirectory + "/Data"))
                    Directory.CreateDirectory(modCommon.CurrentDirectory + "/Data");

                if (File.Exists(modCommon.CurrentDirectory + "/Data/" + profileBox.Text + ".ini"))
                    File.Delete(modCommon.CurrentDirectory + "/Data/" + profileBox.Text + ".ini");

                frmMain.frm.CleanBoxControls();

                string[] files = Directory.GetFiles(modCommon.CurrentDirectory + "/Data/Images/", "*.png");
                for (int i = 0; i < files.Length; i++)
                {
                    string filename = Path.GetFileNameWithoutExtension(files[i]);
                    filename = string.Join("", filename.ToCharArray().Where(Char.IsLetter));
                    if (filename == profileBox.Text)
                        try { File.Delete(files[i]); } catch { }
                }

                profileBox.Items.Remove(profileBox.Text);
            }
        }
        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);
            int attrValue = 2;
            DwmApi.DwmSetWindowAttribute(base.Handle, 2, ref attrValue, 4);
            DwmApi.MARGINS mARGINS = default(DwmApi.MARGINS);
            mARGINS.cyBottomHeight = 1;
            mARGINS.cxLeftWidth = 0;
            mARGINS.cxRightWidth = 0;
            mARGINS.cyTopHeight = 0;
            DwmApi.MARGINS marInset = mARGINS;
            DwmApi.DwmExtendFrameIntoClientArea(base.Handle, ref marInset);
        }

    }
}
