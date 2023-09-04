using System.Diagnostics.Metrics;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;


namespace VendorMachine
{
    public partial class Form1 : Form
    {
        private ComboBox productComboBox;
        private Button proceedToSelectbtn;
        private CheckBox bagCheckBox;
        private CheckBox giftCheckBox;
        private Button proceedToPaymentbtn;
        private Button endPaymentbtn;
        private NumericUpDown numericUpDown;
        private VendorMachine vendorMachine;
        private decimal change;
        private decimal price;
        private Label descLabel;
        private Label PriceLabel;
        private Timer timer;
        public Form1()
        {

            InitializeComponent();
            InitializeStart();

            vendorMachine = new VendorMachine(new VendorSelectionMethod(), this);
        }
        private void InitializeStart()
        {
            this.Controls.Clear();
            proceedToSelectbtn = new Button();
            proceedToSelectbtn.Location = new Point((Width - proceedToSelectbtn.Width) / 2, (Height - proceedToSelectbtn.Height) / 2); ;
            proceedToSelectbtn.Width = 100;
            proceedToSelectbtn.Text = "Start your buing";
            proceedToSelectbtn.Click += ProceedToSelectbtn_Click;
            Controls.Add(proceedToSelectbtn);
        }
        private void InitializePayment()
        {
            Controls.Clear();
            numericUpDown = new NumericUpDown();
            numericUpDown.Location = new System.Drawing.Point(10, 100);
            numericUpDown.Size = new System.Drawing.Size(80, 20);
            numericUpDown.Minimum = 0;
            numericUpDown.Maximum = 100;
            PriceLabel = new Label();
            PriceLabel.Text = $"price {price}";
            PriceLabel.AutoSize = false;
            PriceLabel.TextAlign = ContentAlignment.MiddleCenter;
            endPaymentbtn = new Button();
            endPaymentbtn.Location = new System.Drawing.Point(100, 100);
            endPaymentbtn.Width = 100;
            endPaymentbtn.Text = "Payment";
            endPaymentbtn.Click += Paymentbtn_Click;
            Controls.Add((endPaymentbtn));
            Controls.Add(numericUpDown);
            Controls.Add((PriceLabel));
        }


        private void InitializeSelection()
        {
            proceedToSelectbtn.Hide();
            productComboBox = new ComboBox();
            productComboBox.Location = new System.Drawing.Point(50, 50);
            productComboBox.Size = new System.Drawing.Size(200, 20);
            productComboBox.DropDownStyle = ComboBoxStyle.DropDownList;

            // Add items to the ComboBox
            productComboBox.DataSource = Enum.GetValues(typeof(ProductType));
            bagCheckBox = new CheckBox();
            bagCheckBox.Text = "Bag";
            bagCheckBox.Location = new System.Drawing.Point(50, 100);
            giftCheckBox = new CheckBox();
            giftCheckBox.Text = "Gift";
            giftCheckBox.Location = new System.Drawing.Point(50, 130);
            proceedToPaymentbtn = new Button();
            proceedToPaymentbtn.Text = "Proceed to Payment";
            proceedToPaymentbtn.Dock = DockStyle.Top;
            proceedToPaymentbtn.Click += ProceedToPaymentbtn_Click;

            // Add event handler


            // Add the ComboBox to the form
            Controls.Add(productComboBox);
            Controls.Add(bagCheckBox);
            Controls.Add(giftCheckBox);
            Controls.Add(proceedToPaymentbtn);
        }
        private void InitializeProcess()
        {
            PriceLabel.Hide();
            endPaymentbtn.Hide();
            numericUpDown.Hide();
            descLabel = new Label();
            descLabel.Text = vendorMachine.ProcessProduct().ToString();
            descLabel.AutoSize = false;
            descLabel.TextAlign = ContentAlignment.MiddleCenter;
            descLabel.Font = new Font("Arial", 10, FontStyle.Bold);
            descLabel.ForeColor = Color.White;
            descLabel.BackColor = Color.DarkBlue;
            descLabel.Size = new Size(400, 200);
            descLabel.Location = new Point((Width - descLabel.Width) / 2, (Height - descLabel.Height) / 2);
            Controls.Add(descLabel);
            timer = new Timer();
            timer.Interval = 2000; // Delay in milliseconds (e.g., 2000 = 2 seconds)
            timer.Tick += Timer_Tick;
            timer.Start();



        }
        private void ProceedToSelectbtn_Click(object sender, EventArgs e)
        {
            InitializeSelection();

        }
        private void ProceedToPaymentbtn_Click(object sender, EventArgs e)
        {
            string? selectedOption = productComboBox.SelectedItem.ToString();
            bool isBagSelected = bagCheckBox.Checked;
            bool isGiftSelected = giftCheckBox.Checked;
            price = vendorMachine.SelectProduct(selectedOption, isBagSelected, isGiftSelected).Price;
            InitializePayment();

        }
        private void Paymentbtn_Click(object? sender, EventArgs e)
        {
            decimal numericValue = (decimal)numericUpDown.Value;
            change = vendorMachine.ProcessPayment(numericValue);
            if (change < 0)
            {
                MessageBox.Show("Not Enough Money", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                InitializePayment();
                return;

            }
            if (change == 0) { MessageBox.Show($"You have got no change", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information); }
            else
            {
                MessageBox.Show($"You have got {change} change", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            InitializeProcess();
            return;
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            timer.Stop();
            InitializeStart();
        }


    }
}