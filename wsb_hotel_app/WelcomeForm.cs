
using System;
using System.Drawing;
using System.Windows.Forms;

namespace wsb_hotel_app
{
   
    public partial class WelcomeForm : Form
    {
      
        private Button registerButton;
        private Button loginButton;
        private PictureBox welcomeImage;

    
        public WelcomeForm()
        {
            InitializeComponent();
            InitializeComponents();
            ApplyCustomStyles();
        }

        
        private void InitializeComponents()
        {
            
            registerButton = new Button();
            registerButton.Text = "Zarejestruj się";
            registerButton.Size = new Size(200, 50);
            registerButton.Font = new Font("Arial", 12f);
            registerButton.FlatStyle = FlatStyle.Flat;
            registerButton.FlatAppearance.BorderColor = Color.Black;
            registerButton.FlatAppearance.BorderSize = 2;
            registerButton.Click += registerButton_Click;

           
            loginButton = new Button();
            loginButton.Text = "Zaloguj się";
            loginButton.Size = new Size(200, 50);
            loginButton.Font = new Font("Arial", 12f);
            loginButton.FlatStyle = FlatStyle.Flat;
            loginButton.FlatAppearance.BorderColor = Color.Black;
            loginButton.FlatAppearance.BorderSize = 2;
            loginButton.Click += loginButton_Click;

          
            registerButton.Location = new Point((ClientSize.Width - registerButton.Width - loginButton.Width - 50) / 2, ClientSize.Height - registerButton.Height - 50);
            loginButton.Location = new Point(registerButton.Right + 50, registerButton.Top);

           
            Controls.Add(registerButton);
            Controls.Add(loginButton);

            
            welcomeImage = new PictureBox();
            welcomeImage.Location = new Point((ClientSize.Width - 400) / 2, (ClientSize.Height - 400 - registerButton.Height - 100) / 2);
            welcomeImage.Size = new Size(400, 400);
            welcomeImage.SizeMode = PictureBoxSizeMode.Zoom;
            LoadImageFromUrl("https://img.freepik.com/free-vector/flat-hotel-building-illustration_23-2148147152.jpg?t=st=1717853832~exp=1717857432~hmac=eb3e5af4f505fc56df415bc62f42542d4ff93844bfdbb993606f7cb0440c94f2&w=826");

            
            Controls.Add(welcomeImage);
        }

        
        private void registerButton_Click(object sender, EventArgs e)
        {
            
            RegisterForm registerForm = new RegisterForm();
            registerForm.Show();
            this.Hide();
        }

       
        private void loginButton_Click(object sender, EventArgs e)
        {
           
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
            this.Hide();
        }

       
        private void ApplyCustomStyles()
        {
            
            FormBorderStyle = FormBorderStyle.FixedSingle; 
            Text = "Ekran powitalny"; 
            StartPosition = FormStartPosition.CenterScreen; 
            BackColor = Color.White; 
            Font = new Font("Arial", 10f);
            Size = new Size(900, 650); 
        }

       
        private void LoadImageFromUrl(string url)
        {
            
            using (var webClient = new System.Net.WebClient())
            {
                var stream = new System.IO.MemoryStream(webClient.DownloadData(url));
                welcomeImage.Image = Image.FromStream(stream);
            }
        }
    }
}