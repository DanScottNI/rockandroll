using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace RockAndRoll
{
    public partial class frmPreferences : Form
    {
        ApplicationConfig config;

        public frmPreferences(ref ApplicationConfig configuration)
        {
            InitializeComponent();
            this.config = configuration;
        }

        private void btnLeftColour_Click(object sender, EventArgs e)
        {
            clrDialog.Color = picLeftColour.BackColor;
            if (clrDialog.ShowDialog() == DialogResult.OK)
            {
                picLeftColour.BackColor = clrDialog.Color;
            }
        }

        private void btnMiddleColour_Click(object sender, EventArgs e)
        {
            clrDialog.Color = picMiddleColour.BackColor;
            if (clrDialog.ShowDialog() == DialogResult.OK)
            {
                picMiddleColour.BackColor = clrDialog.Color;
            }
        }

        private void frmPreferences_Load(object sender, EventArgs e)
        {
            LoadConfiguration();
        }

        private void btnEnemyColour_Click(object sender, EventArgs e)
        {
            clrDialog.Color = picEnemyColour.BackColor;
            if (clrDialog.ShowDialog() == DialogResult.OK)
            {
                picEnemyColour.BackColor = clrDialog.Color;
            }
        }

        private void btnSpecObjColour_Click(object sender, EventArgs e)
        {
            clrDialog.Color = picSpecObjColour.BackColor;
            if (clrDialog.ShowDialog() == DialogResult.OK)
            {
                picSpecObjColour.BackColor = clrDialog.Color;
            }
        }

        private void btnBeamdownColour_Click(object sender, EventArgs e)
        {
            clrDialog.Color = picBeamdownColour.BackColor;
            if (clrDialog.ShowDialog() == DialogResult.OK)
            {
                picBeamdownColour.BackColor = clrDialog.Color;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            SaveConfiguration();
        }

        private void LoadConfiguration()
        {
            picLeftColour.BackColor = config.SelectedTileLeftColour;
            picMiddleColour.BackColor = config.SelectedTileMiddleColour;
            picEnemyColour.BackColor = config.EnemyColour;
            picBeamdownColour.BackColor = config.BeamDownColour;
            picSpecObjColour.BackColor = config.SpecialObjectColour;
        }

        private void SaveConfiguration()
        {
            config.SelectedTileLeftColour = picLeftColour.BackColor;
            config.SelectedTileMiddleColour = picMiddleColour.BackColor;
            config.EnemyColour = picEnemyColour.BackColor;
            config.BeamDownColour = picBeamdownColour.BackColor;
            config.SpecialObjectColour = picSpecObjColour.BackColor;
        }
    }
}
