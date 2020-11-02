using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using System.Windows.Threading;
using Chat;
using ChatUI.Chat;
using iTextSharp.text;
using iTextSharp.text.pdf;
using LayerBusiness;
using LayerSoporte.Cache;
using Microsoft.PowerBI.Api.Models;
using Image = System.Drawing.Image;
using Message = Chat.Message;

namespace LayerPresentation
{
    public partial class frm_chat : Form
    {
        public frm_chat()
        {
            InitializeComponent();
        }

        #region Variables
        // User List
        public LinkedList<User> allUsers = new LinkedList<User>();
        // Delegate Subprocess
        private delegate void SafeCallDelegate(string text);
        private delegate void SafeCallDelegateDataGrid(DataGridView dt, Message msg);
        private delegate void SafeCallDelegateDataUser(User u);
        // Variable
        private bool isConnected;
        public Client client;
        User _context;
        private int selectedImage;
        // Class
        BitMap myAvatars = new BitMap();

        // Class Context (Selected User)
        User context
        {
            set
            {
                if (value != null)
                {
                    _context = value;
                    this.ShowMessages();
                    lbl_context.Text = value.nick.ToString();
                }
            }
            get { return _context; }
        }
        #endregion

        #region Function
        /// <summary>
        /// Start the connection with the server and initialize chat components
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StartChat(object sender, EventArgs e)
        {
            string user = lbl_nombre.Text;
            frm_chat f;
            Client c;

            if (user.Trim() != "")
            {
                f = this;
                c = new Client(user, this, selectedImage);
                c.Start();
                f.client = c;
                isConnected = true;
                
                this.context = this.client.GetMyClientUser();
            }
            else
            {
                MessageBox.Show("Ingrese un usuario");
                isConnected = false;
            }
        }
        /// <summary>
        /// When Client Receive User or Message this function display them in the UI
        /// </summary>
        /// <param name="o"></param>
        /// <param name="isConnUser"></param>
        public void UpdateUI(object o, bool isConnUser)
        {
            Dispatcher.CurrentDispatcher.Invoke(new Action(() =>
            {
                if (o is User)
                {
                    // Is user
                    if (isConnUser)
                    {
                        refreshUser((User)o);
                    }
                    else
                    {
                        this.allUsers.AddLast((User)o);
                        this.addUser((User)o);
                    }
                }
                else if (o is Message)
                {
                    // Is message
                    if (((Message)o).isToAll)
                    {
                        this.addMessageToAll((Message)o);
                    }
                    else if (this.context != null && ((Message)o).from.id == this.context.id)
                    {
                        this.addMessage((Message)o);
                    }
                }
            }));
        }
        /// <summary>
        /// Refresh the users in the UI
        /// </summary>
        /// <param name="u"></param>
        private void refreshUser(User u)
        {
            if (dataGridViewUsers.InvokeRequired)
            {
                var d = new SafeCallDelegateDataUser(refreshUser);
                this.Invoke(d, new object[] { u });
            }
            else
            {
                dataGridViewUsers.Rows.Clear();
                tabChat.SelectedIndex = 1;

                Image image = new Bitmap(LayerPresentation.Properties.Resources.group);
                dataGridViewUsers.Rows.Add("Todos", image);

                LinkedList<User> tmp = client.GetUsers();
                LinkedListNode<User> user = tmp.First;

                for (int i = 0; i < tmp.Count; i++)
                {
                    setListUser(user.Value.nick);
                    user = user.Next;
                }
            }
        }
        /// <summary>
        /// Add User to UI
        /// </summary>
        /// <param name="u"></param>
        private void addUser(User u)
        {
            //Creating the user label
            setListUser(u.nick);
        }
        /// <summary>
        /// Add Message Individual to UI
        /// </summary>
        /// <param name="msg"></param>
        private void addMessage(Message msg)
        {
            visualizeMessageInUI(dataGridView_chatIndividual, msg);
        }
        /// <summary>
        /// Add Message All to UI
        /// </summary>
        /// <param name="msg"></param>
        private void addMessageToAll(Message msg)
        {
            visualizeMessageInUI(dataGridView_chatAll, msg);
        }
        private void visualizeMessageInUI(DataGridView dt, Message msg)
        {
            if (dt.InvokeRequired)
            {
                var d = new SafeCallDelegateDataGrid(visualizeMessageInUI);
                this.Invoke(d, new object[] { dt, msg });
            }
            else
            {
                string date = msg.dateTimeInSend.ToShortTimeString();
                string message = msg.msg;
                Bitmap image;
                Bitmap bmpEmpty = new Bitmap(33, 31);
                string nombreFrom = "";

                using (Graphics gr = Graphics.FromImage(bmpEmpty))
                {
                    gr.Clear(Color.FromKnownColor(KnownColor.White));
                }

                if (msg.from.nick == client.GetMyClientNick())
                {
                    nombreFrom = "Yo";
                    image = new Bitmap(pic_myuser.BackgroundImage, new Size(43, 41));
                }
                else
                {
                    nombreFrom = msg.from.nick;
                    image = new Bitmap(getAvatarUI(msg.from.myImageIndex), new Size(43, 41));
                }

                if (msg.msg == msg.from.nick + " se ha conectado..")
                {
                    image = new Bitmap(LayerPresentation.Properties.Resources.status_green);
                    dt.Rows.Add(image, message, date);
                }
                else
                {
                    dt.Rows.Add(image, nombreFrom, "");
                    int j = dt.RowCount - 1;
                    j = (j == 0) ? j : j;
                    dt.AutoResizeRow(j, DataGridViewAutoSizeRowMode.AllCells);

                    dt.Rows.Add(bmpEmpty, message, date);
                    if (message.Length > 46)
                    {
                        j = dt.RowCount - 1;
                        dt.AutoResizeRow(j, DataGridViewAutoSizeRowMode.AllCells);
                    }
                    dt.FirstDisplayedScrollingRowIndex = dt.RowCount - 1;
                }
            }
        }
        /// <summary>
        /// Return if the user is connected
        /// </summary>
        /// <returns></returns>
        private string returnConn()
        {
            if (isConnected == true)
            {
                return "Conectado!";
            }
            else
            {
                return "Desconectado!";
            }
        }
        /// <summary>
        /// Display message from de user selected in the UI
        /// </summary>
        private void ShowMessages()
        {
            User u = this.context;
            LinkedList<Message> current = this.client.GetMessages(u);

            LinkedListNode<Message> msg = current.First;
            clearChatList(0);

            for (int i = 0; i < current.Count; i++)
            {
                if (!msg.Value.isToAll)
                {
                    this.addMessage(msg.Value);
                }
                msg = msg.Next;
            }
        }
        /// <summary>
        /// Display the message in the UI for the ALL of Users Connected
        /// </summary>
        private void ShowMessagesToAll()
        {
            User u = this.context;
            LinkedList<Message> current = this.client.GetMessagesToAll(u);

            LinkedListNode<Message> msg = current.First;
            clearChatList(1);

            for (int i = 0; i < current.Count; i++)
            {
                this.addMessageToAll(msg.Value);
                msg = msg.Next;
            }
        }
        private void SendMessage(object sender, EventArgs e, bool isToAll, DateTime now)
        {
            Message msg;
            string message = txtBox_send.Text;
            if (this.context != null && message.Trim() != "" && !isToAll)
            {
                msg = this.client.SendMessage(message, this.context, isToAll, now);
                this.addMessage(msg);
            }
            else if (this.context != null && message.Trim() != "" && isToAll)
            {
                msg = this.client.SendMessage(message, this.context, isToAll, now);
            }
            txtBox_send.Text = "Ingrese su mensaje aqui";
        }
        /// <summary>
        /// Set the new user to the list chat
        /// </summary>
        /// <param name="text"></param>
        private void setListUser(string text)
        {
            if (dataGridViewUsers.InvokeRequired)
            {
                var d = new SafeCallDelegate(setListUser);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                var bmp = new Bitmap(LayerPresentation.Properties.Resources.status_green);
                dataGridViewUsers.Rows.Add(text, bmp);
                dataGridView_chatAll.Rows.Add(bmp, text + " se ha conectado..");
            }
        }
        
