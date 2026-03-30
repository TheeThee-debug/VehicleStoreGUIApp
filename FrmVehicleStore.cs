using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using VehicleClassLibrary.BusinessLogicLayer;
using VehicleClassLibrary.Models;

namespace VehicleStoreSolution
{
    /// <summary>
    /// Main Windows Forms UI for the Vehicle Store application.
    /// This form builds all controls in code and connects to the business layer.
    /// </summary>
    public class FrmVehicleStore : Form
    {
        // Business logic layer object
        private readonly StoreLogic _storeLogic;

        // Labels
        private Label lblMake = null;
        private Label lblModel = null;
        private Label lblYear = null;
        private Label lblPrice = null;
        private Label lblWheels = null;
        private Label lblSpecialBool = null;
        private Label lblSpecialDecimal = null;
        private Label lblInventory = null;
        private Label lblCart = null;
        private Label lblVehicleType = null;

        // TextBoxes
        private TextBox txtMake = null;
        private TextBox txtModel = null;
        private TextBox txtYear = null;
        private TextBox txtPrice = null;
        private TextBox txtWheels = null;
        private TextBox txtSpecialDecimal = null;

        // CheckBox for the boolean specialty field
        private CheckBox chkSpecialBool = null;

        // Vehicle type radio buttons
        private RadioButton rdoCar = null;
        private RadioButton rdoMotorcycle = null;
        private RadioButton rdoPickup = null;

        // Buttons
        private Button btnCreateVehicle = null;
        private Button btnAddToCart = null;
        private Button btnCheckout = null;
        private Button btnSaveInventory = null;
        private Button btnLoadInventory = null;

        // DataGridViews
        private DataGridView dgvInventory = null;
        private DataGridView dgvShoppingCart = null;

        /// <summary>
        /// Constructor.
        /// </summary>
        public FrmVehicleStore()
        {
            _storeLogic = new StoreLogic();

            SetupForm();
            BuildControls();

            rdoCar.Checked = true;
            UpdateSpecialFieldLabels();
            RefreshInventoryGrid();
            RefreshShoppingCartGrid();
        }

        /// <summary>
        /// Sets the form properties.
        /// </summary>
        private void SetupForm()
        {
            Text = "Vehicle Store";
            Size = new Size(1200, 700);
            StartPosition = FormStartPosition.CenterScreen;
            BackColor = Color.WhiteSmoke;
        }

