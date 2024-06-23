using System;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Net;
using System.Windows.Forms;

namespace wsb_hotel_app
{

    public partial class AddReservationForm : Form
    {
     
        private Label firstNameLabel;
        private TextBox firstNameTextBox;
        private Label lastNameLabel;
        private TextBox lastNameTextBox;
        private Label roomNumberLabel;
        private ComboBox roomNumberComboBox;
        private Label startDateLabel;
        private DateTimePicker startDatePicker;
        private Label endDateLabel;
        private DateTimePicker endDatePicker;
        private Button addButton;
        private Button backButton;
        private PictureBox reservationImage;
        private HotelDatabaseManager databaseManager;

     
        public AddReservationForm()
        {
            InitializeComponent();
            databaseManager = new HotelDatabaseManager();
            InitializeComponents();
            ApplyCustomStyles();
            PopulateRoomNumberComboBox();
        }

    
        private void InitializeComponents()
        {

            firstNameLabel = new Label();
            firstNameLabel.Text = "Imię:";
            firstNameLabel.Location = new Point(50, 20);
            firstNameLabel.Font = new Font("Arial Black", 12f);

            firstNameTextBox = new TextBox();
            firstNameTextBox.Location = new Point(50, 40);
            firstNameTextBox.Size = new Size(200, 35);
            firstNameTextBox.Font = new Font("Arial", 12f);

            lastNameLabel = new Label();
            lastNameLabel.Text = "Nazwisko:";
            lastNameLabel.Location = new Point(50, 70);
            lastNameLabel.Font = new Font("Arial Black", 12f);

            lastNameTextBox = new TextBox();
            lastNameTextBox.Location = new Point(50, 90);
            lastNameTextBox.Size = new Size(200, 35);
            lastNameTextBox.Font = new Font("Arial", 12f);

            roomNumberLabel = new Label();
            roomNumberLabel.Text = "Numer pokoju:";
            roomNumberLabel.Location = new Point(50, 120);
            roomNumberLabel.Font = new Font("Arial Black", 12f);

            roomNumberComboBox = new ComboBox();
            roomNumberComboBox.Location = new Point(50, 140);
            roomNumberComboBox.Size = new Size(200, 35);
            roomNumberComboBox.Font = new Font("Arial", 12f);
            roomNumberComboBox.DropDownStyle = ComboBoxStyle.DropDownList;

            startDateLabel = new Label();
            startDateLabel.Text = "Data przyjazdu:";
            startDateLabel.Location = new Point(50, 170);
            startDateLabel.Font = new Font("Arial Black", 12f);

            startDatePicker = new DateTimePicker();
            startDatePicker.Location = new Point(50, 190);
            startDatePicker.Size = new Size(200, 35);
            startDatePicker.Font = new Font("Arial", 12f);
            startDatePicker.Format = DateTimePickerFormat.Short;

            endDateLabel = new Label();
            endDateLabel.Text = "Data odjazdu:";
            endDateLabel.Location = new Point(50, 220);
            endDateLabel.Font = new Font("Arial Black", 12f);

            endDatePicker = new DateTimePicker();
            endDatePicker.Location = new Point(50, 240);
            endDatePicker.Size = new Size(200, 35);
            endDatePicker.Font = new Font("Arial", 12f);
            endDatePicker.Format = DateTimePickerFormat.Short;

            addButton = new Button();
            addButton.Text = "Dodaj";
            addButton.Location = new Point(50, 300);
            addButton.Size = new Size(200, 30);
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
            backButton.Size = new Size(200, 30);
            backButton.Font = new Font("Arial Black", 12f);
            backButton.FlatStyle = FlatStyle.Flat;
            backButton.FlatAppearance.BorderColor = Color.Black;
            backButton.FlatAppearance.BorderSize = 2;
            backButton.MouseEnter += (sender, e) => backButton.BackColor = Color.LightSkyBlue;
            backButton.MouseLeave += (sender, e) => backButton.BackColor = Color.White;
            backButton.Click += backButton_Click;


            Controls.Add(firstNameLabel);
            Controls.Add(firstNameTextBox);
            Controls.Add(lastNameLabel);
            Controls.Add(lastNameTextBox);
            Controls.Add(roomNumberLabel);
            Controls.Add(roomNumberComboBox);
            Controls.Add(startDateLabel);
            Controls.Add(startDatePicker);
            Controls.Add(endDateLabel);
            Controls.Add(endDatePicker);
            Controls.Add(addButton);
            Controls.Add(backButton);

            reservationImage = new PictureBox();
            reservationImage.Location = new Point(280, 20);
            reservationImage.Size = new Size(300, 450);
            reservationImage.SizeMode = PictureBoxSizeMode.Zoom;
            LoadImageFromUrl("https://img.freepik.com/free-vector/hotel-tower-concept-illustration_114360-17162.jpg?t=st=1717850210~exp=1717853810~hmac=94bea5e51b6cc7fba420d3942405c1aa327ca6d094c3737203517363bd253272&w=826"); // Ustaw URL obrazka

            Controls.Add(reservationImage);
        }

        
        private void addButton_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(firstNameTextBox.Text) ||
                string.IsNullOrEmpty(lastNameTextBox.Text) ||
                string.IsNullOrEmpty(roomNumberComboBox.Text))
            {
                MessageBox.Show("Wszystkie pola są wymagane!", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            if (!DateTime.TryParse(startDatePicker.Text, out DateTime startDate) ||
                !DateTime.TryParse(endDatePicker.Text, out DateTime endDate))
            {
                MessageBox.Show("Nieprawidłowy format daty!", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            if (!int.TryParse(roomNumberComboBox.Text, out int roomNumber))
            {
                MessageBox.Show("Nieprawidłowy numer pokoju!", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            int roomId = databaseManager.GetRoomIdByNumber(roomNumber);


            string errorMessage;
            if (!IsRoomAvailable(roomId, startDate, endDate, out errorMessage))
            {
                MessageBox.Show(errorMessage, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            databaseManager.AddReservation(roomId, firstNameTextBox.Text, lastNameTextBox.Text, startDate, endDate);
            MessageBox.Show("Rezerwacja została dodana!", "Sukces", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        
        private bool IsRoomAvailable(int roomId, DateTime startDate, DateTime endDate, out string errorMessage)
        {
            errorMessage = "";


            string connectionString = $"Data Source={databaseManager.GetDatabasePath()};Version=3;";

            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                string query = @"SELECT COUNT(*) FROM reservations 
                         WHERE roomId = @roomId 
                         AND ((@startDate BETWEEN startDate AND endDate) OR (@endDate BETWEEN startDate AND endDate));";

                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@roomId", roomId);
                    command.Parameters.AddWithValue("@startDate", startDate);
                    command.Parameters.AddWithValue("@endDate", endDate);

                    int count = Convert.ToInt32(command.ExecuteScalar());
                    if (count > 0)
                    {
                        errorMessage = "Pokój jest już zarezerwowany w podanym okresie czasu.";
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
            }
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
                    reservationImage.Image = Image.FromStream(mem);
                }
            }
        }

      
        private void PopulateRoomNumberComboBox()
        {

            var roomNumbers = databaseManager.GetAllRoomNumbers();

            if (roomNumbers != null)
            {
                foreach (var number in roomNumbers)
                {
                    roomNumberComboBox.Items.Add(number);
                }
            }
        }
    }
}