        /// <summary>
        /// Clear User Cache Info 
        /// </summary>
        private void clearUserInfo()
        {
            lbl_name.Text = "Usuario Todos";
            lbl_permises.Text = "Permisos del sistema";
            lbl_city.Text = "Ciudad";
            lbl_email.Text = "useremail@hotmail.com";
            lbl_birthday.Text = "25 enero, 2020";
            lbl_phone.Text = "3492472384";
        }
        /// <summary>
        /// Show user info to the UI
        /// </summary>
        /// <param name="id"></param>
        private void showUserInfo(int id)
        {
            LinkedList<UserChat> tmp = this.client.usersCache.GetUserInfo(id);
            LinkedListNode<UserChat> user = tmp.First;

            for (int i = 0; i < tmp.Count; i++)
            {
                if (user.Value.id == id)
                {
                    // Charge data
                    lbl_name.Text = user.Value.nombre;
                    lbl_permises.Text = user.Value.privilegios;
                    lbl_city.Text = user.Value.city;
                    lbl_email.Text = user.Value.email;
                    lbl_birthday.Text = user.Value.fechaNacimiento.ToShortDateString();
                    lbl_phone.Text = user.Value.cellphone;
                    picBox_UserConnected.BackgroundImage = getAvatarUI(user.Value.image);
                    picBox_UserConnected.BackgroundImageLayout = ImageLayout.Stretch;

                    dg_alertasUser.DataSource = null;
                    dg_alertasUser.Rows.Clear();
                    dg_alertasUser.AutoGenerateColumns = false;

                    dg_alertasUser.DataSource = user.Value.lastAlert;
                }
                user = user.Next;
            }
        }
        
