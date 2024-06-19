using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace wsb_hotel_app
{
    public partial class ReservationsForm : Form
    {
        private Label titleLabel;
        private ListView reservationsListView;
        private Button backButton;
        private HotelDatabaseManager databaseManager;

        public ReservationsForm()
        {
            
            InitializeComponents();
            ApplyCustomStyles();
            databaseManager = new HotelDatabaseManager();
            databaseManager.InitializeDatabase();
            LoadReservationsData();
            CenterToScreen();
        }

        private void InitializeComponents()
        {
            titleLabel = new Label();
            titleLabel.Text = "Wszystkie rezerwacje";
            titleLabel.Font = new Font("Arial Black", 16f);
            titleLabel.TextAlign = ContentAlignment.TopCenter;
            titleLabel.AutoSize = false;
            titleLabel.Size = new Size(400, 40);
            titleLabel.Location = new Point(250, 20);

            reservationsListView = new ListView();
            reservationsListView.Location = new Point(50, 80);
            reservationsListView.Size = new Size(800, 400);
            reservationsListView.View = View.Details;
            reservationsListView.FullRowSelect = true;
            reservationsListView.GridLines = true;
            reservationsListView.BackColor = Color.White;
            reservationsListView.ForeColor = Color.Black;

           
            reservationsListView.Columns.Add("Reservation ID", 100, HorizontalAlignment.Left);
            reservationsListView.Columns.Add("Room ID", 100, HorizontalAlignment.Left);
            reservationsListView.Columns.Add("Client ID", 100, HorizontalAlignment.Left);
            reservationsListView.Columns.Add("First Name", 150, HorizontalAlignment.Left);
            reservationsListView.Columns.Add("Last Name", 150, HorizontalAlignment.Left);
            reservationsListView.Columns.Add("Start Date", 100, HorizontalAlignment.Left);
            reservationsListView.Columns.Add("End Date", 100, HorizontalAlignment.Left);

            backButton = new Button();
            backButton.Text = "Powrót";
            backButton.Location = new Point(350, 500);
            backButton.Size = new Size(200, 40);
            backButton.Font = new Font("Arial Black", 12f);
            backButton.FlatStyle = FlatStyle.Flat;
            backButton.FlatAppearance.BorderColor = Color.Black;
            backButton.FlatAppearance.BorderSize = 2;
            backButton.MouseEnter += (sender, e) => backButton.BackColor = Color.LightSkyBlue;
            backButton.MouseLeave += (sender, e) => backButton.BackColor = Color.White;
            backButton.Click += backButton_Click;

            Controls.Add(titleLabel);
            Controls.Add(reservationsListView);
            Controls.Add(backButton);
        }

        private void LoadReservationsData()
        {
            List<Reservation> reservations = databaseManager.GetAllReservations();

            foreach (var reservation in reservations)
            {
                ListViewItem item = new ListViewItem(reservation.ReservationId.ToString());
                item.SubItems.Add(reservation.RoomId.ToString());
                item.SubItems.Add(reservation.ClientId.ToString());
                item.SubItems.Add(reservation.FirstName);
                item.SubItems.Add(reservation.LastName);
                item.SubItems.Add(reservation.StartDate.ToString("yyyy-MM-dd"));
                item.SubItems.Add(reservation.EndDate.ToString("yyyy-MM-dd"));

                reservationsListView.Items.Add(item);
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
    }
}
