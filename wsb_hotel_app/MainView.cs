
using System;
using System.Drawing;
using System.IO;
using System.Net;
using System.Windows.Forms;

namespace wsb_hotel_app
{
 
    public partial class MainViewForm : Form
    {
        
        private PictureBox reservationImage;
        private Button reservationsButton;
        private Button addRoomButton;
        private Button addReservationButton;

     
        public MainViewForm()
        {
            InitializeComponents();
            ApplyCustomStyles();
            CenterToScreen();
        }

       
        private void InitializeComponents()
        {



            reservationsButton = new Button();
            reservationsButton.Text = "Lista Rezerwacji";
            reservationsButton.Location = new Point(50, 100);
            reservationsButton.Size = new Size(300, 50);
            reservationsButton.Font = new Font("Arial Black", 12f);
            reservationsButton.FlatStyle = FlatStyle.Flat;
            reservationsButton.FlatAppearance.BorderColor = Color.Black;
            reservationsButton.FlatAppearance.BorderSize = 1;
            reservationsButton.MouseEnter += (sender, e) => reservationsButton.BackColor = Color.LightSkyBlue;
            reservationsButton.MouseLeave += (sender, e) => reservationsButton.BackColor = Color.White;
            reservationsButton.Click += (sender, e) =>
            {
                Hide();
                ReservationsForm reservationForm = new ReservationsForm();
                reservationForm.Show();
            };

            addRoomButton = new Button();
            addRoomButton.Text = "Dodaj Pokój";
            addRoomButton.Location = new Point(50, 180);
            addRoomButton.Size = new Size(300, 50);
            addRoomButton.Font = new Font("Arial Black", 12f);
            addRoomButton.FlatStyle = FlatStyle.Flat;
            addRoomButton.FlatAppearance.BorderColor = Color.Black;
            addRoomButton.FlatAppearance.BorderSize = 1;
            addRoomButton.MouseEnter += (sender, e) => addRoomButton.BackColor = Color.LightSkyBlue;
            addRoomButton.MouseLeave += (sender, e) => addRoomButton.BackColor = Color.White;
            addRoomButton.Click += (sender, e) =>
            {
                Hide();
                AddRoomForm addRoomForm = new AddRoomForm();
                addRoomForm.Show();
            };

            addReservationButton = new Button();
            addReservationButton.Text = "Dodaj Rezerwację";
            addReservationButton.Location = new Point(50, 260);
            addReservationButton.Size = new Size(300, 50);
            addReservationButton.Font = new Font("Arial Black", 12f);
            addReservationButton.FlatStyle = FlatStyle.Flat;
            addReservationButton.FlatAppearance.BorderColor = Color.Black;
            addReservationButton.FlatAppearance.BorderSize = 1;
            addReservationButton.MouseEnter += (sender, e) => addReservationButton.BackColor = Color.LightSkyBlue;
            addReservationButton.MouseLeave += (sender, e) => addReservationButton.BackColor = Color.White;
            addReservationButton.Click += (sender, e) =>
            {
                Hide();
                AddReservationForm addReservationForm = new AddReservationForm();
                addReservationForm.Show();
            };



            Controls.Add(reservationsButton);
            Controls.Add(addRoomButton);
            Controls.Add(addReservationButton);


            reservationImage = new PictureBox();
            reservationImage.Location = new Point(450, 20);
            reservationImage.Size = new Size(400, 550);
            reservationImage.SizeMode = PictureBoxSizeMode.Zoom;
            LoadImageFromUrl("https://img.freepik.com/free-vector/hotel-tower-concept-illustration_114360-17162.jpg?t=st=1717850210~exp=1717853810~hmac=94bea5e51b6cc7fba420d3942405c1aa327ca6d094c3737203517363bd253272&w=826"); // Ustaw URL obrazka

            Controls.Add(reservationImage);
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

       
        private void ApplyCustomStyles()
        {
            
            BackColor = Color.White; 
            Font = new Font("Arial", 10f);
            Size = new Size(900, 650);
        }
    }
}