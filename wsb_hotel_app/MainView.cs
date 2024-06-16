using System;
using System.Drawing;
using System.IO;
using System.Net;
using System.Windows.Forms;

namespace wsb_hotel_app
{
    public partial class MainViewForm : Form
    {
        private Button employeesButton;
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
            
            employeesButton = new Button();
            employeesButton.Text = "Pracownicy";
            employeesButton.Location = new Point(50, 50);
            employeesButton.Size = new Size(200, 30);
            employeesButton.Font = new Font("Arial", 12f);
            employeesButton.Click += (sender, e) =>
            {
                Hide();
                
            };

            reservationsButton = new Button();
            reservationsButton.Text = "Lista Rezerwacji";
            reservationsButton.Location = new Point(50, 100);
            reservationsButton.Size = new Size(200, 30);
            reservationsButton.Font = new Font("Arial", 12f);
            reservationsButton.Click += (sender, e) =>
            {
                Hide();
                ReservationsForm reservationForm = new ReservationsForm();
                reservationForm.Show();
            };

            addRoomButton = new Button();
            addRoomButton.Text = "Dodaj Pokój";
            addRoomButton.Location = new Point(50, 150);
            addRoomButton.Size = new Size(200, 30);
            addRoomButton.Font = new Font("Arial", 12f);
            addRoomButton.Click += (sender, e) =>
            {
                Hide();
                AddRoomForm addRoomForm = new AddRoomForm();
                addRoomForm.Show();
            };

            addReservationButton = new Button();
            addReservationButton.Text = "Dodaj Rezerwację";
            addReservationButton.Location = new Point(50, 200);
            addReservationButton.Size = new Size(200, 30);
            addReservationButton.Font = new Font("Arial", 12f);
            addReservationButton.Click += (sender, e) =>
            {
                Hide();
                AddReservationForm addReservationForm = new AddReservationForm();
                addReservationForm.Show();
            };

            
            Controls.Add(employeesButton);
            Controls.Add(reservationsButton);
            Controls.Add(addRoomButton);
            Controls.Add(addReservationButton);
        }

        private void ApplyCustomStyles()
        {
            // Stylizacja formularza
            BackColor = Color.White; // Białe tło
            Font = new Font("Arial", 10f);
            Size = new Size(900, 650); // Ustawienie rozmiaru formularza na 900x650 pikseli
        }
    }
}
