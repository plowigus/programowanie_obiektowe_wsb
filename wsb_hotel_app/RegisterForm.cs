using System;
using System.Drawing;
using System.IO;
using System.Net;
using System.Windows.Forms;

namespace wsb_hotel_app
{
    public partial class RegisterForm : Form
    {
        private Label titleLabel;
        private Label firstNameLabel;
        private TextBox firstNameTextBox;
        private Label lastNameLabel;
        private TextBox lastNameTextBox;
        private Label emailLabel;
        private TextBox emailTextBox;
        private Label passwordLabel;
        private TextBox passwordTextBox;
        private Button registerButton;
        private Label loginInfoLabel;
        private PictureBox roomImage;
        private DatabaseManager databaseManager = new DatabaseManager();

        public RegisterForm()
        {
            InitializeComponent();
            InitializeComponents();
            ApplyCustomStyles();
            databaseManager.InitializeDatabase();
        }

        private void InitializeComponents()
        {


            
            titleLabel = new Label();
            titleLabel.Text = "Rejestracja";
            titleLabel.Font = new Font("Arial Black", 16f);
            titleLabel.TextAlign = ContentAlignment.TopCenter;
            titleLabel.AutoSize = false;
            titleLabel.Size = new Size(320, 40);
            titleLabel.Location = new Point(0, 20);

            firstNameLabel = new Label();
            firstNameLabel.Text = "Imię:";
            firstNameLabel.Location = new Point(50, 100);
            firstNameLabel.Font = new Font("Arial", 12f);

            firstNameTextBox = new TextBox();
            firstNameTextBox.Location = new Point(50, 130);
            firstNameTextBox.Size = new Size(200, 25);
            firstNameTextBox.Font = new Font("Arial", 10f);

            lastNameLabel = new Label();
            lastNameLabel.Text = "Nazwisko:";
            lastNameLabel.Location = new Point(50, 170);
            lastNameLabel.Font = new Font("Arial", 12f);

            lastNameTextBox = new TextBox();
            lastNameTextBox.Location = new Point(50, 200);
            lastNameTextBox.Size = new Size(200, 25);
            lastNameTextBox.Font = new Font("Arial", 10f);

            emailLabel = new Label();
            emailLabel.Text = "Email:";
            emailLabel.Location = new Point(50, 240);
            emailLabel.Font = new Font("Arial", 12f);

            emailTextBox = new TextBox();
            emailTextBox.Location = new Point(50, 270);
            emailTextBox.Size = new Size(200, 25);
            emailTextBox.Font = new Font("Arial", 10f);

            passwordLabel = new Label();
            passwordLabel.Text = "Hasło:";
            passwordLabel.Location = new Point(50, 310);
            passwordLabel.Font = new Font("Arial", 12f);

            passwordTextBox = new TextBox();
            passwordTextBox.Location = new Point(50, 340);
            passwordTextBox.Size = new Size(200, 25);
            passwordTextBox.Font = new Font("Arial", 10f);
            passwordTextBox.PasswordChar = '*';

            registerButton = new Button();
            registerButton.Text = "Zarejestruj";
            registerButton.Location = new Point(50, 390);
            registerButton.Size = new Size(200, 30);
            registerButton.Font = new Font("Arial", 12f, FontStyle.Bold);
            registerButton.FlatStyle = FlatStyle.Flat;
            registerButton.FlatAppearance.BorderColor = Color.Black;
            registerButton.FlatAppearance.BorderSize = 2;
            registerButton.MouseEnter += (sender, e) => registerButton.BackColor = Color.LightBlue;
            registerButton.MouseLeave += (sender, e) => registerButton.BackColor = Color.White;
            registerButton.Click += registerButton_Click;

            loginInfoLabel = new Label();
            loginInfoLabel.Text = "Masz już konto? Zaloguj się!";
            loginInfoLabel.Font = new Font("Arial", 10f);
            loginInfoLabel.AutoSize = true;
            loginInfoLabel.Location = new Point(50, 450);
            loginInfoLabel.Cursor = Cursors.Hand;
            loginInfoLabel.Font = new Font(loginInfoLabel.Font, FontStyle.Underline);
            loginInfoLabel.ForeColor = Color.Blue;


           
            Controls.Add(titleLabel);
            Controls.Add(firstNameLabel);
            Controls.Add(firstNameTextBox);
            Controls.Add(lastNameLabel);
            Controls.Add(lastNameTextBox);
            Controls.Add(emailLabel);
            Controls.Add(emailTextBox);
            Controls.Add(passwordLabel);
            Controls.Add(passwordTextBox);
            Controls.Add(registerButton);
            Controls.Add(loginInfoLabel);



            roomImage = new PictureBox();
            roomImage.Location = new Point(340, 80);
            roomImage.Size = new Size(400, 400);
            roomImage.SizeMode = PictureBoxSizeMode.Zoom;
            LoadImageFromUrl("https://img.freepik.com/free-vector/friendly-receptionists-from-hotel-registration-desk-help-clients_74855-4420.jpg?t=st=1717852009~exp=1717855609~hmac=6aca5741021bf8d40a255bbe9cb32c4e1cea94d8e00cb07d619233e4ba81a036&w=1380"); // Ustaw URL obrazka


            Controls.Add(roomImage);

            loginInfoLabel.Click += (sender, e) => {
                Hide();
                LoginForm loginForm = new LoginForm();
                loginForm.Show();

            };
        }

        private void registerButton_Click(object sender, EventArgs e)
        {
            
            if (!ValidateInput())
            {
                return;
            }

            
            string firstName = firstNameTextBox.Text.Trim();
            string lastName = lastNameTextBox.Text.Trim();
            string email = emailTextBox.Text.Trim();
            string password = passwordTextBox.Text;

            
            DatabaseManager dbManager = new DatabaseManager();
            dbManager.InitializeDatabase();

            if (dbManager.CheckUserExists(email))
            {
                MessageBox.Show("Użytkownik o podanym adresie email już istnieje!", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            dbManager.AddUser(firstName, lastName, email, password);

            MessageBox.Show("Rejestracja zakończona pomyślnie!", "Sukces", MessageBoxButtons.OK, MessageBoxIcon.Information);

            
            Hide();
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
        }

        private bool ValidateInput()
        {
            string firstName = firstNameTextBox.Text.Trim();
            string lastName = lastNameTextBox.Text.Trim();
            string email = emailTextBox.Text.Trim();
            string password = passwordTextBox.Text;

            
            if (firstName.Length < 3 || lastName.Length < 3)
            {
                MessageBox.Show("Imię i nazwisko muszą mieć przynajmniej 3 znaki!", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            
            if (!IsValidEmail(email))
            {
                MessageBox.Show("Nieprawidłowy adres email!", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            
            if (password.Length < 6)
            {
                MessageBox.Show("Hasło musi mieć przynajmniej 6 znaków!", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
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
