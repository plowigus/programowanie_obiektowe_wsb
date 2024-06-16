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
            // Konfiguracja przycisku "Zarejestruj się"
            registerButton = new Button();
            registerButton.Text = "Zarejestruj się";
            registerButton.Size = new Size(200, 50);
            registerButton.Font = new Font("Arial", 12f);
            registerButton.FlatStyle = FlatStyle.Flat;
            registerButton.FlatAppearance.BorderColor = Color.Black;
            registerButton.FlatAppearance.BorderSize = 2;
            registerButton.Click += registerButton_Click;

            // Konfiguracja przycisku "Zaloguj się"
            loginButton = new Button();
            loginButton.Text = "Zaloguj się";
            loginButton.Size = new Size(200, 50);
            loginButton.Font = new Font("Arial", 12f);
            loginButton.FlatStyle = FlatStyle.Flat;
            loginButton.FlatAppearance.BorderColor = Color.Black;
            loginButton.FlatAppearance.BorderSize = 2;
            loginButton.Click += loginButton_Click;

            // Ustawienie położenia przycisków
            registerButton.Location = new Point((ClientSize.Width - registerButton.Width - loginButton.Width - 50) / 2, ClientSize.Height - registerButton.Height - 50);
            loginButton.Location = new Point(registerButton.Right + 50, registerButton.Top);

            // Dodaj przyciski do formularza
            Controls.Add(registerButton);
            Controls.Add(loginButton);

            // Konfiguracja obrazka powitalnego
            welcomeImage = new PictureBox();
            welcomeImage.Location = new Point((ClientSize.Width - 400) / 2, (ClientSize.Height - 400 - registerButton.Height - 100) / 2);
            welcomeImage.Size = new Size(400, 400);
            welcomeImage.SizeMode = PictureBoxSizeMode.Zoom;
            LoadImageFromUrl("https://img.freepik.com/free-vector/flat-hotel-building-illustration_23-2148147152.jpg?t=st=1717853832~exp=1717857432~hmac=eb3e5af4f505fc56df415bc62f42542d4ff93844bfdbb993606f7cb0440c94f2&w=826");

            // Dodaj obrazek do formularza
            Controls.Add(welcomeImage);
        }

        private void registerButton_Click(object sender, EventArgs e)
        {
            // Przejdź do formularza rejestracji
            RegisterForm registerForm = new RegisterForm();
            registerForm.Show();
            this.Hide();
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            // Przejdź do formularza logowania
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
            this.Hide();
        }

        private void ApplyCustomStyles()
        {
            // Stylizacja formularza
            FormBorderStyle = FormBorderStyle.FixedSingle; // Zablokowanie zmiany rozmiaru formularza
            Text = "Ekran powitalny"; // Tytuł formularza
            StartPosition = FormStartPosition.CenterScreen; // Wyśrodkowanie formularza na ekranie
            BackColor = Color.White; // Białe tło
            Font = new Font("Arial", 10f);
            Size = new Size(900, 650); // Ustawienie rozmiaru formularza na 900x650 pikseli
        }

        private void LoadImageFromUrl(string url)
        {
            // Ładowanie obrazka z podanego URL
            using (var webClient = new System.Net.WebClient())
            {
                var stream = new System.IO.MemoryStream(webClient.DownloadData(url));
                welcomeImage.Image = Image.FromStream(stream);
            }
        }
    }
}