        /// <summary>
        /// Clear the datagridview from users
        /// </summary>
        /// <param name="index"></param>
        private void clearChatList(int index)
        {
            if (index == 0)
            {
                // Individual tab
                dataGridView_chatIndividual.Rows.Clear();

            }
            else if (index == 1)
            {
                // Grupal tab
                dataGridView_chatAll.Rows.Clear();
            }
        }
        /// <summary>
        /// Avatar class method
        /// </summary>
        /// 
        public void setComboBoxAvatars()
        {
            PropertyInfo[] info = myAvatars.GetType().GetProperties();
            for (int i = 0; i < info.Length; i++)
            {
                comboBox1.Items.Add("Avatar " + i);
                comboBox1.DisplayMember = i.ToString();
                comboBox1.ValueMember = i.ToString();
            }
        }
        /*
        public Bitmap findAvatarFromUser(int select)
        {
            Bitmap image = new Bitmap(BitmapAvatar.GetBitMap().Avatar0);
            PropertyInfo[] info = BitmapAvatar.GetBitMap().GetType().GetProperties();
            for (int i = 0; i < info.Length; i++)
            {
                if (select == i)
                {
                    image = ((Bitmap)info[i].GetValue(BitmapAvatar.GetBitMap()));
                    selectedImage = i;
                }
            }
            return image;
        }
        */
        private void setAvatarUI(int select)
        {
            PropertyInfo[] info = myAvatars.GetType().GetProperties();
            for (int i = 0; i < info.Length; i++)
            {
                if (select == i)
                {
                    Bitmap image = ((Bitmap)info[i].GetValue(myAvatars));
                    pic_myuser.BackgroundImage = image;
                    selectedImage = i;
                    Properties.Settings.Default.UserImage = i;
                }
            }
        }
        private Bitmap getAvatarUI(int select)
        {
            Bitmap image = new Bitmap(this.myAvatars.Avatar1);
            PropertyInfo[] info = this.myAvatars.GetType().GetProperties();
            for (int i = 0; i < info.Length; i++)
            {
                if (select == i)
                {
                    image = ((Bitmap)info[i].GetValue(myAvatars));
                    Properties.Settings.Default.UserImage = i;
                    return image;
                }
            }
            return image;
        }
        
        /// <summary>
        /// Return WHATSAPP URL from User
        /// </summary>
        /// <returns></returns>
        private string generateWhatsApplink()
        {
            string number = "54" + lbl_phone.Text;
            string link = "https://api.whatsapp.com/send?phone=" + number;
            return link;
        }
        
