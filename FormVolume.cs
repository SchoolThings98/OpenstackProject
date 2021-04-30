using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LTIOpenstackProject
{
    public partial class FormVolume : Form
    {
        public String serverIP = "";
        public String projectID = "";
        public String scopeToken = "";
        public JArray volumeList = null;

        public FormVolume(string ip, string projID, string token)
        {
            InitializeComponent();
            serverIP = ip;
            projectID = projID;
            scopeToken = token;
        }

        private void FormVolume_Load(object sender, EventArgs e)
        {
            OpenstackAPI openstack = new OpenstackAPI();
            var volumes = openstack.volumeList(serverIP,projectID,scopeToken);
            //Console.WriteLine(volumes);
            volumeList = volumes;
            foreach (JToken volume in volumes)
            {
                listBox1.Items.Add((string)volume.SelectToken("name"));
                
            }

        }

        private void buttonCreateVolume_Click(object sender, EventArgs e)
        {
            FormCreateVolume formCreateVolume = new FormCreateVolume(serverIP,projectID,scopeToken);
            formCreateVolume.Show();
        }

        private void buttonRemoveVol_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Selecione um volume para remover");
                return;
            }
            var volumeName = listBox1.SelectedItem.ToString();
            var volumeID = "";
            foreach (JToken volume in volumeList)
            {
                if ((string)volume.SelectToken("name") == volumeName)
                {
                    volumeID = (string)volume.SelectToken("id");
                    break;
                }

            }
            OpenstackAPI openstack = new OpenstackAPI();
            var response = openstack.removeVolume(serverIP, scopeToken,projectID,volumeID);
            HttpStatusCode statusCode = response.StatusCode;
            int numericStatusCode = (int)statusCode;
            Console.WriteLine(numericStatusCode);
            if (numericStatusCode != 202)
            {
                MessageBox.Show(response.StatusCode.ToString());
                return;
            }
            else
            {
                MessageBox.Show(response.StatusCode.ToString());
                listBox1.Items.Remove(listBox1.SelectedItem);
            }

        }
    }
}