        /// <summary>
        /// Builds all controls and places them on the form.
        /// </summary>
        private void BuildControls()
        {
            // Labels
            lblVehicleType = new Label();
            lblVehicleType.Text = "Vehicle Type";
            lblVehicleType.Location = new Point(20, 20);
            lblVehicleType.AutoSize = true;

            lblMake = new Label();
            lblMake.Text = "Make";
            lblMake.Location = new Point(20, 120);
            lblMake.AutoSize = true;

            lblModel = new Label();
            lblModel.Text = "Model";
            lblModel.Location = new Point(20, 160);
            lblModel.AutoSize = true;

            lblYear = new Label();
            lblYear.Text = "Year";
            lblYear.Location = new Point(20, 200);
            lblYear.AutoSize = true;

            lblPrice = new Label();
            lblPrice.Text = "Price";
            lblPrice.Location = new Point(20, 240);
            lblPrice.AutoSize = true;

            lblWheels = new Label();
            lblWheels.Text = "Wheels";
            lblWheels.Location = new Point(20, 280);
            lblWheels.AutoSize = true;

            lblSpecialBool = new Label();
            lblSpecialBool.Text = "Special Bool";
            lblSpecialBool.Location = new Point(20, 320);
            lblSpecialBool.AutoSize = true;

            lblSpecialDecimal = new Label();
            lblSpecialDecimal.Text = "Special Decimal";
            lblSpecialDecimal.Location = new Point(20, 360);
            lblSpecialDecimal.AutoSize = true;

            lblInventory = new Label();
            lblInventory.Text = "Inventory";
            lblInventory.Location = new Point(320, 20);
            lblInventory.AutoSize = true;

            lblCart = new Label();
            lblCart.Text = "Shopping Cart";
            lblCart.Location = new Point(320, 340);
            lblCart.AutoSize = true;

            // RadioButtons
            rdoCar = new RadioButton();
            rdoCar.Text = "Car";
            rdoCar.Location = new Point(20, 50);
            rdoCar.AutoSize = true;

            rdoMotorcycle = new RadioButton();
            rdoMotorcycle.Text = "Motorcycle";
            rdoMotorcycle.Location = new Point(90, 50);
            rdoMotorcycle.AutoSize = true;

            rdoPickup = new RadioButton();
            rdoPickup.Text = "Pickup";
            rdoPickup.Location = new Point(200, 50);
            rdoPickup.AutoSize = true;

            // TextBoxes
            txtMake = new TextBox();
            txtMake.Location = new Point(120, 120);
            txtMake.Width = 150;

            txtModel = new TextBox();
            txtModel.Location = new Point(120, 160);
            txtModel.Width = 150;

            txtYear = new TextBox();
            txtYear.Location = new Point(120, 200);
            txtYear.Width = 150;

            txtPrice = new TextBox();
            txtPrice.Location = new Point(120, 240);
            txtPrice.Width = 150;

            txtWheels = new TextBox();
            txtWheels.Location = new Point(120, 280);
            txtWheels.Width = 150;

            txtSpecialDecimal = new TextBox();
            txtSpecialDecimal.Location = new Point(120, 360);
            txtSpecialDecimal.Width = 150;

            // CheckBox
            chkSpecialBool = new CheckBox();
            chkSpecialBool.Location = new Point(120, 320);
            chkSpecialBool.AutoSize = true;

            // Buttons
            btnCreateVehicle = new Button();
            btnCreateVehicle.Text = "Create Vehicle";
            btnCreateVehicle.Location = new Point(20, 420);
            btnCreateVehicle.Size = new Size(250, 35);

            btnAddToCart = new Button();
            btnAddToCart.Text = "Add Selected To Cart";
            btnAddToCart.Location = new Point(20, 470);
            btnAddToCart.Size = new Size(250, 35);

            btnCheckout = new Button();
            btnCheckout.Text = "Checkout";
            btnCheckout.Location = new Point(20, 520);
            btnCheckout.Size = new Size(250, 35);

            btnSaveInventory = new Button();
            btnSaveInventory.Text = "Save Inventory";
            btnSaveInventory.Location = new Point(20, 570);
            btnSaveInventory.Size = new Size(120, 35);

            btnLoadInventory = new Button();
            btnLoadInventory.Text = "Load Inventory";
            btnLoadInventory.Location = new Point(150, 570);
            btnLoadInventory.Size = new Size(120, 35);

            // Inventory grid
            dgvInventory = new DataGridView();
            dgvInventory.Location = new Point(320, 50);
            dgvInventory.Size = new Size(840, 250);
            dgvInventory.ReadOnly = true;
            dgvInventory.MultiSelect = false;
            dgvInventory.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvInventory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Shopping cart grid
            dgvShoppingCart = new DataGridView();
            dgvShoppingCart.Location = new Point(320, 370);
            dgvShoppingCart.Size = new Size(840, 250);
            dgvShoppingCart.ReadOnly = true;
            dgvShoppingCart.MultiSelect = false;
            dgvShoppingCart.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvShoppingCart.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Add controls to form
            Controls.Add(lblVehicleType);
            Controls.Add(lblMake);
            Controls.Add(lblModel);
            Controls.Add(lblYear);
            Controls.Add(lblPrice);
            Controls.Add(lblWheels);
            Controls.Add(lblSpecialBool);
            Controls.Add(lblSpecialDecimal);
            Controls.Add(lblInventory);
            Controls.Add(lblCart);

            Controls.Add(rdoCar);
            Controls.Add(rdoMotorcycle);
            Controls.Add(rdoPickup);

            Controls.Add(txtMake);
            Controls.Add(txtModel);
            Controls.Add(txtYear);
            Controls.Add(txtPrice);
            Controls.Add(txtWheels);
            Controls.Add(txtSpecialDecimal);

            Controls.Add(chkSpecialBool);

            Controls.Add(btnCreateVehicle);
            Controls.Add(btnAddToCart);
            Controls.Add(btnCheckout);
            Controls.Add(btnSaveInventory);
            Controls.Add(btnLoadInventory);

            Controls.Add(dgvInventory);
            Controls.Add(dgvShoppingCart);

            // Wire up events
            rdoCar.CheckedChanged += VehicleType_CheckedChanged;
            rdoMotorcycle.CheckedChanged += VehicleType_CheckedChanged;
            rdoPickup.CheckedChanged += VehicleType_CheckedChanged;

            btnCreateVehicle.Click += BtnCreateVehicle_Click;
            btnAddToCart.Click += BtnAddToCart_Click;
            btnCheckout.Click += BtnCheckout_Click;
            btnSaveInventory.Click += BtnSaveInventory_Click;
            btnLoadInventory.Click += BtnLoadInventory_Click;
        }

        /// <summary>
        /// Updates the specialty field labels when the vehicle type changes.
        /// </summary>
        private void VehicleType_CheckedChanged(object sender, EventArgs e)
        {
            UpdateSpecialFieldLabels();
        }

