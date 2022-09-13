using SKYNET.GUI;
using SKYNET.Helpers;
using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace SKYNET
{
    public partial class frmProfile : frmBase
    {
        public static string NewProfile;

        public frmProfile()
        {
            InitializeComponent();
            base.SetMouseMove(PN_Top);
            CheckForIllegalCrossThreadCalls = false;  

            if (!Directory.Exists(Path.Combine(Common.GetPath(), "Data")))
                Directory.CreateDirectory(Path.Combine(Common.GetPath(), "Data"));

            string[] files = Directory.GetFiles(Path.Combine(Common.GetPath(), "Data", "*.json"));

            foreach (var item in files)
            {
                profileBox.Items.Add(Path.GetFileNameWithoutExtension(item));
            }
            SelectIndex(Settings.CurrentSection);
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

        private void SetProfile_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(profileBox.Text))
            {
                Common.Show("Seleccione un perfil para continuar");
                return;
            }
            frmMain.frm.LoadProfile(profileBox.Text);
            Settings.CurrentSection = profileBox.Text;
        }

        private void AddProfile_Click(object sender, EventArgs e)
        {
            frmAddProfile addProfile = new frmAddProfile();
            DialogResult result = addProfile.ShowDialog();
            if (result == DialogResult.OK)
            {
                if (!File.Exists(Path.Combine(Common.GetPath(), "Data", NewProfile + ".json")))
                {
                    using (FileStream fileStream = new FileStream(Path.Combine(Common.GetPath(), "Data", NewProfile + ".json"), FileMode.OpenOrCreate)) { }
                }

                profileBox.Items.Add(NewProfile);
                SelectIndex(NewProfile);
            }
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
                if (!Directory.Exists(Path.Combine(Common.GetPath(), "Data")))
                    Directory.CreateDirectory(Path.Combine(Common.GetPath(), "Data"));

                if (File.Exists(Path.Combine(Common.GetPath(), "Data", profileBox.Text + ".ini")))
                    File.Delete(Path.Combine(Common.GetPath(), "Data", profileBox.Text + ".ini"));

                frmMain.frm.CleanBoxControls();

                string[] files = Directory.GetFiles(Path.Combine(Common.GetPath(), "Data", "Images"), "*.png");
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

        private void CloseBox_BoxClicked(object sender, EventArgs e)
        {
            Close();
        }
    }
}
