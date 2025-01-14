using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Praktiline_too_Kino
{
    public partial class RegistreerimineForm : Form
    {
        private Button btnLogin;
        private Label lblRole;
        private ComboBox cbRole;

        public RegistreerimineForm()
        {
            InitializeComponent();
            ConfigureForm();
            AddControls();
        }

        private void ConfigureForm()
        {
            this.Height = 500;
            this.Width = 600;
            this.Text = "Registreerimine";
            this.BackgroundImage = Image.FromFile(@"../../woll.jpg");
            this.BackgroundImageLayout = ImageLayout.Stretch;
        }

        private void AddControls()
        {
            btnLogin = new Button
            {
                Text = "Logi sisse",
                Size = new Size(171, 52),
                Location = new Point(200, 339),
                Font = new Font("Arial", 18, FontStyle.Italic),
                BackColor = Color.Bisque 
            };
            btnLogin.Click += BtnLogin_Click;
            Controls.Add(btnLogin);

            lblRole = new Label
            {
                AutoSize = true,
                Text = "Rolli",
                Font = new Font("Arial", 25, FontStyle.Italic),
                Location = new Point(250, 100),
                BackColor = Color.Bisque
            };
            Controls.Add(lblRole);

            cbRole = new ComboBox
            {
                Location = new Point(200, 200),
                Font = new Font("Arial", 15),
                Width = 180,
                BackColor = Color.Bisque
            };
            cbRole.Items.AddRange(new[] { "Admin", "User" });
            Controls.Add(cbRole);
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            if (cbRole.SelectedItem != null)
            {
                string selectedRole = cbRole.SelectedItem.ToString();

                switch (selectedRole)
                {
                    case "Admin":
                        OpenAdminForm();
                        break;

                    case "User":
                        OpenUserForm();
                        break;

                    default:
                        MessageBox.Show("Valitud roll ei toetatud.", "Viga", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                }
            }
            else
            {
                MessageBox.Show("Valige roll.", "Hoiatus", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void OpenAdminForm()
        {
            TabelidForm adminForm = new TabelidForm();
            adminForm.Show();
        }

        private void OpenUserForm()
        {
            KinoForm userForm = new KinoForm();
            userForm.Show();
        }

        private void RegistreerimineForm_Load(object sender, EventArgs e)
        {
        }
    }
}
