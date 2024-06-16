using System;
using System.Drawing;
using System.IO;
using System.Net;
using System.Windows.Forms;

namespace wsb_hotel_app
{
    public partial class AddRoomForm : Form
    {
        private Label titleLabel;
        private Label roomNumberLabel;
        private TextBox roomNumberTextBox;
        private Label roomTypeLabel;
        private ComboBox roomTypeComboBox;
        private Label pricePerNightLabel;
        private TextBox pricePerNightTextBox;
        private Button addButton;
        private Button backButton;
        private PictureBox roomImage;
        private HotelDatabaseManager databaseManager;

        public AddRoomForm()
        {
            InitializeComponent();
            InitializeComponents();
            ApplyCustomStyles();
            databaseManager = new HotelDatabaseManager();
            databaseManager.InitializeDatabase();
        }

        private void InitializeComponents()
        {
            // Konfiguracja kontrolek
            titleLabel = new Label();
            titleLabel.Text = "Dodawanie pokoju";
            titleLabel.Font = new Font("Arial Black", 16f);
            titleLabel.TextAlign = ContentAlignment.TopCenter;
            titleLabel.AutoSize = false;
            titleLabel.Size = new Size(320, 40);
            titleLabel.Location = new Point(0, 20);

            roomNumberLabel = new Label();
            roomNumberLabel.Text = "Numer pokoju:";
            roomNumberLabel.Location = new Point(50, 80);
            roomNumberLabel.Font = new Font("Arial Black", 12f);

            roomNumberTextBox = new TextBox();
            roomNumberTextBox.Location = new Point(50, 110);
            roomNumberTextBox.Size = new Size(200, 30);
            roomNumberTextBox.Font = new Font("Arial Black", 12f);

            roomTypeLabel = new Label();
            roomTypeLabel.Text = "Typ pokoju:";
            roomTypeLabel.Location = new Point(50, 150);
            roomTypeLabel.Font = new Font("Arial Black", 12f);

            roomTypeComboBox = new ComboBox();
            roomTypeComboBox.Location = new Point(50, 180);
            roomTypeComboBox.Size = new Size(200, 30);
            roomTypeComboBox.Font = new Font("Arial Black", 12f);
            roomTypeComboBox.DropDownStyle = ComboBoxStyle.DropDownList;

            // Symulacja danych dla rodzaju pokoju
            roomTypeComboBox.Items.Add("Pojedynczy");
            roomTypeComboBox.Items.Add("Podwójny");
            roomTypeComboBox.Items.Add("Apartament");

            pricePerNightLabel = new Label();
            pricePerNightLabel.Text = "Cena za noc:";
            pricePerNightLabel.Location = new Point(50, 220);
            pricePerNightLabel.Font = new Font("Arial Black", 12f);

            pricePerNightTextBox = new TextBox();
            pricePerNightTextBox.Location = new Point(50, 250);
            pricePerNightTextBox.Size = new Size(200, 30);
            pricePerNightTextBox.Font = new Font("Arial Black", 12f);

            addButton = new Button();
            addButton.Text = "Dodaj";
            addButton.Location = new Point(50, 300);
            addButton.Size = new Size(200, 40);
            addButton.Font = new Font("Arial Black", 12f);
            addButton.FlatStyle = FlatStyle.Flat;
            addButton.FlatAppearance.BorderColor = Color.Black;
            addButton.FlatAppearance.BorderSize = 2;
            addButton.MouseEnter += (sender, e) => addButton.BackColor = Color.LightSkyBlue;
            addButton.MouseLeave += (sender, e) => addButton.BackColor = Color.White;
            addButton.Click += addButton_Click;

            backButton = new Button();
            backButton.Text = "Powrót";
            backButton.Location = new Point(50, 350);
            backButton.Size = new Size(200, 40);
            backButton.Font = new Font("Arial Black", 12f);
            backButton.FlatStyle = FlatStyle.Flat;
            backButton.FlatAppearance.BorderColor = Color.Black;
            backButton.FlatAppearance.BorderSize = 2;
            backButton.MouseEnter += (sender, e) => backButton.BackColor = Color.LightSkyBlue;
            backButton.MouseLeave += (sender, e) => backButton.BackColor = Color.White;
            backButton.Click += backButton_Click;

            // Dodaj kontrolki do formularza
            Controls.Add(titleLabel);
            Controls.Add(roomNumberLabel);
            Controls.Add(roomNumberTextBox);
            Controls.Add(roomTypeLabel);
            Controls.Add(roomTypeComboBox);
            Controls.Add(pricePerNightLabel);
            Controls.Add(pricePerNightTextBox);
            Controls.Add(addButton);
            Controls.Add(backButton);

            roomImage = new PictureBox();
            roomImage.Location = new Point(340, 80);
            roomImage.Size = new Size(200, 400);
            roomImage.SizeMode = PictureBoxSizeMode.Zoom;
            LoadImageFromUrl("https://img.freepik.com/free-vector/hotel-tower-concept-illustration_114360-17162.jpg?t=st=1717850210~exp=1717853810~hmac=94bea5e51b6cc7fba420d3942405c1aa327ca6d094c3737203517363bd253272&w=826"); // Ustaw URL obrazka

            Controls.Add(roomImage);
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            // Walidacja pól formularza
            if (string.IsNullOrEmpty(roomNumberTextBox.Text) ||
                string.IsNullOrEmpty(roomTypeComboBox.Text) ||
                string.IsNullOrEmpty(pricePerNightTextBox.Text))
            {
                MessageBox.Show("Wszystkie pola są wymagane!", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Walidacja numeru pokoju
            if (!int.TryParse(roomNumberTextBox.Text, out int roomNumber) || roomNumber <= 0)
            {
                MessageBox.Show("Numer pokoju musi być dodatnią liczbą całkowitą!", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Walidacja ceny
            if (!double.TryParse(pricePerNightTextBox.Text, out double pricePerNight) || pricePerNight <= 0)
            {
                MessageBox.Show("Cena za noc musi być dodatnią liczbą!", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Obsługa dodawania nowego pokoju
            string roomType = roomTypeComboBox.Text;
            bool isAvailable = true; // Nowy pokój jest domyślnie dostępny

            databaseManager.AddRoom(roomNumber, roomType, pricePerNight, isAvailable);
            MessageBox.Show("Dodano nowy pokój!", "Sukces", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            Hide();
            MainViewForm mainViewForm = new MainViewForm();
            mainViewForm.Show();
        }

        private void ApplyCustomStyles()
        {
            
            BackColor = Color.White; 
            Font = new Font("Arial Black", 10f);
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
