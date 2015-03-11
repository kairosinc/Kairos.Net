using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SampleApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Kairos.API.KairosClient client = new Kairos.API.KairosClient();

            client.ApplicationID = "6e84090a";
            client.ApplicationKey = "a339642569b8d8d30da6f75b484d904b";

            // Detect the face(s)
            var detectResponse = client.Detect("https://rekognition.com/static/img/demo/people.jpg", "SETPOSE");

            // Get the image and face information
            var detectImage = detectResponse.Images[0];
            var face = detectImage.Faces[0];

            // Enroll the user
            var enrollResponse = client.Enroll("https://rekognition.com/static/img/demo/people.jpg", "girl_test", "gallerytest1", "SETPOSE");

            // Get the user enrollment transaction info
            var userImage = enrollResponse.Images[0].Transaction;

            // Recognize the user
            var user = client.Recognize("girl_test", "gallerytest1" );

            // Detected user ID
            var userID = user.Images[0].Candidates.First().Key;

            MessageBox.Show(userID.ToString());

        }
    }
}