        /// <summary>
        /// Generate and save PDF from datagridview in the current chat.
        /// </summary>
        /// <param name="dg"></param>
        /// <param name="user"></param>
        private void saveInPdf(DataGridView dg, string user)
        {
            if (dg.Rows.Count > 0)
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "PDF (*.pdf)|*.pdf";
                sfd.FileName = user + ".pdf";
                bool fileError = false;

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    if (File.Exists(sfd.FileName))
                    {
                        try
                        {
                            File.Delete(sfd.FileName);
                        }
                        catch (IOException ex)
                        {
                            fileError = true;
                            MessageBox.Show("It wasn't possible to write the data to the disk." + ex.Message);
                        }
                    }
                    if (!fileError)
                    {
                        try
                        {
                            PdfPTable pdfTable = new PdfPTable(dg.Columns.Count);
                            pdfTable.DefaultCell.Padding = 3;
                            pdfTable.WidthPercentage = 100;
                            pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;

                            foreach (DataGridViewColumn column in dg.Columns)
                            {
                                PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText));
                                pdfTable.AddCell(cell);
                            }

                            foreach (DataGridViewRow row in dg.Rows)
                            {
                                foreach (DataGridViewCell cell in row.Cells)
                                {
                                    pdfTable.AddCell(cell.Value.ToString());
                                }
                            }

                            using (FileStream stream = new FileStream(sfd.FileName, FileMode.Create))
                            {
                                Document pdfDoc = new Document(PageSize.A4, 10f, 20f, 20f, 10f);
                                PdfWriter.GetInstance(pdfDoc, stream);
                                pdfDoc.Open();
                                pdfDoc.Add(pdfTable);
                                pdfDoc.Close();
                                stream.Close();
                            }

                            MessageBox.Show("Data Exported Successfully !!!", "Info");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error :" + ex.Message);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("No Record To Export !!!", "Info");
            }
        }
        #endregion

        #region Eventos
        private void btn_connect_Click(object sender, EventArgs e)
        {
            try
            {
                StartChat(sender, e);
                btn_connect.Text = returnConn();
                btn_connect.Enabled = false;
                comboBox1.Enabled = false;
            }
            catch(Exception ex)
            {
                MessageBox.Show(@"La conexion a fallado! Por favor verifique que el servidor este en linea" 
                    + "\nComuniquese con servicio tecnico si el problema persiste", "Error de conexion", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btn_sendMessage_Click(object sender, EventArgs e)
        {
            if(txtBox_send.Text != null) 
            {
                if (tabChat.SelectedIndex.Equals(1)) 
                {
                    SendMessage(sender, e, true, DateTime.Now);
                } else 
                {
                    SendMessage(sender, e, false, DateTime.Now);
                }
            }
        }
        private void dataGridViewUsers_SelectionChanged(object sender, EventArgs e)
        {
            foreach (User user in this.allUsers)
            {
                if (user.nick == dataGridViewUsers.SelectedRows[0].Cells["Usuario"].Value.ToString())
                {
                    this.context = user;
                    this.ShowMessages();
                    tabChat.SelectedIndex = 0;

                    int id = user.idDataBase;
                    showUserInfo(id);
                }
                if (dataGridViewUsers.SelectedRows[0].Cells["Usuario"].Value.ToString() == "Todos")
                {
                    this.context = this.client.GetMyClientUser();
                    this.ShowMessagesToAll();
                    tabChat.SelectedIndex = 1;
                    clearUserInfo();
                }
            }
        }
        private void btn_clearchat_Click(object sender, EventArgs e)
        {
            clearChatList(tabChat.SelectedIndex);
        }
        private void txtBox_send_Enter(object sender, EventArgs e)
        {
            if (txtBox_send.Text == "Ingrese su mensaje aqui")
            {
                txtBox_send.Text = "";
                txtBox_send.ForeColor = Color.Black;
            }
        }
        private void txtBox_send_Leave(object sender, EventArgs e)
        {
            if (txtBox_send.Text == "")
            {
                txtBox_send.Text = "Ingrese su mensaje aqui";
                txtBox_send.ForeColor = Color.DimGray;
            }
        }       
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            setAvatarUI(comboBox1.SelectedIndex);
        }
        private void btn_saveChat_Click(object sender, EventArgs e)
        {
            if (tabChat.SelectedIndex == 0)
            {
                saveInPdf(dataGridView_chatIndividual, context.nick);
            } 
            else 
            {
                saveInPdf(dataGridView_chatAll, context.nick);
            }
        }
        private void btn_whatsapp_Click(object sender, EventArgs e)
        {
            string url = generateWhatsApplink();
            System.Diagnostics.Process.Start(url);
        }
        private void frm_chat_Load(object sender, EventArgs e)
        {
            setComboBoxAvatars();

            //UserLoginCache.imageDefault = selectedImage;
            comboBox1.SelectedIndex = selectedImage;
            setAvatarUI(selectedImage);

            context = null;
            lbl_nombre.Text = UserLoginCache.Username;

            Image image = new Bitmap(LayerPresentation.Properties.Resources.group);
            dataGridViewUsers.Rows.Add("Todos", image);

            tabChat.SelectedIndex = 1;

            selectedImage = Properties.Settings.Default.UserImage;
        }
        #endregion

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
