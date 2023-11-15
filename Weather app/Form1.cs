using System.Xml.Linq;
using System.Drawing;
namespace Weather_app
{
    public partial class Form1 : Form
    {
        String city;
        String icon;
        DateOnly date;
        TimeOnly time;
        int time_counter = 0;
        public Form1()
        {
            InitializeComponent();
            label5.Hide();
            date = DateOnly.FromDateTime(DateTime.Now);
            time = TimeOnly.FromDateTime(DateTime.Now);
            label2.Text = " " + time;
            label3.Text = " " + date;
            timer1.Start();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                city = textBox1.Text;


                string api = "7476ef59fa2c3403e075f8ead0d5017f";
                string connection = "http://api.openweathermap.org/data/2.5/weather?q=" + city + "&mode=xml&lang=tr&units=metric&appid=" + api+"&ctn=8";

                XDocument weather = XDocument.Load(connection);
                var temp = weather.Descendants("temperature").ElementAt(0).Attribute("value").Value;
                var type = weather.Descendants("clouds").ElementAt(0).Attribute("name").Value;



                if (type.Equals("az bulutlu") || type.Equals("parçalı bulutlu"))
                {

                    Image newImage = Image.FromFile("C://Users//ibrah//Desktop//icons8-clouds-48.png");

                    pictureBox2.Image = newImage;
                    label5.Text = temp + " " + type;
                    label5.Show();


                }

                if (type.Equals("açık"))
                {

                    Image newImage = Image.FromFile("C://Users//ibrah//Desktop//icons8-sunny-48.png");

                    pictureBox2.Image = newImage;

                    label5.Text = temp + " " + type;
                    label5.Show();

                }






            }

            catch (Exception be)
            {

                MessageBox.Show(be.Message);
            }



        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (time_counter == 60)
            {

                TimeOnly t = TimeOnly.FromDateTime(DateTime.Now);
                DateOnly d = DateOnly.FromDateTime(DateTime.Now);

                label2.Text = "" + t;
                label3.Text = "" + d;
                time_counter = 0;


            }
            time_counter++;
        }
    }
}