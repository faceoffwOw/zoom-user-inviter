using RestSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System.IO;
using System.Net.Http;
using Newtonsoft.Json.Linq;
using System.DirectoryServices;
using zoom.Properties;

namespace zoom
{
    public partial class Form1 : Form
    {
        string status = "";
        bool check_search = false;
        bool check_create = false;

        public Form1()
        {
            InitializeComponent();
            
            /*var client = new RestClient("https://api.zoom.us/v2/users/isergeev@aobko.ru");
            var request = new RestRequest(Method.GET);
            request.AddHeader("authorization", "Bearer " + ZoomToken());
            IRestResponse response = client.Execute(request);

            //MessageBox.Show(response.Content);
            User user = JsonConvert.DeserializeObject<User>(response.Content);

            MessageBox.Show(user.first_name);*/

        }

        public static string ZoomToken()
        {
            // Token will be good for 20 minutes
            DateTime Expiry = DateTime.UtcNow.AddMinutes(20);

            string ApiKey = "ApiKey";
            string ApiSecret = "ApiSecret";

            int ts = (int)(Expiry - new DateTime(1970, 1, 1)).TotalSeconds;

            // Create Security key  using private key above:
            var securityKey = new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(Encoding.UTF8.GetBytes(ApiSecret));

            // length should be >256b
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            //Finally create a Token
            var header = new JwtHeader(credentials);

            //Zoom Required Payload
            var payload = new JwtPayload
            {
                { "iss", ApiKey},
                { "exp", ts },
            };

            var secToken = new JwtSecurityToken(header, payload);
            var handler = new JwtSecurityTokenHandler();

            // Token to String so you can use it in your client
            var tokenString = handler.WriteToken(secToken);

            return tokenString;
        }

