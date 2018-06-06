using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IntranetTransferer
{
    public partial class Transferer : Form
    {
        private bool isMouseDown = false;
        private Point formLocation;
        private Point mouseOffset;
        private Thread serverThread;
        private Socket clientSocket;
        private int ipIndex = 0;
        private bool passive = true;
        private bool connected = false;

        public Transferer()
        {
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            this.AllowDrop = true;
            this.FileDrapPlace.AllowDrop = true;
            this.FileDrapPlace.DragEnter += Transferer_DragEnter;
            this.FileDrapPlace.DragDrop += Transferer_DragDrop;
            this.MouseDown += Transferer_MouseDown;
            this.MouseMove += Transferer_MouseMove;
            this.MouseUp += Transferer_MouseUp;
            this.Notifier.MouseDown += Notifier_MouseDown;
            this.Notifier.DoubleClick += Notifier_DoubleClick;
            this.FormClosing += Transferer_FormClosing;
            this.TextToSend.KeyDown += TextToSend_KeyDown;
            this.ServerIPAddress.KeyDown += ServerIPAddress_KeyDown;
            PrintLocalIPAddress();
            serverThread = new Thread(new ThreadStart(ServerThread));
            serverThread.IsBackground = true;
            serverThread.Start();
        }

        #region Events
        void Notifier_DoubleClick(object sender, EventArgs e)
        {
            if (!this.Visible)
            {
                this.Show();
                this.Activate();
            }
            else
            {
                this.Hide();
            }
        }

        void Notifier_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                this.Notifier.ContextMenuStrip = this.ExitMenu;
            }
            else
            {
                this.Activate();
            }
        }

        void Transferer_DragDrop(object sender, DragEventArgs e)
        {
            if (connected)
            {
                string filePath = ((System.Array)e.Data.GetData(DataFormats.FileDrop)).GetValue(0).ToString();
                SendControl(clientSocket, "File");
                ReceiveControl(clientSocket);
                SendFile(clientSocket, filePath);
                ReceiveControl(clientSocket);
            }
        }

        void Transferer_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Link;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        void Transferer_MouseMove(object sender, MouseEventArgs e)
        {
            int x = 0;
            int y = 0;
            if (isMouseDown)
            {
                Point pt = Control.MousePosition;
                x = mouseOffset.X - pt.X;
                y = mouseOffset.Y - pt.Y;
                this.Location = new Point(formLocation.X - x, formLocation.Y - y);
            }
        }

        void Transferer_MouseDown(object sender, MouseEventArgs e)
        {
            if ((e as MouseEventArgs).Button == System.Windows.Forms.MouseButtons.Left)
            {
                isMouseDown = true;
                formLocation = this.Location;
                mouseOffset = Control.MousePosition;
            }
            else
            {
                (sender as Control).ContextMenuStrip = this.HideMenu;
            }
        }

        void Transferer_MouseUp(object sender, MouseEventArgs e)
        {
            int loX = this.Location.X;
            int loY = this.Location.Y;
            int width = 0;
            int preWidth = 0;
            if (loX < 0)
            {
                width = Screen.AllScreens[0].WorkingArea.Width;
            }
            else
            {
                foreach (Screen sc in Screen.AllScreens)
                {
                    if (loX > width)
                    {
                        preWidth = width;
                        width += sc.WorkingArea.Width;
                    }
                    else
                    {
                        break;
                    }
                }
            }
            if (loX + this.Width >= width && loY <= 0)
            {
                this.Location = new Point(width - this.Width, 0);
            }
            else if (loX <= preWidth && loY <= 0)
            {
                this.Location = new Point(preWidth, 0);
            }
            else if (loX + this.Width >= width)
            {
                this.Location = new Point(width - this.Width, loY);
            }
            else if (loX <= preWidth)
            {
                this.Location = new Point(preWidth, loY);
            }
            else if (loY <= 0)
            {
                this.Location = new Point(loX, 0);
            }
            isMouseDown = false;
        }

        private void ConnectBtn_Click(object sender, EventArgs e)
        {
            Connect();
        }

        private void SendTxtBtn_Click(object sender, EventArgs e)
        {
            SendText();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void hideToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void RefreshBtn_Click(object sender, EventArgs e)
        {
            ipIndex++;
            PrintLocalIPAddress();
        }

        private void CopyBtn_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.TextToSend.Text))
            {
                Clipboard.SetText(this.TextToSend.Text);
            }
        }

        private void ClearBtn_Click(object sender, EventArgs e)
        {
            this.TextToSend.Text = String.Empty;
        }

        void TextToSend_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Alt && e.KeyCode == Keys.Enter)
            {
                SendText();
            }
        }

        void ServerIPAddress_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Connect();
            }
        }

        void Transferer_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (connected)
            {
                SendControl(clientSocket, "Disconnect");
                clientSocket.Close();
            }
        }
        #endregion

        #region Send & Receive
        private string ReceiveControl(Socket socket)
        {
            int bufSize = 1024;
            byte[] buf = new byte[bufSize];
            int len = socket.Receive(buf);
            return len > 0 ? Encoding.UTF8.GetString(buf, 0, len) : String.Empty;
        }

        private void SendControl(Socket socket, string controlMsg)
        {
            byte[] msgBytes = Encoding.UTF8.GetBytes(controlMsg);
            socket.Send(msgBytes);
        }

        private string ReceiveContent(Socket socket, int contentLen)
        {
            int receivedLen = 0;
            int bufSize = 1024;
            byte[] buf = new byte[bufSize];
            StringBuilder sb = new StringBuilder();
            while (receivedLen < contentLen)
            {
                int len = socket.Receive(buf);
                if (len > 0)
                {
                    sb.Append(Encoding.UTF8.GetString(buf, 0, len));
                    receivedLen += len;
                }
            }
            return sb.ToString();
        }

        private void SendContent(Socket socket, string content)
        {
            byte[] contentBytes = Encoding.UTF8.GetBytes(content);
            SendControl(socket, contentBytes.Length.ToString());
            ReceiveControl(socket);
            socket.Send(contentBytes);
        }

        private void ReceiveFile(Socket socket, string fileName, int fileLen)
        {
            string filePath = Path.Combine(GetCurrentUserDesktopPath(), RenameConflictFileName(fileName));
            using (Stream fs = new FileStream(filePath, FileMode.Create, FileAccess.ReadWrite))
            {
                int bufLen = 1024;
                int receivedLen = 0;
                byte[] buf = new byte[bufLen];
                int len = 0;
                while (receivedLen < fileLen)
                {
                    len = socket.Receive(buf);
                    fs.Write(buf, 0, len);
                    receivedLen += len;
                }
            }
        }

        private void SendFile(Socket socket, string filePath)
        {
            using (Stream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                SendControl(socket, GetFileNameFromPath(filePath));
                ReceiveControl(socket);
                SendControl(socket, fs.Length.ToString());
                ReceiveControl(socket);
                int bufLen = 1024;
                byte[] buf = new byte[bufLen];
                long readLen = 0;
                long fileLen = fs.Length;
                int len = 0;
                while (readLen < fileLen)
                {
                    len = fs.Read(buf, 0, bufLen);
                    readLen += len;
                    int sentLen = 0;
                    int realSent = 0;
                    int left = 0;
                    while (sentLen < len)
                    {
                        left = len - realSent;
                        realSent = socket.Send(buf, sentLen, left, SocketFlags.None);
                        sentLen += realSent;
                    }
                }
            }
        }
        #endregion

        private void SendText()
        {
            if (connected)
            {
                if (!String.IsNullOrEmpty(this.TextToSend.Text))
                {
                    string txt = this.TextToSend.Text;
                    SendControl(clientSocket, "Text");
                    ReceiveControl(clientSocket);
                    SendContent(clientSocket, txt);
                    ReceiveControl(clientSocket);
                }
            }
        }

        private void Connect()
        {
            try
            {
                if (!connected)
                {
                    passive = false;
                    IPAddress serverIPAddress = IPAddress.Parse(this.ServerIPAddress.Text);
                    clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    clientSocket.Connect(serverIPAddress, 60000);
                    string msg = ReceiveControl(clientSocket);
                    if (msg.Equals("Connected"))
                    {
                        this.ConnectBtn.Text = "Disconnect";
                        connected = true;
                    }
                }
                else
                {
                    passive = true;
                    SendControl(clientSocket, "Disconnect");
                    clientSocket.Close();
                    this.ConnectBtn.Text = "Connect";
                    connected = false;
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(string.Format("Failed to connect to server, error: {0}", err.ToString()));
            }
        }

        private void PrintLocalIPAddress()
        {
            int tmpIndex = 0;
            NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();
            foreach (NetworkInterface nic in nics)
            {
                if (nic.NetworkInterfaceType == NetworkInterfaceType.Ethernet)
                {
                    UnicastIPAddressInformationCollection addresses = nic.GetIPProperties().UnicastAddresses;
                    foreach (UnicastIPAddressInformation ip in addresses)
                    {
                        if (ip.Address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                        {
                            if (tmpIndex < ipIndex)
                            {
                                tmpIndex++;
                            }
                            else
                            {
                                this.LocalIPAddress.Text = ip.Address.ToString();
                                return;
                            }
                        }
                    }
                }
            }

            //start from beginning
            ipIndex = 0;
            PrintLocalIPAddress();
        }

        private void ServerThread()
        {
            IPAddress local = IPAddress.Parse("0.0.0.0");
            Socket server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            server.Bind(new IPEndPoint(local, 60000));
            server.Listen(1);
            while (true)
            {
                Socket receivedClientSocket = server.Accept();
                IPEndPoint clientEndPoint = (IPEndPoint)receivedClientSocket.RemoteEndPoint;
                SendControl(receivedClientSocket, "Connected");
                if (passive)
                {
                    clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    clientSocket.Connect(clientEndPoint.Address, 60000);
                    string msg = ReceiveControl(clientSocket);
                    if (msg.Equals("Connected"))
                    {
                        connected = true;
                        this.ConnectBtn.Text = "Disconnect";
                        this.ServerIPAddress.Text = clientEndPoint.Address.ToString();
                    }
                }
                while (connected)
                {
                    string msg = ReceiveControl(receivedClientSocket);
                    switch (msg)
                    {
                        case "Disconnect":
                            receivedClientSocket.Close();
                            clientSocket.Close();
                            this.ConnectBtn.Text = "Connect";
                            passive = true;
                            connected = false;
                            break;
                        case "Text":
                            SendControl(receivedClientSocket, "Received");
                            int length = Convert.ToInt32(ReceiveControl(receivedClientSocket));
                            SendControl(receivedClientSocket, "Received");
                            string content = ReceiveContent(receivedClientSocket, length);
                            SendControl(receivedClientSocket, "Received");
                            this.TextToSend.Text = content;
                            break;
                        case "File":
                            SendControl(receivedClientSocket, "Received");
                            string fileName = ReceiveControl(receivedClientSocket);
                            SendControl(receivedClientSocket, "Received");
                            int fileLen = Convert.ToInt32(ReceiveControl(receivedClientSocket));
                            SendControl(receivedClientSocket, "Received");
                            ReceiveFile(receivedClientSocket, fileName, fileLen);
                            SendControl(receivedClientSocket, "Received");
                            MessageBox.Show("File Received");
                            break;
                    }
                }
            }
        }

        private string GetFileNameFromPath(string path)
        {
            int index = path.LastIndexOf('\\');
            return path.Substring(index + 1);
        }

        private string RenameConflictFileName(string originalName)
        {
            string desktopPath = GetCurrentUserDesktopPath();
            int extensionIndex = originalName.LastIndexOf(".");
            string fileName = originalName.Substring(0, extensionIndex);
            string extensionName = originalName.Substring(extensionIndex + 1);

            int renameIndex = 1;
            string newNameSuffix = String.Format("({0})", renameIndex);
            string finalName = originalName;
            string filePath = Path.Combine(desktopPath, finalName);
            if (File.Exists(filePath))
            {
                finalName = String.Format("{0} {1}.{2}", fileName, newNameSuffix, extensionName);
                filePath = Path.Combine(desktopPath, finalName);
            }
            while (File.Exists(filePath))
            {
                renameIndex += 1;
                string oldNameSuffix = newNameSuffix;
                newNameSuffix = String.Format("({0})", renameIndex);
                finalName = finalName.Replace(oldNameSuffix, newNameSuffix);
                filePath = Path.Combine(desktopPath, finalName);
            }

            return finalName;
        }

        private string GetCurrentUserDesktopPath()
        {
            return Environment.GetFolderPath(System.Environment.SpecialFolder.Desktop);
        }
    }
}
