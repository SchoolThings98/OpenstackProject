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
    public partial class FormImage : Form
    {
        public String serverIP = "";
        public String scopeToken = "";
        public JArray imageList = null;
        public FormImage(string ip, string token)
        {
            InitializeComponent();
            serverIP = ip;
            scopeToken = token;
        }

        private void FormImage_Load(object sender, EventArgs e)
        {
            OpenstackAPI openstack = new OpenstackAPI();
            var images = openstack.imageList(serverIP,scopeToken);
            //Console.WriteLine(images);
            imageList = images;
            foreach (JToken image in images)
            {
                listBox1.Items.Add((string)image.SelectToken("name")+"."+ (string)image.SelectToken("disk_format"));

            }
        }

        private void buttonUploadImage_Click(object sender, EventArgs e)
        {
            var fileName = "";
            //openFileDialogImage.InitialDirectory = Application.StartupPath + @"\templates";
            openFileDialogImage.Filter = "iso files (*.iso)|*.iso";
            if (openFileDialogImage.ShowDialog() == DialogResult.OK)
            {
                fileName = openFileDialogImage.FileName;
                MessageBox.Show("Ficheiro" + fileName + " open with SUCCESS! ");
            }
            else
            {
                MessageBox.Show("Erro trying to open the selected file!!!");
                return;
            }
            OpenstackAPI openstack = new OpenstackAPI();
            openstack.createImage(serverIP, scopeToken, fileName);
        }

        private void buttonRemoveImg_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Selecione uma imagem para remover");
                return;
            }
            var imageName = listBox1.SelectedItem.ToString();
            imageName = imageName.Substring(0,imageName.LastIndexOf("."));
            Console.WriteLine(imageName);
            var imageID = "";
            foreach (JToken image in imageList)
            {
                if ((string)image.SelectToken("name") == imageName)
                {
                    imageID = (string)image.SelectToken("id");
                    break;
                }

            }
            OpenstackAPI openstack = new OpenstackAPI();
            var response =openstack.removeImage(serverIP,scopeToken,imageID);
            HttpStatusCode statusCode = response.StatusCode;
            int numericStatusCode = (int)statusCode;
            Console.WriteLine(numericStatusCode);
            if (numericStatusCode != 204)
            {
                MessageBox.Show(response.StatusCode.ToString());
                return;
            }
            else
            {
                MessageBox.Show("Removido com sucesso");
                listBox1.Items.Remove(listBox1.SelectedItem);
            }

        }
    }
}