        public void CreateUser()
        {
            try
            {
                var client = new RestClient("https://api.zoom.us/v2/users");
                var request = new RestRequest(Method.POST);
                request.AddHeader("content-type", "application/json");
                request.AddHeader("authorization", "Bearer " + ZoomToken());

                JObject user_info = new JObject();
                user_info.Add("email", textBox_email.Text);
                user_info.Add("type", "1");
                user_info.Add("first_name", textBox_surname.Text);
                user_info.Add("last_name", textBox_name.Text);
                //user_info.Add("password", "Ps123456"); // need action = autoCreate

                JObject Action = new JObject();

                if (check_email.Checked == true)
                {
                    Action.Add("action", "autoCreate");
                    user_info.Add("password", "Ps123456");
                }
                else
                {
                    Action.Add("action", "create");
                }

                //Action.Add("action", "create");
                Action.Add("user_info", user_info);

                request.AddParameter("application/json", Action, ParameterType.RequestBody);
                IRestResponse response = client.Execute(request);

                int c = (int)response.StatusCode;
                string s = c.ToString();

                switch ((int)response.StatusCode)
                {
                    case 201:
                        //MessageBox.Show(response.StatusCode.ToString());
                        status = "Пользователь\nдобавлен";
                        button_create.Image = Resources.check;//Image.FromFile(@"C:\Users\isergeev\source\repos\zoom\zoom\Images\check.png");
                        button_create.ImageAlign = ContentAlignment.MiddleLeft;
                        button_create.Text = status;
                        button_search.TextAlign = ContentAlignment.MiddleCenter;
                        break;
                    case 409:
                        MessageBox.Show("Пользователь уже существует");
                        break;
                    default:
                        MessageBox.Show("неизвестно");
                        break;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        public void DefaultParameters()
        {
            try
            {
                JObject more_info = new JObject();
                more_info.Add("language", "ru-RU");
                more_info.Add("timezone", "Europe/Moscow");
                more_info.Add("location", "Боровичи");
                more_info.Add("dept", textBox_departament.Text);

                var client_update = new RestClient("https://api.zoom.us/v2/users/" + textBox_email.Text);
                var request_update = new RestRequest(Method.PATCH);
                request_update.AddHeader("content-type", "application/json");
                request_update.AddHeader("authorization", "Bearer " + ZoomToken());
                request_update.AddParameter("application/json", more_info, ParameterType.RequestBody);
                IRestResponse response_update = client_update.Execute(request_update);

                if(response_update.StatusCode.ToString() != "NoContent")
                {
                    Root error = JsonConvert.DeserializeObject<Root>(response_update.Content);
                    MessageBox.Show("Обновление информации о пользователе" + "\n" + "Ошибка: " + error.code.ToString() + "\n" + error.message);
                }
                
            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public Bitmap MakeSquarePhoto(Bitmap bmp, int size)
        {
            try
            {
                Bitmap res = new Bitmap(size, size);
                Graphics g = Graphics.FromImage(res);
                g.FillRectangle(new SolidBrush(Color.White), 0, 0, size, size);
                int t = 0, l = 0;
                if (bmp.Height > bmp.Width)
                    t = (bmp.Height - bmp.Width) / 8;
                else
                    l = (bmp.Width - bmp.Height) / 8;
                g.DrawImage(bmp, new Rectangle(0, 0, size, size), new Rectangle(l, t, bmp.Width - l * 8, bmp.Height - t * 8), GraphicsUnit.Pixel);
                return res;
            }
            catch
            {
                return null;
            }
        }

        public void UploadPicture()
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\" + textBox_personnel_number.Text + "_tmp.jpg";

            var client_pic = new RestClient("https://api.zoom.us/v2/users/" + textBox_email.Text + "/picture");
            var request_pic = new RestRequest(Method.POST);
            request_pic.AddFile("pic_file", path);
            request_pic.AddHeader("content-type", "multipart/form-data");
            request_pic.AddHeader("authorization", "Bearer " + ZoomToken());
            IRestResponse response_pic = client_pic.Execute(request_pic);

            File.Delete(path);
        }

        public void AD_user_properties()
        {
            DirectoryEntry entry = new DirectoryEntry("LDAP://bko.borovichi-nov.ru");
            DirectorySearcher dSearch = new DirectorySearcher(entry);
            string name = textBox_network_name.Text;
            dSearch.Filter = "(&(objectClass=user)(cn=" + name + "))";

            // get all entries from the active directory.
            // Last Name, name, initial, homepostaladdress, title, company etc..

            try
            {
                foreach (SearchResult sResultSet in dSearch.FindAll())
                {
                    // email address
                    textBox_email.Text = GetProperty(sResultSet, "mail");
                    // Full Name
                    string givenName = GetProperty(sResultSet, "givenName");
                    string[] full_name = givenName.Split(new char[] { ' ' });
                    textBox_surname.Text = full_name[0];
                    textBox_name.Text = full_name[1];
                    //departament
                    textBox_departament.Text = GetProperty(sResultSet, "department");
                    //Room (табельный номер)
                    textBox_personnel_number.Text = GetProperty(sResultSet, "physicalDeliveryOfficeName");
                }

                //myPictureBox.Image = Image.FromStream(new MemoryStream(File.ReadAllBytes(strImageFile)));

                pictureBox1.Image = Image.FromStream(new MemoryStream(File.ReadAllBytes(@"\\nas_gto\GTO\zoom project\фото сотрудников\" + textBox_personnel_number.Text + ".jpg")));
                //pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                int size = 500;
                Bitmap bmp = new Bitmap(pictureBox1.Image);
                pictureBox1.Image = MakeSquarePhoto(bmp, size);
                string path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\" + textBox_personnel_number.Text + "_tmp.jpg";
                pictureBox1.Image.Save(path);
                pictureBox1.Image = Image.FromStream(new MemoryStream(File.ReadAllBytes(path)));

                button_search.Image = Resources.check;//Image.FromFile(@"C:\Users\isergeev\source\repos\zoom\zoom\Images\check.png");
                button_search.ImageAlign = ContentAlignment.MiddleLeft;
                button_search.Text = "Пользователь\nнайден";
                button_search.TextAlign = ContentAlignment.MiddleCenter;
            }
            catch (Exception ex)
            {
                button_search.Image = Resources.close;//Image.FromFile(@"C:\Users\isergeev\source\repos\zoom\zoom\Images\close.png");
                button_search.ImageAlign = ContentAlignment.MiddleLeft;
                button_search.Text = "Пользователь\nне найден";
                button_search.TextAlign = ContentAlignment.MiddleCenter;
            }

            
        }

        public static string GetProperty(SearchResult searchResult, string PropertyName)
        {
            if (searchResult.Properties.Contains(PropertyName))
            {
                return searchResult.Properties[PropertyName][0].ToString();
            }
            else
            {
                return string.Empty;
            }
        }
        private void button_search_Click(object sender, EventArgs e)
        {
            if (check_search == false) 
            {
                AD_user_properties();
                check_search = true;
            }
            else
            {
                string path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\" + textBox_personnel_number.Text + "_tmp.jpg";
                File.Delete(path);

                textBox_network_name.Clear();
                button_search.Text = "Поиск";
                button_search.Image = Resources.search; //Image.FromFile(@"Images\search.png");
                button_search.TextAlign = ContentAlignment.MiddleCenter;
                button_search.ImageAlign = ContentAlignment.MiddleLeft;

                textBox_departament.Clear();
                textBox_email.Clear();
                textBox_name.Clear();
                textBox_personnel_number.Clear();
                textBox_surname.Clear();
                button_create.Text = "Добавить\nпользователя";
                button_create.TextAlign = ContentAlignment.MiddleCenter;
                button_create.Image = Resources.add_user; //Image.FromFile(@"Images\add_user.png");
                button_create.ImageAlign = ContentAlignment.MiddleLeft;
                check_search = false;
                check_create = false;

            }
        }

        private void button_create_Click(object sender, EventArgs e)
        {
            if(check_create == false)
            {
                CreateUser();
                DefaultParameters();

                if(upload_photo_manually.Checked == false)
                {
                    UploadPicture();
                }
                
                check_create = true;
            }
            else
            {
                textBox_departament.Clear();
                textBox_email.Clear();
                textBox_name.Clear();
                textBox_personnel_number.Clear();
                textBox_surname.Clear();
                button_create.Text = "Добавить\nпользователя";
                button_create.TextAlign = ContentAlignment.MiddleCenter;
                button_create.Image = Resources.add_user; //Image.FromFile(@"C:\Users\isergeev\source\repos\zoom\zoom\Images\add_user.png");
                button_create.ImageAlign = ContentAlignment.MiddleLeft;
                check_create = false;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void textBox_network_name_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox_network_name.Text))
            {
                pictureBox1.Image = Resources.face;//Image.FromFile(@"C:\Users\isergeev\source\repos\zoom\zoom\Images\face.png");

                string path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\" + textBox_personnel_number.Text + "_tmp.jpg";
                File.Delete(path);

                textBox_network_name.Clear();
                button_search.Text = "Поиск";
                button_search.Image = Resources.search;//Image.FromFile(@"C:\Users\isergeev\source\repos\zoom\zoom\Images\search.png");
                button_search.TextAlign = ContentAlignment.MiddleCenter;
                button_search.ImageAlign = ContentAlignment.MiddleLeft;

                textBox_departament.Clear();
                textBox_email.Clear();
                textBox_name.Clear();
                textBox_personnel_number.Clear();
                textBox_surname.Clear();
                button_create.Text = "Добавить\nпользователя";
                button_create.TextAlign = ContentAlignment.MiddleCenter;
                button_create.Image = Resources.add_user;//Image.FromFile(@"C:\Users\isergeev\source\repos\zoom\zoom\Images\add_user.png");
                button_create.ImageAlign = ContentAlignment.MiddleLeft;
                check_search = false;
            }
        }
    }
}
