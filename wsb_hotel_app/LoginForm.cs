using System;
using System.Drawing;
using System.IO;
using System.Net;
using System.Windows.Forms;

namespace wsb_hotel_app
{
    public partial class LoginForm : Form
    {
        private Label titleLabel;
        private Label emailLabel;
        private TextBox emailTextBox;
        private Label passwordLabel;
        private TextBox passwordTextBox;
        private Button loginButton;
        private Label registerInfoLabel;
        private PictureBox roomImage;
        private DatabaseManager databaseManager;

        public LoginForm()
        {
            InitializeComponent();
            InitializeComponents();
            ApplyCustomStyles();
            databaseManager = new DatabaseManager();
            databaseManager.InitializeDatabase();
        }

        private void InitializeComponents()
        {
          
            titleLabel = new Label();
            titleLabel.Text = "Logowanie";
            titleLabel.Font = new Font("Arial Black", 16f);
            titleLabel.TextAlign = ContentAlignment.TopCenter;
            titleLabel.AutoSize = false;
            titleLabel.Size = new Size(320, 40);
            titleLabel.Location = new Point(0, 20);

            emailLabel = new Label();
            emailLabel.Text = "Email:";
            emailLabel.Location = new Point(50, 100);
            emailLabel.Font = new Font("Arial", 12f);

            emailTextBox = new TextBox();
            emailTextBox.Location = new Point(50, 130);
            emailTextBox.Size = new Size(200, 25);
            emailTextBox.Font = new Font("Arial", 10f);

            passwordLabel = new Label();
            passwordLabel.Text = "Hasło:";
            passwordLabel.Location = new Point(50, 170);
            passwordLabel.Font = new Font("Arial", 12f);

            passwordTextBox = new TextBox();
            passwordTextBox.Location = new Point(50, 200);
            passwordTextBox.Size = new Size(200, 25);
            passwordTextBox.Font = new Font("Arial", 10f);
            passwordTextBox.PasswordChar = '*';

            loginButton = new Button();
            loginButton.Text = "Zaloguj się";
            loginButton.Location = new Point(50, 240);
            loginButton.Size = new Size(200, 30);
            loginButton.Font = new Font("Arial", 12f, FontStyle.Bold);
            loginButton.FlatStyle = FlatStyle.Flat;
            loginButton.FlatAppearance.BorderColor = Color.Black;
            loginButton.FlatAppearance.BorderSize = 2;
            loginButton.MouseEnter += (sender, e) => loginButton.BackColor = Color.LightBlue;
            loginButton.MouseLeave += (sender, e) => loginButton.BackColor = Color.White;
            loginButton.Click += loginButton_Click;

            registerInfoLabel = new Label();
            registerInfoLabel.Text = "Nie masz jeszcze konta? Zarejestruj się!";
            registerInfoLabel.Font = new Font("Arial", 10f);
            registerInfoLabel.AutoSize = true;
            registerInfoLabel.Location = new Point(50, 290);
            registerInfoLabel.Cursor = Cursors.Hand;
            registerInfoLabel.Font = new Font(registerInfoLabel.Font, FontStyle.Underline);
            registerInfoLabel.ForeColor = Color.Blue;

        
            Controls.Add(titleLabel);
            Controls.Add(emailLabel);
            Controls.Add(emailTextBox);
            Controls.Add(passwordLabel);
            Controls.Add(passwordTextBox);
            Controls.Add(loginButton);
            Controls.Add(registerInfoLabel);


            roomImage = new PictureBox();
            roomImage.Location = new Point(340, 80);
            roomImage.Size = new Size(400, 400);
            roomImage.SizeMode = PictureBoxSizeMode.Zoom;
            LoadImageFromUrl("https://img.freepik.com/free-vector/friendly-receptionists-from-hotel-registration-desk-help-clients_74855-4420.jpg?t=st=1717852009~exp=1717855609~hmac=6aca5741021bf8d40a255bbe9cb32c4e1cea94d8e00cb07d619233e4ba81a036&w=1380"); // Ustaw URL obrazka

            Controls.Add(roomImage);

            registerInfoLabel.Click += (sender, e) => {
                Hide();
                RegisterForm registerForm = new RegisterForm();
                registerForm.Show();
            };
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
          
            if (string.IsNullOrEmpty(emailTextBox.Text) ||
                string.IsNullOrEmpty(passwordTextBox.Text))
            {
                MessageBox.Show("Wszystkie pola są wymagane!", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

           
            string email = emailTextBox.Text;
            string password = passwordTextBox.Text;
            if (databaseManager.AuthenticateUser(email, password))
            {
                MessageBox.Show("Zalogowano pomyślnie!", "Sukces", MessageBoxButtons.OK, MessageBoxIcon.Information);

       
                Hide();
                MainViewForm mainViewForm = new MainViewForm();
                mainViewForm.Show();
            }
            else
            {
                MessageBox.Show("Nieprawidłowy adres e-mail lub hasło.", "Błąd logowania", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ApplyCustomStyles()
        {
           
            BackColor = Color.White; 
            Font = new Font("Arial", 10f);
            Size = new Size(900, 650);
        }

        private void LoadImageFromUrl(string url)
        {
            using (WebClient webClient = new WebClient())
            {
                byte[] data = webClient.DownloadData(url);
                using (MemoryStream mem = new MemoryStream(data))
                {
                    roomImage.Image = Image.FromStream(mem);
                }
            }
        }

    }
}
