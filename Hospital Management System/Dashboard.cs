using System;
using System.Data;
using Microsoft.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;




namespace Hospital_Management_System
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadData();
            AppointmentLoadData();
            MedicalRecordLoadData();
            BillLoadData();
            RoomLoadData();
            AdmissionLoadData();
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView3.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView4.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView5.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView6.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView7.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView8.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

        }

        private void Dashboardbtn_Click(object sender, EventArgs e)
        {
            Dashboardpanel1.Show();
            Patientpanel3.Hide();
            Appointmentpanel.Hide();
            panel4.Hide();
            MedicalRecordpanel.Hide();
            Billingpanel.Hide();
            Roompanel.Hide();
            Admissionpanel.Hide();
            panel12.Hide();
            panel11.Hide();
            panel9.Hide();
            panel7.Hide();


        }

        private void button2_MouseEnter(object sender, EventArgs e)
        {
            button2.BackColor = Color.Red;
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            button2.BackColor = SystemColors.Control;
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            Addpatientbtn.BackColor = Color.Green;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            Addpatientbtn.BackColor = SystemColors.Control;
        }

        private void patientbtn_Click(object sender, EventArgs e)
        {
            Patientpanel3.Show();
            Dashboardpanel1.Hide();
            Appointmentpanel.Hide();
            panel4.Show();
            MedicalRecordpanel.Hide();
            Billingpanel.Hide();
            Roompanel.Hide();
            Admissionpanel.Hide();
            panel12.Hide();
            panel11.Hide();
            panel9.Hide();
            panel7.Hide();

        }

        private void Addpatientbtn_Click(object sender, EventArgs e)
        {

            try
            {
                string patientid = PIDtext.Text;
                string name = Pnametext.Text;
                string dob = p_dobtext.Text;
                string bloodgroup = Pbloodgrouptext.Text;
                string gender = gendercombo.Text;
                Int64 contact = Convert.ToInt64(Contacttext.Text);

                using (SqlConnection con = new SqlConnection("data source=DESKTOP-P38D8KG\\SQLEXPRESS;database=HMSDB;integrated security=True;TrustServerCertificate=True;"))
                {
                    con.Open();

                    string query = "INSERT INTO Patient (ID, Name, DOB, Blood_group, Gender, Contact) VALUES (@PatientId, @Name, @DOB, @BloodGroup, @Gender, @Contact)";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@PatientId", patientid);
                        cmd.Parameters.AddWithValue("@Name", name);
                        cmd.Parameters.AddWithValue("@DOB", dob);
                        cmd.Parameters.AddWithValue("@BloodGroup", bloodgroup);
                        cmd.Parameters.AddWithValue("@Gender", gender);
                        cmd.Parameters.AddWithValue("@Contact", contact);

                        cmd.ExecuteNonQuery();


                    }

                    LoadData();
                    MessageBox.Show("Patient Data has been saved successfully!");
                }

                // Clear fields
                PIDtext.Clear();
                Pnametext.Clear();
                p_dobtext.Clear();
                Pbloodgrouptext.Clear();
                gendercombo.ResetText();
                Contacttext.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

        }

        private void LoadData()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection("data source=DESKTOP-P38D8KG\\SQLEXPRESS;database=HMSDB;integrated security=True;TrustServerCertificate=True;"))
                {
                    SqlDataAdapter DA = new SqlDataAdapter("SELECT * FROM Patient", conn);
                    DataSet DS = new DataSet();
                    DA.Fill(DS);
                    dataGridView2.DataSource = DS.Tables[0];
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.Message);
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Appointmentpanel.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            PIDtext.Clear();
            Pnametext.Clear();
            p_dobtext.Clear();
            Pbloodgrouptext.Clear();
            gendercombo.ResetText();
            Contacttext.Clear();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Appointmentpanel.Show();
            Dashboardpanel1.Hide();
            Patientpanel3.Hide();
            MedicalRecordpanel.Hide();
            Billingpanel.Hide();
            Roompanel.Hide();
            Admissionpanel.Hide();
            panel12.Hide();
            panel11.Hide();
            panel9.Hide();
            panel7.Hide();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string Appointment_id = AppointIdtext.Text;
            string Doctor_id = DoctorIdtext.Text;
            string patient_id = patientidtext.Text;
            string status = AppointStatuscombo.Text;
            DateTime dateTimeValue = Convert.ToDateTime(dateTimePicker1.Value);

            try
            {
                using (SqlConnection con = new SqlConnection("data source=DESKTOP-P38D8KG\\SQLEXPRESS;database=HMSDB;integrated security=True;TrustServerCertificate=True;"))
                {
                    con.Open();

                    string query = "INSERT INTO Appointment (Appointment_ID, ID,Doctor_ID, DateTime, Status) VALUES (@AppointmentId, @PatientId, @DoctorId, @Datetime, @Status)";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@AppointmentId", Appointment_id);
                        cmd.Parameters.AddWithValue("@patientId", Doctor_id);
                        cmd.Parameters.AddWithValue("@DoctorId", patient_id);
                        cmd.Parameters.AddWithValue("@Datetime", dateTimeValue);
                        cmd.Parameters.AddWithValue("@Status", status);

                        cmd.ExecuteNonQuery();


                    }
                    AppointmentLoadData();

                    MessageBox.Show("Appointment Data has been saved successfully!");
                }

                AppointIdtext.Clear();
                DoctorIdtext.Clear();
                patientidtext.Clear();
                AppointStatuscombo.ResetText();
                dateTimePicker1.ResetText();


            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }


        }

        private void AppointmentLoadData()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection("data source=DESKTOP-P38D8KG\\SQLEXPRESS;database=HMSDB;integrated security=True;TrustServerCertificate=True;"))
                {
                    SqlDataAdapter DA = new SqlDataAdapter("SELECT * FROM Appointment", conn);
                    DataSet DS = new DataSet();
                    DA.Fill(DS);
                    dataGridView3.DataSource = DS.Tables[0];
                    dataGridView1.DataSource = DS.Tables[0];
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.Message);
            }
        }

        private void updatebtn_Click(object sender, EventArgs e)
        {
            try
            {

                using (SqlConnection con = new SqlConnection("data source=DESKTOP-P38D8KG\\SQLEXPRESS;database=HMSDB;integrated security=True;TrustServerCertificate=True;"))
                {
                    con.Open();

                    string query = "UPDATE Patient SET Name =@Name, DOB =@DOB, Gender =@Gender, Blood_group =@Blood_group, Contact =@Contact WHERE ID =@ID ";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@ID", PIDtext.Text);
                        cmd.Parameters.AddWithValue("@Name", Pnametext.Text);
                        cmd.Parameters.AddWithValue("@DOB", p_dobtext.Text);
                        cmd.Parameters.AddWithValue("@Blood_group", Pbloodgrouptext.Text);
                        cmd.Parameters.AddWithValue("@Gender", gendercombo.Text);
                        cmd.Parameters.AddWithValue("@Contact", Contacttext.Text);

                        cmd.ExecuteNonQuery();


                    }
                    LoadData();
                    MessageBox.Show("Patient Data has been Update successfully");
                }

                PIDtext.Clear();
                Pnametext.Clear();
                p_dobtext.Clear();
                Pbloodgrouptext.Clear();
                gendercombo.ResetText();
                Contacttext.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }


        }

        private void deletebtn_Click(object sender, EventArgs e)
        {
            try
            {

                using (SqlConnection con = new SqlConnection("data source=DESKTOP-P38D8KG\\SQLEXPRESS;database=HMSDB;integrated security=True;TrustServerCertificate=True;"))
                {
                    con.Open();

                    string query = "DELETE FROM Patient WHERE ID =@ID ";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@ID", PIDtext.Text);

                        cmd.ExecuteNonQuery();

                    }
                    LoadData();
                    MessageBox.Show("Patient Data Delete");
                }

                PIDtext.Clear();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void AppointUpdbtn_Click(object sender, EventArgs e)
        {
            try
            {

                using (SqlConnection con = new SqlConnection("data source=DESKTOP-P38D8KG\\SQLEXPRESS;database=HMSDB;integrated security=True;TrustServerCertificate=True;"))
                {
                    con.Open();

                    string query = "UPDATE Appointment SET ID =@ID, Doctor_ID =@Doctor_ID, DateTime =@DateTime, Status =@Status WHERE Appointment_ID =@Appointment_ID ";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@ID", patientidtext.Text);
                        cmd.Parameters.AddWithValue("@Doctor_ID", DoctorIdtext.Text);
                        cmd.Parameters.AddWithValue("@DateTime", dateTimePicker1.Value);
                        cmd.Parameters.AddWithValue("@Appointment_ID", AppointIdtext.Text);
                        cmd.Parameters.AddWithValue("@Status", AppointStatuscombo.Text);

                        cmd.ExecuteNonQuery();


                    }
                    AppointmentLoadData();
                    MessageBox.Show("Appointment Data has been Update successfully");
                }

                AppointIdtext.Clear();
                DoctorIdtext.Clear();
                patientidtext.Clear();
                AppointStatuscombo.ResetText();
                dateTimePicker1.ResetText();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void AppointDelbtn_Click(object sender, EventArgs e)
        {
            try
            {

                using (SqlConnection con = new SqlConnection("data source=DESKTOP-P38D8KG\\SQLEXPRESS;database=HMSDB;integrated security=True;TrustServerCertificate=True;"))
                {
                    con.Open();

                    string query = "DELETE FROM Appointment WHERE Appointment_ID =@AID ";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@AID", AppointIdtext.Text);

                        cmd.ExecuteNonQuery();

                    }
                    AppointmentLoadData();
                    MessageBox.Show("Appointment Delete");
                }

                AppointIdtext.Clear();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void SaveMedicalbtn_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection con = new SqlConnection("data source=DESKTOP-P38D8KG\\SQLEXPRESS;database=HMSDB;integrated security=True;TrustServerCertificate=True;"))
                {
                    con.Open();

                    string query = "INSERT INTO MedicalRecord (Medical_ID, Patient_ID,Doctor_ID, daignosis, prescriptions) VALUES (@MId, @PId, @DId, @daignosis, @prescriptions)";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@MId", Medicaltext.Text);
                        cmd.Parameters.AddWithValue("@PId", Patienttext.Text);
                        cmd.Parameters.AddWithValue("@DId", Doctortext.Text);
                        cmd.Parameters.AddWithValue("@daignosis", Daignosistext.Text);
                        cmd.Parameters.AddWithValue("@prescriptions", richTextBox1.Text);

                        cmd.ExecuteNonQuery();


                    }

                    MedicalRecordLoadData();
                    MessageBox.Show("Medical Record has been saved successfully!");
                }

                Medicaltext.Clear();
                Patienttext.Clear();
                Doctortext.Clear();
                Daignosistext.Clear();
                richTextBox1.Clear();


            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void MedicalRecordLoadData()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection("data source=DESKTOP-P38D8KG\\SQLEXPRESS;database=HMSDB;integrated security=True;TrustServerCertificate=True;"))
                {
                    SqlDataAdapter DA = new SqlDataAdapter("SELECT * FROM MedicalRecord", conn);
                    DataSet DS = new DataSet();
                    DA.Fill(DS);
                    dataGridView4.DataSource = DS.Tables[0];

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.Message);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Appointmentpanel.Hide();
            Dashboardpanel1.Hide();
            Patientpanel3.Hide();
            MedicalRecordpanel.Show();
            Billingpanel.Hide();
            Roompanel.Hide();
            Admissionpanel.Hide();
            panel12.Hide();
            panel11.Hide();
            panel9.Hide();
            panel7.Show();

        }

        private void MedicalUpdatebtn_Click(object sender, EventArgs e)
        {
            try
            {

                using (SqlConnection con = new SqlConnection("data source=DESKTOP-P38D8KG\\SQLEXPRESS;database=HMSDB;integrated security=True;TrustServerCertificate=True;"))
                {
                    con.Open();

                    string query = "UPDATE MedicalRecord SET  Patient_ID =@PID,  Doctor_ID=@DID, daignosis =@daignosis, prescriptions =@prescriptions  WHERE Medical_ID =@MID ";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@MID", Medicaltext.Text);
                        cmd.Parameters.AddWithValue("@PID", Patienttext.Text);
                        cmd.Parameters.AddWithValue("@DID", Doctortext.Text);
                        cmd.Parameters.AddWithValue("@daignosis", Daignosistext.Text);
                        cmd.Parameters.AddWithValue("@prescriptions", richTextBox1.Text);

                        cmd.ExecuteNonQuery();


                    }
                    MedicalRecordLoadData();
                    MessageBox.Show("Medical Record Update successfully!");
                }

                Medicaltext.Clear();
                Doctortext.Clear();
                Patienttext.Clear();
                Daignosistext.Clear();
                richTextBox1.Clear();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void MedicalDeletebtn_Click(object sender, EventArgs e)
        {
            try
            {

                using (SqlConnection con = new SqlConnection("data source=DESKTOP-P38D8KG\\SQLEXPRESS;database=HMSDB;integrated security=True;TrustServerCertificate=True;"))
                {
                    con.Open();

                    string query = "DELETE FROM MedicalRecord WHERE Medical_ID =@MID ";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@MID", Medicaltext.Text);

                        cmd.ExecuteNonQuery();

                    }
                    MedicalRecordLoadData();
                    MessageBox.Show("Medical Record has been Delete sucessfully!");
                }

                Medicaltext.Clear();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Appointmentpanel.Hide();
            Dashboardpanel1.Hide();
            Patientpanel3.Hide();
            MedicalRecordpanel.Hide();
            Billingpanel.Show();
            Roompanel.Hide();
            Admissionpanel.Hide();
            panel12.Hide();
            panel11.Hide();
            panel9.Show();
            panel7.Hide();

        }

        private void SaveBillbtn_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection con = new SqlConnection("data source=DESKTOP-P38D8KG\\SQLEXPRESS;database=HMSDB;integrated security=True;TrustServerCertificate=True;"))
                {
                    con.Open();

                    string query = "INSERT INTO BIlling (Bill_ID, Patient_ID,Admission_ID, Amount, Status) VALUES (@BId, @PId, @AId, @Amount, @Status)";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@BId", Billtext.Text);
                        cmd.Parameters.AddWithValue("@PId", billPtext.Text);
                        cmd.Parameters.AddWithValue("@AId", BillAdmissiontext.Text);
                        cmd.Parameters.AddWithValue("@Amount", Amounttext.Text);
                        cmd.Parameters.AddWithValue("@Status", BillStatuscombo.Text);

                        cmd.ExecuteNonQuery();


                    }

                    BillLoadData();
                    MessageBox.Show("Bill Record has been saved successfully!");
                }

                Billtext.Clear();
                billPtext.Clear();
                BillAdmissiontext.Clear();
                Amounttext.Clear();
                BillStatuscombo.ResetText();


            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void BillLoadData()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection("data source=DESKTOP-P38D8KG\\SQLEXPRESS;database=HMSDB;integrated security=True;TrustServerCertificate=True;"))
                {
                    SqlDataAdapter DA = new SqlDataAdapter("SELECT * FROM Billing", conn);
                    DataSet DS = new DataSet();
                    DA.Fill(DS);
                    dataGridView5.DataSource = DS.Tables[0];

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.Message);
            }
        }

        private void BillUpdatebtn_Click(object sender, EventArgs e)
        {
            try
            {

                using (SqlConnection con = new SqlConnection("data source=DESKTOP-P38D8KG\\SQLEXPRESS;database=HMSDB;integrated security=True;TrustServerCertificate=True;"))
                {
                    con.Open();

                    string query = "UPDATE Billing SET  Patient_ID =@PID,  Admission_ID=@AID, Amount =@Amount, Status =@Status  WHERE Bill_ID =@BID ";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@BID", Billtext.Text);
                        cmd.Parameters.AddWithValue("@PID", billPtext.Text);
                        cmd.Parameters.AddWithValue("@AID", BillAdmissiontext.Text);
                        cmd.Parameters.AddWithValue("@Amount", Amounttext.Text);
                        cmd.Parameters.AddWithValue("@Status", BillStatuscombo.Text);

                        cmd.ExecuteNonQuery();


                    }
                    BillLoadData();
                    MessageBox.Show("Bill  Record Update successfully!");
                }

                Billtext.Clear();
                billPtext.Clear();
                BillAdmissiontext.Clear();
                Amounttext.Clear();
                BillStatuscombo.ResetText();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void BillDeletebtn_Click(object sender, EventArgs e)
        {
            try
            {

                using (SqlConnection con = new SqlConnection("data source=DESKTOP-P38D8KG\\SQLEXPRESS;database=HMSDB;integrated security=True;TrustServerCertificate=True;"))
                {
                    con.Open();

                    string query = "DELETE FROM Billing WHERE Bill_ID =@BID ";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@BID", Billtext.Text);

                        cmd.ExecuteNonQuery();

                    }
                    BillLoadData();
                    MessageBox.Show("Bill Record has been Delete Successfully!");
                }

                Billtext.Clear();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void SaveRoombtn_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection con = new SqlConnection("data source=DESKTOP-P38D8KG\\SQLEXPRESS;database=HMSDB;integrated security=True;TrustServerCertificate=True;"))
                {
                    con.Open();

                    string query = "INSERT INTO Room (Room_ID, Type, Status) VALUES (@RId, @Type, @Status)";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@RId", RoomIdtext.Text);
                        cmd.Parameters.AddWithValue("@Type", RoomTypecombo.Text);
                        cmd.Parameters.AddWithValue("@Status", RoomStatuscombo.Text);

                        cmd.ExecuteNonQuery();


                    }

                    RoomLoadData();
                    MessageBox.Show("ROOM Record has been saved successfully!");
                }

                RoomIdtext.Clear();
                RoomTypecombo.ResetText();
                RoomStatuscombo.ResetText();


            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void RoomLoadData()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection("data source=DESKTOP-P38D8KG\\SQLEXPRESS;database=HMSDB;integrated security=True;TrustServerCertificate=True;"))
                {
                    SqlDataAdapter DA = new SqlDataAdapter("SELECT * FROM Room", conn);
                    DataSet DS = new DataSet();
                    DA.Fill(DS);
                    dataGridView6.DataSource = DS.Tables[0];

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.Message);
            }
        }

        private void UpdateRoombtn_Click(object sender, EventArgs e)
        {
            try
            {

                using (SqlConnection con = new SqlConnection("data source=DESKTOP-P38D8KG\\SQLEXPRESS;database=HMSDB;integrated security=True;TrustServerCertificate=True;"))
                {
                    con.Open();

                    string query = "UPDATE Room SET  Type =@Type, Status =@Status  WHERE Room_ID =@RID ";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@RID", RoomIdtext.Text);
                        cmd.Parameters.AddWithValue("@Type", RoomTypecombo.Text);
                        cmd.Parameters.AddWithValue("@Status", RoomStatuscombo.Text);

                        cmd.ExecuteNonQuery();


                    }
                    RoomLoadData();
                    MessageBox.Show("ROOM  Record Update successfully!");
                }

                RoomIdtext.Clear();
                RoomTypecombo.ResetText();
                RoomStatuscombo.ResetText();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Appointmentpanel.Hide();
            Dashboardpanel1.Hide();
            Patientpanel3.Hide();
            MedicalRecordpanel.Hide();
            Billingpanel.Hide();
            Roompanel.Show();
            Admissionpanel.Hide();
            panel11.Hide();
            panel9.Hide();
            panel12.Show();
            panel7.Hide();

        }

        private void button9_Click(object sender, EventArgs e)
        {
            Appointmentpanel.Hide();
            Dashboardpanel1.Hide();
            Patientpanel3.Hide();
            MedicalRecordpanel.Hide();
            Billingpanel.Hide();
            Roompanel.Hide();
            Admissionpanel.Show();
            panel12.Hide();
            panel9.Hide();
            panel11.Show();
            panel7.Hide();

        }

        private void PatientSearchbtn_Click(object sender, EventArgs e)
        {
            try
            {

                using (SqlConnection con = new SqlConnection("data source=DESKTOP-P38D8KG\\SQLEXPRESS;database=HMSDB;integrated security=True;TrustServerCertificate=True;"))
                {
                    con.Open();

                    string query = "SELECT * FROM Patient WHERE ID =@PatientId ";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@PatientId", SearchPIdtext.Text);

                        SqlDataAdapter DA = new SqlDataAdapter(cmd);
                        DataSet DS = new DataSet();
                        DA.Fill(DS);
                        dataGridView7.DataSource = DS.Tables[0];

                    }

                }

                SearchPIdtext.Clear();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void AddAdmissionbtn_Click(object sender, EventArgs e)
        {
            try
            {

                using (SqlConnection con = new SqlConnection("data source=DESKTOP-P38D8KG\\SQLEXPRESS;database=HMSDB;integrated security=True;TrustServerCertificate=True;"))
                {
                    con.Open();

                    string query = "INSERT INTO Admission (Admission_ID, Patient_ID, Room_ID, Admit_Date, Discharge_Date, Status) VALUES (@AID, @PID, @RID, @AD, @DD, @Status)";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@AID", AdmissionIDtext.Text);
                        cmd.Parameters.AddWithValue("@PID", AdmissionPIdtext.Text);
                        cmd.Parameters.AddWithValue("@RID", AdmissionRoomIdtext.Text);
                        cmd.Parameters.AddWithValue("@AD", AdmitDatetext.Text);
                        cmd.Parameters.AddWithValue("@DD", DischargeDatetext.Text);
                        cmd.Parameters.AddWithValue("@Status", AdmissionStatuscombo.Text);

                        cmd.ExecuteNonQuery();


                    }

                    AdmissionLoadData();
                    MessageBox.Show("Admission Data has been saved successfully!");
                }

                AdmissionIDtext.Clear();
                AdmissionPIdtext.Clear();
                AdmissionRoomIdtext.Clear();
                AdmitDatetext.Clear();
                DischargeDatetext.Clear();
                AdmissionStatuscombo.ResetText();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void AdmissionLoadData()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection("data source=DESKTOP-P38D8KG\\SQLEXPRESS;database=HMSDB;integrated security=True;TrustServerCertificate=True;"))
                {
                    SqlDataAdapter DA = new SqlDataAdapter("SELECT * FROM Admission", conn);
                    DataSet DS = new DataSet();
                    DA.Fill(DS);
                    dataGridView8.DataSource = DS.Tables[0];

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.Message);
            }
        }

        private void AdmissionUpdatebtn_Click(object sender, EventArgs e)
        {
            try
            {

                using (SqlConnection con = new SqlConnection("data source=DESKTOP-P38D8KG\\SQLEXPRESS;database=HMSDB;integrated security=True;TrustServerCertificate=True;"))
                {
                    con.Open();

                    string query = "UPDATE Admission SET  Patient_ID =@PID, Room_ID =@RID, Admit_Date=@AD, Discharge_Date=@DD, Status=@Status  WHERE Admission_ID =@AID ";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@AID", AdmissionIDtext.Text);
                        cmd.Parameters.AddWithValue("@PID", AdmissionPIdtext.Text);
                        cmd.Parameters.AddWithValue("@RID", AdmissionRoomIdtext.Text);
                        cmd.Parameters.AddWithValue("@AD", AdmitDatetext.Text);
                        cmd.Parameters.AddWithValue("@DD", DischargeDatetext.Text);
                        cmd.Parameters.AddWithValue("@Status", AdmissionStatuscombo.Text);

                        cmd.ExecuteNonQuery();


                    }
                    AdmissionLoadData();
                    MessageBox.Show("Admission Record Update successfully!");
                }

                AdmissionIDtext.Clear();
                AdmissionPIdtext.Clear();
                AdmissionRoomIdtext.Clear();
                AdmitDatetext.Clear();
                DischargeDatetext.Clear();
                AdmissionStatuscombo.ResetText();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void AdmissionDeletebtn_Click(object sender, EventArgs e)
        {
            try
            {

                using (SqlConnection con = new SqlConnection("data source=DESKTOP-P38D8KG\\SQLEXPRESS;database=HMSDB;integrated security=True;TrustServerCertificate=True;"))
                {
                    con.Open();

                    string query = "DELETE FROM Admission WHERE Admission_ID =@AID ";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@AID", AdmissionIDtext.Text);

                        cmd.ExecuteNonQuery();

                    }
                    AdmissionLoadData();
                    MessageBox.Show("Admission Record Delete Successfully!");
                }

                AdmissionIDtext.Clear();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void Admissionpanel_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