        /// <summary>
        /// Changes specialty labels depending on the selected vehicle type.
        /// </summary>
        private void UpdateSpecialFieldLabels()
        {
            if (rdoCar.Checked)
            {
                lblSpecialBool.Text = "Convertible";
                lblSpecialDecimal.Text = "Trunk Size";
            }
            else if (rdoMotorcycle.Checked)
            {
                lblSpecialBool.Text = "Has Side Car";
                lblSpecialDecimal.Text = "Seat Height";
            }
            else if (rdoPickup.Checked)
            {
                lblSpecialBool.Text = "Has Bed Cover";
                lblSpecialDecimal.Text = "Bed Size";
            }
        }

        /// <summary>
        /// Creates a vehicle from the current form input and adds it to inventory.
        /// </summary>
        private void BtnCreateVehicle_Click(object sender, EventArgs e)
        {
            try
            {
                string make = txtMake.Text.Trim();
                string model = txtModel.Text.Trim();
                int year = int.Parse(txtYear.Text.Trim());
                decimal price = decimal.Parse(txtPrice.Text.Trim());
                int wheels = int.Parse(txtWheels.Text.Trim());
                bool specialBool = chkSpecialBool.Checked;
                decimal specialDecimal = decimal.Parse(txtSpecialDecimal.Text.Trim());

                VehicleModel vehicle;

                if (rdoCar.Checked)
                {
                    vehicle = new CarModel(0, make, model, year, price, wheels, specialBool, specialDecimal);
                }
                else if (rdoMotorcycle.Checked)
                {
                    vehicle = new MotorcycleModel(0, make, model, year, price, wheels, specialBool, specialDecimal);
                }
                else
                {
                    vehicle = new PickupModel(0, make, model, year, price, wheels, specialBool, specialDecimal);
                }

                _storeLogic.AddVehicleToInventory(vehicle);
                RefreshInventoryGrid();
                ClearInputFields();

                MessageBox.Show("Vehicle created successfully.");
            }
            catch
            {
                MessageBox.Show("Please enter valid values in all fields.");
            }
        }

        /// <summary>
        /// Adds the selected inventory item to the shopping cart.
        /// </summary>
        private void BtnAddToCart_Click(object sender, EventArgs e)
        {
            if (dgvInventory.CurrentRow == null)
            {
                MessageBox.Show("Please select a vehicle from inventory.");
                return;
            }

            VehicleModel selectedVehicle = dgvInventory.CurrentRow.DataBoundItem as VehicleModel;

            if (selectedVehicle == null)
            {
                MessageBox.Show("Unable to add selected vehicle.");
                return;
            }

            int result = _storeLogic.AddVehicleToCart(selectedVehicle.Id);

            if (result != -1)
            {
                RefreshShoppingCartGrid();
                MessageBox.Show("Vehicle added to cart.");
            }
            else
            {
                MessageBox.Show("Vehicle could not be added.");
            }
        }

        /// <summary>
        /// Performs checkout and displays the total.
        /// </summary>
        private void BtnCheckout_Click(object sender, EventArgs e)
        {
            decimal total = _storeLogic.Checkout();
            RefreshShoppingCartGrid();
            MessageBox.Show(string.Format("Checkout complete. Total: ${0:F2}", total));
        }

        /// <summary>
        /// Saves inventory to file.
        /// </summary>
        private void BtnSaveInventory_Click(object sender, EventArgs e)
        {
            bool success = _storeLogic.WriteInventory();

            if (success)
            {
                MessageBox.Show("Inventory saved successfully.");
            }
            else
            {
                MessageBox.Show("Inventory could not be saved.");
            }
        }

        /// <summary>
        /// Loads inventory from file.
        /// </summary>
        private void BtnLoadInventory_Click(object sender, EventArgs e)
        {
            _storeLogic.ReadInventory();
            RefreshInventoryGrid();
            MessageBox.Show("Inventory loaded.");
        }

        /// <summary>
        /// Refreshes the inventory grid.
        /// </summary>
        private void RefreshInventoryGrid()
        {
            dgvInventory.DataSource = null;
            dgvInventory.DataSource = new List<VehicleModel>(_storeLogic.GetInventory());
        }

        /// <summary>
        /// Refreshes the shopping cart grid.
        /// </summary>
        private void RefreshShoppingCartGrid()
        {
            dgvShoppingCart.DataSource = null;
            dgvShoppingCart.DataSource = new List<VehicleModel>(_storeLogic.GetShoppingCart());
        }

        /// <summary>
        /// Clears the input fields after creating a vehicle.
        /// </summary>
        private void ClearInputFields()
        {
            txtMake.Clear();
            txtModel.Clear();
            txtYear.Clear();
            txtPrice.Clear();
            txtWheels.Clear();
            txtSpecialDecimal.Clear();
            chkSpecialBool.Checked = false;
            txtMake.Focus();
        }
    }
}